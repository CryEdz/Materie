"""Analizza un file con cifre di pi greco e cerca sequenze numeriche.

Il programma non calcola pi greco: legge un file gia' contenente le cifre e
scansiona il contenuto in streaming, cosi' puo' lavorare anche su file molto
grandi senza caricarli interamente in memoria.
"""

from __future__ import annotations

import argparse
import tempfile
from dataclasses import dataclass
from pathlib import Path
from typing import Iterable


DEFAULT_CHUNK_SIZE = 1024 * 1024


@dataclass(frozen=True)
class SearchResult:
    pattern: str
    positions: list[int]


def normalize_digits(text: str) -> str:
    """Rimuove tutto cio' che non e' una cifra."""

    return "".join(character for character in text if character.isdigit())


def search_in_stream(path: Path, patterns: list[str], limit_digits: int, chunk_size: int) -> list[SearchResult]:
    """Cerca le sequenze richieste leggendo il file a blocchi."""

    if not patterns:
        raise ValueError("Devi indicare almeno una sequenza da cercare.")

    if limit_digits <= 0:
        raise ValueError("Il limite di cifre deve essere maggiore di zero.")

    normalized_patterns = [normalize_digits(pattern) for pattern in patterns]
    if any(not pattern for pattern in normalized_patterns):
        raise ValueError("Le sequenze da cercare devono contenere almeno una cifra.")

    max_pattern_length = max(len(pattern) for pattern in normalized_patterns)
    overlap = max_pattern_length - 1

    matches = {pattern: [] for pattern in normalized_patterns}
    digits_seen = 0
    buffer = ""

    with path.open("r", encoding="utf-8", errors="strict") as file_handle:
        while digits_seen < limit_digits:
            raw_chunk = file_handle.read(chunk_size)
            if not raw_chunk:
                break

            chunk_digits = normalize_digits(raw_chunk)
            if not chunk_digits:
                continue

            remaining = limit_digits - digits_seen
            if len(chunk_digits) > remaining:
                chunk_digits = chunk_digits[:remaining]

            window = buffer + chunk_digits
            window_start_position = digits_seen - len(buffer) + 1

            for pattern in normalized_patterns:
                search_from = 0
                while True:
                    index = window.find(pattern, search_from)
                    if index == -1:
                        break

                    absolute_position = window_start_position + index
                    if absolute_position > 0 and absolute_position not in matches[pattern]:
                        matches[pattern].append(absolute_position)

                    search_from = index + 1

            digits_seen += len(chunk_digits)
            if overlap > 0:
                buffer = window[-overlap:]
            else:
                buffer = ""

    return [SearchResult(pattern=pattern, positions=matches[pattern]) for pattern in normalized_patterns]


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description=(
            "Cerca una o piu' sequenze di cifre all'interno di un file con le cifre di pi greco. "
            "Il programma lavora in streaming e puo' essere usato su file molto grandi."
        )
    )
    parser.add_argument(
        "pi_file",
        nargs="?",
        type=Path,
        help="Percorso del file che contiene le cifre di pi greco.",
    )
    parser.add_argument(
        "patterns",
        nargs="*",
        help="Sequenze da cercare, per esempio 31415 92653.",
    )
    parser.add_argument(
        "--limit",
        type=int,
        default=100_000_000_000,
        help="Numero massimo di cifre da analizzare. Default: 100000000000.",
    )
    parser.add_argument(
        "--chunk-size",
        type=int,
        default=DEFAULT_CHUNK_SIZE,
        help="Dimensione del blocco letto dal file. Default: 1048576.",
    )
    parser.add_argument(
        "--self-test",
        action="store_true",
        help="Esegue un test rapido su dati di esempio e termina.",
    )
    return parser


def prompt_patterns() -> list[str]:
    """Chiede all'utente le sequenze da cercare quando non sono state passate da riga di comando."""

    user_input = input("Inserisci le cifre o le sequenze da cercare, separate da spazi: ").strip()
    if not user_input:
        raise ValueError("Non hai inserito alcuna sequenza da cercare.")

    return [token for token in user_input.replace(",", " ").split() if token]


def run_self_test() -> None:
    sample_digits = normalize_digits("3.141592653589793238462643383279")
    with tempfile.NamedTemporaryFile("w", delete=False, encoding="utf-8", suffix=".txt") as temp_file:
        temp_file.write(sample_digits)
        temp_path = Path(temp_file.name)

    try:
        results = search_in_stream(temp_path, ["1415", "92653", "12345"], limit_digits=100, chunk_size=8)
    finally:
        temp_path.unlink(missing_ok=True)

    expected = {
        "1415": [2],
        "92653": [6],
        "12345": [],
    }
    for result in results:
        if result.positions != expected[result.pattern]:
            raise AssertionError(
                f"Test fallito per {result.pattern}: atteso {expected[result.pattern]}, ottenuto {result.positions}"
            )

    print("Self-test superato")


def format_positions(positions: Iterable[int]) -> str:
    values = list(positions)
    if not values:
        return "nessuna occorrenza trovata"
    return ", ".join(str(value) for value in values)


def main() -> int:
    parser = build_parser()
    args = parser.parse_args()

    if args.self_test:
        run_self_test()
        return 0

    if args.pi_file is None:
        parser.error("Devi indicare il file con le cifre di pi greco.")

    patterns = args.patterns
    if not patterns:
        try:
            patterns = prompt_patterns()
        except ValueError as error:
            parser.error(str(error))

    if not args.pi_file.exists():
        parser.error(f"Il file non esiste: {args.pi_file}")

    if not args.pi_file.is_file():
        parser.error(f"Il percorso non e' un file: {args.pi_file}")

    try:
        results = search_in_stream(
            path=args.pi_file,
            patterns=patterns,
            limit_digits=args.limit,
            chunk_size=args.chunk_size,
        )
    except (OSError, ValueError) as error:
        parser.error(str(error))

    print(f"File analizzato: {args.pi_file}")
    print(f"Limite cifre: {args.limit}")
    for result in results:
        print(f"Sequenza {result.pattern}: {format_positions(result.positions)}")

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
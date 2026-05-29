"""Genera un file di cifre di pi greco.

Il programma puo' calcolare piccole quantita' di cifre con la formula di
Chudnovsky oppure copiare in streaming le cifre da una sorgente gia' pronta.
La modalita' pratica per grandi volumi usa --source.
"""

from __future__ import annotations

import argparse
from decimal import Decimal, getcontext
from math import factorial
from pathlib import Path


DEFAULT_DIGITS = 100000000000
MAX_RECOMMENDED_DIGITS = 10000
DEFAULT_OUTPUT = Path("pi_digits.txt")


def chudnovsky_pi(digits: int) -> str:
    """Calcola pi con abbastanza precisione per ottenere il numero richiesto di cifre."""

    if digits <= 0:
        raise ValueError("Il numero di cifre deve essere maggiore di zero.")

    if digits > MAX_RECOMMENDED_DIGITS:
        raise ValueError(
            f"Richiesta troppo grande per questo generatore ({digits} cifre). "
            f"Usa un valore fino a {MAX_RECOMMENDED_DIGITS} oppure un generatore esterno specializzato."
        )

    # Una piccola riserva evita errori di arrotondamento alla fine della conversione.
    getcontext().prec = digits + 10
    terms = digits // 14 + 2
    total = Decimal(0)

    for k in range(terms):
        numerator = factorial(6 * k) * (13591409 + 545140134 * k)
        denominator = factorial(3 * k) * (factorial(k) ** 3) * (640320 ** (3 * k))
        term = Decimal(numerator) / Decimal(denominator)
        if k % 2 == 1:
            term = -term
        total += term

    pi_value = Decimal(426880) * Decimal(10005).sqrt() / total
    return format(+pi_value, "f")


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description=(
            "Genera un file con le cifre di pi greco, utile come input per il programma che cerca sequenze numeriche."
        )
    )
    parser.add_argument(
        "--digits",
        type=int,
        default=DEFAULT_DIGITS,
        help="Numero di cifre da generare dopo la virgola. Default: 1000.",
    )
    parser.add_argument(
        "--output",
        type=Path,
        default=DEFAULT_OUTPUT,
        help="File di output da creare. Default: pi_digits.txt.",
    )
    parser.add_argument(
        "--source",
        type=Path,
        help=(
            "File sorgente gia' contenente le cifre di pi greco da copiare in streaming. "
            "Usalo per richieste molto grandi, compreso il caso da 100000000000 cifre."
        ),
    )
    parser.add_argument(
        "--with-prefix",
        action="store_true",
        help="Scrive anche il prefisso '3.' nel file, invece delle sole cifre dopo la virgola.",
    )
    parser.add_argument(
        "--self-test",
        action="store_true",
        help="Esegue un controllo rapido sul prefisso noto di pi greco e termina.",
    )
    return parser


def run_self_test() -> None:
    known_prefix = "3141592653589793238462643383279"
    generated = chudnovsky_pi(31).replace(".", "")[: len(known_prefix)]
    if generated != known_prefix:
        raise AssertionError(f"Self-test fallito: atteso {known_prefix}, ottenuto {generated}")

    print("Self-test superato")


def write_generated_pi_file(output_path: Path, digits: int, with_prefix: bool) -> None:
    pi_text = chudnovsky_pi(digits)
    if with_prefix:
        content = pi_text
    else:
        content = pi_text.split(".", 1)[1] if "." in pi_text else pi_text

    output_path.parent.mkdir(parents=True, exist_ok=True)
    output_path.write_text(content[:digits if not with_prefix else len(content)], encoding="utf-8")


def write_from_source_file(output_path: Path, source_path: Path, digits: int, with_prefix: bool) -> None:
    if digits <= 0:
        raise ValueError("Il numero di cifre deve essere maggiore di zero.")

    if not source_path.exists():
        raise ValueError(f"Il file sorgente non esiste: {source_path}")

    if not source_path.is_file():
        raise ValueError(f"Il percorso sorgente non e' un file: {source_path}")

    output_path.parent.mkdir(parents=True, exist_ok=True)

    digits_written = 0
    saw_prefix = False
    with source_path.open("r", encoding="utf-8", errors="strict") as source_handle, output_path.open("w", encoding="utf-8") as output_handle:
        if with_prefix:
            output_handle.write("3.")

        while digits_written < digits:
            chunk = source_handle.read(1024 * 1024)
            if not chunk:
                break

            for character in chunk:
                if character.isdigit():
                    if digits_written < digits:
                        output_handle.write(character)
                        digits_written += 1
                elif character == "." and with_prefix and not saw_prefix:
                    saw_prefix = True

    if digits_written < digits:
        raise ValueError(
            f"Il file sorgente contiene solo {digits_written} cifre, ma ne servono {digits}."
        )


def main() -> int:
    parser = build_parser()
    args = parser.parse_args()

    if args.self_test:
        run_self_test()
        return 0

    try:
        if args.source is not None:
            write_from_source_file(
                output_path=args.output,
                source_path=args.source,
                digits=args.digits,
                with_prefix=args.with_prefix,
            )
        else:
            if args.digits > MAX_RECOMMENDED_DIGITS:
                parser.error(
                    f"Per generare {args.digits} cifre usa --source con un file di pi gia' disponibile; "
                    f"il calcolo locale e' consigliato solo fino a {MAX_RECOMMENDED_DIGITS} cifre."
                )
            write_generated_pi_file(output_path=args.output, digits=args.digits, with_prefix=args.with_prefix)
    except (OSError, ValueError) as error:
        parser.error(str(error))

    print(f"File creato: {args.output}")
    print(f"Cifre generate: {args.digits}")
    print("Formato: con prefisso 3. " if args.with_prefix else "Formato: solo cifre dopo la virgola")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
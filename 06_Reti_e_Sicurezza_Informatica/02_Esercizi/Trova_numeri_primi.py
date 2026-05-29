from __future__ import annotations

import math
import multiprocessing
import sys
from pathlib import Path
from typing import Iterable

BASE_DIR = Path(sys.executable).resolve().parent if getattr(sys, "frozen", False) else Path(__file__).resolve().parent
PRIMI_FILE = BASE_DIR / "primi_salvati.txt"
BATCH_SIZE = 10_000_000_000
WORKER_COUNT = max(1, multiprocessing.cpu_count())
GLOBAL_BASE_PRIMES: list[int] = []


def leggi_ultimo_primo() -> int:
    if not PRIMI_FILE.exists():
        
        return 1  # Prima di 2

    ultimo = 1
    with PRIMI_FILE.open("r", encoding="utf-8") as file:
        for line in file:
            line = line.strip()
            if line:
                try:
                    ultimo = int(line)
                except ValueError:
                    pass  # Ignora linee non valide
    return ultimo


def leggi_primi() -> list[int]:
    if not PRIMI_FILE.exists():
    
        return []

    primi: list[int] = []
    with PRIMI_FILE.open("r", encoding="utf-8") as file:
        for line in file:
            line = line.strip()
            if not line:
                continue
            try:
                primi.append(int(line))
            except ValueError as error:
                raise ValueError(f"File {PRIMI_FILE} contiene valori non interi: {line}") from error

    return primi


def salva_primi(primi: list[int]) -> None:
    with PRIMI_FILE.open("w", encoding="utf-8") as file:
        for primo in primi:
            file.write(f"{primo}\n")


def salva_primi_aggiunti(nuovi_primi: list[int]) -> None:
    if not nuovi_primi:
        return

    with PRIMI_FILE.open("a", encoding="utf-8", newline="\n") as file:
        file.writelines(f"{primo}\n" for primo in nuovi_primi)


def is_prime(n: int, primi: list[int]) -> bool:
    if n < 2:
        return False
    limite = int(math.isqrt(n))
    for p in primi:
        if p > limite:
            break
        if n % p == 0:
            return False
    return True


def init_worker(primi: list[int]) -> None:
    global GLOBAL_BASE_PRIMES
    GLOBAL_BASE_PRIMES = primi


def sieve_segment(segment_start: int, segment_end: int) -> list[int]:
    segment_size = segment_end - segment_start + 1
    segment = bytearray(b"\x01") * segment_size

    if segment_start <= 0:
        for i in range(min(2 - segment_start, segment_size)):
            segment[i] = 0

    first_even = segment_start if segment_start % 2 == 0 else segment_start + 1
    for n in range(first_even, segment_end + 1, 2):
        segment[n - segment_start] = 0

    for p in GLOBAL_BASE_PRIMES:
        if p * p > segment_end:
            break

        start = ((segment_start + p - 1) // p) * p
        if start < p * p:
            start = p * p

        for multiple in range(start, segment_end + 1, p):
            segment[multiple - segment_start] = 0

    return [n for idx, n in enumerate(range(segment_start, segment_end + 1)) if segment[idx] and n >= 2]


def sieve_segment_task(args: tuple[int, int]) -> list[int]:
    return sieve_segment(*args)


def chunks_from_range(start: int, end: int, chunk_size: int) -> Iterable[tuple[int, int]]:
    current = start
    while current <= end:
        chunk_end = min(end, current + chunk_size - 1)
        yield current, chunk_end
        current = chunk_end + 1


def calcola_primi_fino_a_parallel(limit: int, start: int) -> int:
    if limit < 2 or start > limit:
        return 0

    sqrt_limit = int(math.isqrt(limit))
    base_primi = calcola_primi_fino_a(sqrt_limit, [2])

    segment_size = max(10_000, min(1_000_000, (limit - start + 1) // WORKER_COUNT))
    totale_primi = 0

    with multiprocessing.Pool(processes=WORKER_COUNT, initializer=init_worker, initargs=(base_primi,)) as pool:
        with PRIMI_FILE.open("a", encoding="utf-8", newline="\n") as file:
            for nuovi_primi in pool.imap(sieve_segment_task, chunks_from_range(start, limit, segment_size), chunksize=1):
                if nuovi_primi:
                    file.writelines(f"{primo}\n" for primo in nuovi_primi)
                    totale_primi += len(nuovi_primi)

    return totale_primi


def calcola_primi_fino_a(limit: int, primi: list[int]) -> list[int]:
    if limit < 2:
        return primi

    if not primi:
        primi = [2]
        start = 3
    else:
        start = primi[-1] + 1
        if start <= 2:
            start = 3

    if start % 2 == 0:
        start += 1

    nuovi_primi = []
    for numero in range(start, limit + 1, 2):
        if is_prime(numero, primi + nuovi_primi):
            nuovi_primi.append(numero)

    return primi + nuovi_primi


def chiedi_continua() -> bool:
    risposta = input("Premi Invio per continuare la ricerca o scrivi 'exit' per interrompere: ").strip().lower()
    return risposta != "exit"


def cerca_primi_senza_limite(ultimo_primo: int, batch_size: int = BATCH_SIZE) -> int:
    if ultimo_primo < 2:
        salva_primi_aggiunti([2])
        print("Aggiunto il primo numero primo: 2")
        ultimo_primo = 2
        totale = 1
    else:
        # Conta il totale leggendo il file, ma per efficienza, assumiamo che sia aggiornato
        totale = sum(1 for _ in PRIMI_FILE.open("r") if _.strip())

    limite_corrente = ultimo_primo
    while True:
        limite_batch = limite_corrente + batch_size * 2
        start = limite_corrente + 1
        print(f"Ricerca dei numeri primi da {start} fino a {limite_batch}...")
        nuovi_count = calcola_primi_fino_a_parallel(limite_batch, start)
        if nuovi_count == 0:
            print("Nessun nuovo numero primo trovato in questo blocco.")
        else:
            print(f"Aggiunti {nuovi_count} nuovi numeri primi.")
            totale += nuovi_count
            print(f"Totale numeri primi salvati: {totale}")

        limite_corrente = limite_batch
        if not chiedi_continua():
            break

    return totale


def main() -> None:
    multiprocessing.freeze_support()
    print("Caricamento dell'ultimo numero primo salvato...")
    ultimo_primo = leggi_ultimo_primo()
    if ultimo_primo >= 2:
        print(f"Ultimo primo salvato: {ultimo_primo}")
    else:
        print("Nessun numero primo salvato. Inizio da 2.")

    print("Ricerca continua dei numeri primi. Scrivi 'exit' per interrompere quando vuoi.")
    totale = cerca_primi_senza_limite(ultimo_primo)

    ultimo_aggiornato = leggi_ultimo_primo()
    print(f"Ultimo numero primo salvato: {ultimo_aggiornato}")
    print(f"Totale numeri primi salvati: {totale}")


if __name__ == "__main__":
    main()

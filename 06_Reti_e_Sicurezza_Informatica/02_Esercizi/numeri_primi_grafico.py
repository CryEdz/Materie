import math
import random

import matplotlib.pyplot as plt
from matplotlib.ticker import ScalarFormatter

MAX_SIEVE_SIZE = 200_000
MAX_GRAPH_SIZE = 20_000
MAX_PRIMI_STAMPA = 1000
SMALL_PRIMES = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29]


def trova_primi(fino_a: int) -> list[int]:
    if fino_a < 2:
        return []

    primi = [True] * (fino_a + 1)
    primi[0] = False
    primi[1] = False

    limite = int(math.isqrt(fino_a))
    for numero in range(2, limite + 1):
        if primi[numero]:
            inizio = numero * numero
            for multiplo in range(inizio, fino_a + 1, numero):
                primi[multiplo] = False

    return [i for i, is_primo in enumerate(primi) if is_primo]


def chiedi_numero() -> int:
    while True:
        testo = input("Inserisci un numero intero maggiore o uguale a 0: ").strip()
        try:
            valore = int(testo)
            if valore < 0:
                print("Errore: inserisci un numero non negativo.")
                continue
            return valore
        except ValueError:
            print("Errore: devi inserire un numero intero valido.")


def mostra_grafico(fino_a: int, primi: list[int] | None) -> None:
    fig, asse = plt.subplots(figsize=(11, 6))

    formatter = ScalarFormatter(useOffset=False)
    formatter.set_scientific(False)
    asse.xaxis.set_major_formatter(formatter)
    asse.yaxis.set_major_formatter(formatter)

    if primi is None or fino_a > MAX_GRAPH_SIZE:
        messaggio = (
            "Il numero inserito è troppo grande per mostrare un grafico dettagliato. "
            "Usa un numero più piccolo di 20.000 per vedere il grafico dei primi."
        )
        asse.text(
            0.5,
            0.5,
            messaggio,
            ha="center",
            va="center",
            wrap=True,
            transform=asse.transAxes,
        )
        asse.set_axis_off()
    elif fino_a >= 2:
        x_valori = list(range(2, fino_a + 1))
        insieme_primi = set(primi)
        conteggio = 0
        pi_x = []
        for x in x_valori:
            if x in insieme_primi:
                conteggio += 1
            pi_x.append(conteggio)

        approssimazione = [x / math.log(x) for x in x_valori]

        asse.plot(x_valori, pi_x, color="#003049", linewidth=2.0, label="pi(x) reale")
        asse.plot(
            x_valori,
            approssimazione,
            color="#d62828",
            linewidth=2.0,
            linestyle="--",
            label="x / log(x) (Teorema dei Numeri Primi)",
        )
        asse.set_xlim(2, fino_a)
        asse.set_xlabel("x")
        asse.set_ylabel("Numero di primi <= x")
        asse.set_title("Confronto: funzione dei primi e Teorema dei Numeri Primi")
        asse.grid(True, linestyle="--", alpha=0.35)
        asse.legend()
    else:
        asse.text(
            0.5,
            0.5,
            "Per mostrare il Teorema dei Numeri Primi inserisci un numero >= 2.",
            ha="center",
            va="center",
            transform=asse.transAxes,
        )
        asse.set_axis_off()

    plt.tight_layout()
    plt.show()


def miller_rabin(n: int, rounds: int = 12) -> bool:
    if n < 2 or n % 2 == 0:
        return n == 2

    d = n - 1
    s = 0
    while d % 2 == 0:
        d //= 2
        s += 1

    for _ in range(rounds):
        a = random.randrange(2, n - 1)
        x = pow(a, d, n)
        if x == 1 or x == n - 1:
            continue

        for _ in range(s - 1):
            x = pow(x, 2, n)
            if x == n - 1:
                break
        else:
            return False

    return True


def is_probable_prime(n: int) -> bool:
    if n < 2:
        return False

    for p in SMALL_PRIMES:
        if n == p:
            return True
        if n % p == 0:
            return False

    return miller_rabin(n)


def main() -> None:
    numero = chiedi_numero()
    if numero <= MAX_SIEVE_SIZE:
        primi = trova_primi(numero)
    else:
        primi = None

    print(f"\nNumero inserito: {numero}")
    if primi is not None:
        if primi:
            if len(primi) <= MAX_PRIMI_STAMPA:
                print(f"Numeri primi tra 0 e {numero}: {primi}")
            else:
                print(f"Trovati {len(primi)} numeri primi tra 0 e {numero}. Elenco omesso per motivi di spazio.")
        else:
            print("Nessun numero primo trovato.")
    else:
        primo = is_probable_prime(numero)
        print("Numero troppo grande per il crivello completo.")
        print(
            "Verifica con un test probabilistico:"
            + (" primo probabile." if primo else " composto.")
        )

    mostra_grafico(numero, primi)


if __name__ == "__main__":
    main()

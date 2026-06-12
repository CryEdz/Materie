#!/usr/bin/env python3
"""
CryptoTool - Crittografia AES-256 per file e cartelle.
Protegge i tuoi dati con password. NON è ransomware: non modifica file
di sistema e non si auto-propaga. Se perdi la password, i dati sono persi.
"""

import os
import sys
import argparse
from pathlib import Path

try:
    from cryptography.hazmat.primitives.ciphers.aead import AESGCM
    from cryptography.hazmat.primitives.kdf.pbkdf2 import PBKDF2HMAC
    from cryptography.hazmat.primitives import hashes
except ImportError:
    print("ERRORE: Installa cryptography con: pip install cryptography")
    sys.exit(1)

VERSION = "1.0.0"
SALT_SIZE = 16
NONCE_SIZE = 12
KEY_SIZE = 32
PBKDF2_ITERATIONS = 600_000

# ── helper: input sicuro per password (visibile, così l'utente vede cosa scrive) ──

def ask_password(prompt="Password: ") -> str:
    return input(prompt)

def ask_password_confirm() -> str:
    while True:
        p1 = ask_password("Password: ")
        p2 = input("Conferma password: ")
        if p1 == p2:
            return p1
        print("ERRORE: Le password non corrispondono. Riprova.")


def derive_key(password: str, salt: bytes) -> bytes:
    kdf = PBKDF2HMAC(
        algorithm=hashes.SHA256(),
        length=KEY_SIZE,
        salt=salt,
        iterations=PBKDF2_ITERATIONS,
    )
    return kdf.derive(password.encode("utf-8"))


def encrypt_file(input_path: Path, password: str, delete_original: bool = False):
    salt = os.urandom(SALT_SIZE)
    nonce = os.urandom(NONCE_SIZE)
    key = derive_key(password, salt)
    aesgcm = AESGCM(key)

    output_path = input_path.with_suffix(input_path.suffix + ".enc")
    if output_path.exists():
        print(f"  SKIP: {output_path.name} esiste già")
        return

    with open(input_path, "rb") as fin:
        plaintext = fin.read()

    ciphertext = aesgcm.encrypt(nonce, plaintext, None)

    with open(output_path, "wb") as fout:
        fout.write(salt)
        fout.write(nonce)
        fout.write(ciphertext)

    print(f"  OK: {input_path.name} -> {output_path.name}")

    if delete_original:
        input_path.unlink()


def decrypt_file(input_path: Path, password: str, delete_original: bool = False):
    if input_path.suffix != ".enc":
        print(f"  SKIP: {input_path.name} non ha estensione .enc")
        return

    with open(input_path, "rb") as fin:
        salt = fin.read(SALT_SIZE)
        nonce = fin.read(NONCE_SIZE)
        ciphertext = fin.read()

    key = derive_key(password, salt)
    aesgcm = AESGCM(key)

    try:
        plaintext = aesgcm.decrypt(nonce, ciphertext, None)
    except Exception as e:
        print(f"  ERRORE ({input_path.name}): {e}")
        return

    output_path = input_path.with_suffix("")
    counter = 1
    while output_path.exists():
        output_path = Path(f"{output_path.stem}_restored{counter}{output_path.suffix}")
        counter += 1

    with open(output_path, "wb") as fout:
        fout.write(plaintext)

    print(f"  OK: {input_path.name} -> {output_path.name}")

    if delete_original:
        input_path.unlink()


def process_path(path: str, password: str, mode: str, recursive: bool,
                 delete: bool):
    p = Path(path)
    if not p.exists():
        print(f"ERRORE: {path} non esiste")
        return

    if p.is_file():
        files = [p]
    else:
        pattern = "**/*" if recursive else "*"
        files = [f for f in p.glob(pattern) if f.is_file()]

    if mode == "decrypt":
        files = [f for f in files if f.suffix == ".enc"]

    if not files:
        print(f"Nessun file trovato in {path}")
        return

    for f in files:
        try:
            if mode == "encrypt" and f.suffix != ".enc":
                encrypt_file(f, password, delete)
            elif mode == "decrypt":
                decrypt_file(f, password, delete)
        except Exception as e:
            print(f"  ERRORE ({f.name}): {e}")


# ── modalità interattiva (doppio clic) ──

def interactive_mode():
    script_dir = Path(sys.argv[0]).resolve().parent
    print(f"=== CryptoTool v{VERSION} - AES-256 ===")
    print(f"Directory: {script_dir}")
    print()

    while True:
        cmd = input("Cosa vuoi fare? [E]ncrypt / [D]ecrypt / [Q]uit: ").strip().lower()
        if cmd in ("q", "quit", "esci"):
            print("Arrivederci.")
            input("\nPremi INVIO per chiudere...")
            return
        if cmd in ("e", "encrypt"):
            mode = "encrypt"
            break
        if cmd in ("d", "decrypt"):
            mode = "decrypt"
            break
        print("Scelta non valida. Digita E, D o Q.")

    delete = False
    d = input("Eliminare i file originali dopo l'operazione? [s/N]: ").strip().lower()
    if d in ("s", "si", "y", "yes"):
        if mode == "decrypt":
            delete = True
        else:
            c = input("ATTENZIONE: i file originali verranno persi. Continuare? [s/N]: ").strip().lower()
            delete = c in ("s", "si", "y", "yes")

    password = ask_password_confirm()

    print()
    process_path(str(script_dir), password, mode, recursive=True, delete=delete)
    print("\nOperazione completata.")
    input("\nPremi INVIO per chiudere...")


# ── modalità da riga di comando ──

def cli_mode():
    parser = argparse.ArgumentParser(
        description=f"CryptoTool v{VERSION} - Proteggi i tuoi file con AES-256",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
Esempi:
  cryptotool.py encrypt documento.docx
  cryptotool.py encrypt -r Documenti/
  cryptotool.py encrypt -r --delete Documenti/
  cryptotool.py decrypt documento.docx.enc
  cryptotool.py decrypt -r --delete Documenti/
        """
    )
    parser.add_argument("mode", choices=["encrypt", "decrypt"])
    parser.add_argument("path", help="File o cartella da elaborare")
    parser.add_argument("-r", "--recursive", action="store_true",
                        help="Elabora ricorsivamente le sottocartelle")
    parser.add_argument("--delete", action="store_true",
                        help="Elimina file originale dopo operazione")
    parser.add_argument("-p", "--password",
                        help="Password (opzionale, altrimenti richiesta)")

    args = parser.parse_args()

    password = args.password
    if not password:
        password = ask_password_confirm()

    process_path(args.path, password, args.mode, args.recursive, args.delete)
    print("\nOperazione completata.")


if __name__ == "__main__":
    if len(sys.argv) > 1:
        cli_mode()
    else:
        interactive_mode()

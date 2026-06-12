#!/usr/bin/env python3
"""
encrypt.py - Encryptor background per file e cartelle.
Usa la chiave generata da genkey.py come password predefinita.
Può operare in modalità one-shot o background (watch).
"""

import os
import sys
import time
import argparse
from pathlib import Path

try:
    from cryptography.hazmat.primitives.ciphers.aead import AESGCM
except ImportError:
    print("ERRORE: Installa cryptography con: pip install cryptography")
    sys.exit(1)

VERSION = "2.0.0"
SALT_SIZE = 16
NONCE_SIZE = 12
KEY_FILE_NAME = "cryptotool.key"

def load_key(key_path: Path) -> bytes:
    with open(key_path, "rb") as f:
        key = f.read()
    if len(key) != 32:
        raise ValueError(f"La chiave deve essere 32 byte, trovati {len(key)}")
    return key

def find_key(start_dir: Path = None) -> Path:
    start = start_dir or Path.cwd()
    for d in [start, start.parent, Path.home()]:
        kp = d / KEY_FILE_NAME
        if kp.exists():
            return kp
    print(f"ERRORE: {KEY_FILE_NAME} non trovato. Esegui prima: python genkey.py")
    sys.exit(1)

def encrypt_file(input_path: Path, key: bytes, delete_original: bool = False):
    salt = os.urandom(SALT_SIZE)
    nonce = os.urandom(NONCE_SIZE)
    aesgcm = AESGCM(key)

    output_path = input_path.with_suffix(input_path.suffix + ".enc")
    if output_path.exists():
        print(f"  SKIP: {output_path.name} esiste gia")
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

def process_path(path: str, key: bytes, recursive: bool, delete: bool):
    p = Path(path)
    if not p.exists():
        print(f"ERRORE: {path} non esiste")
        return

    if p.is_file():
        files = [p]
    else:
        pattern = "**/*" if recursive else "*"
        files = [f for f in sorted(p.glob(pattern)) if f.is_file() and f.suffix != ".enc"]

    if not files:
        print(f"Nessun file da criptare in {path}")
        return

    for f in files:
        try:
            encrypt_file(f, key, delete)
        except Exception as e:
            print(f"  ERRORE ({f.name}): {e}")

def watch_loop(watch_dir: Path, key: bytes, delete: bool):
    print(f"[Watch] Monitoraggio avviato: {watch_dir}")
    print(f"[Watch] Cripto automaticamente nuovi file... (Ctrl+C per fermare)")
    known = {f for f in watch_dir.glob("*") if f.is_file() and f.suffix != ".enc"}

    while True:
        time.sleep(3)
        current = {f for f in watch_dir.glob("*") if f.is_file() and f.suffix != ".enc"}
        new_files = current - known
        for f in sorted(new_files):
            print(f"[Watch] Nuovo file rilevato: {f.name}")
            try:
                encrypt_file(f, key, delete)
            except Exception as e:
                print(f"  ERRORE ({f.name}): {e}")
        known = current

def main():
    parser = argparse.ArgumentParser(
        description=f"Encryptor v{VERSION} - Cripta file con chiave AES-256 (keyfile)",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
Esempi:
  encrypt.py file.txt
  encrypt.py -r Documenti/
  encrypt.py --watch
  encrypt.py --watch --delete
        """
    )
    parser.add_argument("path", nargs="?", default=None,
                        help="File o cartella da criptare")
    parser.add_argument("-r", "--recursive", action="store_true",
                        help="Elabora ricorsivamente")
    parser.add_argument("--delete", action="store_true",
                        help="Elimina originale dopo crittografia")
    parser.add_argument("-w", "--watch", action="store_true",
                        help="Modalita background: monitora la cartella")
    parser.add_argument("--key", default=None,
                        help="Percorso file chiave (default: cerca cryptotool.key)")

    args = parser.parse_args()

    if args.key:
        key_path = Path(args.key)
    else:
        key_path = find_key()

    key = load_key(key_path)

    if args.watch:
        watch_dir = Path(args.path) if args.path else Path.cwd()
        watch_loop(watch_dir, key, args.delete)
    elif args.path:
        process_path(args.path, key, args.recursive, args.delete)
    else:
        parser.print_help()

if __name__ == "__main__":
    main()

#!/usr/bin/env python3
"""
decrypt.py - Decryptor background per file .enc crittati con AES-256.
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

def decrypt_file(input_path: Path, key: bytes, delete_original: bool = False):
    if input_path.suffix != ".enc":
        print(f"  SKIP: {input_path.name} non ha estensione .enc")
        return

    with open(input_path, "rb") as fin:
        salt = fin.read(SALT_SIZE)
        nonce = fin.read(NONCE_SIZE)
        ciphertext = fin.read()

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

def process_path(path: str, key: bytes, recursive: bool, delete: bool):
    p = Path(path)
    if not p.exists():
        print(f"ERRORE: {path} non esiste")
        return

    if p.is_file():
        files = [p]
    else:
        pattern = "**/*" if recursive else "*"
        files = [f for f in sorted(p.glob(pattern)) if f.is_file() and f.suffix == ".enc"]

    if not files:
        print(f"Nessun file .enc trovato in {path}")
        return

    for f in files:
        try:
            decrypt_file(f, key, delete)
        except Exception as e:
            print(f"  ERRORE ({f.name}): {e}")

def watch_loop(watch_dir: Path, key: bytes, delete: bool):
    print(f"[Watch] Monitoraggio avviato: {watch_dir}")
    print(f"[Watch] Decripto automaticamente nuovi file .enc... (Ctrl+C per fermare)")
    known = {f for f in watch_dir.glob("*") if f.is_file() and f.suffix == ".enc"}

    while True:
        time.sleep(3)
        current = {f for f in watch_dir.glob("*") if f.is_file() and f.suffix == ".enc"}
        new_files = current - known
        for f in sorted(new_files):
            print(f"[Watch] Nuovo file .enc rilevato: {f.name}")
            try:
                decrypt_file(f, key, delete)
            except Exception as e:
                print(f"  ERRORE ({f.name}): {e}")
        known = current

def main():
    parser = argparse.ArgumentParser(
        description=f"Decryptor v{VERSION} - Decripta file .enc con chiave AES-256 (keyfile)",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
Esempi:
  decrypt.py file.txt.enc
  decrypt.py -r Documenti/
  decrypt.py --watch
  decrypt.py --watch --delete
        """
    )
    parser.add_argument("path", nargs="?", default=None,
                        help="File .enc o cartella da decriptare")
    parser.add_argument("-r", "--recursive", action="store_true",
                        help="Elabora ricorsivamente")
    parser.add_argument("--delete", action="store_true",
                        help="Elimina file .enc dopo decrittografia")
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

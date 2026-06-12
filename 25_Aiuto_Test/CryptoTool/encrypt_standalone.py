#!/usr/bin/env python3
"""
encrypt.exe - Cripta file con AES-256.
Eseguibile standalone, chiave incorporata. Non dipende da file esterni.
"""

import os
import sys
import time
import base64
import argparse
from pathlib import Path

try:
    from cryptography.hazmat.primitives.ciphers.aead import AESGCM
except ImportError:
    sys.exit(1)

VERSION = "2.0.0"
SALT_SIZE = 16
NONCE_SIZE = 12

EMBEDDED_KEY = base64.b64decode("rJ5YlCUyponaAxB9F1+4GYE+wEwQ6fEmkdT1RH3HYHw=")

def encrypt_file(input_path: Path, delete_original: bool = False):
    salt = os.urandom(SALT_SIZE)
    nonce = os.urandom(NONCE_SIZE)
    aesgcm = AESGCM(EMBEDDED_KEY)

    output_path = input_path.with_suffix(input_path.suffix + ".enc")
    if output_path.exists():
        return

    with open(input_path, "rb") as fin:
        plaintext = fin.read()

    ciphertext = aesgcm.encrypt(nonce, plaintext, None)

    with open(output_path, "wb") as fout:
        fout.write(salt)
        fout.write(nonce)
        fout.write(ciphertext)

    if delete_original:
        input_path.unlink()

def process_path(path: str, recursive: bool, delete: bool):
    p = Path(path)
    if not p.exists():
        return

    if p.is_file():
        files = [p]
    else:
        pattern = "**/*" if recursive else "*"
        files = [f for f in sorted(p.glob(pattern)) if f.is_file() and f.suffix != ".enc"]

    for f in files:
        try:
            encrypt_file(f, delete)
        except Exception:
            pass

def watch_loop(watch_dir: Path, delete: bool):
    known = {f for f in watch_dir.glob("*") if f.is_file() and f.suffix != ".enc"}
    while True:
        time.sleep(3)
        current = {f for f in watch_dir.glob("*") if f.is_file() and f.suffix != ".enc"}
        new_files = current - known
        for f in sorted(new_files):
            try:
                encrypt_file(f, delete)
            except Exception:
                pass
        known = current

def main():
    parser = argparse.ArgumentParser(description="Encrypt file with AES-256")
    parser.add_argument("path", nargs="?", default=None)
    parser.add_argument("-r", "--recursive", action="store_true")
    parser.add_argument("--delete", action="store_true")
    parser.add_argument("-w", "--watch", action="store_true")
    args = parser.parse_args()

    if args.watch:
        watch_dir = Path(args.path) if args.path else Path.cwd()
        watch_loop(watch_dir, args.delete)
    elif args.path:
        process_path(args.path, args.recursive, args.delete)

if __name__ == "__main__":
    main()

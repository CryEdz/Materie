#!/usr/bin/env python3
"""
genkey.py - Genera una chiave AES-256 casuale e la salva in un file.
La chiave è lunga 256 bit (32 byte) generata con os.urandom(),
cryptograficamente sicura e NON ottenibile tramite bruteforce.
"""

import os
import sys
from pathlib import Path

KEY_FILE = "cryptotool.key"
KEY_SIZE = 32

def generate_key(output_dir: Path = None) -> Path:
    key = os.urandom(KEY_SIZE)
    out = (output_dir or Path.cwd()) / KEY_FILE
    with open(out, "wb") as f:
        f.write(key)
    os.chmod(out, 0o600)
    return out

if __name__ == "__main__":
    out = generate_key()
    print(f"Chiave AES-256 generata e salvata in: {out}")
    print(f"Dimensione: {KEY_SIZE} byte (256 bit)")
    print("ATTENZIONE: Conserva questo file al sicuro. Senza di esso i dati crittati sono irrecuperabili.")

---
description: "Usa queste regole quando scrivi o modifichi codice Python per esercizi, script o mini-progetti del corso ITS ICT."
applyTo: "**/*.py"
---
# Linee guida Python ITS

- Mantieni funzioni brevi e con singola responsabilita.
- Usa type hints quando migliorano la leggibilita.
- Gestisci sempre errori attesi con eccezioni specifiche.
- Evita side effect nascosti: preferisci input e output espliciti.
- Per script CLI, usa `if __name__ == "__main__":`.

## Qualita e test
- Fornisci almeno un esempio di esecuzione o un test base.
- Per logica non banale, aggiungi un commento sintetico sul perche.
- Se introduci dipendenze, indica il comando di installazione.

## Dati e sicurezza
- Non salvare credenziali nel codice.
- Per accesso a file, valida path e gestisci errori di I/O.
- Per richieste HTTP, imposta timeout esplicito.

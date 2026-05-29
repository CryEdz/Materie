# Analizzatore cifre di pi greco

Questo mini-programma cerca sequenze numeriche all'interno di un file che contiene le cifre di pi greco.

Accanto allo script di ricerca c'e' anche un secondo programma che genera il file con le cifre di pi greco.

## Cosa fa

- legge il file a blocchi, quindi non deve caricare tutto in memoria;
- cerca una o piu' sequenze, per esempio `31415` o `92653`;
- mostra le posizioni in cui ogni sequenza appare.

## Importante

Il programma non calcola pi greco. Serve un file gia' pronto con le cifre di pi greco, anche molto grande.

## Esempio

```powershell
python analizzatore_pigreco.py pi_digits.txt 31415 92653 --limit 1000000
```

Se non passi le sequenze sulla riga di comando, il programma te le chiede in modo interattivo.

## Verifica rapida

```powershell
python analizzatore_pigreco.py --self-test
```

La verifica rapida usa dati di esempio interni e non richiede un file reale di pi greco.

## Generatore del file

```powershell
python genera_pigreco.py --digits 1000 --output pi_digits.txt
```

Se vuoi, puoi anche includere il prefisso `3.` con `--with-prefix`.

Per scrivere le prime 100000000000 cifre dopo la virgola in modo pratico, usa `--source` con un file che contiene gia' le cifre di pi greco: lo script le copia in streaming e puo' scrivere anche file enormi, senza ricomputarle da zero.

Per richieste molto grandi senza `--source`, questo script mostra un errore esplicito invece di andare in memoria esaurita.
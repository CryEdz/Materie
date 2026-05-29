# Report di processo

## Obiettivo

Trasformare i file giornalieri dei voti Fantacalcio in un dataset pulito e aggregato, allineato al template `Fantacalcio_tidy.xlsx`, e produrre alcune analisi utili a fantallenatori e appassionati.

## Passi eseguiti

1. Lettura di tutte le giornate presenti nella cartella.
2. Riconoscimento del titolo variabile in testa al foglio e delle righe di meta-informazione.
3. Estrazione dei blocchi squadra e delle righe giocatore.
4. Pulizia dei voti con asterisco e conversione dei campi numerici.
5. Calcolo del fantavoto per singola presenza.
6. Aggregazione stagionale per squadra, codice, ruolo e nome.
7. Esportazione del workbook finale e produzione di grafici e report.

## Difficolta incontrate

- Il titolo iniziale cambia da giornata a giornata, quindi non si poteva usare un pattern fisso sulla prima riga.
- La giornata 37 non e presente tra i file disponibili, quindi il controllo dei round ha dovuto accettare una sequenza non completa.
- Alcuni voti sono scritti come `6*`; la pulizia ha rimosso il marcatore mantenendo il valore numerico.
- Alcuni codici giocatore compaiono in piu squadre nel corso della stagione; per evitare aggregazioni errate ho usato la chiave `Squadra + Cod. + Ruolo + Nome`.

## Misure adottate

- Parsing robusto basato sulla forma della riga, non su offset fissi.
- Conversione esplicita dei campi numerici con fallback a zero sui bonus/malus non valorizzati.
- Validazione finale con conteggio di file, righe e giocatori aggregati.
- Separazione tra report conclusivo e report metodologico per rendere il risultato piu leggibile.

## Output prodotti

- Workbook finale: `Fantacalcio_tidy.xlsx`
- Grafici: cartella `output/`
- Report analitico: `report_analisi.md`
- Report di processo: `report_processo.md`

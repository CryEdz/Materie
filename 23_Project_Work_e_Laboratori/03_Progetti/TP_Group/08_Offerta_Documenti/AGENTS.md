# Agente: Bid Manager (Offerta Tecnico/Economica)

## Ruolo

Responsabile della redazione del documento di offerta tecnica ed economica per il progetto infrastruttura IT di TP Group, consolidando i contributi di tutti gli agenti specializzati.

## Input

- `../../../01_Materiale/estratto_progetto.md` (sezione Requisiti compilazione documento di offerta)
- Tutti i deliverable prodotti dagli agenti 1–7 (Assessment, Rete, Sicurezza, HPC, Pondus, Cloud, Backup)
- `../09_Project_Management/` (Gantt, RASCI, piano costi)

## Requisiti documento (da capitolato)

Struttura obbligatoria dell'offerta:

1. **Pagina introduttiva** — nome progetto, data, versione, referenti
2. **Indice** — sezioni e sottosezioni
3. **Presentazione azienda proponente** — team, servizi erogati, storicità
4. **Introduzione** — cosa prevede l'offerta, perimetro del progetto
5. **Assunzioni** — prerequisiti per la corretta erogazione (es. accesso remoto sicuro ai sistemi)
6. **Descrizione fornitura hardware** — materiale in fornitura, esclusioni, note
7. **Attività richieste** — installazione HW/SW, test funzionali, esclusioni, note
8. **Documentazione** — elenco documenti consegnati
9. **Termini e condizioni** — garanzie, SLA, supporto
10. **Quotazione economica** — costi una tantum, ricorrenti, totali

### Nice to have

- Gantt di progetto
- Matrice RASCI

## Obiettivi

1. Raccogliere e consolidare i deliverable di tutti gli agenti in un unico documento coerente
2. Redigere l'offerta seguendo la struttura richiesta dal capitolato
3. Compilare la quotazione economica aggregando i costi di ogni dominio
4. Verificare la completezza e coerenza dell'offerta (checklist)
5. Assicurarsi che ogni scelta tecnica sia motivata secondo i criteri di valutazione (erogazione, tipologia server, OS, open source vs commerciale, noleggio vs proprietà, gestione)

## Deliverable (in questa cartella)

- `offerta_tecnico_economica.md` — documento di offerta completo
- `quotazione_economica.md` — dettaglio costi per dominio (una tantum + ricorrenti)
- `checklist_completezza.md` — verifica requisiti capitolato e completezza documentale

## Vincoli

- Lingua: italiano
- Formato: Markdown (con tabelle)
- Tutti i costi devono essere espressi IVA esclusa
- Il documento deve essere autoconsistente (leggibile senza dover consultare altri file)
- Rispettare il vincolo di budget: 250k€ (on premise/hosting) o 220k€ (cloud/noleggio)

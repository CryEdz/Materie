# Matrice RASCI — TP Group

## Legenda

| Sigla | Ruolo |
| --- | --- |
| R | Responsible (esegue l'attività) |
| A | Accountable (approva/responde del risultato) |
| S | Support (fornisce supporto) |
| C | Consulted (fornisce informazioni) |
| I | Informed (informato) |

## Matrice

| Attività | PM | Sistemista | Security Officer | HPC Engineer | App Architect | Cloud Specialist | Backup Engineer | Bid Manager | Referente Thema | Referente Pro Studio | Direzione |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **1. Assessment** | | | | | | | | | | | |
| 1.1 Censimento asset Thema | A | R | C | C | C | — | C | I | R | — | I |
| 1.2 Censimento servizi Pro Studio | A | R | C | — | — | C | — | I | — | R | I |
| 1.3 Gap analysis | A | R | R | C | C | C | C | I | C | C | I |
| **2. Rete e VPN** | | | | | | | | | | | |
| 2.1 Progettazione rete | A | R | C | C | — | — | — | I | C | — | I |
| 2.2 Acquisto HW rete | A | R | — | — | — | — | — | C | — | — | I |
| 2.3 Installazione e cablaggio | I | R | — | — | — | — | — | — | S | — | — |
| 2.4 Configurazione Fortigate | I | R | C | — | — | C | — | I | — | — | — |
| 2.5 Test connettività | A | R | — | — | — | C | — | I | C | — | — |
| **3. Sicurezza** | | | | | | | | | | | |
| 3.1 Gap analysis ISO | A | C | R | — | — | — | — | I | — | — | I |
| 3.2 Politiche sicurezza | I | — | R | — | — | — | — | C | C | — | A |
| 3.3 Implementazione cifratura | I | R | A | C | C | C | C | — | — | — | — |
| 3.4 MFA/IAM | I | R | A | — | C | C | — | — | C | C | — |
| **4. Cluster HPC** | | | | | | | | | | | |
| 4.1 Dimensionamento | A | C | — | R | — | — | — | I | C | — | I |
| 4.2 Acquisto HW HPC | A | C | — | R | — | — | — | C | — | — | I |
| 4.3 Installazione hosting | I | S | — | R | — | — | — | — | — | — | — |
| 4.4 Configurazione Infiniband | I | — | — | R | — | — | — | — | — | — | — |
| 4.5 Benchmark | I | — | — | R | — | — | — | — | C | — | — |
| **5. Pondus** | | | | | | | | | | | |
| 5.1 Preparazione VM | I | S | C | — | R | — | — | — | C | — | — |
| 5.2 Migrazione DB | A | S | — | — | R | — | C | — | — | — | I |
| 5.3 Configurazione HA | I | S | — | — | R | — | — | — | — | — | — |
| 5.4 Test | A | — | — | — | R | — | — | — | C | — | — |
| **6. Cloud Migration** | | | | | | | | | | | |
| 6.1 VPN GCP + GCDS | I | R | C | — | — | A | — | — | — | C | — |
| 6.2 Migrazione servizi | A | S | — | — | — | R | — | I | C | C | I |
| 6.3 Integrazione finale | A | R | C | — | — | R | C | I | C | — | I |
| **7. Backup e DR** | | | | | | | | | | | |
| 7.1 Configurazione backup | I | R | C | C | C | C | A | — | — | — | — |
| 7.2 Procedure DR | A | R | C | — | C | — | R | I | — | — | I |
| 7.3 Test DR | A | R | C | — | C | C | R | I | — | — | I |
| **8. Offerta** | | | | | | | | | | | |
| 8.1 Raccolta contributi | A | I | I | I | I | I | I | R | — | — | — |
| 8.2 Redazione offerta | A | C | C | C | C | C | C | R | — | — | I |
| 8.3 Quotazione economica | A | C | C | C | — | C | C | R | — | — | I |
| **9. Project Management** | | | | | | | | | | | |
| 9.1 Pianificazione | R/A | — | — | — | — | — | — | — | C | C | I |
| 9.2 Coordinamento | R/A | I | I | I | I | I | I | I | C | C | I |
| 9.3 Gestione rischi | R/A | C | C | C | C | C | C | I | — | — | I |
| 9.4 Reportistica | R/A | I | I | I | I | I | I | I | I | I | I |
| 9.5 Chiusura | R/A | I | I | I | I | I | I | I | C | C | A |

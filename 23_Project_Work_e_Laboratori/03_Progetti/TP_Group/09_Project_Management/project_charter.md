# Project Charter — TP Group

## Identificazione progetto

| Campo | Valore |
| --- | --- |
| Nome progetto | Integrazione Infrastruttura IT TP Group |
| Acronimo | TP-IT-01 |
| Sponsor | Direzione TP Group |
| Project Manager | [Da nominare] |
| Data inizio | [Da definire] |
| Data fine prevista | [Da definire] (6 mesi migrazione) |

## Obiettivi

1. Convergere le infrastrutture IT di Thema Consulting (on premise) e Pro Studio (cloud) in un'unica architettura coerente
2. Ottenere la conformità ai requisiti ISO/IEC 27001 (business continuity, disaster recovery, sicurezza accessi)
3. Potenziare il cluster HPC da 8 a 16 nodi con interconnessione Infiniband 200 Gbps
4. Potenziare e ridistribuire l'applicazione Pondus con architettura HA
5. Garantire la continuità operativa durante e dopo la migrazione

## Scope

**Incluso:**
- Progettazione e implementazione rete/VPN
- Adeguamento sicurezza ISO 27001
- Potenziamento cluster HPC
- Migrazione Pondus a VM HA
- Integrazione cloud ibrido GCP/Workspace
- Backup e disaster recovery
- Documentazione e formazione

**Escluso:**
- Certificazione formale ISO 27001 (ente esterno)
- Sviluppo nuove funzionalità Pondus
- Fornitura laptop/postazioni utente
- Infrastruttura fisica edificio (UPS, condizionamento, rack)

## Milestone

| Milestone | Data prevista | Deliverable |
| --- | --- | --- |
| M1 — Assessment completato | Mese 1 | Documento AS-IS + GAP analysis |
| M2 — Rete e VPN operative | Mese 2 | Nuova rete + VPN funzionanti |
| M3 — Sicurezza implementata | Mese 3 | Politiche, cifratura, MFA attivi |
| M4 — HPC potenziato | Mese 4 | 8 nuovi nodi operativi |
| M5 — Pondus migrato e HA | Mese 5 | Pondus su VM con failover |
| M6 — Cloud integrato | Mese 5 | AD/Workspace SSO, backup off-site |
| M7 — Backup e DR pronti | Mese 5 | Recovery test superato |
| M8 — Offerta consegnata | Mese 6 | Documento finale + quotazione |
| M9 — Progetto chiuso | Mese 6 | Handover, documentazione, formazione |

## Budget

| Voce | Importo |
| --- | --- |
| Budget HW HPC (acquisto) | € 250.000 |
| Budget HPC (noleggio cloud alternativo) | € 220.000 |
| Costi sistemista (€500/gg) | Da stimare (~€40.000) |
| Costi PM (€650/gg) | Da stimare (~€19.500) |
| Costi HW rete, backup, sicurezza | Da quotazione |
| Costi ricorrenti (36 mesi) | Da stimare (~€63.000) |

## Team di progetto

| Ruolo | Figura | Impegno stimato |
| --- | --- | --- |
| Project Manager | [Da nominare] | 30 giorni |
| Sistemista senior | [Da nominare] | 80 giorni |
| Security specialist | [Da nominare] | 20 giorni |
| Sviluppatore .NET (Pondus) | [Da nominare] | 15 giorni |
| Referente IT Thema | [Da nominare] | Part-time |
| Referente IT Pro Studio | [Da nominare] | Part-time |

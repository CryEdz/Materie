# Registro Rischi — TP Group

## Riepilogo

| Livello | Conteggio |
| --- | --- |
| Critico (9) | 0 |
| Alto (6) | 4 |
| Medio (3-4) | 10 |
| Basso (1-2) | 4 |
| **Totale** | **18** |

## Dettaglio

| ID | Area | Rischio | Impatto | Prob. | Livello | Contromisura | Owner | Stato | Scadenza |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| R01 | Rete | Rottura cavo fibra ISP primario | Alto (3) | Media (2) | **6 — Alto** | Doppio provider ISP con failover automatico | Network Engineer | Aperto | Mese 1 |
| R02 | Rete | Attacco DDoS alla connettività | Alto (3) | Media (2) | **6 — Alto** | Fortigate IPS/DoS policy + ISP anti-DDoS | Network Engineer | Aperto | Mese 2 |
| R03 | Sicurezza | Accesso non autorizzato via VPN | Alto (3) | Bassa (1) | 3 — Medio | MFA obbligatorio + log audit + revoca immediata | Security Officer | Aperto | Mese 3 |
| R04 | Sicurezza | Perdita dati per cifratura incompleta | Alto (3) | Bassa (1) | 3 — Medio | Politica cifratura + audit trimestrale | Security Officer | Aperto | Mese 3 |
| R05 | HPC | Guasto HW nodo HPC (scratch) | Alto (3) | Media (2) | **6 — Alto** | RAID0 scratch + backup periodico su NAS | HPC Engineer | Aperto | Mese 4 |
| R06 | HPC | Switch Infiniband guasto | Alto (3) | Bassa (1) | 3 — Medio | Switch di scorta + sostituzione 24h | HPC Engineer | Aperto | Mese 4 |
| R07 | HPC | Cluster saturo prima del previsto | Medio (2) | Media (2) | 4 — Medio | Piano espansione già previsto a 16+ nodi | HPC Engineer | Monitor | Mese 4 |
| R08 | Pondus | Downtime servizio clienti | Alto (3) | Media (2) | **6 — Alto** | HA web + replica DB verso DR | App Architect | Aperto | Mese 5 |
| R09 | Pondus | Perdita dati clienti DB | Alto (3) | Bassa (1) | 3 — Medio | Backup orario RPO 1h + TDE + replica DR | App Architect | Aperto | Mese 5 |
| R10 | Cloud | Google Workspace irraggiungibile | Medio (2) | Bassa (1) | 2 — Basso | Connessione diretta ISP + AD cached | Cloud Specialist | Monitor | Mese 5 |
| R11 | Cloud | Migrazione Drive incompleta | Medio (2) | Bassa (1) | 2 — Basso | Backup pre-migrazione + coesistenza 30gg | Cloud Specialist | Aperto | Mese 5 |
| R12 | Backup | NAS QNAP saturo | Medio (2) | Media (2) | 4 — Medio | Monitoraggio + alert 80% + espansione su cloud | Backup Engineer | Monitor | Mese 5 |
| R13 | Backup | Rottura NAS senza off-site | Alto (3) | Bassa (1) | 3 — Medio | Backup off-site GCP già previsto (3-2-1) | Backup Engineer | Aperto | Mese 3 |
| R14 | Gestione | Superamento budget | Alto (3) | Media (2) | **6 — Alto** | Monitoraggio costi + contingency 10% | PM | Aperto | Mese 6 |
| R15 | Gestione | Personale chiave non disponibile | Medio (2) | Media (2) | 4 — Medio | Documentazione processi + backup competenze | PM | Aperto | Mese 1 |
| R16 | Gestione | Ritardo per problemi logistici | Medio (2) | Alta (3) | **6 — Alto** | Gantt con buffer + checkpoint settimanali | PM | Aperto | Mese 6 |
| R17 | Sicurezza | Non conformità ISO 27001 in audit | Alto (3) | Bassa (1) | 3 — Medio | Gap analysis + checklist + consultant esterno | Security Officer | Aperto | Mese 3 |
| R18 | Rete | Firewall configurato in modo non sicuro | Alto (3) | Bassa (1) | 3 — Medio | Hardening checklist + pentest pre-go-live | Network Engineer | Aperto | Mese 2 |

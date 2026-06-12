# Matrice Rischi — TP Group

## Legenda

| Impatto | Probabilità | Livello rischio |
| --- | --- | --- |
| Alto (3) | Alta (3) | 9 — Critico |
| Alto (3) | Media (2) | 6 — Alto |
| Medio (2) | Alta (3) | 6 — Alto |
| Alto (3) | Bassa (1) | 3 — Medio |
| Medio (2) | Media (2) | 4 — Medio |
| Basso (1) | Alta (3) | 3 — Medio |
| Basso (1) | Media (2) | 2 — Basso |
| Basso (1) | Bassa (1) | 1 — Basso |
| Medio (2) | Bassa (1) | 2 — Basso |

## Rischi

| ID | Area | Rischio | Impatto | Prob. | Livello | Contromisura | Owner |
| --- | --- | --- | --- | --- | --- | --- | --- |
| R01 | Rete | Rottura cavo fibra ISP primario | Alto (3) | Media (2) | **6 — Alto** | Doppio provider ISP con failover automatico | Network Engineer |
| R02 | Rete | Attacco DDoS alla connettività Internet | Alto (3) | Media (2) | **6 — Alto** | Fortigate IPS/DoS policy + ISP anti-DDoS | Network Engineer |
| R03 | Sicurezza | Accesso non autorizzato via VPN | Alto (3) | Bassa (1) | 3 — Medio | MFA obbligatorio + log audit + revoca immediata | Security Officer |
| R04 | Sicurezza | Perdita dati per cifratura incompleta | Alto (3) | Bassa (1) | 3 — Medio | Politica cifratura aderente a ISO 27001 + audit trimestrale | Security Officer |
| R05 | HPC | Guasto hardware nodo HPC (scratch) | Alto (3) | Media (2) | **6 — Alto** | RAID0 su scratch NVMe (stripe) + backup periodico su NAS | HPC Engineer |
| R06 | HPC | Rottura switch Infiniband | Alto (3) | Bassa (1) | 3 — Medio | Switch di scorta + piano sostituzione 24h | HPC Engineer |
| R07 | HPC | Cluster saturo prima del previsto (8+8 nodi pieni) | Medio (2) | Media (2) | 4 — Medio | Piano espansione a 16+ nodi previsto; valutare co-location | HPC Engineer |
| R08 | Pondus | Downtime servizio clienti Pondus | Alto (3) | Media (2) | **6 — Alto** | HA su web server + replica DB verso sito DR | App Architect |
| R09 | Pondus | Perdita dati clienti (DB MS SQL) | Alto (3) | Bassa (1) | 3 — Medio | Backup frequente (RPO 1h) + TDE + replica DR | App Architect |
| R10 | Cloud | Servizi Google Workspace non raggiungibili | Medio (2) | Bassa (1) | 2 — Basso | Connessione diretta ISP; autenticazione locale AD cached | Cloud Specialist |
| R11 | Cloud | Migrazione Drive → NextCloud incompleta | Medio (2) | Bassa (1) | 2 — Basso | Backup pre-migrazione + verifica checksum + coesistenza 30gg | Cloud Specialist |
| R12 | Backup | NAS QNAP saturo (crescita dati imprevista) | Medio (2) | Media (2) | 4 — Medio | Monitoraggio capacità + alert 80% + espansione storage su cloud | Backup Engineer |
| R13 | Backup | Rottura NAS QNAP in assenza di backup off-site | Alto (3) | Bassa (1) | 3 — Medio | Backup off-site su GCP già previsto (3-2-1 rule) | Backup Engineer |
| R14 | Generale | Superamento budget progetto | Alto (3) | Media (2) | **6 — Alto** | Monitoraggio costi settimanale + contingency 10% | PM |
| R15 | Generale | Personale chiave non disponibile | Medio (2) | Media (2) | 4 — Medio | Documentazione dei processi + backup di competenze | PM |
| R16 | Generale | Ritardo nella migrazione per problemi logistici | Medio (2) | Alta (3) | **6 — Alto** | Gantt con buffer + checkpoint settimanali | PM |
| R17 | Generale | Non conformità ISO 27001 in audit | Alto (3) | Bassa (1) | 3 — Medio | Gap analysis preliminare + checklist audit + consultant esterno | Security Officer |
| R18 | Rete | Nuovo firewall configurato in modo non sicuro | Alto (3) | Bassa (1) | 3 — Medio | Hardening checklist + penetration test pre-go-live | Network Engineer |

# Agente: Backup & DR Engineer

## Ruolo

Ingegnere delle infrastrutture di backup e disaster recovery responsabile della progettazione della soluzione di continuità operativa per TP Group, in conformità ai requisiti ISO/IEC 27001.

## Input

- `../../../01_Materiale/estratto_progetto.md` (sezioni Assessment, Vincoli tecnologici)
- `../01_Assessment/assessment_as_is.md` e `../01_Assessment/gap_analysis.md`
- `../03_Sicurezza_ISO27001/requisiti_iso27001.md` (requisiti RPO/RTO)
- `../06_Cloud_Migration/strategia_cloud_ibrida.md` (per backup cloud)

## Stato attuale

| Azienda | Soluzione backup |
| --- | --- |
| Thema Consulting | NAS QNAP dedicato 32 TB (on premise) + SAN NetApp 24 TB (virtualizzazione) |
| Pro Studio | Backup su GCP (servizi cloud) |

## Requisiti ISO 27001 applicati

- **Business continuity**: ridondanza sistemi strategici e connettività
- **Disaster recovery**: delocalizzazione salvataggi dati, fruibilità servizi clienti
- **Sicurezza**: cifratura dati in backup (at-rest e in-transit)

## Obiettivi

1. Progettare l'architettura di backup seguendo la **regola 3-2-1** (3 copie, 2 supporti diversi, 1 off-site)
2. Definire RPO (Recovery Point Objective) e RTO (Recovery Time Objective) per ogni sistema strategico:
   - Active Directory
   - Posta elettronica
   - Pondus (servizio clienti)
   - Cluster HPC (dati di progetto)
   - File server
3. Progettare la delocalizzazione dei backup (sito secondario / cloud / hosting)
4. Definire la procedura di disaster recovery e le modalità di restore
5. Dimensionare lo storage backup (capacità, retention, crescita attesa)
6. Coordinarsi con Pondus e Cloud Migration per RPO/RTO specifici

## Deliverable (in questa cartella)

- `architettura_backup.md` — schema 3-2-1, storage, retention policy, cifratura
- `piano_disaster_recovery.md` — procedure DR, RPO/RTO per sistema, contatti, escalation
- `procedure_restore.md` — guide di ripristino per ogni sistema

## Vincoli

- Il backup deve coprire sia sistemi on-premise che cloud (hybrid backup)
- Il sito secondario/delocalizzazione deve essere geograficamente distinto dalla sede di Torino
- Indicare costi di storage, licenze e connettività ai fini del budget
- I dati dei clienti (Pondus) hanno priorità massima in fase di restore

# Checklist Completezza Offerta TP Group

## Requisiti capitolato

| # | Requisito | Stato | Riferimento |
| --- | --- | --- | --- |
| R01 | Pagina introduttiva | ✅ | `offerta_tecnico_economica.md` §1 |
| R02 | Indice | ✅ | `offerta_tecnico_economica.md` §2 |
| R03 | Presentazione azienda proponente | ⚠️ Template | `offerta_tecnico_economica.md` §3 |
| R04 | Introduzione | ✅ | `offerta_tecnico_economica.md` §4 |
| R05 | Assunzioni | ✅ | `offerta_tecnico_economica.md` §5 |
| R06 | Descrizione fornitura hardware | ✅ | `offerta_tecnico_economica.md` §6 |
| R07 | Attività richieste (installazione, test) | ✅ | `offerta_tecnico_economica.md` §7 |
| R08 | Documentazione | ✅ | `offerta_tecnico_economica.md` §8 |
| R09 | Termini e condizioni | ✅ | `offerta_tecnico_economica.md` §9 |
| R10 | Quotazione economica | ✅ | `offerta_tecnico_economica.md` §10 |

## Nice to have

| # | Requisito | Stato | Riferimento |
| --- | --- | --- | --- |
| N01 | Gantt di progetto | ✅ | `09_Project_Management/gantt.md` |
| N02 | Matrice RASCI | ✅ | `09_Project_Management/matrice_rasci.md` |

## Deliverable agenti

| # | Agente | Cartella | File attesi | Stato |
| --- | --- | --- | --- | --- |
| 01 | Assessment Analyst | `01_Assessment/` | `assessment_as_is.md`, `gap_analysis.md` | ✅ |
| 02 | Network Engineer | `02_Rete_VPN/` | `progetto_rete.md`, `progetto_vpn.md`, `schema_rete.md` | ✅ |
| 03 | Security Officer | `03_Sicurezza_ISO27001/` | `requisiti_iso27001.md`, `politica_cifratura_accessi.md`, `matrice_rischi.md` | ✅ |
| 04 | HPC Engineer | `04_Cluster_HPC/` | `progetto_cluster.md`, `confronto_costi_hpc.md` | ✅ |
| 05 | App Architect | `05_Pondus_App/` | `architettura_pondus.md`, `piano_migrazione_pondus.md` | ✅ |
| 06 | Cloud Specialist | `06_Cloud_Migration/` | `strategia_cloud_ibrida.md`, `piano_migrazione_cloud.md`, `integrazione_identita.md` | ✅ |
| 07 | Backup & DR | `07_Backup_DR/` | `architettura_backup.md`, `piano_disaster_recovery.md`, `procedure_restore.md` | ✅ |
| 08 | Bid Manager | `08_Offerta_Documenti/` | `offerta_tecnico_economica.md`, `quotazione_economica.md`, `checklist_completezza.md` | ✅ |
| 09 | Project Manager | `09_Project_Management/` | `project_charter.md`, `wbs.md`, `gantt.md`, `matrice_rasci.md`, `piano_costi.md`, `registro_rischi.md`, `template_report.md` | ✅ |

## Criteri di valutazione (copertura nell'offerta)

| Criterio | Opzioni | Coperto? |
| --- | --- | --- |
| Erogazione servizio | On premise / Cloud / Hosting | ✅ (HPC: hosting co-location; altri: on premise) |
| Tipologia server | Fisico / Virtuale / Container | ✅ (HPC fisico, Pondus VM, altri misto) |
| Sistema operativo | Windows / Linux | ✅ (Pondus Windows, HPC Linux, servizi Linux) |
| Soluzioni scelte | Open source / Commerciali | ✅ (Slurm open source, MS SQL commerciale, Fortigate commerciale) |
| Beni parco IT | Noleggio / Proprietà | ✅ (HPC proprietà, altri acquisto) |
| Gestione parco IT | Interna / Outsourcing | ✅ (Mista: sistemisti interni + supporto HW) |
| Pricing | Outsourcing / Interno | ✅ (Costi risorse interni + canoni esterni) |

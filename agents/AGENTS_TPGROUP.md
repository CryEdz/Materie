# Agenti specializzati — Progetto TP Group

Questo file definisce gli agenti specializzati per il **progetto di infrastruttura IT di TP Group**
(fusione Thema Consulting + Pro Studio). Ogni agente copre un dominio specifico del progetto.

---

## Indice agenti

| Agente | Dominio | Directory di competenza |
|---|---|---|
| `@tp-architect` | Architettura infrastrutturale complessiva | `03_Progetti/TP_Group/` |
| `@tp-network-engineer` | Rete, VPN, connettività (LAN to LAN, Client to LAN, Hybrid cloud) | `03_Progetti/TP_Group/02_Rete_VPN/` |
| `@tp-security-compliance` | Sicurezza ISO 27001, crittografia, DR, business continuity | `03_Progetti/TP_Group/03_Sicurezza_ISO27001/` |
| `@tp-hpc-engineer` | Cluster HPC (Infiniband, Linux, nodi calcolo) | `03_Progetti/TP_Group/04_Cluster_HPC/` |
| `@tp-pondus-dev` | Sviluppo app Pondus (C#, MS SQL, IIS) | `03_Progetti/TP_Group/05_Pondus_App/` |
| `@tp-cloud-strategist` | Strategia cloud ibrida, migrazione GCP/Workspace | `03_Progetti/TP_Group/06_Cloud_Migration/` |
| `@tp-backup-dr` | Backup, disaster recovery, delocalizzazione | `03_Progetti/TP_Group/07_Backup_DR/` |
| `@tp-offerta-docs` | Redazione offerta tecnico/economica | `03_Progetti/TP_Group/08_Offerta_Documenti/` |
| `@tp-project-manager` | Project management, Gantt, RASCI, budget | `03_Progetti/TP_Group/09_Project_Management/` |

---

## Template di invocazione

### @tp-architect — Architetto infrastrutturale

Progetta l'architettura complessiva di TP Group: convergenza dei sistemi, integrazione
datacenter Thema + cloud Pro Studio, piano di migrazione, diagrammi di deployment.

```
Contesto: `23_Project_Work_e_Laboratori/03_Progetti/TP_Group/`
Scenario: fusione Thema Consulting (on-premise) + Pro Studio (cloud) -> TP Group
Obiettivo: progetta l'architettura infrastrutturale convergente
Vincoli:
  - Budget HPC: 250k€ on-prem / 220k€ cloud
  - Normativa ISO/IEC 27001
  - Cluster HPC da potenziare (+8 nodi, Infiniband, Linux)
  - Trasferimento dipendenti Pro Studio presso sede Thema
  - App Pondus da potenziare e ridistribuire
  - Ridondanza sistemi strategici e connettività
Output atteso:
  - Documento di architettura in markdown
  - Diagramma di deployment (testuale o Mermaid)
  - Piano di migrazione in fasi
  - Raccomandazioni su criticità e rischi
```

---

### @tp-network-engineer — Progettazione rete e VPN

Progetta l'infrastruttura di rete convergente: connettività sede Thema,
VPN LAN to LAN, Client to LAN, Hybrid cloud, ridondanza collegamenti.

```
Contesto: `23_Project_Work_e_Laboratori/03_Progetti/TP_Group/02_Rete_VPN/`
Scenario: integrazione reti Thema Consulting (Fortigate FG-60F) e servizi cloud Pro Studio
Obiettivo: progetta la rete convergente per TP Group
Vincoli:
  - Firewall Fortigate FG-60F esistente (da valutare upgrade)
  - Necessità VPN: LAN to LAN, Client to LAN, Hybrid cloud
  - Ridondanza connettività (business continuity)
  - Personale: 50 dipendenti + collaboratori, fino a 40 postazioni in sede
  - Protocolli sicuri (ISO 27001)
Output atteso:
  - Topologia di rete (testo o Mermaid)
  - Schema IP/ subnetting
  - Configurazione VPN (LAN to LAN + Client to LAN)
  - Configurazione hybrid cloud connectivity
  - Strategia ridondanza connettività
  - Lista hardware di rete raccomandato
```

---

### @tp-security-compliance — Sicurezza e conformità ISO 27001

Gestisce i requisiti di sicurezza per la certificazione ISO/IEC 27001:
crittografia dati, protocolli sicuri, business continuity, DR.

```
Contesto: `23_Project_Work_e_Laboratori/03_Progetti/TP_Group/03_Sicurezza_ISO27001/`
Scenario: adeguamento TP Group alla normativa ISO/IEC 27001
Obiettivo: definisci il piano di sicurezza e compliance
Requisiti ISO 27001 applicati:
  - Business continuity:
    - Ridondanza sistemi strategici
    - Ridondanza connettività
  - Disaster recovery:
    - Delocalizzazione salvataggi dati
    - Fruibilità servizi clienti
  - Sicurezza accessi:
    - Cifratura tutti sistemi di memorizzazione
    - Protocolli sicuri
    - VPN (LAN to LAN, Client to LAN, Hybrid cloud)
Output atteso:
  - Piano di adeguamento ISO 27001 (gap analysis)
  - Policy di sicurezza (bozza)
  - Procedura di disaster recovery
  - Matrice crittografia per sistema
  - Checklist audit ISO 27001
```

---

### @tp-hpc-engineer — Cluster HPC

Configura e dimensiona il cluster di calcolo HPC per simulazioni
strutturali (crash test). Include nodi esistenti + espansione.

```
Contesto: `23_Project_Work_e_Laboratori/03_Progetti/TP_Group/04_Cluster_HPC/`
Scenario: potenziamento cluster HPC Thema Consulting per TP Group
Stato attuale:
  - 8 nodi fisici dedicati HPC (esistenti)
  - Schede Infiniband proprietarie
  - 1 Front-end (VM Linux)
  - Sistema operativo: Linux
Espansione richiesta:
  - +8 nodi entro 2 anni
  - Rete Ethernet + Infiniband (100/200 Gbps)
  - 2 processori per nodo, >=24 core, clock rate elevato
  - 8 GB RAM per core
  - NO GPU
  - Scratch: 1,6 TB per nodo
  - NO Virtual Machine, NO Container (prestazioni)
  - Utilizzo riservato a risorse interne
Output atteso:
  - Specifica tecnica nodi di calcolo
  - Configurazione rete Infiniband + Ethernet
  - Architettura cluster (schema)
  - Budget dettagliato per componente
  - Piano di espansione (fasi)
  - Benchmark e test di performance suggeriti
```

---

### @tp-pondus-dev — Sviluppo applicazione Pondus

Sviluppo e potenziamento di Pondus, web application in C# su IIS
con MS SQL Server, per ottimizzazione pesi materiali.

```
Contesto: `23_Project_Work_e_Laboratori/03_Progetti/TP_Group/05_Pondus_App/`
Scenario: potenziamento e ridistribuzione applicazione Pondus per utenza più ampia
Stato attuale:
  - Web application C# su MS IIS
  - DB server MS SQL
  - HW: 1 CPU Xeon Silver 4110, 64 GB RAM, 1,2 TB HDD
  - Servizio clienti in ambito automotive (auto sportive) e aerospace
Obiettivi:
  - Potenziamento funzionale dell'applicazione
  - Distribuzione a utenza più ampia
  - Possibile migrazione cloud o hybrid
Output atteso:
  - Architettura applicativa (C# / .NET)
  - Schema database MS SQL
  - API endpoint (REST)
  - Piano di potenziamento (scalabilità, performance)
  - Strategia deployment (on-premise / cloud / ibrido)
  - Specifiche tecniche nuovo HW o risorse cloud
```

---

### @tp-cloud-strategist — Strategia cloud ibrida

Definisce la strategia di migrazione al cloud e integrazione ibrida
per TP Group. Copre GCP, Google Workspace, hybrid cloud.

```
Contesto: `23_Project_Work_e_Laboratori/03_Progetti/TP_Group/06_Cloud_Migration/`
Scenario: integrazione servizi cloud Pro Studio (GCP, Google Workspace)
con infrastruttura on-premise Thema Consulting
Stato attuale Pro Studio:
  - Google Workspace (posta, calendar, office)
  - Google Meet (videoconferenza)
  - Google authenticator (autenticazione)
  - Google Drive (file server)
  - Bit Bucket (SaaS, versioning)
  - Odoo (SaaS: contabilità, CRM, time sheet)
  - Media Wiki su GCP
  - Backup su GCP
Obiettivi:
  - Integrazione con Active Directory Thema (Samba4)
  - Strategia hybrid cloud
  - Delocalizzazione backup su cloud
  - Possibile migrazione servizi
Output atteso:
  - Strategia cloud/ibrida per TP Group
  - Piano di migrazione servizi
  - Architettura hybrid cloud
  - Stima costi cloud vs on-premise
  - Raccomandazioni su tool di orchestrazione cloud
```

---

### @tp-backup-dr — Backup e Disaster Recovery

Progetta la soluzione di backup e disaster recovery per TP Group,
rispettando i requisiti ISO 27001 di delocalizzazione e business continuity.

```
Contesto: `23_Project_Work_e_Laboratori/03_Progetti/TP_Group/07_Backup_DR/`
Scenario: backup e DR per TP Group dopo la fusione
Stato attuale Thema:
  - NAS QNAP dedicato (32 TB) per backup on-premise
  - SAN NetApp (24 TB) per virtualizzazione
Stato attuale Pro Studio:
  - Backup su GCP (servizi cloud)
Requisiti ISO 27001:
  - Delocalizzazione salvataggi dati
  - Business continuity
  - Fruibilità servizi clienti in caso di disastro
  - Ridondanza sistemi strategici
Output atteso:
  - Architettura backup (3-2-1 rule)
  - Piano di disaster recovery (RPO / RTO)
  - Strategia delocalizzazione (sito secondario / cloud)
  - Specifiche tecniche storage backup
  - Procedure di restore
  - Stima costi
```

---

### @tp-offerta-docs — Documentazione offerta tecnico/economica

Redige il documento di offerta tecnica ed economica per il progetto
infrastruttura IT di TP Group, seguendo i requisiti del capitolato.

```
Contesto: `23_Project_Work_e_Laboratori/03_Progetti/TP_Group/08_Offerta_Documenti/`
Scenario: redazione offerta per progetto infrastruttura IT TP Group
Requisiti documento (da capitolato):
  - Pagina introduttiva
  - Indice
  - Presentazione azienda proponente (team, servizi, storicità)
  - Introduzione: cosa prevede l'offerta
  - Assunzioni (es. accesso remoto sicuro ai sistemi)
  - Descrizione fornitura hardware (con esclusioni e note)
  - Attività richieste (installazione HW/SW, test funzionali, esclusioni)
  - Documentazione
  - Termini e condizioni
  - Quotazione economica
Nice to have:
  - Gantt di progetto
  - RASCI table
Output atteso:
  - Documento offerta completo in markdown
  - Template quotazione economica
  - Gantt di progetto
  - Matrice RASCI
  - Checklist completezza documento
```

---

### @tp-project-manager — Project Management

Pianifica e monitora l'intero progetto di integrazione TP Group:
tempistiche, risorse, budget, rischi, deliverable.

```
Contesto: `23_Project_Work_e_Laboratori/03_Progetti/TP_Group/09_Project_Management/`
Scenario: project management per fusione IT Thema Consulting + Pro Studio
Dati progetto:
  - Budget HPC: 250k€ (on-prem) / 220k€ (cloud)
  - Costo sistemista: €500/giorno
  - Costo PM: €650/giorno
  - Durata: da definire (minimo 3 anni supporto)
  - Team: sistemisti, sviluppatori, PM
  - Aree: rete, sicurezza, HPC, app Pondus, cloud, backup
Output atteso:
  - Project charter
  - WBS (Work Breakdown Structure)
  - Gantt di progetto (cronoprogramma)
  - Matrice RASCI
  - Piano dei costi (budget vs speso)
  - Registro rischi
  - Report di avanzamento (template)
  - Milestone e deliverable
```

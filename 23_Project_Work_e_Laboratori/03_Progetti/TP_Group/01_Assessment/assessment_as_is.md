# Assessment AS-IS — TP Group

> **Documento:** Inventario completo dello stato attuale di Thema Consulting srl e Pro Studio srl  
> **A cura di:** Assessment Analyst  
> **Data:** Giugno 2025

---

## 1. Profili aziendali

| Dato | Thema Consulting | Pro Studio |
| --- | --- | --- |
| **Settore** | Progettazione strutturale automotive | Progettazione aerospace |
| **Anno fondazione** | Fine anni '90 | 2023 |
| **Personale** | 30 dipendenti/collaboratori | 20 dipendenti |
| **Sede** | Centro Torino (di proprietà) | Condominio uffici Torino (affitto) |
| **Destino sede** | Mantenuta, capienza max 40 postazioni | **Da dismettere** (affitto non rinnovato) |
| **Modello IT** | On-premise prevalente | Full cloud |

---

## 2. Censimento asset hardware

### 2.1 Virtualizzazione e storage

| Asset | Specifiche | Note |
| --- | --- | --- |
| **2 host VMWare** | On premise, rack 19" | 2 rack saturi, non espandibili |
| **SAN NetApp** | 24 TB totali | Storage condiviso per virtualizzazione |
| **NAS QNAP** | 32 TB totali | Backup on-premise |

### 2.2 Rete e sicurezza perimetrale

| Asset | Specifiche | Note |
| --- | --- | --- |
| **Firewall Fortigate FG-60F** | 1 unità | Protezione perimetro sede Thema |
| **Switch LAN** | Non specificato | Connettività postazioni e server |

### 2.3 Cluster HPC (calcolo strutturale)

| Componente | Quantità | Specifiche |
| --- | --- | --- |
| **Nodi di calcolo fisici** | 8 | Infiniband proprietario, Linux |
| **Front-end** | 1 | VM Linux |
| **Rete Infiniband** | Proprietaria | Collegamento nodi HPC |
| **Rete Ethernet** | Presente | Management e storage |
| **GPU** | Nessuna | Non richieste |
| **Utilizzo** | Solo risorse interne | Simulazioni crash test |

### 2.4 Infrastruttura fisica data center

| Sistema | Stato | Criticità |
| --- | --- | --- |
| **Rack** | 2 armadi rack, saturi | Impossibile espandere |
| **UPS** | Autonomia ~10 minuti | Sopperisce solo a brevi interruzioni |
| **Condizionamento** | Al limite per carico attuale | Difficilmente potenziabile |
| **Ubicazione** | Edificio storico centro Torino | Limiti strutturali all'espansione |

### 2.5 Pondus — Server applicativo e DB

| Componente | Specifica |
| --- | --- |
| **CPU** | 1x Xeon Silver 4110 |
| **RAM** | 64 GB |
| **Storage** | 1,2 TB HDD |
| **Ruolo** | Web server (MS IIS) + DB server (MS SQL) |

---

## 3. Censimento asset software

### 3.1 Sistemi operativi e virtualizzazione

| Prodotto | Tipo | Sede |
| --- | --- | --- |
| **VMWare** | Hypervisor | Thema |
| **Linux (VM guest)** | OS server | Thema (multipli guest) |
| **Windows Server** | OS server | Thema (Profis, Pondus) |

### 3.2 Servizi applicativi — Thema Consulting

| Servizio | Prodotto | Piattaforma |
| --- | --- | --- |
| Posta / Calendario | Zimbra | VM Linux |
| Office / Produttività | MS365 + LibreOffice | Desktop + cloud |
| Videoconferenza / IM | MS Teams | Cloud |
| Autenticazione | Active Directory (Samba4) | VM Linux |
| File Server | NextCloud | VM Linux |
| Sviluppo / Versioning | GiTea | Self hosted |
| Contabilità | Profis | On premise, Windows Server |
| CRM | Sugar CRM | Self hosted, VM Linux |
| Timesheet | Kimai | Self hosted, VM Linux |
| Documentazione | Media Wiki | Self hosted, VM Linux |
| Applicazione clienti | Pondus (C#, IIS, MS SQL) | HW fisico dedicato |

### 3.3 Servizi applicativi — Pro Studio

| Servizio | Prodotto | Piattaforma |
| --- | --- | --- |
| Posta / Calendario | Google Workspace | Cloud (SaaS) |
| Office / Produttività | Google Workspace | Cloud (SaaS) |
| Videoconferenza / IM | Google Meet | Cloud (SaaS) |
| Autenticazione | Google Authenticator | Cloud (SaaS) |
| File Server | Google Drive | Cloud (SaaS) |
| Sviluppo / Versioning | Bit Bucket | Cloud (SaaS) |
| Contabilità | Odoo | Cloud (SaaS) |
| CRM | Odoo | Cloud (SaaS) |
| Timesheet | Odoo | Cloud (SaaS) |
| Documentazione | Media Wiki | Self hosted on GCP (IaaS) |

---

## 4. Stima volumi consolidati

| Parametro | Valore | Fonte |
| --- | --- | --- |
| **Utenti totali** | 50 (30 Thema + 20 Pro Studio) | Dati anagrafici |
| **Postazioni in sede** | Max 40 | Capienza uffici Thema |
| **Laptop aziendali** | 50 (1 per dipendente) | Vincolo progetto |
| **Storage primario (SAN)** | 24 TB | NetApp |
| **Storage backup** | 32 TB | QNAP |
| **Nodi HPC attuali** | 8 fisici | Cluster esistente |
| **Rack disponibili** | 2, saturi | Data center Thema |
| **Domini utenza** | 2 (Thema + Pro Studio) | Da unificare |

---

## 5. Mappa delle dipendenze tra servizi

```
Autenticazione (AD/Samba4)
  ├── Accesso postazioni LAN
  ├── Zimbra (posta)
  ├── NextCloud (file server)
  ├── GiTea (versioning)
  ├── Sugar CRM
  ├── Kimai (timesheet)
  └── Media Wiki (documentazione)

Firewall Fortigate FG-60F
  ├── VPN accesso remoto
  ├── NAT / pubblicazione servizi (Pondus, NextCloud, Media Wiki)
  └── Segmentazione rete interna (HPC, server, LAN utenti)

VMWare (2 host)
  ├── VM Linux: Zimbra, NextCloud, AD/Samba4, GiTea, Sugar CRM, Kimai, Media Wiki
  ├── VM Windows: Profis
  └── Front-end HPC (VM Linux)

NAS QNAP 32 TB
  └── Backup di: SAN NetApp, VM, DB Pondus, cluster HPC
```

---

## 6. Servizi esclusivi di ciascuna azienda

### Solo Thema Consulting (da mantenere/conservare)

- **Cluster HPC** (8 nodi fisici) — risorsa unica, non presente in Pro Studio
- **Pondus** — applicazione proprietaria di ottimizzazione pesi, erogata a clienti
- **Profis** — contabilità on premise
- **Infrastruttura fisica data center** (rack, UPS, condizionamento, firewall)

### Solo Pro Studio (da integrare/dismettere)

- **Google Authenticator** — autenticazione a fattore singolo
- **Google Drive + Workspace** — ecosistema Google (da convergere)
- **Bit Bucket** — repository Git SaaS
- **Odoo** — ERP SaaS (contabilità, CRM, timesheet)

### Servizi con stessa tipologia ma piattaforma diversa

| Servizio | Thema | Pro Studio | Duplicato? |
| --- | --- | --- | --- |
| Posta/Calendario | Zimbra | Google Workspace | Sì |
| Office | MS365 / LibreOffice | Google Workspace | Sì |
| Videoconferenza | MS Teams | Google Meet | Sì |
| Autenticazione | AD (Samba4) | Google Authenticator | Sì |
| File Server | NextCloud | Google Drive | Sì |
| Versioning | GiTea | Bit Bucket | Sì |
| Contabilità | Profis | Odoo | No* |
| CRM | Sugar CRM | Odoo | Sì |
| Timesheet | Kimai | Odoo | Sì |
| Documentazione | Media Wiki (on-prem) | Media Wiki (GCP) | Sì (stesso prodotto) |

> *Profis e Odoo coprono entrambi la contabilità ma sono prodotti diversi; tuttavia Odoo include anche CRM e timesheet, creando sovrapposizione parziale.

---

## 7. Criticità rilevate

| # | Criticità | Impatto | Descrizione |
| --- | --- | --- | --- |
| C1 | **Data center saturo** | Alto | 2 rack al completo, impossibile aggiungere HW senza rimuovere asset esistenti |
| C2 | **UPS limitato (10')** | Alto | Autonomia insufficiente per shutdown ordinato in caso di blackout prolungato |
| C3 | **Condizionamento al limite** | Alto | L'incremento del carico termico (es. +8 nodi HPC) rischia di superare la capacità di raffreddamento |
| C4 | **Sede Pro Studio da dismettere** | Alto | Tutti i servizi cloud e personale vanno riconvertiti/trasferiti in sede Thema |
| C5 | **Due domini di autenticazione** | Medio | AD (Samba4) e Google Workspace disallineati: ogni utente ha due identità |
| C6 | **Backup senza delocalizzazione** | Medio | Thema ha backup solo on-premise (NAS QNAP), non conforme a ISO 27001 (DR) |
| C7 | **Nessuna ridondanza connettività** | Medio | Singolo firewall/collegamento: single point of failure per accesso esterno |
| C8 | **Piattaforme office eterogenee** | Basso | MS365 + LibreOffice (Thema) vs Google Workspace (Pro Studio): possibili incompatibilità documentale |
| C9 | **Assenza di MFA strutturato** | Medio | Thema usa solo AD/password, Pro Studio solo Google Authenticator: nessun 2FA centralizzato |
| C10 | **Versioning non unificato** | Basso | GiTea (self hosted) e Bit Bucket (SaaS) separati: doppia gestione repository |

# CSP - BF 2025-27 - Learning by project - Progetto

**Versione documento:** 260603  
**Docente:** Luca ROBALDO  
**Unità Formativa:** Learning by project  
**Argomento:** Progetto infrastruttura IT  
**Pagine:** 9

---

## Indice

1. Scenario di riferimento
2. Descrizione dello scenario
   - Thema Consulting
   - Pro Studio srl
3. Assessment
4. Servizi / Sistemi
5. Vincoli, requisiti ed obiettivi, budget
   - Vincoli tecnologici
   - Vincoli logistici
   - Obiettivi per il futuro
   - Budget di progetto
6. Costi indicativi risorse
7. Requisiti compilazione documento di offerta tecnico/economico
8. Criteri di valutazione

---

## Scenario di riferimento

Due aziende che operano nel campo della progettazione nel settore automotive / aerospace decidono di creare un'alleanza (associazione di imprese) per proporsi ad un mercato sempre più richiedente di soluzioni altamente tecnologiche.

**Dall'unione di Thema Consulting e Pro Studio nasce TP Group.**

Nella fase di integrazione / convergenza, sono pesantemente coinvolti tutti i sistemi informativi, oggetto del progetto richiesto.

---

## Descrizione dello scenario

### Thema Consulting srl

Nasce alla fine degli anni '90 dall'idea di tre ingegneri progettisti, attivi da un decennio nel settore della progettazione meccanica; si occupa prevalentemente di progettazione strutturale in ambito automotive.

- **Sede** di proprietà in un edificio storico situato nel centro di Torino
- **Data center**: piccolo, efficiente, ma poco capiente — non è possibile espanderlo, i due armadi rack sono saturi
- **Personale**: 30 persone (tra dipendenti e collaboratori)
- **Uffici**: possono ospitare fino a 40 postazioni di lavoro
  - La postazione è composta da scrivania con connessione LAN e monitor esterno a cui collegare il proprio laptop
- **Cluster HPC**: cluster di calcolo a esclusivo utilizzo del personale interno, in grado di svolgere simulazioni (crash test) e fornire al cliente un progetto completo di calcolo strutturale
- **Servizio Pondus**: dal 2015 erogano per una cerchia ristretta di clienti un servizio di ottimizzazione dei pesi dei materiali, per la scelta di componenti speciali in ambito automotive (auto sportive) ed aerospace

### Pro Studio srl

Nasce nel 2023 come startup ed è composta da giovani ingegneri progettisti che lavorano in ambito aerospace.

- **Sede** di rappresentanza in affitto presso un condominio uffici che fornisce tutte le facilities necessarie (energia elettrica, riscaldamento/condizionamento e connettività)
- **Personale**: 20 dipendenti a Torino
- **Infrastruttura IT**: non possiede infrastruttura IT interna, utilizza servizi in cloud
- **Calcolo strutturale**: sottomesso sui sistemi dei loro clienti finali

---

## Assessment

| | Datacenter Thema Consulting | Pro Studio |
| --- | --- | --- |
| **Sistemi di virtualizzazione** | 2 host con VMWare + 1 SAN NetApp (24 TB tot.) on premise | Nessuno |
| **Backup** | Salvataggi on premise su NAS QNAP dedicato (32 TB tot.) | On GCP |
| **Firewall** | 1 x Fortigate FG-60F | N/A |
| **Cluster di calcolo** | 8 nodi dedicati al calcolo HPC (fisici, con soluzioni HW proprietarie come schede Infiniband, on premise, Linux) + 1 Front-end (VM Linux) | N/A |
| **UPS** | In grado di sopperire ad una interruzione di corrente massima di 10' | N/A |
| **Condizionamento** | Al limite per l'attuale struttura, difficilmente potenziabile | N/A |

---

## Servizi / Sistemi

| Servizio / Sistema | Thema Consulting | Pro Studio |
| --- | --- | --- |
| **Posta / Calendario** | Zimbra (VM Linux) | Google Workspace |
| **Office / Produttività** | MS365 / LibreOffice | Google Workspace |
| **Videoconferenza / IM** | MS Teams | Google Meet |
| **Autenticazione** | Active Directory su Samba4 (VM Linux) | Google authenticator |
| **File Server** | NextCloud (VM Linux) | Google Drive |
| **Sviluppo e versioning** | GiTea | Bit Bucket (SaaS) |
| **Contabilità** | Profis (on premise Server Windows) | Odoo (SaaS) |
| **CRM** | Sugar CRM (self hosted, VM Linux) | Odoo (SaaS) |
| **Time Sheet** | Kimai (Self hosted, VM Linux) | Odoo (SaaS) |
| **Documentazione** | Media Wiki (Self hosted, VM Linux) | Media Wiki (Self hosted on GCP) |
| **Applicazioni proprietarie** | Pondus — Web application in C#: Web server (MS IIS) + DB server (MS SQL) su HW fisico: 1 CPU Xeon Silver 4110, 64 GB RAM, 1,2 TB HDD | N/A |

- Ogni singolo dipendente ha un laptop aziendale assegnato
- Non si richiedono soluzioni VDI per i dipendenti / collaboratori

---

## Vincoli, requisiti ed obiettivi, budget

### Vincoli tecnologici

Al fine di presentarsi ad un mercato sempre più richiedente in termini di certificazioni, il nuovo gruppo (TP Group) ha deciso di ottemperare a quanto richiesto dalla normativa **ISO/IEC 27001**, con una particolare attenzione ai seguenti requisiti:

- **Business continuity**
  - Ridondanza
    - dei sistemi più strategici
    - delle connettività
- **Disaster recovery**, applicato a:
  - Delocalizzazione dei salvataggi dei dati
  - Fruibilità dei servizi dedicati ai clienti
- **Sicurezza degli accessi ai dati**
  - Cifratura di tutti i sistemi di memorizzazione dei dati
  - Utilizzo di applicazioni di rete che fanno uso di protocolli sicuri
  - Accessi via VPN
    - LAN to LAN
    - Client To LAN
    - Hybrid cloud

### Vincoli logistici

Con la fusione delle due aziende **non si intende rinnovare il contratto di locazione** della Pro Studio: i dipendenti saranno trasferiti presso la sede della Thema Consulting.

### Obiettivi per il futuro

- **Potenziamento dell'applicazione Pondus** e distribuzione della stessa ad un'utenza più ampia
- **Potenziamento del cluster di calcolo** con l'incremento di altri 8 nodi entro 2 anni (mantenendone l'utilizzo riservato alle risorse interne)
  - Per garantire le massime prestazioni nell'elaborazione, si sconsigliano sia la soluzione Virtual Machine sia la soluzione Container
  - I compute node del cluster devono essere connessi sia da una rete Ethernet, sia da una rete Infiniband (100 o 200 Gbps)
  - Si predilige una soluzione con 2 processori, ≥ 24 core, con clock rate elevato e 8 GB di RAM per ogni core
  - Non servono GPU a bordo dei server di calcolo
  - Sistema operativo richiesto: **Linux**
  - Capacità richiesta per lo scratch sul singolo compute node: **1,6 TB**

### Budget di progetto

| Soluzione | Costo |
| --- | --- |
| **On Premise/Hosting** (acquisto proprietà nodi di calcolo) | 250k € + IVA |
| **On Cloud** (noleggio) | 220k € + IVA |

---

## Costi indicativi risorse

| Ruolo | Costo |
| --- | --- |
| Tecnico sistemista con almeno 5 anni di esperienza | € 500/giorno |
| Project manager | € 650/giorno |

---

## Requisiti compilazione documento di offerta tecnico/economico

Si richiede da parte dell'ente proponente la redazione di un documento di offerta, tecnica ed economica, contenente i seguenti minimi requisiti:

- **Pagina introduttiva**
- **Indice**
- **Presentazione azienda (team) proponente** (chi siete, principali servizi erogati, storicità)
- **Introduzione**: cosa prevede la vs. offerta
- **Assunzioni** (assunzioni eventuali in ordine alla corretta erogazione delle fasi progettuali, es. si assume nel caso di erogazione di servizi da remoto la necessità di poter accedere ai sistemi aziendali mediante connessione sicura)
- **Descrizione fornitura hardware** (se presente)
  - Descrizione materiale HW in fornitura
  - Esclusioni
  - Note
- **Attività richieste** (attività tecnico-operative previste dal progetto)
  - Installazione Hardware (es.)
  - Installazione Software (es.)
  - Test funzionali (es.)
  - Esclusioni
  - Note
- **Documentazione**
- **Termini e condizioni** (se presenti)
- **Quotazione economica**

### Nice to have

- Gantt di progetto
- Rasci table

---

## Criteri di valutazione

Per la redazione del progetto si richiede di considerare i seguenti criteri di valutazione:

| Criterio | Opzioni |
| --- | --- |
| **Erogazione del servizio** | On premise (supporto manutentivo minimo 3 anni) / In cloud (minimo 3 anni) / Hosting co-location (contratto di hosting per minimo 3 anni) |
| **Tipologie di server** | Fisico / Virtuale / Container |
| **Sistema operativo** | MS Windows server / Linux server |
| **Soluzioni scelte** | Open source / Commerciali |
| **Beni del parco IT** | A noleggio / Di proprietà |
| **Gestione del parco IT** | Con personale interno / In outsourcing |
| **Pricing** | In outsourcing / Con personale interno |

---

Documento estratto dal PDF originale "CSP - BF 2025-27 - Learning by project - Progetto.pdf"

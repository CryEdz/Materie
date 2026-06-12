# Offerta Tecnico/Economica — Progetto Infrastruttura IT TP Group

**Versione:** 1.0  
**Data:** Giugno 2026  
**Cliente:** TP Group (Thema Consulting srl + Pro Studio srl)  
**Proponente:** [Nome Azienda Proponente]

---

## 1. Pagina introduttiva

| Campo | Valore |
| --- | --- |
| Progetto | Integrazione infrastruttura IT TP Group |
| Cliente | TP Group — Thema Consulting srl + Pro Studio srl |
| Budget | 250k € + IVA (on premise/hosting) / 220k € + IVA (cloud/noleggio) |
| Durata progetto | 6 mesi (migrazione) + 36 mesi (supporto) |
| Data emissione | Giugno 2026 |
| Versione documento | 1.0 |

## 2. Indice

1. Presentazione azienda proponente
2. Introduzione
3. Assunzioni
4. Descrizione fornitura hardware
5. Attività richieste
6. Documentazione
7. Termini e condizioni
8. Quotazione economica
9. Appendice A: Gantt di progetto
10. Appendice B: Matrice RASCI

## 3. Presentazione azienda proponente

[Da compilare con i dati dell'azienda che redige l'offerta]

- Nome azienda
- Team tecnico (sistemisti, sviluppatori, PM)
- Principali servizi erogati
- Storicità e referenze nel settore infrastruttura IT

## 4. Introduzione

La presente offerta descrive la soluzione tecnica ed economica per l'integrazione dell'infrastruttura IT di TP Group, nata dalla fusione di Thema Consulting srl (datacenter on premise, Torino) e Pro Studio srl (servizi cloud, GCP/Workspace).

Il progetto copre le seguenti aree:
- **Rete e connettività**: ridondanza ISP, firewall HA, VPN (LAN to LAN, Client to LAN, Hybrid cloud)
- **Sicurezza**: adeguamento ISO/IEC 27001 (cifratura, MFA, protocolli sicuri)
- **Cluster HPC**: potenziamento a 16 nodi con Infiniband 200 Gbps
- **Applicazione Pondus**: potenziamento e migrazione a VM HA
- **Cloud ibrido**: integrazione GCP/Workspace con AD on premise
- **Backup e DR**: architettura 3-2-1 con delocalizzazione su GCP

## 5. Assunzioni

L'offerta si basa sulle seguenti assunzioni:

1. **Accesso remoto**: il proponente potrà accedere ai sistemi aziendali tramite VPN sicura per tutta la durata del progetto
2. **Disponibilità sede**: i lavori in sede si svolgeranno in orario ufficio (9:00-18:00), salvo diverso accordo per attività critiche
3. **Connettività**: la connettività Internet esistente rimarrà attiva durante la migrazione
4. **Collaborazione personale**: il personale TP Group collaborerà attivamente nelle fasi di test e validazione
5. **Documentazione**: TP Group fornirà tutta la documentazione esistente (configurazioni, credenziali, contratti)
6. **Imprevisti**: non sono inclusi costi per danni a hardware esistente o per sostituzione di componenti non preventivati

## 6. Descrizione fornitura hardware

### 6.1 Hardware in fornitura

| ID | Apparato | Q.tà | Costo unitario | Totale |
| --- | --- | --- | --- | --- |
| HW-01 | Fortigate FG-100F (HA cluster) | 2 | € 4.500 | € 9.000 |
| HW-02 | Switch Core L3 (stack) | 2 | € 1.200 | € 2.400 |
| HW-03 | Switch L2 accesso 48 porte | 2 | € 900 | € 1.800 |
| HW-04 | Access Point WiFi 6 | 3 | € 150 | € 450 |
| HW-05 | Nodo calcolo HPC (nuovo) | 8 | € 18.000 | € 144.000 |
| HW-06 | Switch Infiniband HDR 200 Gbps | 1 | € 25.000 | € 25.000 |
| HW-07 | NAS QNAP 40 TB | 1 | € 4.000 | € 4.000 |
| **Totale hardware** | | | | **€ 186.650** |

### 6.2 Specifica nodo HPC (HW-05)

| Componente | Specifica |
| --- | --- |
| CPU | 2× AMD EPYC 9454 (48 core, 3.8 GHz) |
| RAM | 768 GB (48× 16 GB DDR5-4800) |
| Scratch | 2× 800 GB NVMe SSD in RAID0 (1,6 TB) |
| Infiniband | 1× ConnectX-7 HDR 200 Gbps |
| Ethernet | 2× 25 GbE SFP28 |
| OS | Linux (Rocky Linux 9 / Ubuntu 22.04 LTS) |

### 6.3 Esclusioni

- Laptop e postazioni utente (di proprietà TP Group)
- Licenze software già in uso (es. MS365, VMWare)
- Arredi e infrastruttura fisica (rack, cablaggio edificio, UPS condizionamento)
- Google Workspace e Odoo (costi SaaS a carico TP Group)

### 6.4 Note

- I prezzi sono IVA esclusa
- Trasporto e installazione inclusi
- Garanzia hardware: 3 anni on-site (NBD per HPC, 4h per Fortigate)

## 7. Attività richieste

### 7.1 Installazione Hardware

| Attività | Durata | Note |
| --- | --- | --- |
| Montaggio rack e cablaggio Fortigate HA | 2 giorni | Co-location o sede |
| Configurazione switch core e accesso | 2 giorni | |
| Installazione e cablaggio cluster HPC | 5 giorni | In hosting/co-location |
| Configurazione NAS QNAP | 1 giorno | |

### 7.2 Installazione Software

| Attività | Durata | Note |
| --- | --- | --- |
| Configurazione Fortigate (HA, VPN, WAF, IPS) | 5 giorni | |
| Deploy cluster HPC (OS, Slurm, Infiniband) | 10 giorni | |
| Migrazione Pondus (VM IIS + SQL HA) | 20 giorni | |
| Configurazione backup Veeam + GCS | 5 giorni | |
| Integrazione AD/Google Workspace (GCDS, SAML) | 5 giorni | |

### 7.3 Test funzionali

| Test | Durata |
| --- | --- |
| Test connettività e VPN | 2 giorni |
| Test failover Fortigate HA | 1 giorno |
| Test cluster HPC (benchmark) | 3 giorni |
| Test Pondus (carico, failover, backup) | 3 giorni |
| Test disaster recovery | 2 giorni |
| Test ISO 27001 readiness | 2 giorni |

### 7.4 Esclusioni

- Sviluppo di nuove funzionalità per Pondus (fuori perimetro)
- Certificazione formale ISO 27001 (costo ente certificatore escluso)
- Formazione approfondita utenti (solo sessioni di handover)

## 8. Documentazione

| Documento | Formato | Lingua |
| --- | --- | --- |
| Assessment infrastrutturale AS-IS | Markdown | IT |
| Progetto rete e VPN | Markdown | IT |
| Politica di sicurezza e cifratura | Markdown | IT |
| Specifica cluster HPC | Markdown | IT |
| Architettura Pondus TO-BE | Markdown | IT |
| Strategia cloud ibrida | Markdown | IT |
| Piano backup e disaster recovery | Markdown | IT |
| Documento di offerta (presente) | Markdown | IT |
| Manuale utente servizi migrati | Markdown | IT |

## 9. Termini e condizioni

- **Validità offerta:** 60 giorni
- **Consegna:** Chiavi in mano (inclusa installazione, configurazione e test)
- **Garanzia hardware:** 3 anni
- **Supporto manutentivo:** 3 anni minimo (rinnovabile)
- **Pagamento:** 30% acconto, 40% al collaudo intermedio, 30% al collaudo finale
- **Penali:** 0,1% del valore ordine per ogni giorno di ritardo sui milestone (max 10%)

## 10. Quotazione economica

### 10.1 Costi una tantum

| Area | Voce | Costo |
| --- | --- | --- |
| **Rete** | Hardware rete (Fortigate HA, switch, AP) | € 13.650 |
| **Rete** | Cablaggio e connettori | € 1.500 |
| **HPC** | 8 nodi calcolo + switch Infiniband | € 169.000 |
| **HPC** | Co-location hosting (1 anno) | € 9.600 |
| **Backup** | NAS QNAP 40 TB | € 4.000 |
| **Sicurezza** | FortiAuthenticator + FortiToken | € 2.000 |
| **Pondus** | Licenze Windows Server + SQL Server | € 4.800 |
| **Sistemista** | 80 giorni × € 500/giorno | € 40.000 |
| **PM** | 30 giorni × € 650/giorno | € 19.500 |
| **Totale una tantum** | | **€ 264.050** |

### 10.2 Costi ricorrenti (mensili)

| Area | Voce | Costo/mese |
| --- | --- | --- |
| **Rete** | Doppio provider ISP | € 240 |
| **HPC** | Co-location hosting (dal 2° anno) | € 800 |
| **Backup** | GCS Nearline 10 TB | € 150 |
| **Cloud** | GCP Cloud VPN + VM DR | € 300 |
| **Sicurezza** | Licenze FortiGate (UTM) | € 200 |
| **Supporto** | Manutenzione HW (3° anno) | € 500 |
| **Totale ricorrente/mese** | | **€ 2.190** |

### 10.3 Riepilogo

| Voce | On premise / Hosting | Cloud / Noleggio |
| --- | --- | --- |
| Costi una tantum | € 264.050 | € 264.050 |
| Costi ricorrenti (36 mesi) | € 78.840 | — |
| **Totale 3 anni** | **€ 342.890** | *Da quotare* |
| Budget disponibile | € 250.000 + IVA | € 220.000 + IVA |

**Nota:** Il costo totale supera il budget per la componente HPC (nodi acquistati + co-location). Si raccomanda di valutare la soluzione hosting/co-location per i nodi HPC (budget 250k€) oppure di optare per il noleggio cloud HPC (budget 220k€) come dettagliato nel confronto costi HPC.

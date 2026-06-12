# Progetto Cluster HPC — TP Group

> **Documento:** Architettura del cluster HPC potenziato per simulazioni strutturali (crash test)
> **A cura di:** HPC Architect
> **Data:** Giugno 2025

---

## Indice

1. Scenario di riferimento
2. Stato attuale
3. Dimensionamento nuovi nodi
4. Rete Infiniband ed Ethernet
5. Integrazione con nodi esistenti
6. Stack software
7. Soluzione logistica: co-location vs cloud HPC
8. Piano di espansione in fasi

---

## 1. Scenario di riferimento

TP Group (fusione Thema Consulting + Pro Studio) necessita di potenziare il cluster HPC esistente per far fronte all'aumento del carico di lavoro dovuto alla crescita del team di progettazione strutturale (da 30 a 50 persone) e alla previsione di nuove commesse in ambito automotive e aerospace.

Il cluster è dedicato esclusivamente a simulazioni di crash test e calcolo strutturale, utilizzato solo da personale interno.

---

## 2. Stato attuale

| Componente | Dettaglio |
| --- | --- |
| **Nodi di calcolo** | 8 nodi fisici, Linux, con schede Infiniband proprietarie |
| **Front-end** | 1 VM Linux (accesso utenti, job submission) |
| **Rete Infiniband** | Proprietaria, collega gli 8 nodi esistenti |
| **Rete Ethernet** | Presente per management e storage |
| **Storage** | Non specificato — si presume storage condiviso su SAN/locale |
| **Scheduler** | Non specificato — da definire |
| **Ubicazione** | Data center on-premise, sede Torino |
| **Criticità** | Datacenter saturo (2 rack al completo), condizionamento al limite, UPS 10' |

---

## 3. Dimensionamento nuovi nodi

### 3.1 Specifica tecnica per ogni nuovo nodo

| Parametro | Valore | Note |
| --- | --- | --- |
| **CPU** | 2 × AMD EPYC 9654 (96 core ciascuno) **oppure** 2 × Intel Xeon Platinum 8490H (60 core ciascuno) | Si consiglia AMD EPYC per miglior rapporto core/costo e maggiore densità per core |
| **Core totali per nodo** | 120–192 | Dipende dalla scelta del processore |
| **RAM** | 768 GB–1.536 GB (8 GB/core × core totali) | Minimo garantito: 384 GB con CPU a 24 core; con CPU moderne si ottengono densità molto superiori |
| **Scratch locale** | 1 × SSD NVMe U.2 1,6 TB | Per file temporanei dei job |
| **Rete Infiniband** | 1 × HCA Infiniband NDR200 (200 Gbps) o HDR100 (100 Gbps) | Doppia porta per ridondanza opzionale |
| **Rete Ethernet** | 1 × 25 GbE (o 2 × 25 GbE in bonding) | Per management, storage condiviso, boot PXE |
| **GPU** | Nessuna | Non richiesta |
| **OS** | Linux (Rocky Linux 9 o Ubuntu Server 24.04 LTS) | Si consiglia Rocky Linux per stabilità enterprise |
| **Form factor** | 1U o 2U rack | 2U consigliato per migliore raffreddamento e espandibilità storage |

### 3.2 Configurazione consigliata — benchmark di riferimento

| Componente | Modello suggerito | Q.tà per nodo | Costo unitario stimato | Subtotale |
| --- | --- | --- | --- | --- |
| **CPU** | AMD EPYC 9654 (96C, 2.4 GHz base, 3.7 GHz boost) | 2 | € 6.500 | € 13.000 |
| **RAM** | DDR5-4800 ECC RDIMM 128 GB | 12 | € 350 | € 4.200 |
| **Scratch NVMe** | Samsung PM9A3 1,6 TB U.2 | 1 | € 250 | € 250 |
| **HCA Infiniband** | NVIDIA ConnectX-7 NDR200 (200 Gbps) | 1 | € 1.200 | € 1.200 |
| **NIC Ethernet** | Intel E810-2CQDA2 2×25 GbE | 1 | € 400 | € 400 |
| **Chassis/alimentatore** | Supermicro 2U chassis con dual PSU ridondanti | 1 | € 800 | € 800 |
| **Cavi Infiniband** | Cavo DAC NDR200 3 m | 1 | € 150 | € 150 |
| **Cavi Ethernet** | Cavo DAC SFP28 25 GbE 3 m | 2 | € 30 | € 60 |
| | | | **Totale per nodo** | **€ 20.060** |

**Totale 8 nodi: ≈ € 160.500**

### 3.3 Alternativa Intel

| Componente | Modello suggerito | Q.tà per nodo | Costo unitario stimato | Subtotale |
| --- | --- | --- | --- | --- |
| **CPU** | Intel Xeon Platinum 8490H (60C, 1.9 GHz base, 3.5 GHz boost) | 2 | € 8.500 | € 17.000 |
| **(restante config identica)** | | | | ≈ € 6.860 |
| | | | **Totale per nodo** | **€ 23.860** |

**Totale 8 nodi: ≈ € 191.000**

> **Raccomandazione:** Si consiglia la soluzione AMD EPYC per il miglior rapporto prestativo/costo. I 96 core per EPYC 9654 garantiscono un totale di 192 core per nodo e 1.536 GB RAM, ben oltre il minimo richiesto, offrendo margine di crescita.

---

## 4. Rete Infiniband ed Ethernet

### 4.1 Architettura di rete

```
                    ┌─────────────────────────────┐
                    │     Switch Infiniband        │
                    │  NVIDIA QM9790 NDR200 (36p)  │
                    │  oppure QM9700 HDR200 (32p)  │
                    └──────────┬──────────────────┘
                               │
         ┌─────────────────────┼─────────────────────┐
         │     │     │     │   │   │     │     │     │
    ┌────┴────┐ ┌┴────┐ ┌┴────┐ ... ┌┴────┐ ┌┴────┐
    │ Nodo 01 │ │Nodo02│ │Nodo03│     │Nodo16│ │NodoFE│
    │ (esist.)│ │(esist)│ │(nuovo)     │(nuovo)│ │(front)│
    └─────────┘ └──────┘ └──────┘     └──────┘ └──────┘
                               │
                    ┌──────────┴──────────────────┐
                    │     Switch Ethernet          │
                    │  Top of Rack 25/100 GbE      │
                    └──────────────────────────────┘
                               │
                         ┌─────┴─────┐
                         │ Storage   │
                         │ condiviso │
                         └───────────┘
```

### 4.2 Switch Infiniband

| Componente | Modello | Porte | Costo stimato |
| --- | --- | --- | --- |
| **Switch Infiniband NDR200** | NVIDIA QM9790 (o MQM9790 managable) | 36 porte NDR200 (200 Gbps) | € 25.000 |
| **Cavi DAC NDR200** | 3m per nodo (16 nodi + front-end) | 17 cavi | € 2.550 |
| **Opzione economica: Switch HDR100** | NVIDIA QM9700 | 32 porte HDR100 (100 Gbps) | € 12.000 |
| **Cavi DAC HDR100** | 3m | 17 cavi | € 1.700 |

> **Nota:** Lo switch NDR200 a 36 porte è sufficiente per connettere 16 nodi di calcolo + 1 front-end + 2 porte per storage condiviso, con porte di scorta. L'opzione HDR100 (100 Gbps) è adeguata per la maggior parte dei carichi di crash test e consente un risparmio significativo.

### 4.3 Switch Ethernet

| Componente | Modello | Porte | Costo stimato |
| --- | --- | --- | --- |
| **Switch ToR 25 GbE** | NVIDIA SN2010 (o Mellanox) | 18 porte 25 GbE + 4 porte 100 GbE uplink | € 4.000 |
| **Cavi DAC 25 GbE** | 3m | 18 cavi | € 540 |

### 4.4 Integrazione con la rete esistente

- Lo switch Ethernet ToR si collega alla rete LAN aziendale esistente tramite uplink 100 GbE (o 2 × 25 GbE LAG) verso lo switch di core/aggregazione
- La rete Infiniband è segregata: solo traffico MPI tra nodi di calcolo
- Il front-end è connesso a entrambe le reti: Ethernet per accesso utenti e storage, Infiniband per job submission e orchestrazione

---

## 5. Integrazione con nodi esistenti

### 5.1 Criticità

I nodi esistenti (8 unità) montano schede Infiniband **proprietarie** di vecchia generazione. L'integrazione con la nuova rete Infiniband NDR200/HDR100 richiede una delle seguenti strategie:

| Strategia | Descrizione | Vantaggi | Svantaggi |
| --- | --- | --- | --- |
| **A — Switch compatibile** | Verificare se lo switch NDR200 è retrocompatibile con le schede esistenti (es. NVIDIA HDR backward compatible con HDR) | Nessuna modifica ai nodi esistenti | Le schede proprietarie potrebbero non essere compatibili; rischio di blocco |
| **B — Sostituzione HCA nei nodi esistenti** | Sostituire le vecchie schede Infiniband con nuove HCA NDR200 | Omogeneità della rete, piena compatibilità, performance uniformi | Costo aggiuntivo per 8 HCA + lavoro di installazione |
| **C — Cluster separato** | Mantenere i vecchi 8 nodi sulla rete Infiniband legacy e connettere i nuovi 8 su una rete NDR200 separata; due partizioni Slurm | Nessuna modifica all'esistente, minori rischi | Due reti da gestire, job non possono migrare tra partizioni |

**Raccomandazione: Strategia B** (sostituzione HCA). Costo contenuto (~ € 1.200 × 8 = € 9.600) e semplificazione gestionale notevole.

### 5.2 Cablaggio

| Tratta | Tipo cavo | Lunghezza stimata |
| --- | --- | --- |
| Nodi → Switch Infiniband | DAC NDR200 passive | 3 m |
| Nodi → Switch Ethernet | DAC 25 GbE passive | 3 m |
| Switch Ethernet → Rete aziendale | Fibra multimodale OM4 100 GbE (o 4×25 GbE breakout) | 10–30 m |

---

## 6. Stack software

### 6.1 Sistema operativo

| Componente | Scelta | Motivazione |
| --- | --- | --- |
| **OS nodi calcolo** | Rocky Linux 9 | Stabile, compatibile RHEL, buon supporto HPC, gratuito |
| **OS front-end** | Rocky Linux 9 | Coerenza con i nodi di calcolo |
| **OS nodi esistenti** | Da riconciliare su Rocky Linux 9 (se diverso) | Uniformità gestionale |

### 6.2 Scheduler e job management

| Componente | Scelta | Motivazione |
| --- | --- | --- |
| **Resource manager / Scheduler** | **Slurm** (Simple Linux Utility for Resource Management) | Standard de facto per HPC, open source, supporta partizioni, QoS, job dependencies, MPI integration |
| **Configurazione partizioni** | `partizione_legacy` (8 nodi vecchi) + `partizione_nuova` (8 nodi nuovi) oppure partizione unica se HCA sostituite (strategia B) | Flessibilità nella gestione dei due gruppi di nodi |

### 6.3 Filesystem condiviso

| Componente | Scelta | Motivazione |
| --- | --- | --- |
| **Filesystem parallelo** | **Lustre** | Standard HPC parallelo, open source, performante su Infiniband, maturo e supportato dalla comunità. Alternativa: **BeeGFS** (più semplice da configurare) |
| **Architettura storage** | 1 MDS (Metadata Server) + 4 OSS (Object Storage Server) su storage condiviso (es. su SAN NetApp o storage HPC dedicato) | Separazione metadata/data per performance |
| **Capacità storage condiviso** | Minimo 100 TB utili | Per dati di input/output delle simulazioni, home directory, applicazioni |
| **Protocollo accesso** | Infiniband (LNet) | Sfrutta la bassa latenza Infiniband per I/O parallelo |
| **Storage esistente** | Verificare se la SAN NetApp 24 TB può essere riconfigurata come target Lustre OSS | Ottimizzazione delle risorse esistenti |

### 6.4 Stack di sviluppo e runtime

| Componente | Scelta |
| --- | --- |
| **MPI** | OpenMPI + MPICH (entrambi ottimizzati per Infiniband con UCX) |
| **Compiler** | GCC + Intel oneAPI (per ottimizzazione su CPU Intel/AMD) |
| **Librerie matematiche** | BLAS, LAPACK, FFTW, Intel MKL (o AMD AOCC) |
| **Debugger/Profiler** | GDB, Valgrind, Intel VTune, Arm DDT (opzionale) |
| **Package manager** | Spack (per installazione pacchetti HPC) |
| **Gestione code** | Slurm sacct, sreport per accounting |

### 6.5 Monitoring e amministrazione

| Componente | Scelta |
| --- | --- |
| **Monitoring** | Prometheus + Grafana + Node Exporter + Slurm Exporter |
| **Logging** | rsyslog centralizzato + Elastic Stack (opzionale) |
| **Backup** | Backup periodico di /home, /scratch importante su NAS QNAP + cloud |
| **Provisioning** | Warewulf o xCAT per PXE boot e immagine nodi |

---

## 7. Soluzione logistica: co-location vs cloud HPC

### 7.1 Problema

Il datacenter on-premise è saturo (2 rack al completo), il condizionamento è al limite e l'UPS ha autonomia insufficiente. Non è possibile installare fisicamente gli 8 nuovi nodi nel data center esistente.

### 7.2 Opzione A — Hosting/Co-location (raccomandata)

Affittare spazio in un datacenter di terze parti (es. Equinix, Aruba, Supernap, retelit) per ospitare i nuovi nodi HPC, mantenendo la connettività con la sede Thema.

| Vantaggi | Svantaggi |
| --- | --- |
| Server fisici dedicati, massime prestazioni | Costo ricorrente di hosting (~ € 500–1.000/mese per 10U) |
| Infiniband nativo possibile (switch e cablaggio in locale) | Latenza aggiuntiva rete WAN rispetto a on-premise |
| Raffreddamento, UPS, sicurezza fisica inclusi | Necessità di connettività dedicata (VPN L2 o fibra) |
| Scalabilità futura senza vincoli di spazio | Tempo di provisioning iniziale (30–60 giorni) |
| Conforme ai requisiti ISO 27001 (ridondanza, DR) | |

**Configurazione co-location:**

- 1 armadio rack 19" dedicato (20U–30U):
  - 8 nodi di calcolo nuovi (≈ 16U–20U in formato 2U)
  - 1 nodo front-end (o VM, ma si sconsiglia per coerenza → meglio un server fisico 1U)
  - 2 switch Infiniband + Ethernet (≈ 2U)
  - Spazio per futuro storage HPC dedicato (se necessario)
- Connettività: VPN L2 site-to-site (Fortigate → datacenter) su fibra dedicata o VLAN over MPLS
- Contratto: 36 mesi

**Costi indicativi hosting:**

| Voce | Costo mensile | Costo annuale | 3 anni |
| --- | --- | --- | --- |
| Rack 20U con alimentazione Dual Path 4 kW | € 800 | € 9.600 | € 28.800 |
| Connettività 1 Gbps dedicata (o VPN L2) | € 200 | € 2.400 | € 7.200 |
| Supporto/manutenzione HW (4h response) | € 300 | € 3.600 | € 10.800 |
| **Totale hosting** | **€ 1.300** | **€ 15.600** | **€ 46.800** |

### 7.3 Opzione B — Cloud HPC (non raccomandata)

Utilizzare servizi HPC cloud (AWS ParallelCluster, Azure CycleCloud, GCP Batch, o Penguin Computing on Demand).

| Motivazione del NO | Dettaglio |
| --- | --- |
| **NO VM/container** | Il bando vieta espressamente VM e container per i compute node; il cloud HPC si basa essenzialmente su VM (anche bare-metal sono VM con virtualizzazione leggera). Non conforme al requisito. |
| **Infiniband in cloud** | Pochi provider offrono Infiniband nativo (es. AWS con Elastic Fabric Adapter non è Infiniband; Azure con InfiniBand su HB-series è disponibile ma con costi elevatissimi). |
| **Costi** | Il budget 220k€ per 3 anni (~ € 6.100/mese) può coprire solo una frazione della potenza di 8 nodi dedicati 24/7. A confronto, nodi Azure HBv4 (2× EPYC 64C, 512 GB RAM) costano ~ € 5–8/ora → 8 nodi = € 40–64/ora. Con utilizzo 24/7: € 28.800–46.000/mese, fuori budget. |
| **Dati sensibili** | Simulazioni crash test per automotive/aerospace: i dati sono sensibili e riservati. Il cloud potrebbe sollevare problemi di data sovereignty e compliance ISO 27001 (certificazione del provider). |
| **Lock-in** | Dipendenza da un singolo provider cloud. |

### 7.4 Opzione C — Ampliamento datacenter on-premise (non fattibile)

| Motivazione del NO | Dettaglio |
| --- | --- |
| **Spazio** | Edificio storico, impossibile espandere i 2 rack. |
| **Condizionamento** | Già al limite; 8 nodi HPC aggiuntivi generano ~ 4–6 kW termici aggiuntivi. |
| **UPS** | Autonomia 10', insufficiente anche per il carico attuale. |
| **Costo** | Potenziare condizionamento + UPS + eventuale terzo rack non è economicamente sostenibile (stima: € 30–50k solo per infrastruttura) e i vincoli strutturali permangono. |

### 7.5 Raccomandazione finale

| Scelta | Motivazione |
| --- | --- |
| **Hosting/Co-location** | Unica soluzione che rispetta tutti i vincoli: server fisici (no VM/container), rete Infiniband nativa, OS Linux, scratch NVMe 1,6 TB. Costo contenuto (~ € 47k in 3 anni). Consente di mantenere la proprietà dei server (budget 250k€). |

---

## 8. Piano di espansione in fasi

### Fase 1 — Preparazione (Mese 1–2)

- Scelta del datacenter di co-location e stipula contratto
- Ordinazione HW: 8 nodi, switch Infiniband, switch Ethernet, cavi
- Verifica compatibilità HCA con nodi esistenti (strategia B)
- Configurazione VPN L2 site-to-site Fortigate → datacenter

### Fase 2 — Installazione (Mese 2–3)

- Consegna HW in datacenter
- Montaggio a rack e cablaggio Infiniband + Ethernet
- Installazione OS Rocky Linux 9 su tutti i nodi
- Configurazione switch Infiniband (partizioni, routing)
- Configurazione rete Ethernet (VLAN management, storage, accesso utenti)

### Fase 3 — Stack software (Mese 3–4)

- Installazione Slurm: configurazione partizioni, code, QoS
- Setup Lustre (o BeeGFS): MDS + OSS su storage condiviso
- Installazione MPI (OpenMPI + UCX ottimizzato Infiniband)
- Installazione compilatori e librerie (Intel oneAPI + AOCC)
- Integrazione repository Spack

### Fase 4 — Integrazione (Mese 4–5)

- Migrazione nodi esistenti su nuova rete Infiniband (se strategia B)
- Riconciliazione OS su Rocky Linux 9 (se necessario)
- Configurazione Slurm partizione unica
- Test connettività WAN: ping, iperf, Infiniband ibping, MPI bandwidth test
- Test job: sottomissione job MPI su partizione legacy + nuova

### Fase 5 — Collaudo (Mese 5–6)

- Esecuzione benchmark HPL (LINPACK) su tutti i nodi
- Esecuzione simulazione crash test reale (campione)
- Validazione performance vs requisiti
- Documentazione: diagramma di rete, procedure di backup, runbook

### Fase 6 — Produzione (Mese 6+)

- Passaggio in produzione
- Formazione utenti (sottomissione job Slurm)
- Attivazione monitoring (Prometheus + Grafana)
- Review SLA con datacenter e contratti manutenzione HW

---

## Appendice A — Riepilogo costi HW (nuovi nodi + rete)

| Voce | Costo |
| --- | --- |
| 8 nodi di calcolo (config AMD EPYC 9654) | € 160.500 |
| Sostituzione HCA nodi esistenti (8 × ConnectX-7 NDR200) | € 9.600 |
| Switch Infiniband QM9790 NDR200 (36 porte) | € 25.000 |
| Cavi DAC NDR200 (17 pezzi) | € 2.550 |
| Switch Ethernet ToR 25 GbE | € 4.000 |
| Cavi DAC 25 GbE (18 pezzi) | € 540 |
| 1 nodo front-end fisico (server 1U, SSD 512 GB, 64 GB RAM) | € 3.500 |
| **Totale HW** | **€ 205.690** |

> Vedi `confronto_costi_hpc.md` per il confronto completo on-premise/hosting vs noleggio/cloud.

---

## Appendice B — Stima consumi termici

| Componente | Watt | Q.tà | Totale W |
| --- | --- | --- | --- |
| Nodo calcolo AMD EPYC 9654 (2 CPU + RAM + NVMe + HCA) | 700 W | 8 | 5.600 W |
| Nodo front-end | 150 W | 1 | 150 W |
| Switch Infiniband QM9790 | 250 W | 1 | 250 W |
| Switch Ethernet SN2010 | 100 W | 1 | 100 W |
| **Totale carico termico** | | | **~ 6.100 W** |

> Il carico termico di ~6 kW è gestibile da un datacenter di co-location standard. L'attuale condizionamento on-premise non sarebbe in grado di smaltirlo (conferma la scelta co-location).

---

## Appendice C — Budget riepilogo

| Voce | Costo |
| --- | --- |
| HW nodi + rete + front-end | € 205.690 |
| Hosting co-location 3 anni | € 46.800 |
| Manutenzione HW (3 anni, OEM) | € 15.000 |
| Installazione e configurazione (sistemista, 40gg × € 500) | € 20.000 |
| **Totale** | **€ 287.490** |

> Il costo totale (€ 287k) supera il budget di € 250k di circa € 37k. Possibili ottimizzazioni:
> - Ridurre lo switch Infiniband a HDR100 (risparmio ~ € 15k)
> - Scegliere CPU con core count inferiore (es. EPYC 9334, 32 core, risparmio ~ € 4k per nodo)
> - Negoziare sconto sul volume con il fornitore HW
> - Ridurre i giorni di installazione (30gg invece di 40gg)

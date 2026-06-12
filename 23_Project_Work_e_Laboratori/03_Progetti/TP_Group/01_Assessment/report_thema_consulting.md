# Report di Analisi — Thema Consulting

## Anagrafica

| Campo | Valore |
|---|---|
| **Nome** | Thema Consulting srl |
| **Settore** | Progettazione strutturale (automotive) |
| **Fondazione** | Fine anni '90 |
| **Sede** | Edificio storico, centro Torino (di proprietà) |
| **Personale** | 30 persone (dipendenti + collaboratori) |
| **Postazioni** | Fino a 40 (scrivania + LAN + monitor esterno, laptop personale) |

---

## Infrastruttura IT

### Datacenter
| Componente | Specifica |
|---|---|
| **Location** | In sede (edificio storico) |
| **Capienza** | 2 armadi rack saturi — **non espandibile** |
| **Virtualizzazione** | 2 host VMWare |
| **Storage SAN** | NetApp 24 TB |
| **Backup** | NAS QNAP 32 TB (on-premise) |
| **Firewall** | Fortigate FG-60F |
| **UPS** | Autonomia ~10 minuti |
| **Condizionamento** | Al limite, difficilmente potenziabile |

### Cluster HPC
| Componente | Specifica |
|---|---|
| **Nodi calcolo** | 8 nodi fisici dedicati |
| **Interconnessione** | Infiniband (schede proprietarie) |
| **Front-end** | 1 VM Linux |
| **OS** | Linux |
| **Utilizzo** | Solo risorse interne |
| **Scopo** | Simulazioni strutturali (crash test) |

### Applicazioni e Servizi
| Servizio | Soluzione | Piattaforma |
|---|---|---|
| Posta/Calendario | Zimbra | VM Linux |
| Office | MS365 / LibreOffice | — |
| Videoconferenza | MS Teams | — |
| Autenticazione | Active Directory (Samba4) | VM Linux |
| File Server | NextCloud | VM Linux |
| Sviluppo & Versioning | GiTea | Self-hosted |
| Contabilità | Profis | Server Windows on-prem |
| CRM | Sugar CRM | VM Linux self-hosted |
| Time Sheet | Kimai | VM Linux self-hosted |
| Documentazione | MediaWiki | VM Linux self-hosted |
| App proprietaria | **Pondus** (C# / MS SQL / IIS) | HW fisico dedicato |

### Pondus — Dettaglio HW
| Componente | Specifica |
|---|---|
| CPU | 1x Xeon Silver 4110 |
| RAM | 64 GB |
| Storage | 1,2 TB HDD |
| Web Server | MS IIS |
| DB Server | MS SQL |

---

## Punti di Forza

1. **Infrastruttura on-premise consolidata** — datacenter funzionante, personale tecnico presente
2. **Cluster HPC proprietario** — know-how distintivo, calcolo strutturale interno
3. **App Pondus** — servizio già erogato a clienti automotive/aerospace, potenziale di crescita
4. **Sistemi self-hosted** — controllo completo su dati e servizi
5. **Sede di proprietà** — nessun costo locazione, stabilità

---

## Punti di Debolezza

1. **Datacenter saturo** — impossibile espandere fisicamente i rack
2. **Condizionamento al limite** — rischio termico in caso di carico aggiuntivo
3. **UPS insufficiente** — solo 10 minuti di autonomia, non sufficiente per spegnimento ordinato
4. **Backup solo on-premise** — nessuna delocalizzazione (viola ISO 27001)
5. **Nessuna ridondanza connettività** — single point of failure
6. **Hardware Pondus datato** — HDD 1,2 TB (no SSD), singola CPU
7. **Eterogeneità piattaforme** — mix di VM Linux, Windows, HW fisico

---

## Rischi Identificati

| Rischio | Impatto | Probabilità |
|---|---|---|
| Saturazione datacenter blocca crescita | Alto | Media |
| Guasto condizionamento in estate | Alto | Bassa |
| Interruzione corrente > 10 min | Alto | Media |
| Singolo punto di rottura firewall | Alto | Bassa |
| Obsolescenza HW Pondus | Medio | Alta |

---

## Raccomandazioni Preliminari

1. Valutare upgrade UPS o gruppo elettrogeno
2. Valutare soluzione hosting/colo per decongestionare il datacenter
3. Implementare backup off-site (cloud o sito secondario)
4. Pianificare upgrade connettività con 2° ISP
5. Valutare migrazione Pondus su HW più performante (SSD, CPU moderna)

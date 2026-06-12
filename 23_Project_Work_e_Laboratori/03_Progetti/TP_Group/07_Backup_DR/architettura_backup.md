# Architettura Backup — TP Group

## Regola 3-2-1

- **3** copie dei dati
- **2** supporti diversi
- **1** copia off-site

## Schema architetturale

```mermaid
graph TB
    subgraph ONPREM["Sede Torino — Primaria"]
        PROD[Dati di produzione<br/>SAN NetApp 24 TB<br/>VM, DB, Pondus]
        NAS[NAS QNAP 32 TB<br/>Backup locale<br/>AES-256]
        HPC[Cluster HPC<br/>dati scratch<br/>su NAS]
    end

    subgraph OFFSITE["GCP — Off-site (DR)"]
        GCS[Google Cloud Storage<br/>Backup crittografato]
    end

    subgraph REPLICA["Replica interna"]
        NAS_OLD[NAS QNAP esistente<br/>(sostituzione/eccedenze)]
    end

    PROD -->|Backup giornaliero<br/>Veeam / rsync| NAS
    PROD -->|Backup notturno<br/>cifrato AES-256| GCS
    HPC -->|Backup settimanale| NAS
    NAS -->|Replica settimanale<br/>off-site| GCS
    NAS -->|Copia aggiuntiva| NAS_OLD
```

## Storage backup

| Storage | Capacità | Utilizzo | Retention | Cifratura |
| --- | --- | --- | --- | --- |
| NAS QNAP (nuovo) | 40 TB (sostituisce 32 TB) | Backup on-premise primario | 30 giorni + mensili 12 mesi | AES-256 volume |
| GCS Nearline | 10 TB iniziali | Backup off-site delocalizzato | 90 giorni + annuali 3 anni | AES-256 (CSEK) |
| SAN NetApp | 24 TB (produzione) | Snapshot VMWare + replica DB | 7 giorni + 4 settimanali | NSE AES-256 |

## Politica di retention

| Dato | Frequenza backup | Retention on-prem | Retention off-site |
| --- | --- | --- | --- |
| VM (Veeam) | Giornaliero | 30 giorni | 90 giorni |
| DB Pondus (MS SQL) | Ogni ora | 7 giorni | 30 giorni |
| File server (NextCloud) | Giornaliero | 30 giorni | 90 giorni |
| AD Samba4 | Giornaliero | 14 giorni | 30 giorni |
| Cluster HPC (dati progetto) | Settimanale | 90 giorni | 12 mesi |
| Config firewall switch | Ad ogni modifica | 12 mesi | 12 mesi |

## RPO / RTO target

| Sistema | RPO | RTO | Priorità |
| --- | --- | --- | --- |
| Pondus (servizio clienti) | 1 ora | 4 ore | Critica |
| AD Samba4 | 24 ore | 4 ore | Alta |
| Posta (Google Workspace) | N/A (SaaS) | 24 ore | Media |
| File server (NextCloud) | 24 ore | 8 ore | Media |
| Cluster HPC | 7 giorni | 48 ore | Bassa |
| Sistemi interni (CRM, TS) | 24 ore | 24 ore | Media |

## Costi storage backup

| Voce | Costo iniziale | Costo ricorrente/mese |
| --- | --- | --- |
| NAS QNAP 40 TB | € 4.000 | € 0 |
| GCS Nearline 10 TB | € 0 | € 150 |
| Licenza Veeam Backup (5 VM) | € 700/anno | € 60 |
| **Totale** | **€ 4.700** | **€ 210** |

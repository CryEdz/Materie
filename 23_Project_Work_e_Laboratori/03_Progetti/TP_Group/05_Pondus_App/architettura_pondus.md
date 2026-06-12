# Architettura Pondus — TO-BE

## Stato attuale

| Componente | Valore |
| --- | --- |
| Tipologia | Web application C# su MS IIS |
| DB server | MS SQL Server |
| HW fisico | 1 CPU Xeon Silver 4110, 64 GB RAM, 1,2 TB HDD |
| Servizio | Ottimizzazione pesi materiali (automotive/aerospace) |
| Cliente | Cerchia ristretta dal 2015 |

## Architettura TO-BE

```mermaid
graph TB
    subgraph EXTERNAL["Rete Esterna"]
        CLIENTI[Clienti Pondus<br/>HTTPS/TLS 1.3]
        DNS[DNS: pondus.tpgroup.it]
    end

    subgraph DMZ["DMZ — Perimetro Fortigate"]
        WAF[WAF Fortigate<br/>Protezione applicativa]
        LB[Load Balancer<br/>HAProxy / NLB]
    end

    subgraph APP["VLAN 50 — Pondus"]
        WEB1[Web Server IIS<br/>Primary]
        WEB2[Web Server IIS<br/>Secondary HA]
    end

    subgraph DB_TIER["VLAN 51 — Database"]
        DB1[MS SQL Server<br/>Primary]
        DB2[MS SQL Server<br/>Secondary<br/>(sincrono)]
    end

    subgraph STORAGE["Storage"]
        NAS_BACKUP[NAS QNAP<br/>Backup DB]
        DR_SITE[Sito DR<br/>Replica asincrona]
    end

    CLIENTI -->|HTTPS| DNS
    DNS -->|443| WAF
    WAF --> LB
    LB --> WEB1
    LB --> WEB2
    WEB1 --> DB1
    WEB2 --> DB1
    DB1 <-->|AlwaysOn| DB2
    DB1 --> NAS_BACKUP
    DB2 --> DR_SITE
```

## Dimensionamento

| Componente | Specifica | Giustificazione |
| --- | --- | --- |
| **Web server IIS (2 VM)** | 4 vCPU, 16 GB RAM, 80 GB SSD | Carico bilanciato, failover HA |
| **DB server MS SQL (2 VM)** | 8 vCPU, 32 GB RAM, 500 GB SSD (dati) + 100 GB SSD (log) | Sempre critico; AlwaysOn Availability Group per HA |
| **Host VMWare** | Nodi esistenti (2 host) | Pondus in VM su VMWare (ammesso: solo HPC vieta VM) |
| **Storage condiviso** | SAN NetApp 24 TB (esistente) | Dati VM + DB su storage SAN |

## Sicurezza

| Aspetto | Soluzione |
| --- | --- |
| **HTTPS** | TLS 1.3 con certificato wildcard *.tpgroup.it |
| **WAF** | Fortigate Web Application Firewall (protezione SQL injection, XSS) |
| **Autenticazione** | AD Samba4 + MFA per amministratori; JWT token per clienti |
| **Cifratura DB** | MS SQL TDE (Transparent Data Encryption) |
| **Backup DB** | Backup completo giornaliero su NAS + log shipping ogni ora |
| **Isolamento** | VLAN 50 (web) e VLAN 51 (db) separate; solo web→db consentito |

## Esposizione clienti

- **URL:** `https://pondus.tpgroup.it`
- **Autenticazione clienti:** JWT (JSON Web Token) con refresh token
- **Rate limiting:** 100 richieste/minuto per IP
- **SLA:** 99.5% uptime (con HA e replica DR)

## Costi licenze e infrastruttura

| Voce | Costo |
| --- | --- |
| Windows Server Standard (2 VM web) | € 1.200 |
| MS SQL Server Standard (2 core edition) | € 3.600 |
| Certificato TLS wildcard | € 200/anno |
| Sistemista migrazione (15 giorni × €500) | € 7.500 |
| **Totale Pondus** | **€ 12.500** |

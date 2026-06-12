# Requisiti ISO/IEC 27001 — TP Group

## Mappatura requisiti di progetto → controlli ISO 27001 → soluzioni

### A. Business continuity — Ridondanza

| Requisito | Controllo ISO 27001 | Soluzione proposta | Sistema coinvolto | Costo stimato |
| --- | --- | --- | --- | --- |
| Ridondanza sistemi strategici | A.17.1.2 — Disponibilità | HA cluster Fortigate FG-100F (2 unità) | Perimetro di rete | € 9.000 |
| Ridondanza sistemi strategici | A.17.1.2 — Disponibilità | Sito DR con replica dati | Pondus, AD, DB | Vedi Backup/DR |
| Ridondanza connettività | A.17.1.3 — Verifica continuità | Doppio provider ISP (TIM + WindTre) | WAN | € 240/mese |

### B. Disaster recovery — Delocalizzazione

| Requisito | Controllo ISO 27001 | Soluzione proposta | Sistema coinvolto | Costo stimato |
| --- | --- | --- | --- | --- |
| Delocalizzazione salvataggi | A.17.1.2 — Disaster recovery | Backup off-site su GCP + NAS locale | Pondus, AD, HPC, file server | Vedi Backup/DR |
| Fruibilità servizi clienti | A.17.1.2 — Continuità servizi | VM replica Pondus su sito DR | Pondus | Vedi Backup/DR |
| RPO target | A.12.3.1 — Backup | RPO 1h (Pondus), 24h (altri) | Tutti | Vedi Backup/DR |
| RTO target | A.17.1.2 — RTO | RTO 4h (Pondus), 24h (altri) | Tutti | Vedi Backup/DR |

### C. Sicurezza accessi — Cifratura

| Requisito | Controllo ISO 27001 | Soluzione proposta | Sistema coinvolto | Costo stimato |
| --- | --- | --- | --- | --- |
| Cifratura sistemi memorizzazione | A.10.1.1 — Controllo crittografico | SAN: Self-Encrypting Drive / LUKS | SAN NetApp | Incluso in HW |
| Cifratura sistemi memorizzazione | A.10.1.1 — Controllo crittografico | AES-256 NAS QNAP | NAS backup | € 0 (nativo) |
| Cifratura sistemi memorizzazione | A.10.1.1 — Controllo crittografico | VMWare encryption at-rest | VM datacenter | € 0 (licenza) |
| Cifratura laptop | A.10.1.1 — Controllo crittografico | BitLocker (Windows) / LUKS (Linux) | 50 laptop | € 0 (nativo) |
| Protocolli sicuri | A.13.2.1 — Scambio informazioni | TLS 1.3, IPsec, SSHv2, WireGuard | Tutti i servizi | € 0 |
| VPN accessi remoti | A.6.2.2 — Lavoro da remoto | IPsec LAN to LAN + WireGuard Client | Remoto, DR, Cloud | Incluso in VPN |

### D. Controlli organizzativi

| Requisito | Controllo ISO 27001 | Soluzione proposta | Costo |
| --- | --- | --- | --- |
| Gestione identità | A.9.2.1 — Registrazione utenti | AD Samba4 + GCDS + Google Workspace SSO | € 4.500 |
| MFA | A.9.4.2 — Autenticazione sicura | FortiToken su VPN + accessi sensibili | € 500 |
| Revisione accessi | A.9.2.5 — Revisione diritti utenti | Audit AD trimestrale | € 0 (interno) |
| Formazione sicurezza | A.7.2.2 — Consapevolezza | Workshop annuale per 50 utenti | € 2.000 |
| Gestione vulnerabilità | A.12.6.1 — Gestione vulnerabilità | Scan trimestrale (es. OpenVAS) | € 0 (open source) |
| Log e monitoraggio | A.12.4.1 — Registrazione eventi | FortiAnalyzer o syslog centralizzato | € 3.000 |

## Riepilogo costi sicurezza

| Voce | Costo |
| --- | --- |
| Fortinet HA + MFA (quota parte sicurezza) | € 5.000 |
| Formazione sicurezza | € 2.000 |
| Log e monitoraggio | € 3.000 |
| Sistemista sicurezza (15 giorni × €500) | € 7.500 |
| **Totale adeguamento ISO 27001** | **€ 17.500** |

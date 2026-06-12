# Politica di Cifratura e Accessi — TP Group

## 1. Cifratura at-rest

| Sistema | Tecnologia | Standard | Stato |
| --- | --- | --- | --- |
| SAN NetApp 24 TB | NetApp Storage Encryption (NSE) | AES-256 | HW nativo |
| NAS QNAP 32 TB | QNAP AES-256 volume encryption | AES-256 | Da attivare |
| Host VMWare + datastore | VM encryption (vSphere) | AES-256 | Da attivare |
| Laptop Windows (40 unità) | BitLocker | AES-256-XTS | Da deployare |
| Laptop Linux (10 unità) | LUKS | AES-256-XTS | Da configurare |
| Cluster HPC — scratch | LUKS su partizione scratch | AES-256-XTS | Da configurare |
| Backup su GCP | Cifratura lato GCP (CSEK) | AES-256 | Già attivo |
| Database Pondus (MS SQL) | Transparent Data Encryption (TDE) | AES-256 | Da attivare |
| Web server IIS | Certificati TLS | RSA 4096 / ECDSA P-384 | Da rinnovare |

## 2. Cifratura in-transit

| Canale | Protocollo | Standard | Note |
| --- | --- | --- | --- |
| VPN LAN to LAN | IPsec IKEv2 | AES-256-GCM | Sede ↔ DR |
| VPN Client to LAN | WireGuard | ChaCha20-Poly1305 | Laptop dipendenti |
| VPN Hybrid Cloud | IPsec IKEv2 | AES-256-GCM | Sede ↔ GCP |
| HTTPS siti interni | TLS 1.3 | AES-256-GCM | Pondus, Media Wiki |
| HTTPS servizi esterni | TLS 1.3 | AES-256-GCM | Esposizione clienti |
| Amministrazione server | SSHv2 | ChaCha20-Poly1305 | Tutti i server Linux |
| RDP | TLS 1.2+ | AES-256 | Server Windows |
| DB remoto | SQL Server TLS | TLS 1.2 | Connessioni DB |

## 3. Gestione identità e accessi (IAM)

| Aspetto | Soluzione |
| --- | --- |
| Identity Provider | AD Samba4 (su VM Linux) |
| MFA | FortiToken mobile app (push OTP) |
| SSO | SAML 2.0 per Google Workspace |
| Sincronizzazione cloud | Google Cloud Directory Sync (GCDS) |
| Password policy | Complessità: 12+ caratteri, maiuscole, numeri, simboli. Scadenza: 90 giorni |
| Accesso VPN | Richiede autenticazione AD + MFA |
| Accesso server | AD + SSH key (Linux) / RDP + AD (Windows) |

## 4. Protocolli consentiti e vietati

| Protocollo | Stato | Note |
| --- | --- | --- |
| TLS 1.3 | ✅ Consentito | Predefinito per HTTPS |
| TLS 1.2 | ✅ Consentito | Solo con cipher suite forti |
| TLS 1.1 | ❌ Vietato | Da disabilitare |
| TLS 1.0 | ❌ Vietato | Da disabilitare |
| SSL 3.0 | ❌ Vietato | Da disabilitare |
| SSHv2 | ✅ Consentito | |
| SSHv1 | ❌ Vietato | |
| IPsec IKEv2 | ✅ Consentito | VPN |
| WireGuard | ✅ Consentito | Client to LAN |
| OpenVPN | ✅ Consentito | Alternativa a WireGuard |
| FTP | ❌ Vietato | Usare SFTP o SCP |
| HTTP (non TLS) | ❌ Vietato | Solo redirect a HTTPS |
| Telnet | ❌ Vietato | Usare SSH |
| SNMP v1/v2 | ❌ Vietato | Usare SNMPv3 |

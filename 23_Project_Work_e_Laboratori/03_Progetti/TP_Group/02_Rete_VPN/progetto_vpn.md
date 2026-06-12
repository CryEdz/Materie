# Progetto VPN TP Group

## 1. VPN LAN to LAN (sede ↔ sito DR)

| Parametro | Valore |
| --- | --- |
| Protocollo | IPsec IKEv2 |
| Cifratura | AES-256-GCM |
| Autenticazione | Pre-shared key + certificati |
| Throughput | 500 Mbps |
| Gateway sede | Fortigate FG-100F |
| Gateway DR | Fortigate/Firewall sito secondario |
| Reti coinvolte | 10.10.0.0/16 ↔ 10.20.0.0/16 |

**Utilizzo:** Repliche database Pondus, backup inter-sede, sincronizzazione AD.

## 2. VPN Client to LAN (accesso remoto dipendenti)

| Parametro | Valore |
| --- | --- |
| Protocollo | WireGuard (consigliato) o OpenVPN |
| Cifratura | ChaCha20 (WireGuard) / AES-256 (OpenVPN) |
| Autenticazione | Chiavi pubbliche + MFA (FortiToken/Google Authenticator) |
| Utenti massimi | 50 dipendenti (+ collaboratori) |
| Gateway | Fortigate FG-100F (VPN server nativo) |
| Client | WireGuard client su laptop aziendali |

**Vantaggi WireGuard:**
- Overhead ridotto, performance elevate
- Configurazione semplice
- Supporto nativo su Linux, Windows, macOS, iOS, Android

**Accesso:** Solo alla VLAN uffici (10.10.10.0/24) e VLAN Pondus (10.10.50.0/24) per i clienti.

## 3. VPN Hybrid Cloud (sede ↔ GCP)

| Parametro | Valore |
| --- | --- |
| Protocollo | IPsec IKEv2 (tunnel VPN GCP) |
| Cifratura | AES-256-GCM |
| Gateway GCP | Cloud VPN Gateway (HA) |
| Gateway sede | Fortigate FG-100F |
| Reti coinvolte | 10.10.0.0/16 ↔ subnet GCP (10.30.0.0/16) |
| Throughput | 1 Gbps |

**Servizi coinvolti:**
- Media Wiki su GCP
- Backup delocalizzato su GCP
- Odoo (SaaS) accessibile via Internet, non via tunnel

## Dimensionamento VPN

| Tipologia | Tunnel simultanei | Throughput stimato | Impatto su Fortigate |
| --- | --- | --- | --- |
| LAN to LAN | 1 | 500 Mbps | Basso |
| Client to LAN | Fino a 25 contemporanei | 200 Mbps aggregati | Medio |
| Hybrid Cloud | 1 | 1 Gbps | Basso |
| **Totale** | **27** | **1,7 Gbps** | **Gestibile da FG-100F** |

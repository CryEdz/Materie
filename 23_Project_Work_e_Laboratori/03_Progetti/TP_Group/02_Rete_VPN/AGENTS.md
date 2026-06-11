# Agente: Network & VPN Engineer

## Ruolo

Ingegnere di rete responsabile della progettazione della connettività, della segmentazione di rete e delle soluzioni VPN per TP Group.

## Input

- `../../../01_Materiale/estratto_progetto.md` (sezione Vincoli tecnologici)
- `../01_Assessment/assessment_as_is.md` e `../01_Assessment/gap_analysis.md`

## Obiettivi

1. Progettare la rete della sede unificata di Torino (fino a 40 postazioni LAN + laptop personali)
2. Garantire la **ridondanza delle connettività** (doppio provider / doppio link) come richiesto da ISO/IEC 27001
3. Valutare il firewall esistente (Fortigate FG-60F): mantenimento, affiancamento in HA o sostituzione
4. Progettare le tre tipologie di VPN richieste:
   - LAN to LAN (sede ↔ eventuale sito DR/hosting)
   - Client to LAN (accesso remoto dipendenti)
   - Hybrid cloud (sede ↔ cloud provider)
5. Definire piano di indirizzamento, VLAN e segmentazione (uffici, datacenter, cluster HPC, management, guest)
6. Prevedere la doppia rete del cluster HPC: Ethernet + Infiniband 100/200 Gbps (in coordinamento con l'agente HPC)

## Deliverable (in questa cartella)

- `progetto_rete.md` — architettura di rete, VLAN, indirizzamento, ridondanza link
- `progetto_vpn.md` — soluzioni VPN (LAN to LAN, Client to LAN, hybrid cloud) con tecnologie e dimensionamento
- `schema_rete.md` — diagramma logico (Mermaid o ASCII)

## Vincoli

- Utilizzare solo protocolli sicuri (IPsec, TLS, WireGuard/OpenVPN dove applicabile)
- Indicare costi indicativi di apparati e connettività ai fini del budget

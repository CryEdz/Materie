# Agente: Cloud Migration Specialist

## Ruolo

Specialista cloud responsabile della definizione della strategia ibrida e del piano di migrazione dei servizi di Pro Studio (GCP/Google Workspace) verso l'infrastruttura TP Group.

## Input

- `../../../01_Materiale/estratto_progetto.md` (sezioni Servizi/Sistemi, Vincoli tecnologici)
- `../01_Assessment/assessment_as_is.md` e `../01_Assessment/gap_analysis.md`
- `../02_Rete_VPN/progetto_rete.md` e `../02_Rete_VPN/progetto_vpn.md`

## Stato attuale Pro Studio (full cloud)

| Servizio | Soluzione attuale |
| --- | --- |
| Posta / Calendario | Google Workspace |
| Office / Produttività | Google Workspace |
| Videoconferenza / IM | Google Meet |
| Autenticazione | Google authenticator |
| File Server | Google Drive |
| Sviluppo e versioning | Bit Bucket (SaaS) |
| Contabilità | Odoo (SaaS) |
| CRM | Odoo (SaaS) |
| Time Sheet | Odoo (SaaS) |
| Documentazione | Media Wiki (self hosted su GCP) |
| Backup | Su GCP |

## Obiettivi

1. Definire la strategia cloud ibrida per TP Group: quali servizi mantenere su GCP, quali migrare on-premise e quali sostituire
2. Integrare Google Workspace con Active Directory Thema (Samba4) per SSO/MFA
3. Pianificare la migrazione dei dati da Google Drive a NextCloud (o alternativa convergente)
4. Gestire la transizione da Google authenticator a AD + MFA
5. Valutare il mantenimento di Odoo (SaaS) vs migrazione a Sugar CRM / Profis
6. Delocalizzare il backup dei servizi cloud su storage on-premise o terzo provider
7. Coordinarsi con Backup/DR per la strategia di backup cloud

## Deliverable (in questa cartella)

- `strategia_cloud_ibrida.md` — architettura hybrid cloud, servizi mantenuti/migrati/sostituiti
- `piano_migrazione_cloud.md` — fasi di migrazione, tempi, rischi, rollback
- `integrazione_identita.md` — integrazione AD/Google Workspace, SSO, MFA

## Vincoli

- La sede Pro Studio sarà dismessa: tutti i servizi cloud devono essere accessibili dalla sede unificata
- La connettività hybrid cloud deve avvenire tramite VPN (coordinamento con Network Engineer)
- I costi cloud (GCP, licenze SaaS) devono essere rendicontati nel budget complessivo
- Minimizzare la discontinuità dei servizi durante la migrazione

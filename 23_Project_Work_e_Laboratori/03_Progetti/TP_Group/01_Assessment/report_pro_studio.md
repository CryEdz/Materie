# Report di Analisi — Pro Studio srl

## Anagrafica

| Campo | Valore |
|---|---|
| **Nome** | Pro Studio srl |
| **Settore** | Progettazione (ambito aerospace) |
| **Fondazione** | 2023 (startup) |
| **Sede** | Condominio uffici in affitto, Torino |
| **Personale** | 20 dipendenti |
| **Infrastruttura IT** | Nessuna on-premise — **100% cloud** |

---

## Infrastruttura IT

### Datacenter
| Componente | Specifica |
|---|---|
| **Tipo** | Nessun datacenter fisico |
| **Virtualizzazione** | Nessuna on-premise |
| **Backup** | Su GCP |
| **Firewall** | N/A (affidato a cloud provider) |
| **Condizionamento/UPS** | N/A (forniti dal condominio uffici) |

### Calcolo Strutturale
| Componente | Specifica |
|---|---|
| **Esecuzione** | Su sistemi dei clienti finali |
| **Infrastruttura interna** | Nessuna |

### Applicazioni e Servizi (tutti in cloud/SaaS)

| Servizio | Soluzione | Tipo |
|---|---|---|
| Posta/Calendario | **Google Workspace** | SaaS |
| Office/Produttività | **Google Workspace** | SaaS |
| Videoconferenza | **Google Meet** | SaaS |
| Autenticazione | **Google Authenticator** | SaaS |
| File Server | **Google Drive** | SaaS |
| Sviluppo & Versioning | **BitBucket** | SaaS |
| Contabilità | **Odoo** | SaaS |
| CRM | **Odoo** | SaaS |
| Time Sheet | **Odoo** | SaaS |
| Documentazione | **MediaWiki** (su GCP) | IaaS/PaaS |
| Backup | **GCP** | IaaS |

---

## Punti di Forza

1. **Infrastruttura 100% cloud** — nessun CAPEX, massima flessibilità, scalabilità immediata
2. **Ecosistema Google Workspace** — integrazione nativa tra posta, calendario, drive, meet, autenticazione
3. **Odoo unificato** — contabilità, CRM, timesheet su unica piattaforma SaaS
4. **Nessun vincolo fisico** — non dipende da datacenter, UPS, condizionamento
5. **Startup agile** — stack tecnologico moderno, nessun debito tecnico legacy
6. **Backup già su cloud** — nessuna modifica necessaria per compliance ISO 27001 (delocalizzazione già soddisfatta)

---

## Punti di Debolezza

1. **Dipendenza totale da cloud provider** — nessun controllo su HW, uptime, performance; lock-in Google
2. **Nessun cluster HPC interno** — subisce i vincoli dei sistemi dei clienti per le simulazioni
3. **Sede in affitto** — contratto da non rinnovare (da trasferire presso Thema)
4. **Autenticazione Google-only** — nessun AD/Azure AD/Okta centralizzato
5. **Versioning su BitBucket SaaS** — dati codice fuori dal controllo diretto
6. **Nessuna ridondanza su provider** — single cloud provider (GCP), single point of failure
7. **Costi operativi ricorrenti** — canoni SaaS mensili si accumulano

---

## Rischi Identificati

| Rischio | Impatto | Probabilità |
|---|---|---|
| Vendor lock-in Google Workspace | Alto | Alta |
| Outage GCP blocca operatività | Alto | Bassa |
| Perdita contrattuale sede (già in chiusura) | Medio | Alta |
| Mancanza AD centralizzato in ottica fusione | Alto | Alta |
| Trasferimento dipendenti impatta produttività | Medio | Media |

---

## Raccomandazioni Preliminari

1. **Pianificare integrazione AD** — unire Google Workspace con Samba4 di Thema per SSO
2. **Valutare migrazione parziale** — alcuni servizi (es. Git, MediaWiki) potrebbero convergere su self-hosted Thema
3. **Preparare piano di delocalizzazione fisica** — trasferimento 20 persone presso sede Thema
4. **Rivedere backup su GCP** — integrare con strategia 3-2-1 complessiva di TP Group
5. **Valutare retention Odoo** — Odoo SaaS è centralizzato ma potrebbe servire integrazione con Profis (Thema)

---

## Prospettiva Fusione — Impatto su Pro Studio

| Area | Cambiamento Atteso |
|---|---|
| Sede | Chiusura ufficio attuale, trasferimento presso Thema (Torino centro) |
| Posta/Calendar | Possibile migrazione da GWS a Zimbra o mantenimento ibrido |
| AD/Auth | Integrazione con Samba4 di Thema |
| File server | GDrive → NextCloud o ibrido |
| Backup | Già su GCP, da allineare a policy ISO 27001 |
| Sviluppo | BitBucket → GiTea o mantenimento SaaS |
| Calcolo HPC | Accesso al cluster Thema (non più clienti finali) |

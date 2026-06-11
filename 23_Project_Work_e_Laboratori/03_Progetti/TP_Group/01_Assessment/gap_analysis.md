# Gap Analysis — TP Group

> **Documento:** Analisi dei servizi duplicati, criticità e raccomandazioni di convergenza TO-BE  
> **A cura di:** Assessment Analyst  
> **Data:** Giugno 2025

---

## 1. Servizi duplicati — raccomandazioni di convergenza

Per ogni coppia di servizi equivalenti viene indicata la scelta TO-BE raccomandata: **mantenere** uno dei due, **migrare** da uno all'altro, o **sostituire** entrambi con una terza soluzione.

| # | Servizio | Thema (AS-IS) | Pro Studio (AS-IS) | Raccomandazione TO-BE | Motivazione |
| --- | --- | --- | --- | --- | --- |
| D1 | **Posta / Calendario** | Zimbra (VM Linux) | Google Workspace | **Migrare** da Zimbra a Google Workspace | Google Workspace è SaaS, richiede zero manutenzione server, già adottato da Pro Studio; riduce VM Linux on-prem liberando risorse rack. Zimbra è autogestito e aggiunge complessità. |
| D2 | **Office / Produttività** | MS365 + LibreOffice | Google Workspace | **Mantenere** entrambi con gradualità verso Google Workspace | MS365 è necessario per compatibilità con clienti automotive (formati .docx/.xlsx avanzati). Google Workspace copre le esigenze base. Si può convergere su Google Workspace con migrazione graduale, mantenendo MS365 in licenza ridotta. |
| D3 | **Videoconferenza / IM** | MS Teams | Google Meet | **Migrare** da MS Teams a Google Meet | Coerenza con l'ecosistema Workspace (posto D1). Meet è incluso in Google Workspace senza costi aggiuntivi. Teams richiederebbe licenze MS365 separate. |
| D4 | **Autenticazione** | AD (Samba4, VM Linux) | Google Authenticator | **Mantenere** AD + integrare con Google Workspace (SSO federato) | AD è il repository centrale delle identità Thema e serve per accesso LAN, servizi on-prem (NextCloud, GiTea, Pondus, ecc.). Google Authenticator è solo 2FA personale, non directory. Si raccomanda di federare Google Workspace con AD per SSO, mantenendo AD come Identity Provider primario. |
| D5 | **File Server** | NextCloud (VM Linux) | Google Drive | **Migrare** da NextCloud a Google Drive | Google Drive è SaaS, elimina una VM Linux on-prem. Drive offre condivisione esterna nativa per clienti. NextCloud richiede backup, aggiornamenti e manutenzione. |
| D6 | **Sviluppo / Versioning** | GiTea (self hosted) | Bit Bucket (SaaS) | **Sostituire** entrambi con GitLab (self hosted o cloud) | GitLab unifica le funzionalità di versioning, CI/CD e project management in un unico prodotto. Bit Bucket ha costi SaaS ricorrenti, GiTea è meno diffuso e con ecosistema ridotto. GitLab offre sia edizione Community (self hosted,免费) sia cloud. Alternativa accettabile: mantenere GiTea e migrare i repo Bit Bucket su GiTea. |
| D7 | **Contabilità** | Profis (on-prem, Windows) | Odoo (SaaS) | **Mantenere** Profis | Profis è consolidato in Thema, integrato con i flussi contabili esistenti. Odoo copre anche CRM e timesheet (vedi D8, D9). Tenere Profis per la sola contabilità evita una migrazione dati contabili complessa. |
| D8 | **CRM** | Sugar CRM (self hosted) | Odoo (SaaS) | **Sostituire** Sugar CRM con Odoo | Odoo ha funzionalità CRM moderne, è già in uso da Pro Studio, ed è SaaS (zero manutenzione). Sugar CRM su VM Linux è un ulteriore carico sul data center. |
| D9 | **Timesheet** | Kimai (self hosted) | Odoo (SaaS) | **Sostituire** Kimai con Odoo | Odoo include già il modulo timesheet, integrandosi con contabilità e CRM. Kimai su VM Linux è ridondante e va rimosso. |
| D10 | **Documentazione** | Media Wiki (on-prem) | Media Wiki (GCP) | **Migrare** entrambe in una singra istanza Media Wiki su GCP (o on-prem) | Stesso prodotto, due istanze separate. Unificarle elimina la duplicazione. Posizionare l'istanza convergente su GCP (cloud) per ridurre il carico on-prem e garantire accesso esterno. In alternativa, mantenerla on-prem con replica DR su cloud. |

### Riepilogo delle azioni per servizio

| Azione | Servizi coinvolti |
| --- | --- |
| **Mantenere** | AD (D4), Profis (D7) |
| **Migrare** | Zimbra → Google Workspace (D1), MS Teams → Google Meet (D3), NextCloud → Google Drive (D5), Media Wiki duale → singola (D10) |
| **Sostituire** | GiTea + Bit Bucket → GitLab (D6), Sugar CRM → Odoo (D8), Kimai → Odoo (D9) |
| **Mantenere entrambi** | MS365 + Google Workspace (D2) — convergenza graduale |

---

## 2. Analisi criticità e raccomandazioni

### C1 — Data center saturo (2 rack)

| Impatto | **Alto** |
| --- | --- |
| **Descrizione** | I due rack 19" del data center Thema sono completamente occupati. Non è possibile aggiungere nuove unità senza rimuovere HW esistente. |
| **Conseguenze** | Impossibile installare gli 8 nuovi nodi HPC, nuovo storage o server aggiuntivi senza un intervento di razionalizzazione. |
| **Raccomandazione** | Ridurre il footprint on-prem migrando servizi candidati al cloud (posta, file server, documentazione, CRM, timesheet — vedi sezione 1). Valutare hosting esterno (co-location) per il cluster HPC o parte di esso. |

### C2 — UPS con autonomia 10'

| Impatto | **Alto** |
| --- | --- |
| **Descrizione** | L'UPS attuale garantisce solo 10 minuti di autonomia, insufficienti per uno shutdown ordinato di tutti i sistemi in caso di blackout prolungato. |
| **Conseguenze** | Rischio di corruzione dati su sistemi non protetti da shutdown programmato (SAN, NAS, DB Pondus). Non conforme ai requisiti ISO 27001 di business continuity. |
| **Raccomandazione** | Potenziare l'UPS (o affiancarne un secondo) per garantire almeno 30' di autonomia, oppure integrare con un gruppo elettrogeno. |

### C3 — Condizionamento al limite

| Impatto | **Alto** |
| --- | --- |
| **Descrizione** | L'impianto di condizionamento del data center opera già al limite della capacità per il carico termico attuale. Ogni incremento di HW (es. nuovi nodi HPC, storage aggiuntivo) rischia di superare la soglia. |
| **Conseguenze** | Surriscaldamento dei rack, throttling delle CPU, riduzione della vita utile dei componenti, possibili downtime. |
| **Raccomandazione** | Valutare co-location per il cluster HPC espanso, oppure installare condizionamento di precisione dedicato (se lo spazio e la struttura lo consentono). In alternativa: ridurre il carico termico spostando servizi in cloud (vedi sezione 1). |

### C4 — Sede Pro Studio da dismettere

| Impatto | **Alto** |
| --- | --- |
| **Descrizione** | Il contratto di locazione di Pro Studio non sarà rinnovato: i 20 dipendenti vanno trasferiti presso la sede Thema (capienza max 40 postazioni). |
| **Conseguenze** | Riorganizzazione logistica degli spazi, connettività LAN/WiFi aggiuntiva, predisposizione postazioni. Tutti i servizi cloud Pro Studio devono rimanere accessibili dalla nuova sede. |
| **Raccomandazione** | Verificare che la LAN Thema supporti 40 postazioni contemporanee. Adeguare WiFi e switch se necessario. I servizi cloud (Google Workspace, Odoo, Bit Bucket) non richiedono modifiche. |

### C5 — Due domini di autenticazione

| Impatto | **Medio** |
| --- | --- |
| **Descrizione** | Thema utilizza AD su Samba4, Pro Studio utilizza Google Workspace con autenticazione Google. Ogni utente ha due credenziali distinte. |
| **Conseguenze** | Doppia gestione utenti, difficoltà di audit, rischio di credential sprawl. |
| **Raccomandazione** | Federare Google Workspace con AD tramite SAML 2.0 / LDAP. AD rimane l'Identity Provider primario; Google Workspace eredita utenti e password. Per i soli utenti Pro Studio senza account AD, creare identità in AD. |

### C6 — Backup senza delocalizzazione

| Impatto | **Medio** |
| --- | --- |
| **Descrizione** | Thema esegue backup solo su NAS QNAP on-premise. Nessuna copia fuori sede. La norma ISO 27001 richiede delocalizzazione dei salvataggi. |
| **Conseguenze** | Non conformità ISO 27001. In caso di disastro fisico (incendio, allagamento) i dati andrebbero persi. |
| **Raccomandazione** | Attivare backup su cloud (GCP o Azure) come copia off-site, oppure replicare il NAS QNAP in un secondo sito. |

### C7 — Nessuna ridondanza connettività

| Impatto | **Medio** |
| --- | --- |
| **Descrizione** | Singolo firewall Fortigate FG-60F e singolo collegamento WAN. Senza failover, un guasto alla connettività blocca l'accesso esterno a tutti i servizi (posta, Pondus, VPN). |
| **Conseguenze** | Interruzione dei servizi verso clienti (Pondus) e blocco del lavoro da remoto. Non conformità ISO 27001. |
| **Raccomandazione** | Valutare secondo collegamento WAN (4G/5G backup o secondo operatore) e firewall in alta affidabilità (active/passive). |

### C8 — Piattaforme office eterogenee

| Impatto | **Basso** |
| --- | --- |
| **Descrizione** | Thema usa MS365 + LibreOffice, Pro Studio usa Google Workspace. Possibili incompatibilità di formati tra docenti delle due aziende. |
| **Conseguenze** | Rielaborazione documenti, perdita di formattazione. |
| **Raccomandazione** | Convergere gradualmente su Google Workspace (vedi D2). Mantenere MS365 in licenza ridotta per i soli casi di compatibilità con clienti esterni. |

### C9 — Assenza di MFA strutturato

| Impatto | **Medio** |
| --- | --- |
| **Descrizione** | Thema non ha 2FA; Pro Studio usa solo Google Authenticator su Workspace. Nessuna protezione MFA per accesso VPN, AD, servizi on-prem. |
| **Conseguenze** | Rischio di accesso non autorizzato in caso di furto/compromissione credenziali. Non conformità ISO 27001. |
| **Raccomandazione** | Implementare MFA centralizzato (es. AD + Microsoft Authenticator / Google Authenticator tramite RADIUS o SAML) per VPN, accesso remoto e servizi critici (Pondus, AD, posta). |

### C10 — Versioning non unificato

| Impatto | **Basso** |
| --- | --- |
| **Descrizione** | Thema usa GiTea (self hosted), Pro Studio usa Bit Bucket (SaaS). Repository separati, nessuna visibilità incrociata. |
| **Conseguenze** | Doppia amministrazione, possibile fork involontario del codice. |
| **Raccomandazione** | Unificare su un'unica piattaforma Git (GitLab self hosted o cloud, vedi D6). Effettuare migrazione一次性 dei repo esistenti. |

---

## 3. Matrice dei rischi — impatto vs probabilità

| Criticità | Impatto | Probabilità | Priorità |
| --- | --- | --- | --- |
| C1 — Datacenter saturo | Alto | Alta | **Critica** |
| C2 — UPS 10' | Alto | Media | **Alta** |
| C3 — Condizionamento al limite | Alto | Media | **Alta** |
| C4 — Sede Pro Studio da dismettere | Alto | Alta | **Critica** |
| C5 — Due domini autenticazione | Medio | Alta | **Media** |
| C6 — Backup non delocalizzato | Medio | Media | **Media** |
| C7 — Nessuna ridondanza connettività | Medio | Media | **Media** |
| C8 — Office eterogenei | Basso | Alta | **Bassa** |
| C9 — Assenza MFA strutturato | Medio | Media | **Media** |
| C10 — Versioning non unificato | Basso | Bassa | **Bassa** |

---

## 4. Roadmap di convergenza suggerita (fasi)

Non vengono forniti dettagli implementativi (compito degli agenti a valle), ma si indica l'ordine logico delle attività:

| Fase | Priorità | Servizi coinvolti | Criticità correlate |
| --- | --- | --- | --- |
| **1. Riduzione carico on-prem** | Urgente | Migrare posta, file server, documentazione, CRM, timesheet in cloud | C1 (saturo), C3 (condizionamento) |
| **2. Unificazione autenticazione** | Alta | Federare Google Workspace con AD | C5, C9 |
| **3. Ridondanza connettività e UPS** | Alta | Secondo link WAN, potenziamento UPS, MFA | C2, C7, C9 |
| **4. Delocalizzazione backup** | Media | Backup su cloud/secondo sito | C6 |
| **5. Convergenza office graduale** | Media | MS365 + Google Workspace → Google Workspace | C8 |
| **6. Unificazione versioning** | Bassa | GiTea/Bit Bucket → GitLab | C10 |
| **7. Trasferimento sede Pro Studio** | Da calendarizzare | Logistica e postazioni sede Thema | C4 |

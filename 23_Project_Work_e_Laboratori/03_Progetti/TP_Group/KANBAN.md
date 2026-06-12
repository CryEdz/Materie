# Personal Kanban — TP Group

## 🧱 BACKLOG (Idee / Da approfondire)

| Carta | Priorità | Note |
|---|---|---|
| Valutare upgrade Firewall Fortigate FG-60F | Media | Potrebbe non bastare per 50 persone + VPN |
| Definire subnetting IP completo | Alta | Propedeutico a VPN e VLAN |
| Scegliere 2° ISP per ridondanza connettività | Alta | Business continuity |
| Valutare hosting vs on-premise per Pondus | Media | Impatto su scalabilità |
| Definire piano di test funzionali per ogni area | Media | Requisito offerta |

---

## 📋 TODO (Da fare)

| # | Area | Carta | Dettaglio | Stakeholder |
|---|---|---|---|---|
| 1 | **Rete/VPN** | Progettare connettività sede unificata | LAN + VPN LAN-to-LAN, Client-to-LAN, Hybrid cloud | Thema → TP Group |
| 2 | **Sicurezza** | Stesura policy di sicurezza (ISO 27001) | Gap analysis, crittografia, protocolli sicuri | Tutti |
| 3 | **Sicurezza** | Piano di disaster recovery | RPO/RTO, delocalizzazione backup | Thema + Pro Studio |
| 4 | **Cloud** | Integrazione Google Workspace + AD Samba4 | SSO, identità unificata | Pro Studio |
| 5 | **Cloud** | Inventario servizi cloud Pro Studio da migrare | GCP, Odoo, BitBucket, MediaWiki | Pro Studio |
| 6 | **HPC** | Specifica tecnica nuovi 8 nodi | 2 CPU ≥24 core, 8GB RAM/core, Infiniband 100/200G | Thema |
| 7 | **Pondus** | Requisiti funzionali nuova versione | Utenza ampliata, nuove feature | Thema |
| 8 | **Backup** | Soluzione backup off-site / cloud | 3-2-1 rule, NAS QNAP + GCP | Thema + Pro Studio |
| 9 | **Logistica** | Piano trasloco dipendenti Pro Studio | Postazioni LAN, banchi, tempistiche | Pro Studio → Thema |
| 10 | **Offerta** | Redigere presentazione azienda proponente | Team, servizi, storicità | — |

---

## 🔧 IN PROGRESS (In corso)

| # | Area | Carta | Assegnatario | Stato |
|---|---|---|---|---|
| 1 | **Architettura** | Assessment infrastrutturale convergente | Arch. Infrastrutturale | 70% |
| 2 | **Project Mgmt** | Project charter + WBS + Gantt preliminare | PM | 40% |
| 3 | **Offerta** | Bozza documento offerta (struttura + indice) | Team | 30% |

---

## ✅ DONE (Completato)

| # | Carta | Note |
|---|---|---|
| 1 | Analisi documento estratto_progetto | Scenario compreso, requisiti estratti |
| 2 | Creazione repository progetto (struttura cartelle) | 9 aree identificate |

---

## 📊 Riepilogo carichi di lavoro

| Area | Backlog | Todo | In Progress | Done |
|---|---|---|---|---|
| 🌐 Rete / VPN | 2 | 1 | — | — |
| 🔒 Sicurezza ISO 27001 | — | 2 | — | — |
| 🖥️ Cluster HPC | — | 1 | — | — |
| 📱 App Pondus | 1 | 1 | — | — |
| ☁️ Cloud Migration | — | 2 | — | — |
| 💾 Backup / DR | — | 1 | — | — |
| 📄 Offerta documenti | — | 1 | 1 | — |
| 📋 Project Management | — | — | 1 | — |
| 🏗️ Architettura / Assessment | — | — | 1 | — |
| 🚚 Logistica | — | 1 | — | — |

---

> **Legenda priorità:** 🔴 Alta | 🟡 Media | 🟢 Bassa
>
> Creato il: 12/06/2026 — Revisionalo settimanalmente.

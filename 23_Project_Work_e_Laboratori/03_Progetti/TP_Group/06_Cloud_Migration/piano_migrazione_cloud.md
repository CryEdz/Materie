# Piano di Migrazione Cloud TP Group

## Fasi

### Fase 1 — Preparazione (Settimane 1-2)
- [ ] Configurare tunnel VPN IPsec sede ↔ GCP
- [ ] Installare e configurare Google Cloud Directory Sync (GCDS)
- [ ] Testare SSO SAML tra AD e Google Workspace
- [ ] Verificare connettività tra tutti i servizi

### Fase 2 — Identità e autenticazione (Settimane 2-3)
- [ ] Sincronizzare utenti AD → Google Workspace
- [ ] Abilitare MFA per VPN (FortiToken)
- [ ] Configurare SAML SSO per Workspace
- [ ] Formazione utenti su nuovo metodo di autenticazione

### Fase 3 — Migrazione documentazione (Settimane 3-4)
- [ ] Esportare Media Wiki da GCP
- [ ] Importare Media Wiki su VM on-premise
- [ ] Re-indirizzare DNS a Media Wiki on-premise
- [ ] Verificare contenuti e permessi

### Fase 4 — Migrazione file (Settimane 4-6)
- [ ] Trasferire dati da Google Drive a NextCloud
- [ ] Strumento: rclone su VPN IPsec
- [ ] Comunicare agli utenti la nuova posizione dei file
- [ ] Periodo di coesistenza (30 giorni) prima di disabilitare Drive

### Fase 5 — Versioning (Settimana 5)
- [ ] Configurare GiTea come repository unico
- [ ] Migrare repository da Bit Bucket a GiTea
- [ ] Aggiornare URL remoti nei progetti attivi
- [ ] Disdire abbonamento Bit Bucket

### Fase 6 — CRM e Time Sheet (Settimane 5-6)
- [ ] Esportare dati da Sugar CRM
- [ ] Importare in Odoo
- [ ] Esportare dati da Kimai
- [ ] Importare in Odoo (modulo timesheet)
- [ ] Formazione utenti su Odoo
- [ ] Dismettere Sugar CRM e Kimai

### Fase 7 — Finalizzazione (Settimane 6-8)
- [ ] Disattivare Google authenticator
- [ ] Verificare che tutti i servizi siano accessibili dalla sede unificata
- [ ] Test di disaster recovery su backup delocalizzato
- [ ] Documentazione finale e handover

## Rischi e rollback

| Rischio | Probabilità | Impatto | Contromisura | Rollback |
| --- | --- | --- | --- | --- |
| SSO non funzionante durante migrazione | Media | Alto | Mantenere autenticazione locale parallela | Ripristinare login diretto Workspace |
| Perdita dati durante trasferimento Drive→NextCloud | Bassa | Alto | Backup completo pre-migrazione | Ripristinare da backup |
| Downtime Media Wiki | Media | Basso | Wiki non critica, tolleranza ore | Puntare DNS a VM GCP originale |
| Odoo non compatibile con dati Sugar CRM | Media | Medio | Mappatura campi preliminare | Mantenere Sugar CRM in sola lettura |

## Costi migrazione

| Voce | Costo |
| --- | --- |
| Sistemista (20 giorni × €500) | € 10.000 |
| GCDS (gratuito) | € 0 |
| Traffico VPN GCP (stimato) | € 500 |
| **Totale migrazione cloud** | **€ 10.500** |

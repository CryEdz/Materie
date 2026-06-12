# Piano Migrazione Pondus

## Strategia

Migrazione da HW fisico dedicato a VM su infrastruttura VMWare esistente, con separazione dei layer web e database e introduzione di alta affidabilità.

## Fasi

### Fase 0 — Preparazione (Settimane 1-2)
- [ ] Verificare requisiti hardware VMWare (risorse necessarie per 4 VM)
- [ ] Installare Windows Server su VM web (2 istanze)
- [ ] Installare MS SQL Server su VM db (2 istanze)
- [ ] Configurare AlwaysOn Availability Group tra i due DB server
- [ ] Testare connettività tra layer

### Fase 1 — Migrazione database (Settimana 3)
- [ ] Eseguire backup completo del DB Pondus dal server fisico
- [ ] Ripristinare DB su VM SQL Primary
- [ ] Configurare replica sincrona su VM SQL Secondary
- [ ] Verificare integrità dati (confronto row count, checksum)
- [ ] Attivare TDE sul DB

**Rollback:** Mantenere server fisico acceso in sola lettura per 7 giorni.

### Fase 2 — Migrazione applicazione (Settimana 3)
- [ ] Deployare il sito web IIS su VM Web Primary
- [ ] Configurare load balancer (HAProxy o NLB)
- [ ] Eseguire test funzionali completi
- [ ] Puntare DNS pondus.tpgroup.it al load balancer
- [ ] Verificare accesso clienti HTTPS

**Rollback:** Puntare DNS all'IP del server fisico originale.

### Fase 3 — Alta affidabilità (Settimana 4)
- [ ] Deployare il sito web su VM Web Secondary
- [ ] Verificare failover automatico web (NLB)
- [ ] Verificare failover DB (AlwaysOn)
- [ ] Testare scenario: fermata VM Primary → servizio continua su Secondary

### Fase 4 — Dismissione (Settimana 4)
- [ ] Verificare che nessun servizio punti ancora al server fisico
- [ ] Spostare il server fisico in cold storage per 30 giorni
- [ ] Dopo 30 giorni: riformattare o riallocare HW

## Test di accettazione

| Test | Criterio di successo |
| --- | --- |
| Caricamento pagina web | < 2 secondi |
| Login cliente | < 3 secondi |
| Query DB complessa | < 5 secondi |
| Failover web (stop IIS primario) | Downtime < 30 secondi |
| Failover DB (stop SQL primario) | Downtime < 60 secondi |
| Backup DB (completo) | Completato entro 30 minuti |
| HTTPS con TLS 1.3 | Nessun errore certificate |

## Durata e costi migrazione

| Voce | Valore |
| --- | --- |
| Durata totale | 4 settimane |
| Sistemista (20 giorni × €500) | € 10.000 |
| Downtime massimo previsto | 2 ore (Fase 2) |

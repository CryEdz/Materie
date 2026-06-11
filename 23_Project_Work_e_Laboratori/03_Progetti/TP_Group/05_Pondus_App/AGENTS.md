# Agente: Application Architect (Pondus)

## Ruolo

Architetto applicativo responsabile del potenziamento dell'applicazione proprietaria **Pondus** e della sua distribuzione a un'utenza più ampia.

## Input

- `../../../01_Materiale/estratto_progetto.md` (sezioni Servizi/Sistemi e Obiettivi per il futuro)
- `../01_Assessment/assessment_as_is.md`
- `../03_Sicurezza_ISO27001/` (requisiti di sicurezza e cifratura)

## Stato attuale

- Web application in C#: Web server (MS IIS) + DB server (MS SQL)
- Hardware fisico dedicato: 1 CPU Xeon Silver 4110, 64 GB RAM, 1,2 TB HDD
- Servizio erogato dal 2015 a una cerchia ristretta di clienti (ottimizzazione pesi materiali, automotive sportivo e aerospace)

## Obiettivi

1. Progettare l'architettura TO-BE per scalare il servizio a un'utenza più ampia:
   - migrazione da HW fisico a VM/container o cloud (qui VM e container SONO ammessi, il divieto vale solo per il cluster HPC)
   - separazione e ridondanza dei layer web e database
   - alta affidabilità e fruibilità in ottica disaster recovery (requisito ISO: "fruibilità dei servizi dedicati ai clienti")
2. Garantire accesso sicuro ai clienti esterni (HTTPS, WAF, autenticazione)
3. Definire il dimensionamento (CPU, RAM, storage) e la strategia di licensing Windows/SQL Server, valutando alternative
4. Coordinarsi con Backup/DR per RPO/RTO del servizio

## Deliverable (in questa cartella)

- `architettura_pondus.md` — architettura TO-BE, dimensionamento, sicurezza, esposizione clienti
- `piano_migrazione_pondus.md` — fasi di migrazione dal server fisico, test, rollback

## Vincoli

- Il servizio è strategico e rivolto a clienti: minimizzare il downtime di migrazione
- Indicare costi (licenze, risorse cloud/HW) ai fini del budget

# Piano di Disaster Recovery — TP Group

## Scenario di disastro

Il presente piano copre i seguenti scenari:

| Scenario | Esempio | Attivazione |
| --- | --- | --- |
| **Danno limitato** | Rottura NAS, guasto switch, blocco VM | Il responsabile sistema attiva il recovery locale |
| **Danno grave** | Incendio/Allagamento sede, furto server | Il PM attiva il DR formale |
| **Disastro completo** | Distruzione sede, attacco ransomware | Il PM + Direzione attivano DR su sito secondario |

## Attivazione DR

1. **Rilevamento:** Alert monitoring (Nagios/Zabbix) o segnalazione utente
2. **Valutazione:** Il sistemista di turno valuta l'impatto entro 15 minuti
3. **Decisione:** PM decide se attivare DR formale
4. **Comunicazione:** Email a tutti i dipendenti + clienti interessati
5. **Esecuzione:** Seguire le procedure per sistema (vedi `procedure_restore.md`)

## Matrice escalation

| Ruolo | Contatto | Supplenza |
| --- | --- | --- |
| Sistemista | Da definire | Sistemista backup |
| PM | Da definire | Direttore tecnico |
| Security Officer | Da definire | PM |
| Cliente Pondus | Da definire | Account manager |

## Priorità ripristino

1. **Pondus** (servizio clienti, RTO 4h)
2. **AD Samba4** (autenticazione, RTO 4h)
3. **Firewall + VPN** (connettività, RTO 4h)
4. **File server NextCloud** (RTO 8h)
5. **Posta Google Workspace** (RTO 24h — servizio cloud)
6. **Sistemi interni** (CRM, TS, contabilità, RTO 24h)
7. **Cluster HPC** (RTO 48h)
8. **Servizi minori** (Media Wiki, GiTea, RTO 72h)

## Sito di disaster recovery

| Opzione | Descrizione | Costo stimato/mese |
| --- | --- | --- |
| **A — Co-location hosting** | Rack presso provider italiano (es. Aruba/Seeweb), VM replica Pondus + AD + backup | € 800 |
| **B — Cloud DR (GCP)** | VM replica su GCP tramite VPN, solo Pondus + AD | € 600 |
| **C — Sede secondaria** | Ufficio secondario con piccola infrastruttura | € 1.500 |

**Raccomandazione:** **Opzione B — Cloud DR su GCP** (costo inferiore, integrazione con backup già su GCP, VPN già configurata).

## Test DR

| Tipologia | Frequenza | Descrizione |
| --- | --- | --- |
| Test di ripristino singolo sistema | Mensile | Ripristinare una VM da backup su ambiente isolato |
| Test di failover Pondus | Trimestrale | Attivare VM replica su GCP e verificare accesso clienti |
| Test DR completo | Annuale | Simulare disastro sede: attivare DR su GCP, misurare RTO effettivo |

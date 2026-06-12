# Procedure di Restore — TP Group

## 1. Restore Pondus (VM web + DB)

### Scenario: Corruzione database
```bash
# 1. Fermare servizio web IIS
Stop-Service -Name W3SVC

# 2. Ripristinare DB da backup orario su NAS
# Usando SQL Server Management Studio:
#   Tasks → Restore → Database
#   Selezionare backup più recente < 1 ora
#   Opzioni: Overwrite existing database

# 3. Avviare servizio web
Start-Service -Name W3SVC

# 4. Verificare integrità
SELECT COUNT(*) FROM clienti;
SELECT TOP 10 * FROM ordini ORDER BY data_ins DESC;
```

**Tempo stimato:** 15-30 minuti (DB < 100 GB)

### Scenario: VM web corrotta
```bash
# 1. Attivare VM Web Secondary (se non già attiva)
# 2. Puntare DNS al load balancer
# 3. Verificare funzionamento
```

**Tempo stimato:** < 5 minuti (failover automatico)

## 2. Restore AD Samba4

### Scenario: VM AD corrotta
```bash
# 1. Spegnere VM AD problematica
# 2. Creare nuova VM con template Samba4
# 3. Ripristinare backup più recente da NAS:
#    sudo tar -xzf /backup/ad/samba4_backup_$(date +%Y%m%d).tar.gz -C /
# 4. Avviare servizi:
#    sudo systemctl start samba-ad-dc
# 5. Verificare:
#    sudo samba-tool domain info 10.10.20.10
```

**Tempo stimato:** 1-2 ore

## 3. Restore file server NextCloud

### Scenario: Dati persi
```bash
# 1. Fermare servizio NextCloud
# 2. Ripristinare directory data/ dal backup NAS:
#    rsync -av /backup/nextcloud/data/ /var/www/nextcloud/data/
# 3. Ripristinare database NextCloud:
#    mysql -u nextcloud -p nextcloud < /backup/nextcloud/nextcloud_db.sql
# 4. Avviare servizio
# 5. Verificare:
#    sudo -u www-data php occ files:scan --all
```

**Tempo stimato:** 1-3 ore (dipende da volume dati)

## 4. Restore configurazione Fortigate

### Scenario: Firewall da ricostruire
```bash
# 1. Accedere a Fortigate via console seriale
# 2. Caricare backup configurazione:
#    execute restore config tftp config_backup.conf <tftp_server>
# 3. Riavviare:
#    execute reboot
```

**Tempo stimato:** 15 minuti

## 5. Restore completo da DR (sito GCP)

### Scenario: Sede Torino non operativa
```bash
# 1. Attivare VPN da GCP a clienti autorizzati
# 2. Avviare VM replica su GCP (Pondus, AD)
# 3. Puntare DNS a IP GCP (TTL basso, 60 secondi)
# 4. Comunicare ai clienti l'URL temporaneo se necessario
# 5. Verificare servizi essenziali:
#    - Pondus: https://pondus.tpgroup.it/
#    - Posta: Google Workspace (cloud nativo)
#    - File: Google Drive (fino a ripristino sede)
```

**Tempo stimato:** 2-4 ore

## 6. Verifica post-restore (checklist)

- [ ] Pondus accessibile e funzionante (login + query)
- [ ] AD risponde alle richieste LDAP
- [ ] Firewall/VPN operativi
- [ ] File server accessibile con permessi corretti
- [ ] Email funzionante (Google Workspace)
- [ ] Snapshot/backup del nuovo stato eseguiti
- [ ] Eventuali discrepanze documentate

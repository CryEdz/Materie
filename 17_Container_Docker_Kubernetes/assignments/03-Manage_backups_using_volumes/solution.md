# Manage Backups Using Volumes - Soluzione

## Task 1) Persistere i dati MySQL in un volume

Crea il volume:

```powershell
docker volume create db-vol
```

Avvia MySQL montando il volume su `/var/lib/mysql` (dove MySQL salva i dati):

```powershell
docker run `
    --name mysql-container `
    --mount source=db-vol,target=/var/lib/mysql `
    -e MYSQL_ROOT_PASSWORD=mypass `
    -d `
    mysql:latest
```

Ora tutti i dati di MySQL sono persistenti nel volume `db-vol`.

## Task 2) Backup dei dati usando un container helper

Usa un container `busybox` che monta lo stesso volume (in sola lettura) e lo comprime in un archivio salvato sull'host tramite bind mount:

```powershell
docker run `
    --rm `
    --name mysql-backupper `
    --mount source=db-vol,target=/var/lib/mysql,readonly `
    --mount type=bind,source="$(pwd)",target=/backups `
    busybox:latest `
    tar czvf /backups/mysql_datafiles.tar.gz /var/lib/mysql
```

Spiegazione:
- `--rm` elimina il container dopo l'esecuzione
- `db-vol` montato in **readonly** per non alterare i dati
- la directory corrente (`$(pwd)`) è montata come bind mount su `/backups`
- `tar czvf` crea l'archivio compresso dentro `/backups`, che corrisponde alla tua cartella locale

### Verifica

```powershell
# Lista il file creato
ls -l mysql_datafiles.tar.gz

# Guarda i contenuti dell'archivio
tar -tzf mysql_datafiles.tar.gz
```

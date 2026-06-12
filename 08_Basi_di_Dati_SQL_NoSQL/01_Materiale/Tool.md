# SQL & NoSQL Tools — Guida Essenziale

Elenco completo dei tool e comandi più utilizzati per database SQL e NoSQL, organizzati per categoria. Ogni tool include descrizione, comando principale, esempio d'uso e note.

---

## Indice

1. [SQL — Interrogazione Dati (DQL)](#1-sql--interrogazione-dati-dql)
2. [SQL — Manipolazione Dati (DML)](#2-sql--manipolazione-dati-dml)
3. [SQL — Definizione Dati (DDL)](#3-sql--definizione-dati-ddl)
4. [SQL — Controllo Dati (DCL)](#4-sql--controllo-dati-dcl)
5. [MySQL / MariaDB](#5-mysql--mariadb)
6. [PostgreSQL](#6-postgresql)
7. [SQLite](#7-sqlite)
8. [Microsoft SQL Server](#8-microsoft-sql-server)
9. [MongoDB](#9-mongodb)
10. [Redis](#10-redis)
11. [Strumenti di Modellazione e Amministrazione](#11-strumenti-di-modellazione-e-amministrazione)
12. [Strumenti Ausiliari](#12-strumenti-ausiliari)

---

## 1. SQL — Interrogazione Dati (DQL)

### `SELECT`
**Recupera righe da una o più tabelle.**

- **Sintassi:** `SELECT [colonne | *] FROM tabella [condizioni]`
- **Esempio:** `SELECT nome, cognome FROM clienti WHERE città = 'Roma' ORDER BY cognome`
- **Note:** `SELECT DISTINCT` per valori unici, `SELECT TOP n` / `LIMIT` per limitare

### `JOIN`
**Combina righe da due o più tabelle basandosi su una condizione.**

- **Tipi:** `INNER JOIN`, `LEFT JOIN`, `RIGHT JOIN`, `FULL OUTER JOIN`, `CROSS JOIN`
- **Esempio:**
  ```sql
  SELECT o.id, c.nome
  FROM ordini o
  INNER JOIN clienti c ON o.cliente_id = c.id
  ```
- **Note:** `NATURAL JOIN` unisce su colonne con stesso nome

### `WHERE`
**Filtra righe basandosi su condizioni booleane.**

- **Operatori:** `=`, `<>`, `>`, `<`, `LIKE`, `IN`, `BETWEEN`, `IS NULL`
- **Esempio:** `SELECT * FROM prodotti WHERE prezzo BETWEEN 10 AND 50 AND categoria IN ('Elettronica', 'Informatica')`

### `GROUP BY` / `HAVING`
**Raggruppa righe per colonne e applica funzioni di aggregazione.**

- **Funzioni:** `COUNT()`, `SUM()`, `AVG()`, `MIN()`, `MAX()`
- **Esempio:** `SELECT categoria, COUNT(*) AS totale FROM prodotti GROUP BY categoria HAVING COUNT(*) > 5`

### `ORDER BY`
**Ordina i risultati per una o più colonne.**

- **Esempio:** `SELECT * FROM impiegati ORDER BY cognome ASC, nome DESC`
- **Direzioni:** `ASC` (default), `DESC`

### `UNION`
**Combina i risultati di due o più query SELECT rimuovendo duplicati.**

- **Esempio:** `SELECT città FROM clienti UNION SELECT città FROM fornitori`
- **Note:** `UNION ALL` mantiene i duplicati

### `Subquery`
**Query annidata all'interno di un'altra query.**

- **Esempio:**
  ```sql
  SELECT nome FROM clienti
  WHERE id IN (SELECT cliente_id FROM ordini WHERE totale > 1000)
  ```
- **Note:** Può essere correlata (riferimento alla query esterna) o non correlata

### `WITH` (CTE)
**Common Table Expression — query temporanea nominata.**

- **Esempio:**
  ```sql
  WITH ordini_2024 AS (
    SELECT * FROM ordini WHERE YEAR(data) = 2024
  )
  SELECT cliente_id, COUNT(*) FROM ordini_2024 GROUP BY cliente_id
  ```

### `EXISTS`
**Verifica l'esistenza di righe in una subquery.**

- **Esempio:** `SELECT * FROM clienti c WHERE EXISTS (SELECT 1 FROM ordini o WHERE o.cliente_id = c.id)`

---

## 2. SQL — Manipolazione Dati (DML)

### `INSERT`
**Inserisce nuove righe in una tabella.**

- **Esempio:** `INSERT INTO clienti (nome, cognome, email) VALUES ('Mario', 'Rossi', 'mario@example.com')`
- **Esempio:** `INSERT INTO log SELECT * FROM log_backup WHERE data < '2024-01-01'`

### `UPDATE`
**Modifica i dati esistenti in una tabella.**

- **Esempio:** `UPDATE prodotti SET prezzo = prezzo * 1.1 WHERE categoria = 'Elettronica'`
- **Note:** Usare sempre `WHERE` per evitare aggiornamenti massivi involontari

### `DELETE`
**Rimuove righe da una tabella.**

- **Esempio:** `DELETE FROM log WHERE data < DATEADD(year, -1, GETDATE())`
- **Note:** `TRUNCATE TABLE` rimuove tutte le righe più velocemente (senza log riga per riga)

### `MERGE` (Upsert)
**Inserisce o aggiorna basandosi su una condizione di matching.**

- **Sintassi (SQL Server, PostgreSQL):**
  ```sql
  MERGE INTO target AS t
  USING source AS s ON t.id = s.id
  WHEN MATCHED THEN UPDATE SET t.nome = s.nome
  WHEN NOT MATCHED THEN INSERT (id, nome) VALUES (s.id, s.nome)
  ```

### `REPLACE` (MySQL)
**Equivalente di INSERT ma cancella la riga esistente se c'è conflitto su chiave primaria/unica.**

- **Esempio:** `REPLACE INTO utenti (id, email) VALUES (1, 'nuovo@example.com')`

### `INSERT ... ON DUPLICATE KEY UPDATE`
**MySQL: inserisce o aggiorna in caso di conflitto.**

- **Esempio:**
  ```sql
  INSERT INTO utenti (id, nome) VALUES (1, 'Mario')
  ON DUPLICATE KEY UPDATE nome = VALUES(nome)
  ```

### `INSERT ... ON CONFLICT`
**PostgreSQL: upsert nativo.**

- **Esempio:**
  ```sql
  INSERT INTO utenti (id, nome) VALUES (1, 'Mario')
  ON CONFLICT (id) DO UPDATE SET nome = EXCLUDED.nome
  ```

---

## 3. SQL — Definizione Dati (DDL)

### `CREATE TABLE`
**Crea una nuova tabella con colonne, tipi e vincoli.**

- **Esempio:**
  ```sql
  CREATE TABLE clienti (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    data_nascita DATE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
  )
  ```

### `ALTER TABLE`
**Modifica la struttura di una tabella esistente.**

- **Esempio:** `ALTER TABLE clienti ADD COLUMN telefono VARCHAR(20)`
- **Esempio:** `ALTER TABLE clienti DROP COLONNA vecchia_colonna`
- **Esempio:** `ALTER TABLE clienti MODIFY COLUMN email VARCHAR(320) NOT NULL`

### `DROP TABLE`
**Rimuove una tabella e tutti i suoi dati.**

- **Sintassi:** `DROP TABLE [IF EXISTS] tabella [CASCADE | RESTRICT]`
- **Esempio:** `DROP TABLE IF EXISTS log_temp`

### `CREATE INDEX`
**Crea un indice per accelerare le query.**

- **Esempio:** `CREATE INDEX idx_clienti_cognome ON clienti(cognome)`
- **Tipi:** `UNIQUE`, `FULLTEXT` (MySQL), `GIN`/`GiST` (PostgreSQL), composto

### `CREATE VIEW`
**Crea una vista (query salvata come tabella virtuale).**

- **Esempio:**
  ```sql
  CREATE VIEW clienti_attivi AS
  SELECT * FROM clienti WHERE stato = 'attivo'
  ```

### `CREATE SCHEMA`
**Crea uno schema (namespace per oggetti database).**

- **Esempio:** `CREATE SCHEMA vendite`
- **Note:** In MySQL, CREATE SCHEMA è sinonimo di CREATE DATABASE

### `TRUNCATE TABLE`
**Rimuove tutte le righe da una tabella rapidamente (non loggato per riga).**

- **Esempio:** `TRUNCATE TABLE log_temporanei`
- **Note:** Resetta gli AUTO_INCREMENT; non attiva trigger

---

## 4. SQL — Controllo Dati (DCL)

### `GRANT`
**Concede permessi a utenti o ruoli.**

- **Esempio:** `GRANT SELECT, INSERT ON database.clienti TO 'app_user'@'localhost'`
- **Note:** `GRANT ALL PRIVILEGES ON *.* TO 'admin'@'%' WITH GRANT OPTION`

### `REVOKE`
**Revoca permessi precedentemente concessi.**

- **Esempio:** `REVOKE DELETE ON database.clienti FROM 'app_user'@'localhost'`

### `CREATE USER`
**Crea un nuovo utente del database.**

- **Esempio (MySQL):** `CREATE USER 'app'@'%' IDENTIFIED BY 'password_sicura'`
- **Esempio (PostgreSQL):** `CREATE USER app WITH PASSWORD 'password_sicura';`

### `FLUSH PRIVILEGES`
**Ricarica le tabelle dei privilegi (MySQL/MariaDB).**

- **Esempio:** `FLUSH PRIVILEGES`
- **Note:** Necessario dopo modifiche manuali alle tabelle dei grant

---

## 5. MySQL / MariaDB

### `mysql` (CLI client)
**Client a riga di comando per MySQL/MariaDB.**

- **Comando:** `mysql [opzioni] [database]`
- **Esempio:** `mysql -u root -p -h localhost mydb`
- **Esempio:** `mysql -u root -p -e "SHOW DATABASES;"`

### `mysqldump`
**Esegue backup di database MySQL/MariaDB.**

- **Comando:** `mysqldump [opzioni] database [tabelle]`
- **Esempio:** `mysqldump -u root -p --all-databases > backup.sql`
- **Esempio:** `mysqldump -u root -p --single-transaction mydb > mydb.sql`

### `mysqladmin`
**Amministrazione MySQL (creazione/cancellazione DB, ping, shutdown).**

- **Comando:** `mysqladmin [opzioni] comando`
- **Esempio:** `mysqladmin -u root -p status`

### `mysqlimport`
**Importa file di testo (CSV, TSV) in tabelle MySQL.**

- **Comando:** `mysqlimport [opzioni] database file`
- **Esempio:** `mysqlimport --fields-terminated-by=, --local -u root mydb data.csv`

### `mysqlcheck`
**Controllo, riparazione, ottimizzazione e analisi tabelle MySQL.**

- **Comando:** `mysqlcheck [opzioni] database [tabelle]`
- **Esempio:** `mysqlcheck -u root -p --optimize --all-databases`

### `SHOW VARIABLES`
**Mostra le variabili di configurazione del server MySQL.**

- **Esempio:** `SHOW VARIABLES LIKE 'max_connections'`
- **Note:** Utile per diagnostica e tuning

### `SHOW PROCESSLIST`
**Mostra le connessioni attive e le query in esecuzione.**

- **Comando:** `SHOW FULL PROCESSLIST`
- **Esempio:** `SHOW PROCESSLIST` (identifica query lente)

### `EXPLAIN`
**Mostra il piano di esecuzione di una query (indici, join, scansioni).**

- **Esempio:** `EXPLAIN SELECT * FROM clienti WHERE cognome = 'Rossi'`

---

## 6. PostgreSQL

### `psql`
**Client a riga di comando interattivo per PostgreSQL.**

- **Comando:** `psql [opzioni] [database]`
- **Esempio:** `psql -U postgres -h localhost mydb`
- **Comandi interni:** `\l` (list DB), `\dt` (list tabelle), `\d tabella` (descrivi), `\?` (help)

### `pg_dump`
**Esegue backup di un database PostgreSQL.**

- **Comando:** `pg_dump [opzioni] [database]`
- **Esempio:** `pg_dump -U postgres -F c mydb > mydb.dump` (custom format)
- **Esempio:** `pg_dump -U postgres --table=clienti --data-only mydb`

### `pg_restore`
**Ripristina un backup creato con pg_dump (formato custom/directory).**

- **Comando:** `pg_restore [opzioni] [file]`
- **Esempio:** `pg_restore -U postgres -d mydb mydb.dump`

### `pg_isready`
**Verifica lo stato del server PostgreSQL.**

- **Comando:** `pg_isready [opzioni]`
- **Esempio:** `pg_isready -h localhost -p 5432`

### `vacuumdb`
**Manutenzione del database (VACUUM, ANALYZE, REINDEX).**

- **Comando:** `vacuumdb [opzioni] [database]`
- **Esempio:** `vacuumdb -U postgres --analyze --verbose mydb`
- **Note:** Alternativa al comando SQL `VACUUM`

### `createdb` / `dropdb`
**Crea o elimina un database PostgreSQL.**

- **Comando:** `createdb [opzioni] database`
- **Esempio:** `createdb -U postgres -T template0 mydb`

### `EXPLAIN ANALYZE`
**Mostra il piano di esecuzione con tempi effettivi (PostgreSQL).**

- **Esempio:** `EXPLAIN ANALYZE SELECT * FROM clienti WHERE cognome = 'Rossi'`

### `\timing` (psql)
**Attiva la misurazione dei tempi di esecuzione in psql.**

- **Comando:** `\timing`
- **Esempio:** `\timing on`

---

## 7. SQLite

### `sqlite3`
**CLI per database SQLite (file-based, zero configurazione).**

- **Comando:** `sqlite3 [opzioni] [database] [comandi SQL]`
- **Esempio:** `sqlite3 mydb.db "SELECT * FROM clienti;"`
- **Esempio:** `sqlite3 mydb.db .tables` (comandi punto)

### `.dump`
**Esporta l'intero database come comandi SQL.**

- **Comando:** `.dump [tabelle]`
- **Esempio:** `sqlite3 mydb.db .dump > backup.sql`

### `.import`
**Importa un file CSV in una tabella SQLite.**

- **Comando:** `.import [opzioni] file tabella`
- **Esempio:** `sqlite3 mydb.db ".import --csv data.csv clienti"`

### `.mode`
**Imposta il formato di output (column, csv, json, markdown, box).**

- **Esempio:**
  ```
  .mode json
  SELECT * FROM clienti;
  ```

### `.exit` / `.quit`
**Esce dal client SQLite.**

- **Comando:** `.exit [codice]`
- **Esempio:** `.exit 0`

### `.schema`
**Mostra la struttura del database (CREATE TABLE, CREATE INDEX).**

- **Comando:** `.schema [pattern]`
- **Esempio:** `.schema clienti`

### `.indexes`
**Elenca gli indici nel database.**

- **Comando:** `.indexes [pattern]`
- **Esempio:** `.indexes`

### `VACUUM`
**Ricostruisce il file del database liberando spazio non utilizzato.**

- **Comando:** `VACUUM`
- **Esempio:** `VACUUM;`

---

## 8. Microsoft SQL Server

### `sqlcmd`
**Client a riga di comando per SQL Server.**

- **Comando:** `sqlcmd [opzioni]`
- **Esempio:** `sqlcmd -S server\istanza -U sa -P password -Q "SELECT @@VERSION"`
- **Comandi interni:** `GO` (esegue batch), `:r file.sql` (esegue script)

### `bcp` (Bulk Copy Program)
**Copia bulk di dati tra SQL Server e file di dati.**

- **Comando:** `bcp [opzioni]`
- **Esempio:** `bcp mydb.dbo.clienti out clienti.csv -S server -U sa -P pass -c -t,`
- **Esempio:** `bcp mydb.dbo.clienti in clienti.csv -S server -U sa -P pass -c -t,`

### `SSMS` (SQL Server Management Studio)
**GUI per amministrazione SQL Server.**

- **Note:** Include Object Explorer, Query Editor, Profiler, Agent

### `DBCC`
**Database Console Commands per diagnostica e manutenzione.**

- **Comandi:** `DBCC CHECKDB` (verifica integrità), `DBCC SHRINKFILE` (riduce file), `DBCC FREEPROCCACHE`
- **Esempio:** `DBCC CHECKDB('mydb') WITH NO_INFOMSGS`

### `sp_who2` / `sp_lock`
**Stored procedure di sistema per diagnostica concorrenza.**

- **Esempio:** `EXEC sp_who2 'active'`

### `SET STATISTICS TIME ON` / `SET STATISTICS IO ON`
**Abilita statistiche per performance tuning in SQL Server.**

- **Esempio:**
  ```sql
  SET STATISTICS TIME ON
  SET STATISTICS IO ON
  SELECT * FROM clienti WHERE città = 'Roma'
  ```

---

## 9. MongoDB

### `mongosh`
**Shell interattiva moderna per MongoDB.**

- **Comando:** `mongosh [opzioni] [connection-string]`
- **Esempio:** `mongosh "mongodb://localhost:27017/mydb"`
- **Comandi:** `show dbs`, `use mydb`, `show collections`

### `find()`
**Interroga documenti in una collezione.**

- **Esempio:** `db.clienti.find({ città: "Roma" }, { nome: 1, cognome: 1 }).limit(10).sort({ cognome: 1 })`
- **Note:** `pretty()` per output formattato

### `insertOne()` / `insertMany()`
**Inserisce documenti in una collezione.**

- **Esempio:** `db.clienti.insertOne({ nome: "Mario", cognome: "Rossi", città: "Roma" })`

### `updateOne()` / `updateMany()` / `replaceOne()`
**Aggiorna documenti esistenti.**

- **Esempio:** `db.clienti.updateMany({ città: "Roma" }, { $set: { regione: "Lazio" } })`
- **Operatori:** `$set`, `$unset`, `$inc`, `$push`, `$pull`, `$addToSet`

### `deleteOne()` / `deleteMany()`
**Rimuove documenti da una collezione.**

- **Esempio:** `db.log.deleteMany({ data: { $lt: new Date("2024-01-01") } })`

### `aggregate()`
**Pipeline di aggregazione per trasformazioni e analisi dati.**

- **Esempio:**
  ```javascript
  db.ordini.aggregate([
    { $match: { stato: "completato" } },
    { $group: { _id: "$cliente_id", totale: { $sum: "$importo" } } },
    { $sort: { totale: -1 } },
    { $limit: 10 }
  ])
  ```
- **Stages:** `$match`, `$group`, `$sort`, `$project`, `$lookup` (JOIN), `$unwind`, `$bucket`

### `createIndex()`
**Crea un indice per ottimizzare le query.**

- **Esempio:** `db.clienti.createIndex({ cognome: 1, nome: 1 })`
- **Tipi:** Singolo, composto, unique, TTL, text, 2dsphere (geospaziale)

### `mongodump` / `mongorestore`
**Backup e restore di database MongoDB.**

- **Comando:** `mongodump [opzioni]`
- **Esempio:** `mongodump --uri="mongodb://localhost:27017/mydb" --out ./backup`
- **Esempio:** `mongorestore --drop ./backup`

### `mongoexport` / `mongoimport`
**Esporta/importa collezioni in formato JSON o CSV.**

- **Esempio:** `mongoexport --uri="mongodb://localhost:27017/mydb" --collection=clienti --out=clienti.json`
- **Esempio:** `mongoimport --uri="mongodb://localhost:27017/mydb" --collection=clienti --file=clienti.json`

### `mongostat`
**Mostra statistiche live del server MongoDB (connessioni, operazioni/sec).**

- **Comando:** `mongostat [opzioni]`
- **Esempio:** `mongostat --uri="mongodb://localhost:27017" --rowcount=5`

### `mongotop`
**Mostra il tempo speso in operazioni di lettura/scrittura per collezione.**

- **Comando:** `mongotop [opzioni]`
- **Esempio:** `mongotop 5`

---

## 10. Redis

### `redis-cli`
**CLI per Redis (database chiave-valore in memoria).**

- **Comando:** `redis-cli [opzioni] [comando]`
- **Esempio:** `redis-cli -h localhost -p 6379 PING`
- **Esempio:** `redis-cli --scan --pattern "session:*"`

### `SET` / `GET`
**Imposta e recupera valori stringa.**

- **Esempio:**
  ```
  SET user:1000 "Mario Rossi"
  GET user:1000
  ```
- **Opzioni SET:** `EX` (secondi), `PX` (millisecondi), `NX` (solo se non esiste), `XX` (solo se esiste)

### `SETNX` / `SETEX` / `PSETEX`
**Varianti di SET con condizioni o scadenza.**

- **Esempio:**
  ```
  SETNX lock:resource "locked"    (solo se chiave non esiste)
  SETEX session:abc 3600 "data"   (con scadenza in secondi)
  ```

### `DEL`
**Elimina una o più chiavi.**

- **Esempio:** `DEL session:abc user:1000`

### `EXISTS`
**Verifica se una chiave esiste.**

- **Comando:** `EXISTS chiave [chiave...]`
- **Esempio:** `EXISTS user:1000`

### `EXPIRE` / `TTL`
**Imposta/controlla il tempo di vita di una chiave.**

- **Esempio:**
  ```
  EXPIRE session:abc 3600
  TTL session:abc    (tempo rimanente in secondi, -1 = eterno, -2 = non esiste)
  ```

### `INCR` / `DECR`
**Incrementa/decrementa atomicamente un contatore intero.**

- **Esempio:**
  ```
  INCR page:visits:2024-01-01
  INCRBY user:1000:score 10
  ```

### `LPUSH` / `RPUSH` / `LPOP` / `RPOP` / `LRANGE`
**Comandi per liste (inserimento/estrazione sinistra/destra, range).**

- **Esempio:**
  ```
  LPUSH coda "job1"
  RPUSH coda "job2"
  LRANGE coda 0 -1
  LPOP coda
  ```

### `HSET` / `HGET` / `HGETALL` / `HDEL`
**Comandi per hash (mappe chiave-valore annidate).**

- **Esempio:**
  ```
  HSET user:1000 name "Mario" age 30 city "Roma"
  HGET user:1000 name
  HGETALL user:1000
  ```

### `SADD` / `SMEMBERS` / `SINTER` / `SUNION`
**Comandi per set (insiemi non ordinati).**

- **Esempio:**
  ```
  SADD tags:post:42 "redis" "database" "nosql"
  SMEMBERS tags:post:42
  SINTER tags:post:42 tags:post:10  (intersezione)
  ```

### `ZADD` / `ZRANGE` / `ZRANK` / `ZSCORE`
**Comandi per sorted set (set ordinati per punteggio).**

- **Esempio:**
  ```
  ZADD leaderboard 100 "Mario" 85 "Luigi" 92 "Anna"
  ZRANGE leaderboard 0 2 WITHSCORES  (top 3)
  ZRANK leaderboard "Mario"          (posizione)
  ```

### `PUBLISH` / `SUBSCRIBE`
**Pub/Sub messaging — canali di messaggistica.**

- **Esempio:**
  ```
  PUBLISH canale:notifiche "Nuovo ordine"
  SUBSCRIBE canale:notifiche
  ```

### `SAVE` / `BGSAVE`
**Salvataggio persistente su disco (RDB).**

- **Esempio:** `BGSAVE` (salvataggio in background)

### `INFO`
**Mostra statistiche e informazioni sul server Redis.**

- **Comando:** `INFO [sezione]`
- **Esempio:** `INFO memory` (memoria), `INFO keyspace` (statistiche chiavi)

### `FLUSHALL` / `FLUSHDB`
**Cancella tutte le chiavi (tutti i database / database corrente).**

- **Esempio:** `FLUSHALL ASYNC`

### `MONITOR`
**Stream in tempo reale di tutti i comandi eseguiti su Redis.**

- **Comando:** `MONITOR`
- **Note:** Solo per debug, impatta sulle performance

### `CONFIG GET` / `CONFIG SET`
**Legge o modifica parametri di configurazione a caldo.**

- **Esempio:**
  ```
  CONFIG GET maxmemory
  CONFIG SET maxmemory 512mb
  ```

---

## 11. Strumenti di Modellazione e Amministrazione

### `drawDB` / `DBDiagram`
**Strumenti online per creazione diagrammi ER e generazione SQL.**

- **Note:** drawDB (https://drawdb.app) — schema builder visuale gratuito
- **DBDiagram** — DSL per definire schemi, esporta SQL

### `MySQL Workbench`
**GUI per modellazione, amministrazione e sviluppo MySQL.**

- **Funzioni:** Schema designer, query editor, server administration, migration wizard

### `pgAdmin`
**GUI per amministrazione PostgreSQL.**

- **Funzioni:** Query tool, schema designer, dashboard, backup/restore grafico

### `DBeaver`
**Client universale multi-DB con interfaccia grafica.**

- **DB supportati:** MySQL, PostgreSQL, SQLite, SQL Server, Oracle, MongoDB, Redis
- **Funzioni:** ER diagram, query builder, data export/import, SSH tunneling

### `Adminer`
**Client web leggero per amministrazione database (file PHP singolo).**

- **DB supportati:** MySQL, PostgreSQL, SQLite, MS SQL, Oracle, MongoDB
- **Note:** Alternativa leggera a phpMyAdmin

### `phpMyAdmin`
**Amministrazione web per MySQL/MariaDB.**

- **Funzioni:** Gestione DB, tabelle, query SQL, import/export, privileges

### `Azure Data Studio`
**Client moderno per SQL Server e database Azure (multi-piattaforma).**

- **Funzioni:** Query editor, notebook, dashboard, extensions

---

## 12. Strumenti Ausiliari

### `usql`
**Client universale per database SQL (interfaccia unificata).**

- **Comando:** `usql <connection-string>`
- **Esempio:** `usql postgres://user:pass@localhost/mydb`
- **DB supportati:** PostgreSQL, MySQL, SQLite, SQL Server, Oracle, Cassandra

### `sqlline`
**Client JDBC a riga di comando per vari database.**

- **Comando:** `sqlline <connection-string>`
- **Esempio:** `sqlline -u jdbc:mysql://localhost:3306/mydb`

### `sql-formatter`
**Formattatore automatico di query SQL.**

- **Comando:** `sql-formatter [opzioni] <file>`
- **Installazione:** `npm install -g sql-formatter`
- **Esempio:** `sql-formatter --language mysql query.sql`

### `sqlfluff`
**Linter SQL con supporto multi-dialect.**

- **Comando:** `sqlfluff lint [opzioni] <file>`
- **Installazione:** `pip install sqlfluff`
- **Esempio:** `sqlfluff lint --dialect postgres query.sql`

### `sqldef`
**Migration tool dichiarativo (definisci schema desiderato, calcola le differenze).**

- **Comando:** `sqldef <connection-string> --dry-run < schema.sql`
- **Esempio:** `mysqldef -u root mydb --dry-run < desired-schema.sql`

### `redis-commander`
**GUI web per Redis.**

- **Comando:** `redis-commander`
- **Installazione:** `npm install -g redis-commander`

### `RedisInsight`
**GUI Redis ufficiale con analisi performance e profiler.**

- **Note:** Disponibile gratuitamente da Redis

### `MongoDB Compass`
**GUI ufficiale per MongoDB (query builder, index analyzer, schema visualization).**

- **Esempio:** Connessione via stringa URI `mongodb://localhost:27017`

---

## Licenza

MIT

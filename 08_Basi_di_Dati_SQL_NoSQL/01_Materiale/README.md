# SQL & NoSQL Tools

Una guida essenziale e strutturata ai tool e comandi più utilizzati per database SQL e NoSQL.

## Contenuto

Il repository contiene:

- **`Tool.md`** — Elenco completo di strumenti per database organizzati per categoria:
  - SQL: DQL (SELECT, JOIN, GROUP BY), DML (INSERT, UPDATE, DELETE), DDL (CREATE, ALTER), DCL (GRANT)
  - MySQL / MariaDB: CLI, mysqldump, mysqladmin, EXPLAIN
  - PostgreSQL: psql, pg_dump, pg_restore, vacuumdb
  - SQLite: sqlite3, .dump, .import, .mode
  - Microsoft SQL Server: sqlcmd, bcp, DBCC, SSMS
  - MongoDB: mongosh, aggregazioni, indici, backup/restore
  - Redis: stringhe, liste, hash, set, sorted set, pub/sub, persistenza
  - Strumenti di modellazione e amministrazione
  - Strumenti ausiliari

Ogni tool include: nome, descrizione, comando principale, esempio d'uso e note.

## Struttura del file

```markdown
### `nome-comando`
**Descrizione breve.**

- **Comando:** `comando principale`
- **Esempio:** `esempio d'uso`
- **Note:** Note aggiuntive
```

## Requisiti

- **Database:** MySQL, PostgreSQL, SQLite, MongoDB e Redis (a seconda della sezione di interesse)
- **Strumenti ausiliari:** Installabili singolarmente (usql, sqlfluff, RedisInsight, MongoDB Compass, ecc.)

## Licenza

MIT

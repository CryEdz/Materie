import express from 'express';
import bodyParser from 'body-parser';
import sqlite3 from 'sqlite3';
import { CREATE_LIBRI_TABLE } from './database/script_libri.js';
import { CREATE_CLIENTI_TABLE } from './database/script_clienti.js';
import libriRouter from './routes/libriRouter.js';
import clientiRouter from './routes/clientiRouter.js';
import swaggerUi from 'swagger-ui-express';
import swaggerConf from './swagger/swagger.json' with { type: 'json' };

const app = express();
const port = 3000;
app.use(bodyParser.json());
app.use("/api/v2/libri", libriRouter);
app.use("/api/v2/clienti", clientiRouter);

//integrazione Swagger UI per la documentazione interattiva dell'API
app.use("/api-docs",swaggerUi.serve, swaggerUi.setup(swaggerConf));


export const db = new sqlite3.Database("./database/libreria.db");

app.listen(port, () => {
  console.log(`Il server è attivo sulla porta ${port}`);
  initializeDatabase();
});


function initializeDatabase() {
    console.log("Inizializzazione del database...");

  db.exec(CREATE_LIBRI_TABLE, (err) => {
    if (err){
      console.error("Errore durante la creazione della tabella libri:", err.message);
      } else {
        console.log("Tabella libri creata o già esistente.");
      }
  });
  db.exec(CREATE_CLIENTI_TABLE, (err) => {
    if (err){
      console.error("Errore durante la creazione della tabella clienti:", err.message);
      } else {
        console.log("Tabella clienti creata o già esistente.");
      }
  });
}
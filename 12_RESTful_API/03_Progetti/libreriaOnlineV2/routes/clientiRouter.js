import express from 'express';
import { db } from '../server.js';
import { SELECT_ALL, SELECT_BY_ID, SELECT_BY_NOME, SELECT_BY_COGNOME, INSERT_CLIENTE, 
    UPDATE_CLIENTE, DELETE_CLIENTE } from '../database/script_clienti.js';

const clientiRouter = express.Router();

clientiRouter.get("/", (req, res) => {
    console.log("GET /api/v2/clienti");
    db.all(SELECT_ALL, [], (err, rows) => {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.json(rows);
        }
    });
});

clientiRouter.get("/search", (req, res) => {
    const nome = req.query.nome;
    console.log(`GET /api/v2/clienti?nome="${nome}"`);

    if (!nome) {
        res.status(400).json({ error: "Nome non valido" });
        return;
    }

    db.all(SELECT_BY_NOME, [nome], function(err, rows){
        if (err) {
            res.status(500).json({ error: err.message });   
            return;
        } else {
            res.json(rows);
        }
    });
});

clientiRouter.get("/:id", (req, res) => {
    console.log(`GET /api/v2/clienti/${req.params.id}`);

    db.get(SELECT_BY_ID, [req.params.id], function(err, row) {
        if (err) {
            res.status(500).json({ error: err.message });
        } else if (!row) {
            res.status(404).json({ message: "Cliente non trovato con l'id specificato" });
        } else {
            res.json(row);
        }
    });
});

clientiRouter.post("/", (req, res) => {
    console.log("POST /api/v2/clienti");

    const errorMessage = validaCliente(req.body);
    if (errorMessage) {
        res.status(400).json({ error: errorMessage });
        return;
    }

    // estraggo le proprietà dal body
    const {nome, cognome, email, telefono} = req.body;

    db.run(INSERT_CLIENTE, [nome, cognome, email, telefono], function(err) {
        if (err) {
            res.status(500).json({ error: err.message });
            return;
        } else {
            res.status(201).json({ message: `Cliente creato con ID ${this.lastID}`});
        }
    });
});

clientiRouter.delete("/:id", (req, res) => {
    const id = req.params.id;
    console.log(`DELETE /api/v2/clienti/${id}`);

    db.run(DELETE_CLIENTE, [id], function(err) {
        if (err) {
            res.status(500).json({ error: err.message });
            return;
        } else if (this.changes === 0) {
            res.status(404).json({ message: "Cliente non presente in database" });
        } else {
            res.json({ message: "Cliente eliminato con successo" });
        }
    });
});

/* UTILITY */
function validaCliente(cliente) {
    let errorMessage;

    if (!cliente) {
        errorMessage = "Cliente non presente.";
    }
    if (cliente.email && !isValidEmail(cliente.email)) {
        errorMessage = "Email non valida.";
    }

    return errorMessage;
}

function isValidEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}


export default clientiRouter;

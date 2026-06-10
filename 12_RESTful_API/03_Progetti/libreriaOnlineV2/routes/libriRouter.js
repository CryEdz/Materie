import express from 'express';
import { db } from "../server.js";
import { SELECT_ALL, SELECT_BY_ID, SELECT_BY_TITOLO, INSERT_LIBRO,
    UPDATE_LIBRO, DELETE_LIBRO, SELECT_BY_AUTORE
} from "../database/script_libri.js";


const libriRouter = express.Router();

libriRouter.get("/", (req, res) => {
    console.log("GET /api/v2/libri");

    db.all(SELECT_ALL, (err, rows) => {
        if (err) {
            res.status(500).json({ error: err.message });
        } else {
            res.json(rows);
        }
    });
});

libriRouter.get("/search", (req, res) => {
    const titolo = req.query.titolo;
    const autore = req.query.autore;
    console.log(`GET /api/v2/libri/search?titolo="${titolo}"&autore="${autore}"`);

    if (!titolo && !autore) {
        return res.status(400).json({ error: "Specificare almeno un criterio di ricerca (titolo o autore)" });
    }

    if (titolo && autore) {
        const sql = "SELECT * FROM libri WHERE LOWER(titolo) LIKE '%' || LOWER(?) || '%' AND LOWER(autore) LIKE '%' || LOWER(?) || '%'";
        db.all(sql, [titolo, autore], function (err, rows) {
            if (err) return res.status(500).json({ error: err.message });
            res.json(rows);
        });
    } else if (titolo) {
        db.all(SELECT_BY_TITOLO, [titolo], function (err, rows) {
            if (err) return res.status(500).json({ error: err.message });
            res.json(rows);
        });
    } else {
        db.all(SELECT_BY_AUTORE, [autore], function (err, rows) {
            if (err) return res.status(500).json({ error: err.message });
            res.json(rows);
        });
    }
});

libriRouter.get("/:id", (req, res) => {
    console.log(`GET /api/v2/libri/${req.params.id}`);

    db.get(SELECT_BY_ID, [req.params.id], function(err, row) {
        if (err) {
            res.status(500).json({ error: err.message });
        } else if (!row) {
            res.status(404).json({ message: "Libro non trovato con l'id specificato" });
        } else {
            res.json(row);
        }
    });
});




libriRouter.post("/", (req, res) => {
    console.log("POST /api/v2/libri");

    const errorMessage = validaLibro(req.body);
    if (errorMessage) {
        res.status(400).json({ error: errorMessage });
        return;
    }

    // estraggo le proprietà dal body
    const {titolo, autore, editore, genere, numero_pagine} = req.body;

    db.run(INSERT_LIBRO, [titolo, autore, editore, genere, numero_pagine], function(err) {
        if (err) {
            res.status(500).json({ error: err.message });
            return;
        } else {
            res.status(201).json({ message: `Libro creato con ID ${this.lastID}`});
        }
    });
});

libriRouter.delete("/:id", (req, res) => {
    const id = req.params.id;
    console.log(`DELETE /api/v2/libri/${id}`);

    db.run(DELETE_LIBRO, [id], function(err) {
        if (err) {
            res.status(500).json({ error: err.message });
            return;
        } else if (this.changes === 0) {
            res.status(404).json({ message: "Libro non presente in database" });
        } else {
            res.json({ message: "Libro eliminato con successo" });
        }
    });
});


/* UTILITY */
function validaLibro(libro) {
    let errorMessage;

    if (!libro) {
        errorMessage = "Libro non presente.";
    }
    if (libro.numero_pagine && isNaN(libro.numero_pagine)) {
        errorMessage = "Il numero pagine deve essere numerico."
    }

    return errorMessage;
}


export default libriRouter;
import express from 'express';
import bodyParser from 'body-parser';
import catalogoLibri from './model/catalogo.js';
import clientiFile from './model/clienti.js';


const app = express();
app.use(bodyParser.json());
const PORT = 3000;
const BASE_PATH = "/api/v1";

var catalogo = [...catalogoLibri];
var clienti = [...clientiFile];

// avvia il server
app.listen(PORT, () => {
    console.log("Server attivo sulla porta " + PORT);
});

// endpoint per restituire un testo di prova
app.get("/", (req, res) => {
    res.send("Benvenuto nella tua libreria online!");
});

// endpoint per recuperare l'intero catalogo dei libri
app.get(BASE_PATH + "/libri", (req, res) => {
    res.json(catalogo);
});

// endpoint per recuperare l'intero elenco dei clienti
app.get(BASE_PATH + "/clienti", (req, res) => {
    res.json(clienti);
});

// endpoint per aggiungere un nuovo libro al catalogo
app.post(`${BASE_PATH}/libri`, (req, res) => {
    //estrago i dati del nuovo libro dal corpo della richiesta
    const nuovoLibro = req.body;

    if (!validaLibro(nuovoLibro)) {
        res.status(400).json({ error: "Libro non valido" });
        return;
    }

    // assegno un id univoco; normalmente questa operazione la farebbe il database sottostante
    const maxId = catalogo.map(item => item.id)
                          .reduce((a, b) => Math.max(a, b), 0);
    nuovoLibro.id = maxId + 1;

    console.log("Aggiungo il libro: " + JSON.stringify(nuovoLibro));
    catalogo.push(nuovoLibro);
    res.status(201).json(nuovoLibro);
});

//endpoint per aggiornar i dati di un libro
app.put(`${BASE_PATH}/libri/:id`,(req,res) => {
    //recupero l'id dal path
    const idParam = parseInt(req.params.id);

    //recupero il libro aggiornato dal corpo della richiesta
    const libroAggiornato = req.body;

    //controllo che il libro passato sia valido
    if (!validaLibro(libroAggiornato)){
        res.status(400).json({ error: "Libro non valido" });
        return;
    }

    //recupero l'indice dle libro da aggiornare perchè stiamo operando su un array
    //normalmente basterebbe passare l'id al database per aggiornare il record corrisponente.
    const index = catalogo.findIndex(libro => libro.id === idParam)
    if (index === -1){
        res.status(404).json({ error: "Libro non trovato" });
        return;
    }

    let libroDaAggiornare = catalogo[index];
    /*
        libroDaAggiornare.titolo = libroAggiornato.titolo;
        libroDaAggiornare.autore = libroAggiornato.autore;
        libroDaAggiornare.editore = libroAggiornato.editore;
        ...
    */

    catalogo[index] = {...libroDaAggiornare, ...libroAggiornato};
    res.status(200).json({message: 'Libro aggiornato con successo'});

});

// endpoint per restituire il dettaglio del libro specificato
app.get(`${BASE_PATH}/libri/:id`, (req, res) => {
    // recupero l'id del path e lo converto in numero
    const idParam = parseInt(req.params.id);
    let libroTrovato = catalogo.find(libro => libro.id === idParam);
    if (libroTrovato){
        res.status(200).json(libroTrovato);
    }else{
        res.status(404).json({message:"Libro non trovato"});
    }
});

//CLIENTI

app.get(`${BASE_PATH}/clienti/:id`, (req, res) => {
    const idCliente = parseInt(req.params.id);
    let clienteTrovato = clienti.find(cliente => cliente.id == idCliente);
    if (clienteTrovato){
        res.status(200).json(clienteTrovato);
    }else{
        res.status(404).json({message:"Cliente non trovato"});
    }
});

/* ====================== UTILITY FUNCTION =====================================================*/

function validaLibro(libro){
    if(libro && libro.titolo && libro.editore && libro.autore){
        return true;
    }else{
        return false;
    }
}


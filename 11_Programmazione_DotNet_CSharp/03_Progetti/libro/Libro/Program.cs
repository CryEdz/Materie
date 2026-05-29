using LibroAutoriEditore;

namespace LibroAutoriEditore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Libro Autori Editore");

            var indirizzo = new Indirizzo
            {
                Via = "Vie dei 1000, 101",
                Cap = "10100",
                Citta = "Torino",
                Provincia = "TO"
            };
            var editore = new Editore
            {
                RagioneSociale = "UTET",
                Email = "info@utet.com",
                Indirizzo = indirizzo, //1..1
                SitoWeb = "https://www.utet.com",
                Telefono = "0110112213"
            };

            var autori = new Autore[] {
            new Autore{ Nome="Pietro", Cognome="Giudilli"},
            new Autore{ Nome="Laura", Cognome="Maestri"},
            new Autore{ Nome="Giulia", Cognome="Gomez"}
            };

            var libro = new Libro
            {
                ISBN = "978880245896",
                Titolo = "Programmazione C#",
                Autori = autori, //1..N
                Editore = editore, //1..1
                NumeroPagine = 584,
                AnnoPubblicazione = 2022
            };

            Console.WriteLine(libro.StampaDettaglio());
        }
    }
}
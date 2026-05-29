namespace Prodotti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prodotti!");

            Prodotto[] prodotti = new Prodotto[7];

            // Prodotti generici
            prodotti[0] = new Prodotto() 
            { 
                Codice = 1, 
                Denominazione = "Prodotto Generico 1", 
                Descrizione = "Un semplice prodotto", 
                Prezzo = 9.99, 
                Giacenza = 15 
            };

            prodotti[1] = new Prodotto() 
            { 
                Codice = 2, 
                Denominazione = "Prodotto Generico 2", 
                Prezzo = 19.99, 
                Giacenza = 5 
            };

            // Prodotti Alimentari
            prodotti[2] = new Alimentare() 
            { 
                Codice = 10, 
                Denominazione = "Pane Integrale", 
                Descrizione = "Pane fresco cotto al forno", 
                Prezzo = 2.50, 
                Giacenza = 20, 
                DataScadenza = new DateTime(2024, 12, 25) 
            };

            prodotti[3] = new Alimentare() 
            { 
                Codice = 11, 
                Denominazione = "Latte Intero", 
                Prezzo = 1.80, 
                Giacenza = 8, 
                DataScadenza = new DateTime(2024, 12, 20) 
            };

            prodotti[4] = new Alimentare() 
            { 
                Codice = 12, 
                Denominazione = "Formaggio Parmigiano", 
                Descrizione = "Formaggio stagionato 24 mesi", 
                Prezzo = 12.00, 
                Giacenza = 0, 
                DataScadenza = new DateTime(2026, 6, 15) 
            };

            // Prodotti Non Alimentari
            prodotti[5] = new NonAlimentare() 
            { 
                Codice = 20, 
                Denominazione = "Bottiglia d'Acqua", 
                Descrizione = "Bottiglia riutilizzabile", 
                Prezzo = 8.99, 
                Giacenza = 50, 
                Materiale = "Plastica Riciclata" 
            };

            prodotti[6] = new NonAlimentare() 
            { 
                Codice = 21, 
                Denominazione = "Sacchetto di Carta", 
                Prezzo = 0.50, 
                Giacenza = 3, 
                Materiale = "Carta Kraft" 
            };

            foreach (Prodotto p in prodotti) {
                Console.WriteLine(p.FormatDettaglio());

                if (p is Alimentare alimentare)
                {
                    Console.WriteLine($"Data Scadenza: {alimentare.DataScadenza:dd/MM/yyyy}");
                }
                else if (p is NonAlimentare nonAlimentare)
                {
                    Console.WriteLine($"Materiale: {nonAlimentare.Materiale}");
                }

                if (p.IsEsaurito())
                {
                    Console.WriteLine("*** PRODOTTO ESAURITO ***");
                }
                else if (p.IsInScorta())
                {
                    Console.WriteLine("*** PRODOTTO IN SCORTA ***");
                }

                Console.WriteLine("-----------------------------------\n");
            }
        }
    }
}

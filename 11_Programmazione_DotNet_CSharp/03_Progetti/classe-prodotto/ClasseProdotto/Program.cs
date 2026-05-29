/*
 * Di un prodotto si conoscono le seguenti caratteristiche: codice di tipo numerico, denominazione di tipo stringa, descrizione di tipo stringa, prezzo di tipo double, giacenza di tipo intero (scorta a magazzino).
 * 
Si richiede la possibilità di sapere se un prodotto è in scorta ovvero se la sua giacenza è compresa tra 1 e 9 pezzi oppure se il prodotto è esaurito ovvero la giacenza è pari a zero.

Si vuole anche avere due metodi per formattare l'output di stampa del prodotto. I due metodi sono StampaLineare e StampaDettaglio.

Istanziare due oggetti di tipo Prodotto nel main della classe Program e utilizzare per uno dei due metodi di stampa proposti per i due prodotti.
 
 
 */


namespace ClasseProdotto
{
    internal class Program
    {
        //propietà

        public int Codice { get; set; }
        public string Denominazione { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public int Giacenza { get; set; }

        //metodi
        public bool IsInScorta()
        {
            return Giacenza > 0 && Giacenza < 10;
        }

        public bool IsEsaurito()
        {
            return Giacenza == 0;
        }

        //metodi "Usa e getta"

        public string FormatLineare()
        {
            return $"" +
                $"Codice = {Codice}" +
                $", Denominazione = {Denominazione}" +
                $", Descrizione = {Descrizione}" +
                $", Prezzo = {Prezzo}" +
                $", Giacenza = {Giacenza}"
                ;
        }

        public string FormatDettaglio()
        {
            return $"Codice: {Codice}" +
                $"\nDenominazione: {Denominazione}" +
                $"\nDescrizione: {Descrizione}" +
                $"\nPrezzo: {Prezzo}" +
                $"\nGiacenza: {Giacenza}"
                ;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

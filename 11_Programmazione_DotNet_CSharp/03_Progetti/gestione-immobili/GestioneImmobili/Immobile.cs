using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneImmobili
{
    internal class Immobile
    {
        //propietà

        public string Codice { get; set; }
        public string Indirizzo { get; set; }
        public string Cap { get; set; }
        public string Citta { get; set; }
        public int Superficie { get; set; }
        public double Prezzo { get; set; }

        //metodi

        public string FormatLineare()
        {
            return $"" +
                $"Codice = {Codice}" +
                $", Indirizzo = {Indirizzo}" +
                $", CAP = {Cap}" +
                $", Città = {Citta}" +
                $", Superficie = {Superficie} mq" +
                $", Prezzo = {Prezzo} €"
                ;
        }

        public string FormatDettaglio()
        {
            return $"Codice: {Codice}" +
                $"\nIndirizzo: {Indirizzo}" +
                $"\nCAP: {Cap}" +
                $"\nCittà: {Citta}" +
                $"\nSuperficie: {Superficie} mq" +
                $"\nPrezzo: {Prezzo} €"
                ;
        }

        public string FormatCSV()
        {
            return $"{Codice};{Indirizzo};{Cap};{Citta};{Superficie};{Prezzo}";
        }
    }
}

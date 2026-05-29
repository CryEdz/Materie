using System;
using System.Collections.Generic;
using System.Text;

namespace Prodotti
{
    internal class Prodotto
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
    }
}
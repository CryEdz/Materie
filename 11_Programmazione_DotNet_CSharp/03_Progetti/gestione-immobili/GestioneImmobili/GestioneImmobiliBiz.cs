using System;
using System.Collections.Generic;
using System.IO;

namespace GestioneImmobili
{
    internal class GestioneImmobiliBiz
    {
        public Immobile[] Elenco { get; set; }

        public GestioneImmobiliBiz()
        {
            Elenco = Array.Empty<Immobile>();
        }

        public string StampaElenco()
        {
            string risultato = "";
            foreach (var item in Elenco)
                risultato += item.FormatLineare() + "\n";
            return risultato;
        }

        public string StampaAppartamenti()
        {
            string risultato = "";
            foreach (var item in Elenco)
                if (item is Appartamento && !(item is Villa))
                    risultato += item.FormatLineare() + "\n";
            return risultato;
        }

        public string StampaVille()
        {
            string risultato = "";
            foreach (var item in Elenco)
                if (item is Villa)
                    risultato += item.FormatLineare() + "\n";
            return risultato;
        }

        public string StampaBox()
        {
            string risultato = "";
            foreach (var item in Elenco)
                if (item is Box)
                    risultato += item.FormatLineare() + "\n";
            return risultato;
        }

        public string StampaPerCitta(string citta)
        {
            string risultato = "";
            foreach (var item in Elenco)
                if (item.Citta.Equals(citta, StringComparison.OrdinalIgnoreCase))
                    risultato += item.FormatLineare() + "\n";
            return risultato;
        }

        public string StampaDettaglio(string codice)
        {
            foreach (var item in Elenco)
            {
                if (item.Codice.Equals(codice, StringComparison.OrdinalIgnoreCase))
                {
                    string dettaglio = item.FormatDettaglio();
                    if (item is Box box)
                        dettaglio += $"\nPosti auto: {box.NumeroPostiAuto}";
                    else if (item is Villa villa)
                        dettaglio += $"\nGiardino: {villa.DimensioneGiardino} mq";
                    else if (item is Appartamento appartamento)
                        dettaglio += $"\nVani: {appartamento.NumeroVani}, Bagni: {appartamento.NumeroBagni}";
                    return dettaglio;
                }
            }
            return "Nessun immobile trovato con questo codice.";
        }

        public void EsportaCSV(string tipo)
        {
            string nomeFile = "";
            List<Immobile> filtri = new List<Immobile>();

            if (tipo.Equals("Box", StringComparison.OrdinalIgnoreCase))
            {
                nomeFile = "ElencoBox.csv";
                foreach (var item in Elenco)
                    if (item is Box)
                        filtri.Add(item);
            }
            else if (tipo.Equals("Appartamenti", StringComparison.OrdinalIgnoreCase))
            {
                nomeFile = "ElencoAppartamenti.csv";
                foreach (var item in Elenco)
                    if (item is Appartamento && !(item is Villa))
                        filtri.Add(item);
            }
            else if (tipo.Equals("Ville", StringComparison.OrdinalIgnoreCase))
            {
                nomeFile = "ElencoVille.csv";
                foreach (var item in Elenco)
                    if (item is Villa)
                        filtri.Add(item);
            }
            else
            {
                Console.WriteLine("Tipo non valido!");
                return;
            }

            string path = $@"..\..\..\File\{nomeFile}";
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var item in filtri)
                    sw.WriteLine(item.FormatCSV());
            }
            Console.WriteLine($"File {nomeFile} creato con successo!");
        }
    }
}

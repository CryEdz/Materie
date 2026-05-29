using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroAutoriEditore
{
    public class Libro
    {
        public string? ISBN { get; set; }
        public string? Titolo { get; set; }
        public Autore[]? Autori { get; set; }
        public Editore? Editore { get; set; }
        public int NumeroPagine { get; set; }
        public int AnnoPubblicazione { get; set; }

        public double CostoFissoPerStampa { get; } = 5.05;

        public readonly double CostoFissoPerStampaPagina = 0.15;

        public double Prezzo() {
            return CostoFissoPerStampa + NumeroPagine * CostoFissoPerStampaPagina;
        }

        private string ElencoAutori() {

            string msg = "";
            foreach (var a in Autori!)
                msg += (msg.Length!=0 ? ", ":"") + a.Nominativo();

            return msg;
        }

        public string StampaDettaglio() {
            return $"ISBN: {ISBN}" +
                $"\nTitolo: {Titolo}" +
                $"\nAutori: {ElencoAutori()}" +
                $"\nEditore: {Editore!.RagioneSociale}" +
                $"\nNumerodi pagine: {NumeroPagine}" +
                $"\nAnno pubblicazione: {AnnoPubblicazione}" +
                $"\nPrezzo: {Prezzo():#.##} euro"
                ;
        
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}" +
                $"\nTitolo: {Titolo}" +
                $"\nAutori: {ElencoAutori()}" +
                $"\nEditore: {Editore!.RagioneSociale}" +
                $"\nNumerodi pagine: {NumeroPagine}" +
                $"\nAnno pubblicazione: {AnnoPubblicazione}" +
                $"\nCosto fisso per stampa: {CostoFissoPerStampa} euro" +
                $"\nCosto fisso per stampa pagina: {CostoFissoPerStampaPagina} euro" +
                $"\nPrezzo: {Prezzo():#.##} euro"
                ;
        }


    }
}

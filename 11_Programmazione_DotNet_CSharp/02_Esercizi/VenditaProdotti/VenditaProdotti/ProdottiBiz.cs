using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenditaProdotti
{
    public class ProdottiBiz
    {
        public List<Prodotto> Elenco { get; set; }

        public ProdottiBiz()
        {
            Elenco = new List<Prodotto>();
        }

        public string StampaElenco() {
            return string.Join("\n", Elenco);
        }

        public List<ProdottoAlimentare> ElencoProdottiInScadenza()
        {
            var lista = new List<ProdottoAlimentare>();
            foreach (var p in Elenco)
                if (p is ProdottoAlimentare inScadenza)
                    if (inScadenza.IsInScadenza())
                        lista.Add(inScadenza);
            return lista;
        }

        public List<ProdottoNonAlimentare> ElencoProdottiPercentualeMateriaPrima()
        {
            var lista = new List<ProdottoNonAlimentare>();
            foreach (var p in Elenco)
                if (p is ProdottoNonAlimentare nonAlimentare)
                    lista.Add(nonAlimentare);
            return lista;
        }
    }
}

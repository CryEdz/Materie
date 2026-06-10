using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenditaProdotti
{
    public class ProdottoAlimentare:Prodotto
    {
        public DateTime DataScadenza { get; set; }

        public bool IsInScadenza() {
            return DateTime.Now.AddDays(10) >= DataScadenza;
        }

        public override string ToString()
        {
            return base.ToString()
                +$", Data Scadenza={DataScadenza.ToShortDateString()}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenditaProdotti
{
    public abstract class Prodotto
    {
        public int Codice { get; set; }
        public string? Nome { get; set; }
        public double Prezzo { get; set; }
        public DateTime DataProduzione { get; set; }

        public override string ToString()
        {
            return $"{nameof(Codice)}={Codice.ToString()}, {nameof(Nome)}={Nome}, {nameof(Prezzo)}={Prezzo.ToString()}, {nameof(DataProduzione)}={DataProduzione.ToShortDateString()}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenditaProdotti
{
    public class ProdottoNonAlimentare:Prodotto
    {
        //la percentuale della materia prima
        public List<Materiale> MateriePrime { get; set; }
        
        public override string ToString()
        {
            return base.ToString()
                +$"\nPercentuali di materiale prima: {string.Join('\n',MateriePrime)}"; //format P => ? %
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenditaProdotti
{
    public class Materiale
    {
        public string? Denominazione { get; set; }
        public double Percentuale { get; set; }

        public override string ToString()
        {
            return $"Materiale: {Denominazione}, Percentuale: {Percentuale}";
        }
    }
}

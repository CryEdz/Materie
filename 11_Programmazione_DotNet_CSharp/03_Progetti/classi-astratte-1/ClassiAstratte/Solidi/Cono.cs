using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidi
{
    internal class Cono : Cilindro
    {
        public Cono(double raggio, double altezza, Materiale materiale) : base(raggio, altezza, materiale)
        {
        }

        public override double Volume()
        {
            return Math.PI*Math.Pow(raggio,2)*altezza/3;
        }
    }
}

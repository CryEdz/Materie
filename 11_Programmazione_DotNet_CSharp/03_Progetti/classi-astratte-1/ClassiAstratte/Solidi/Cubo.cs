using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidi
{
    internal class Cubo:Solido
    {
        protected double lato;

        public Cubo(double lato,Materiale materiale):base(materiale) {
            this.lato = lato;
        }

        public override double Volume()
        {
            return Math.Pow(lato,3);
        }

        public override string ToString()
        {
            return $"Lato: {lato} dm" +
                $", {base.ToString()}"
                ;
        }
    }
}

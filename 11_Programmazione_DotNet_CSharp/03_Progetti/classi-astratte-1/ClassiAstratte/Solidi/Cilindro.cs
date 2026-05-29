using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Solidi
{
    internal class Cilindro:Solido
    {
        protected double raggio;
        protected double altezza;

        public Cilindro(double raggio, double altezza, Materiale materiale):base(materiale)
        {
            this.raggio = raggio;
            this.altezza = altezza;
        }

        public override double Volume()
        {
            return Math.PI*raggio*raggio*altezza;
        }
        public override string ToString() {

            return $"Raggio: {raggio} dm" +
                $", Altezza: {altezza} dm" +
                $", " + base.ToString();
        
        }
    }
}

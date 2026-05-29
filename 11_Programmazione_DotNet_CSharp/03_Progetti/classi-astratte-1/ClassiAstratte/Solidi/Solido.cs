using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Solidi
{
    internal abstract class Solido
    {
        protected Materiale materiale;

        //costruttore con passaggio di parametri
        public Solido(Materiale materiale)
        {
            this.materiale = materiale;
        }

        public double Peso()
        {
            return materiale.PesoSpecifico*Volume();
        }

        public abstract double Volume();

        public string StampaLineare()
        {
            return $"{this.GetType().Name.ToUpper()} => " + ToString();
        }

        public override string ToString() {
            return 
                $"{materiale.ToString()}" +
                $", Peso: {Math.Round(Peso(),1)} kg" +
                $", Volume: {Math.Round(Volume(),1)} dm^3"
                ;
        }

    }
}

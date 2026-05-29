using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
    internal abstract class Solido
    {

        /*
         Determinare il peso di un solido , dato da il peso specifico del materiale scelto per il volume del solido.
        */
        public double PesoSpecifico { get; set; }

        public double Peso() { 
        
            return PesoSpecifico * Volume();
        }

        public abstract double Volume(); //metodo abstract

        public override string ToString()
        {
            return 
                $"{nameof(PesoSpecifico)}={PesoSpecifico.ToString()} kg/dm^3" +
                $", peso={Peso()} kg" +
                $", Volume={Volume()} dm^3";
        }
    }
}

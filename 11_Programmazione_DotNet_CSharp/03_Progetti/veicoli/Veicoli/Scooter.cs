using System;
using System.Collections.Generic;
using System.Text;

namespace Veicoli
{
    internal class Scooter : Veicolo
    {
        public int NumeroRuote { get; set; }


    public override string ToString()
    {
        return base.ToString()
            + $", Numero di ruote = {NumeroRuote}"            
             ;
        }
    }
}

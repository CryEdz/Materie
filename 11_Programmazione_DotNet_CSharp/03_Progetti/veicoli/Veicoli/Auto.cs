using System;
using System.Collections.Generic;
using System.Text;

namespace Veicoli
{
    internal class Auto : Veicolo
    {
        public int NumeroPorte { get; set; }
    
        public TipoCambio Cambio { get; set; }

        public override string ToString()
        {
            return base.ToString()
                + $", Numero di porte = {NumeroPorte}" +
                  $",Tipo di Cambio = {Cambio}"
                 ;
        }
    }
}

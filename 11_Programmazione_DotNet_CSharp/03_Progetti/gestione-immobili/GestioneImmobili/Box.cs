using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneImmobili
{
    internal class Box : Immobile
    {
        public int NumeroPostiAuto { get; set; }

        public string FormatLineare()
        {
            return base.FormatLineare() +
                $", Posti auto = {NumeroPostiAuto}"
                ;
        }

        public string FormatDettaglio()
        {
            return base.FormatDettaglio() +
                $"\nPosti auto: {NumeroPostiAuto}"
                ;
        }

        public string FormatCSV()
        {
            return $"{base.FormatCSV()};{NumeroPostiAuto}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneImmobili
{
    internal class Box : Immobile
    {
        public int NumeroPostiAuto { get; set; }

        public override string FormatLineare()
        {
            return base.FormatLineare() +
                $", Posti auto = {NumeroPostiAuto}"
                ;
        }

        public override string FormatDettaglio()
        {
            return base.FormatDettaglio() +
                $"\nPosti auto: {NumeroPostiAuto}"
                ;
        }

        public override string FormatCSV()
        {
            return $"{base.FormatCSV()};{NumeroPostiAuto}";
        }
    }
}

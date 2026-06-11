using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneImmobili
{
    internal class Appartamento : Immobile
    {
        public int NumeroVani { get; set; }
        public int NumeroBagni { get; set; }

        public override string FormatLineare()
        {
            return base.FormatLineare() +
                $", Vani = {NumeroVani}" +
                $", Bagni = {NumeroBagni}"
                ;
        }

        public override string FormatDettaglio()
        {
            return base.FormatDettaglio() +
                $"\nVani: {NumeroVani}" +
                $"\nBagni: {NumeroBagni}"
                ;
        }

        public override string FormatCSV()
        {
            return $"{base.FormatCSV()};{NumeroVani};{NumeroBagni}";
        }
    }
}

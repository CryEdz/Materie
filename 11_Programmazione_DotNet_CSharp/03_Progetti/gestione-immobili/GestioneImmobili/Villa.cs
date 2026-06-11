using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneImmobili
{
    internal class Villa : Appartamento
    {
        public int DimensioneGiardino { get; set; }

        public override string FormatLineare()
        {
            return base.FormatLineare() +
                $", Giardino = {DimensioneGiardino} mq"
                ;
        }

        public override string FormatDettaglio()
        {
            return base.FormatDettaglio() +
                $"\nGiardino: {DimensioneGiardino} mq"
                ;
        }

        public override string FormatCSV()
        {
            return $"{base.FormatCSV()};{DimensioneGiardino}";
        }
    }
}

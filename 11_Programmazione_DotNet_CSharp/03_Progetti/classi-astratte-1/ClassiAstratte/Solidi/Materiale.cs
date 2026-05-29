using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidi
{
    internal class Materiale
    {
        public TipoMateriale Denominazione { get; set; }
        public double PesoSpecifico { get; set; }

        internal Solido Solido
        {
            get => default;
            set
            {
            }
        }

        internal TipoMateriale TipoMateriale
        {
            get => default;
            set
            {
            }
        }

        public override string ToString()
        {
            return $"Materiale: {Denominazione.ToString()}" +
                $", Peso Specifico: {PesoSpecifico.ToString()} kg/dm^3";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
    internal class Sfera : Solido
    {
        public double Raggio { get; set; }

        public override double Volume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Raggio, 3);
        }
        public override string ToString()
        {
            return $"{GetType().Name}: " +
                $"Raggio={Raggio} dm" +
                $", {base.ToString()}"
                ;
        }
    }
}
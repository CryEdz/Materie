using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
    internal class Cubo:Solido
    {
        public double Lato { get; set; }

        public override double Volume()
        {
            return Math.Pow(Lato,3);
        }

        public override string ToString()
        {
            return $"{GetType().Name}: " +
                $"Lato={Lato} dm" +
                $", {base.ToString()}"
                ;
                
        }
    }
}

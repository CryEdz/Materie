using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
    internal class Esacisicosaedro:Solido
    {
        //Riferimenti e risorse
        // Volume: https://it.wikipedia.org/wiki/Esacisicosaedro
        public double Spigolo { get;   set; }

        public override double Volume()
        {
            // V = (1805 + 805√5) / 12 × a³
            return ((1805 + 805 * Math.Sqrt(5)) / 12) * Math.Pow(Spigolo, 3);
        }

        public override string ToString()
        {
            return $"{GetType().Name}: " +
                $"Spigolo={Spigolo} dm" +
                $", {base.ToString()}"          
                ;
        }
    }
}

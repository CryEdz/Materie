using System;
using System.Collections.Generic;
using System.Text;

namespace Quadrilateri
{
    internal class Rettangolo : Quadrilatero
    {
        public Rettangolo(double @base, double altezza) : base(@base, altezza, @base, altezza) { }

        public double Area()
        {
            return base.lato1 * base.lato2;
        }

        public double Diagonale()
        {
            return Math.Sqrt(Math.Pow(base.lato1, 2) + Math.Pow(base.lato2, 2));
        }

        public override string ToString()
        {
            return $"{GetType().Name}: " +
                $"base={lato1}" +
                $", altezza={lato2}" +
                $", perimetro={Perimetro()}" +
                $", area={Area()}" +
                $", diagonale={Diagonale()}" +
                $", perimetro={Perimetro()}"
            ;
        }
    }
}

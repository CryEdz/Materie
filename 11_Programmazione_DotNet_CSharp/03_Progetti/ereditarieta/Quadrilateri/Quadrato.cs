using System;
using System.Collections.Generic;
using System.Text;

namespace Quadrilateri
{
    internal class Quadrato : Rettangolo
    {
        public Quadrato(double lato) : base(lato, lato) { }

        public override string ToString()
        {
            return $"{GetType().Name}: " +
                $"base={lato1}" +
                $", perimetro={Perimetro()}" +
                $", area={Area()}" +
                $", diagonale={Diagonale()}" +
                $", perimetro={Perimetro()}"
            ;

        }
    }
}

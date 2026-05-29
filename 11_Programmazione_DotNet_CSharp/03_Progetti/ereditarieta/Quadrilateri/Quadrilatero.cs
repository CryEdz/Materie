using System;
using System.Collections.Generic;
using System.Text;

namespace Quadrilateri
{
    internal class Quadrilatero
    {
        //attributi
        protected double lato1;
        protected double lato2;
        private double lato3;
        private double lato4;

        public Quadrilatero(double lato1, double lato2, double lato3, double lato4)
        {
            this.lato1 = lato1;
            this.lato2 = lato2;
            this.lato3 = lato3;
            this.lato4 = lato4;
        }

        //metodi

        public double Perimetro()
        {
            return lato1 + lato2 + lato3 + lato4;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: " +
                $"lato1={ lato1}" +
                $", lato2={lato2}" +
                $", lato3={lato3}" +
                $", lato4={lato4}" +
                $", perimetro={Perimetro()}"
            ;
        }
    }
}

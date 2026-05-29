using System;
using System.Collections.Generic;
using System.Text;

namespace FigureGeometriche.Piane
{
    internal class Pentagono
    {
                private double _lato;

        public double Perimetro()
        { 
            double p = _lato * 5;
            return p;
        }
        public double Apotema()
        {
            double a = _lato * 0.688;
            return a;
        }
        public double Area()
        {
            double a = _lato * Apotema() / 2;
            return a;
        }
         

    }
}

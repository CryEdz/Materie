using System;
using System.Collections.Generic;
using System.Text;

namespace FigureGeometriche.Piane
{
    internal class Esagono
    {
        private double _lato;
        private double f = 0.866;
        public double Perimetro()
        {
            double p = _lato * 6;
            return p;
        }
        public double Apotema()
        {
            double a = _lato * f;
            return a;
        }
        public double Area()
        {
            double a = _lato * Apotema() / 2;
            return a;
        }


    }
}

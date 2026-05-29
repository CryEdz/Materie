using System;
using System.Collections.Generic;
using System.Text;

namespace FigureGeometriche.Piane
{
    internal class Quadrato
    {
        //caratteristica 
        //attrubiti
        public double lato;

        //funzionalità
        //azioni
        //metodi
        public double Perimetro()
        {
            double p = lato *4;
            return p;
        }

        public double Area()
        {
            double a = lato * lato;
            return a;
        }
        public double Diagonale()
        {
            double d = lato * Math.Sqrt(2);
            return d;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseRettangolo
{
    internal class Rettangolo
    {
        private double _base;
        private double _altezza;

        public double Base
        {
            get { return _base; }
            set {
                if (value <= 0)
                    throw new Exception("Errore dato non valido");
                    _base = value;
            }
        }

        public double Altezza
        {
            get { return _altezza; }
            set {
                if (value <= 0)
                    throw new Exception("Errore dato non valido"); 
                _altezza = value;
            }
        }

        public double Perimetro()
        {
            return 2* (_base + _altezza);
        }
        public double Area()
        {
            return _base * _altezza;
        }
        public double Diagonale()
        {
            return Math.Sqrt(Math.Pow(_base, 2) + Math.Pow(_altezza, 2));
        }
    }
}

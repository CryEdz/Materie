using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Matite
{
    internal class Matita
    {
        private string marca;
        private string modello;
        private double lunghezza;

        public Matita()
        {
            lunghezza = 20;
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Modello
        {
            get { return modello; }
            set { modello = value; }
        }
        public double Lunghezza
        {
            get { return lunghezza; }
            set { lunghezza = value; }
        }
        public void Temperare()
        {
            lunghezza -= 0.5;
        }
        public override string ToString()
        {
            return base.ToString()
                           + $"Marca = {Marca}" +
                             $",Modello = {Modello}" +
                             $",Lunghezza = {Lunghezza}"
                            ;
        }
    }
}

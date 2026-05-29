using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseRismaCarta
{
    internal class Foglio
    {
        public string Formato { get; set; }
        public float Peso { get; set; } = 0.8f;

        public Foglio()
        {
            Formato = "A4";
        }

        public Foglio(string formato, float peso)
        {
            Formato = formato;
            Peso = peso;
        }
    }
}

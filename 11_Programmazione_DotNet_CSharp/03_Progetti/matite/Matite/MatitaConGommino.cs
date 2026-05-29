using System;
using System.Collections.Generic;
using System.Text;

namespace Matite
{
    internal class MatitaConGommino : Matita
    {
        private int gommino = 10;

        public void cancella ()
        {
            if (gommino > 0)
            {
                gommino--;
                Console.WriteLine($"Gommino usato! Gommini rimanenti: {gommino}");
            }
            else
            {
                Console.WriteLine("Gommino esaurito! Non puoi più cancellare.");
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Gommini = {gommino}";
        }
    }
}

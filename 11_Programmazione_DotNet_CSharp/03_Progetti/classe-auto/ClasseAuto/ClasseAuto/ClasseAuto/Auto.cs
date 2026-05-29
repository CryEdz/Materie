using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseAuto
{
    internal class Auto
    {
        private string marca;
        private string modello;
        private int cilindrata;
        private Alimentazione alimentazione;
        private string colore;

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

        public int Cilindrata
        {
            get { return cilindrata; }
            set { cilindrata = value; }
        }

        public Alimentazione Alimentazione
        {
            get { return alimentazione; }
            set { alimentazione = value; }
        }

        public string Colore
        {
            get { return colore; }
            set { colore = value; }
        }

        //metodi
        public int VelocitaMax()
        {
            int v = cilindrata / 10;

            switch (alimentazione)
            {
                case Alimentazione.BENZINA: v += 30; break;
                case Alimentazione.DIESEL: v += 20; break;
                case Alimentazione.GPL: v -= 10; break;
                case Alimentazione.METANO: v -= 30; break;
            }
            return v;
        }

        public string Stampa() {

            return $"" +
                $"Marca: {marca}" +
                $"\nModello: {modello}" +
                $"\nCilindrata: {cilindrata}" +
                $"\nAlimentazione: {alimentazione}" +
                $"\nColore: {colore}" +
                $"\nVelocità Max: {VelocitaMax()}"
                ;
        }

    }
}

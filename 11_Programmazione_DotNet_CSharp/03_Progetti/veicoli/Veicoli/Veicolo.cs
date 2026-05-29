using System;
using System.Collections.Generic;
using System.Text;

namespace Veicoli
{
    internal class Veicolo
    {
        public string Marca { get; set; }
        public string Modello { get; set; }
        public int Cilindrata { get; set; }
        public TipoCarburante Carburante { get; set; }
        public string Colore { get; set; }

        public int VelocitaMax()
        {
            int v = Cilindrata / 10;

            switch (Carburante)
            {
                case TipoCarburante.BENZINA: v += 30; break;
                case TipoCarburante.DIESEL: v += 20; break;
                case TipoCarburante.GPL: v -= 10; break;
                case TipoCarburante.METANO: v -= 30; break;
            }

            return v;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: " +
                $"{nameof(Marca)}={Marca}" +
                $", {nameof(Modello)}={Modello}" +
                $", {nameof(Cilindrata)}={Cilindrata.ToString()}" +
                $", {nameof(Carburante)}={Carburante.ToString()}" +
                $", {nameof(Colore)}={Colore}" 
                ;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseAuto
{
    internal class Auto
    {
        public int VelocitàMax()
        { int v = Cilindrata / 10;
            switch (Carburante)
            {
                case TipoCarburante.BENZINA: v += 30; break;
                    case TipoCarburante.DIESEL: v += 20; break;
                case TipoCarburante.GPL: v -= 20; break;
                    case TipoCarburante.METANO: v -= 30; break;

            } 
        }

        public override string ToString()
        {
            return $"{{}}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Solidi
{
    internal class PiramidePentagonale:Solido
    {
        //Riferimenti e risorse
        // Volume: https://www.youmath.it/domande-a-risposte/view/8114-piramide-pentagonale.html

        public double AreaBase { get; set; }
        public double Altezza { get; set; }

        public override double Volume()
        {
            return (AreaBase * Altezza) / 3.0;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: " +
                $"AreaBase={AreaBase} dm" +
                $", Altezza={Altezza} dm" +
                $", {base.ToString()}"
                ;
        }
    }
}

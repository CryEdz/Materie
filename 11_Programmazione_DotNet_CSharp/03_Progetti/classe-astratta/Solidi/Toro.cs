using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Solidi
{
    internal class Toro:Solido
    {
        //Riferimenti e risorse
        // Volume: https://www.calkoo.com/it/calcolatore-volume-toro

        public double RaggioMaggiore { get; set; }
        public double RaggioMinore { get; set; }

        public override double Volume()
        {
            return 2 * Math.Pow(Math.PI, 2) * RaggioMaggiore * Math.Pow(RaggioMinore, 2);
        }
        public override string ToString()
        {
            return $"{GetType().Name}: " +
                $"RaggioMaggiore={RaggioMaggiore} dm" +
                $", RaggioMinore={RaggioMinore} dm" +
                $", {base.ToString()}"
                ;
        }


    }
}

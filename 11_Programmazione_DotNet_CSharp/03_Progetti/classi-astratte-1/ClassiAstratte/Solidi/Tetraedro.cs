using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidi
{
    internal class Tetraedro:Cubo
    {   
        
        public Tetraedro(double lato, Materiale materiale):base(lato,materiale)
        {
            
        }

        public override double Volume()
        {
            return lato * 0.1179; //https://www.matematika.it/public/allegati/50/05_02_Volumi_superfici_figure_solide_3_0.pdf
        }        
    }
}

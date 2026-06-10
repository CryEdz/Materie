using System;
using System.Collections.Generic;
using System.Text;

namespace Atleti
{
    internal interface IAtletaUniversale:IAtleta, ITennista, INuotatore
    {
        //metodi astratti
        public string Mangio();
        public string Bevo();
    }
}

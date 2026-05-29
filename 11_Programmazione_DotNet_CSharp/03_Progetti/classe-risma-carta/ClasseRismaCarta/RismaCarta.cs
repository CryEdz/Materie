using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseRismaCarta
{
    internal class RismaCarta : Foglio
    {
        public const int FogliMassimi = 500;
        public string Marca { get; set; }
        public int NumeroFogli { get; set; }
        public float PesoRisma => NumeroFogli * Peso;
        public string StatoRisma => CalcolaStatoRisma();

        public RismaCarta(string marca, int numeroFogli) : base()
        {
            Marca = marca;
            NumeroFogli = numeroFogli;
        }

        private string CalcolaStatoRisma()
        {
            if (NumeroFogli == 0)
            {
                return "Esaurita";
            }

            if (NumeroFogli <= 30)
            {
                return "In esaurimento";
            }

            if (NumeroFogli == FogliMassimi)
            {
                return "Da iniziare";
            }

            return "Iniziata";
        }

        public override string ToString()
        {
            return $"{{{nameof(Marca)}={Marca}, " +
                $"{nameof(NumeroFogli)}={NumeroFogli}, " +
                $"{nameof(Formato)}={Formato}, " +
                $"{nameof(Peso)}={Peso}g, " +
                $"{nameof(PesoRisma)}={PesoRisma}g, " +
                $"{nameof(StatoRisma)}={StatoRisma}}}";
        }
    } 
}

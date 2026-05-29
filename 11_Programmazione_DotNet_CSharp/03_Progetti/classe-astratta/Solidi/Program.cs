using Solidi;

namespace Solidi
{
    internal class Program
    {
        /*
         * Riferimenti e risorse
         * 
         * Materiali: https://www.oppo.it/tabelle/pesi_specifici.html
         * Volumi:https://www.matematika.it/public/allegati/50/Volumi_figure_solide_1_3.pdf
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Istanze di Solidi!");

            double pesoSpecificoAcciaio = 7.85; // kg/dm3
            double pesoSpecificoAlluminio = 2.60; // kg/dm3
            double pesoSpecificoArgilla = 2.10; // kg/dm3
            double pesoSpecificoTungsteno = 19.10; // kg/dm3
            double pesoSpecificoPlatino = 21.45; // kg/dm3
            Solido s; // = new Solido();
        
            Cubo s1 = new Cubo() { Lato = 1, PesoSpecifico = pesoSpecificoAcciaio };
            Console.WriteLine(s1);

            Sfera s2 = new Sfera() { Raggio = 1, PesoSpecifico = pesoSpecificoAlluminio };
            Console.WriteLine(s2);

            PiramidePentagonale s3 = new PiramidePentagonale() { AreaBase = 1, Altezza = 1, PesoSpecifico = pesoSpecificoArgilla };
            Console.WriteLine(s3);
            
            Toro s4 = new Toro() { RaggioMaggiore = 1, RaggioMinore = 0.5, PesoSpecifico = pesoSpecificoTungsteno };
            Console.WriteLine(s4);

            Esacisicosaedro s5 = new Esacisicosaedro() { Spigolo = 1, PesoSpecifico = pesoSpecificoPlatino };
            Console.WriteLine(s5);

            //Array per raggruppare tutti gli oggetti
            Solido[] lista = { s1, s2, s3, s4, s5 };

            foreach(Solido solido in lista)
                Console.WriteLine(solido);
        }
    }
}



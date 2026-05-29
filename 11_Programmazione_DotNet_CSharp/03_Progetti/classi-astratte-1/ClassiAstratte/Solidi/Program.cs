namespace Solidi
{
    internal class Program
    {
        /// <summary>
        /// Si vuole calcolare il peso di un solido costruito con un certo materiale (ad esempio l'acciaio, il bronzo, l'alluminio, il platino, ecc...) di cui si conosce il peso specifico.
        /// 
        /// Si richiede la creazione delle seguenti istanze:
        ///  cubo di acciaio  e lato 12.5 dm
        ///  sfera di alluminio di raggio 5.5 dm
        ///  tetraedro di bronzo di lato 9 dm
        ///  cilindro di zinco di raggio 5 dm e altezza 7.5 dm
        ///  cono di stagno di raggio 8 dm e altezza 11.5 dm 
        ///  
        ///Visualizzare tutti i dati necessari        
        /// </summary>
               
        static void Main(string[] args)
        {
            Console.WriteLine("I Solidi!");

            //https://www.oppo.it/tabelle/pesi_specifici.html

            Materiale acciaio = new Materiale() { Denominazione = TipoMateriale.ACCIAIO, PesoSpecifico = 7.85 };
            Materiale alluminio = new Materiale() { Denominazione = TipoMateriale.ALLUMINIO, PesoSpecifico = 2.60 };
            Materiale bronzo = new Materiale() { Denominazione = TipoMateriale.BRONZO, PesoSpecifico = 7.40 };
            Materiale zinco = new Materiale() { Denominazione = TipoMateriale.ZINCO, PesoSpecifico = 7.10 };
            Materiale stagno = new Materiale() { Denominazione = TipoMateriale.STAGNO, PesoSpecifico = 7.28 };
            //acciaio: 7.85 kg/dm^3
            //alluminio: 2.60 kg/dm^3
            //bronzo (7,9%): 7.40 kg/dm^3
            //stagno: 7.28 kg/dm^3
            //zinco: 7.10 kg/dm^3 

            Solido s1;// = new Solido(7.85); //non ammessa

            Cubo cubo=new Cubo(12.5,acciaio);
            Console.WriteLine(cubo.StampaLineare());

            Sfera sfera=new Sfera(5.5,alluminio);
            Console.WriteLine(sfera.StampaLineare());

            Tetraedro tetraedro = new Tetraedro(12.5, bronzo);
            Console.WriteLine(tetraedro.StampaLineare());

            Cilindro cilindro = new Cilindro(5,7.5, stagno);
            Console.WriteLine(cilindro.StampaLineare());

            Cono cono = new Cono(8,11.5, zinco);
            Console.WriteLine(cono.StampaLineare());



        }
    }
}

using System;
using System.Collections.Generic;

namespace VenditaProdotti
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vendita Prodotti!");

            var lista = new List<Prodotto>
            {
                new ProdottoAlimentare {Codice=1122,Nome="Mozzarella",Prezzo=1.25,DataProduzione=new DateTime(2023,4,15),DataScadenza=new DateTime(2024,06,30) },
                new ProdottoAlimentare {Codice=1221,Nome="Prosciutto cotto",Prezzo=11.75,DataProduzione=new DateTime(2023,2,15),DataScadenza=new DateTime(2024,06,30) },
                new ProdottoAlimentare {Codice=1123,Nome="Antipasto",Prezzo=13.25,DataProduzione=new DateTime(2023,3,15),DataScadenza=new DateTime(2024,06,30) },
                new ProdottoAlimentare {Codice=1456,Nome="Petti di pollo",Prezzo=7.25,DataProduzione=new DateTime(2023,4,5),DataScadenza=new DateTime(2024,06,30) },
                new ProdottoAlimentare {Codice=1334,Nome="Coniglio",Prezzo=9.25,DataProduzione=new DateTime(2023,4,1),DataScadenza=new DateTime(2024,06,30) },
                new ProdottoAlimentare {Codice=1244,Nome="Formaggio",Prezzo=12.25,DataProduzione=new DateTime(2023,1,15),DataScadenza=new DateTime(2024,06,30) },
                new ProdottoAlimentare {Codice=1521,Nome="Latte",Prezzo=1.35,DataProduzione=new DateTime(2023,2,5),DataScadenza=new DateTime(2024,06,30) },
                new ProdottoAlimentare {Codice=1212,Nome="Yogurt",Prezzo=0.35,DataProduzione=new DateTime(2023,3,25),DataScadenza=new DateTime(2024,06,30) },
                new ProdottoAlimentare {Codice=1023,Nome="Prosciutto crudo",Prezzo=30.25,DataProduzione=new DateTime(2023,4,7),DataScadenza=new DateTime(2024,06,30) },
                new ProdottoNonAlimentare {Codice=1025,Nome="Imbuto",Prezzo=2.25,DataProduzione=new DateTime(2023,4,7),MateriePrime=new List<Materiale>{ new Materiale {Denominazione="Plastica", Percentuale=100 } } },
                new ProdottoNonAlimentare {Codice=1026,Nome="Tovaglia",Prezzo=12.25,DataProduzione=new DateTime(2023,4,7),MateriePrime=new List<Materiale>{ new Materiale {Denominazione="Cotone", Percentuale=90 }, new Materiale { Denominazione="Poliestere",Percentuale=5} } },
                new ProdottoNonAlimentare {Codice=1030,Nome="Tovaglioli",Prezzo=3.25,DataProduzione=new DateTime(2023,4,7),MateriePrime=new List<Materiale>{ new Materiale {Denominazione="Carta", Percentuale=100 } } },
                new ProdottoNonAlimentare {Codice=1031,Nome="Colla",Prezzo=1.25,DataProduzione=new DateTime(2023,4,7),MateriePrime=new List<Materiale>{ new Materiale {Denominazione="Plastica", Percentuale=100 } } }
            };

            var biz = new ProdottiBiz();
            biz.Elenco = lista;

            var menu = "\nScegli una tra le seguenti operazioni:" +
                "\n0 - Termina il programma" +
                "\n1 - Visualizza elenco prodotti" +
                "\n2 - Visualizza elenco prodotti in scadenza" +
                "\n3 - Visualizza elenco materie prime (prodotto)" +
                "\n\nScegli: ";
            int scelta=-1;

            do {

                Console.Write(menu);
                scelta = int.Parse(Console.ReadLine()!);
                switch (scelta)
                {
                    case 0: Console.WriteLine("Programma terminato"); break;
                    case 1: Console.WriteLine(biz.StampaElenco()); break;
                    case 2: Console.WriteLine(string.Join('\n',biz.ElencoProdottiInScadenza())); break;
                    case 3: Console.WriteLine(string.Join('\n', biz.ElencoProdottiPercentualeMateriaPrima())); break;
                    default: Console.WriteLine("Scelta errata!");break;
                }

                Console.Write("Premi un tasto per continuare ...");
                Console.ReadLine();
                Console.Clear();


            } while (scelta!=0);
            
        }
    }
}

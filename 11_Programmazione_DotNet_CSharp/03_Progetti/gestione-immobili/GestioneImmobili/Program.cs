using System;

namespace GestioneImmobili
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gestione Immobili!");

            var biz = new GestioneImmobiliBiz
            {
                Elenco = new Immobile[]
                {
                    new Box { Codice="B001",Indirizzo="Via Roma 10",Cap="10100",Citta="Torino",Superficie=20,Prezzo=25000,NumeroPostiAuto=1 },
                    new Box { Codice="B002",Indirizzo="Via Garibaldi 5",Cap="20100",Citta="Milano",Superficie=35,Prezzo=45000,NumeroPostiAuto=2 },
                    new Appartamento { Codice="A001",Indirizzo="Corso Francia 120",Cap="10100",Citta="Torino",Superficie=80,Prezzo=120000,NumeroVani=4,NumeroBagni=2 },
                    new Appartamento { Codice="A002",Indirizzo="Via Nazionale 25",Cap="00100",Citta="Roma",Superficie=65,Prezzo=95000,NumeroVani=3,NumeroBagni=1 },
                    new Villa { Codice="V001",Indirizzo="Via Collina 1",Cap="10020",Citta="Torino",Superficie=150,Prezzo=350000,NumeroVani=6,NumeroBagni=3,DimensioneGiardino=500 },
                    new Villa { Codice="V002",Indirizzo="Strada Panoramica 8",Cap="16100",Citta="Genova",Superficie=200,Prezzo=520000,NumeroVani=7,NumeroBagni=4,DimensioneGiardino=800 }
                }
            };

            string menu = "\nScegli una tra le seguenti operazioni:" +
                "\n1 - Visualizza il numero di immobili" +
                "\n2 - Visualizza l'elenco degli immobili" +
                "\n3 - Visualizza l'elenco degli appartamenti" +
                "\n4 - Visualizza l'elenco delle ville" +
                "\n5 - Visualizza l'elenco dei box" +
                "\n6 - Visualizza l'elenco degli immobili in una certa città" +
                "\n7 - Visualizza la scheda di dettaglio di un immobile (tramite codice)" +
                "\n8 - Produci elenco CSV" +
                "\n0 - Termina il programma" +
                "\n\nScelta: ";

            int scelta;
            do
            {
                Console.Write(menu);
                scelta = int.Parse(Console.ReadLine()!);

                switch (scelta)
                {
                    case 0:
                        Console.WriteLine("Programma terminato!");
                        break;

                    case 1:
                        Console.WriteLine($"Numero totale immobili: {biz.Elenco.Length}");
                        break;

                    case 2:
                        Console.WriteLine(biz.StampaElenco());
                        break;

                    case 3:
                        Console.WriteLine(biz.StampaAppartamenti());
                        break;

                    case 4:
                        Console.WriteLine(biz.StampaVille());
                        break;

                    case 5:
                        Console.WriteLine(biz.StampaBox());
                        break;

                    case 6:
                        {
                            Console.Write("Inserisci città: ");
                            string citta = Console.ReadLine()!;
                            Console.WriteLine(biz.StampaPerCitta(citta));
                        }
                        break;

                    case 7:
                        {
                            Console.Write("Inserisci codice immobile: ");
                            string codice = Console.ReadLine()!;
                            Console.WriteLine(biz.StampaDettaglio(codice));
                        }
                        break;

                    case 8:
                        {
                            Console.Write("Tipo elenco (Box, Appartamenti, Ville): ");
                            string tipo = Console.ReadLine()!;
                            biz.EsportaCSV(tipo);
                        }
                        break;

                    default:
                        Console.WriteLine("Scelta errata!");
                        break;
                }

                if (scelta != 0)
                {
                    Console.Write("\nPremi un tasto per continuare...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (scelta != 0);
        }
    }
}

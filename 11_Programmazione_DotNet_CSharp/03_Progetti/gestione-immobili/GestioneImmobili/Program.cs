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

                    // Box
                    new Box { Codice="B001",Indirizzo="Via Roma 10",Cap="10100",Citta="Torino",Superficie=20,Prezzo=25000,NumeroPostiAuto=1 },
                    new Box { Codice="B002",Indirizzo="Via Garibaldi 5",Cap="20100",Citta="Milano",Superficie=35,Prezzo=45000,NumeroPostiAuto=2 },
                    new Box { Codice="B003",Indirizzo="Via Monte Bianco 15",Cap="20100",Citta="Milano",Superficie=18,Prezzo=22000,NumeroPostiAuto=1 },
                    new Box { Codice="B004",Indirizzo="Via Roma 55",Cap="50100",Citta="Firenze",Superficie=25,Prezzo=30000,NumeroPostiAuto=1 },
                    new Box { Codice="B005",Indirizzo="Corso Venezia 3",Cap="20121",Citta="Milano",Superficie=30,Prezzo=38000,NumeroPostiAuto=2 },
                    new Box { Codice="B006",Indirizzo="Via Napoli 42",Cap="80100",Citta="Napoli",Superficie=22,Prezzo=28000,NumeroPostiAuto=1 },
                    new Box { Codice="B007",Indirizzo="Via Dante 18",Cap="40100",Citta="Bologna",Superficie=28,Prezzo=32000,NumeroPostiAuto=2 },
                    new Box { Codice="B008",Indirizzo="Via Garibaldi 33",Cap="16100",Citta="Genova",Superficie=15,Prezzo=18000,NumeroPostiAuto=1 },
                    new Box { Codice="B009",Indirizzo="Piazza Duomo 1",Cap="20122",Citta="Milano",Superficie=40,Prezzo=55000,NumeroPostiAuto=2 },
                    new Box { Codice="B010",Indirizzo="Via Roma 77",Cap="10100",Citta="Torino",Superficie=20,Prezzo=25000,NumeroPostiAuto=1 },
                    new Box { Codice="B011",Indirizzo="Via Mazzini 12",Cap="50100",Citta="Firenze",Superficie=32,Prezzo=40000,NumeroPostiAuto=2 },
                    new Box { Codice="B012",Indirizzo="Corso Italia 8",Cap="80100",Citta="Napoli",Superficie=19,Prezzo=23000,NumeroPostiAuto=1 },
                    new Box { Codice="B013",Indirizzo="Corso Umberto 45",Cap="80100",Citta="Napoli",Superficie=16,Prezzo=20000,NumeroPostiAuto=1 },
                    new Box { Codice="B014",Indirizzo="Via Manzoni 22",Cap="20100",Citta="Milano",Superficie=35,Prezzo=48000,NumeroPostiAuto=2 },
                    new Box { Codice="B015",Indirizzo="Viale Libertà 10",Cap="27100",Citta="Pavia",Superficie=24,Prezzo=27000,NumeroPostiAuto=1 },
                    new Box { Codice="B016",Indirizzo="Via Trento 30",Cap="38100",Citta="Trento",Superficie=20,Prezzo=29000,NumeroPostiAuto=1 },
                    new Box { Codice="B017",Indirizzo="Via Verdi 8",Cap="34100",Citta="Trieste",Superficie=26,Prezzo=31000,NumeroPostiAuto=2 },
                    // Appartamenti
                    new Appartamento { Codice="A001",Indirizzo="Corso Francia 120",Cap="10100",Citta="Torino",Superficie=80,Prezzo=120000,NumeroVani=4,NumeroBagni=2 },
                    new Appartamento { Codice="A002",Indirizzo="Via Nazionale 25",Cap="00100",Citta="Roma",Superficie=65,Prezzo=95000,NumeroVani=3,NumeroBagni=1 },
                    new Appartamento { Codice="A003",Indirizzo="Via Manzoni 30",Cap="20100",Citta="Milano",Superficie=90,Prezzo=145000,NumeroVani=4,NumeroBagni=2 },
                    new Appartamento { Codice="A004",Indirizzo="Via Po 15",Cap="10100",Citta="Torino",Superficie=55,Prezzo=85000,NumeroVani=3,NumeroBagni=1 },
                    new Appartamento { Codice="A005",Indirizzo="Via dell'Amore 10",Cap="50100",Citta="Firenze",Superficie=75,Prezzo=130000,NumeroVani=3,NumeroBagni=2 },
                    new Appartamento { Codice="A006",Indirizzo="Corso Vittorio Emanuele 50",Cap="80100",Citta="Napoli",Superficie=85,Prezzo=115000,NumeroVani=4,NumeroBagni=2 },
                    new Appartamento { Codice="A007",Indirizzo="Via Indipendenza 20",Cap="40100",Citta="Bologna",Superficie=70,Prezzo=110000,NumeroVani=3,NumeroBagni=1 },
                    new Appartamento { Codice="A008",Indirizzo="Via Balbi 5",Cap="16100",Citta="Genova",Superficie=60,Prezzo=90000,NumeroVani=3,NumeroBagni=1 },
                    new Appartamento { Codice="A009",Indirizzo="Piazza Navona 2",Cap="00100",Citta="Roma",Superficie=95,Prezzo=180000,NumeroVani=4,NumeroBagni=2 },
                    new Appartamento { Codice="A010",Indirizzo="Via San Marco 12",Cap="30100",Citta="Venezia",Superficie=50,Prezzo=160000,NumeroVani=2,NumeroBagni=1 },
                    new Appartamento { Codice="A011",Indirizzo="Via Roma 100",Cap="37100",Citta="Verona",Superficie=78,Prezzo=125000,NumeroVani=3,NumeroBagni=2 },
                    new Appartamento { Codice="A012",Indirizzo="Via Cavour 25",Cap="35100",Citta="Padova",Superficie=65,Prezzo=100000,NumeroVani=3,NumeroBagni=1 },
                    new Appartamento { Codice="A013",Indirizzo="Corso Magenta 8",Cap="25100",Citta="Brescia",Superficie=72,Prezzo=115000,NumeroVani=3,NumeroBagni=1 },
                    new Appartamento { Codice="A014",Indirizzo="Via XX Settembre 40",Cap="24100",Citta="Bergamo",Superficie=68,Prezzo=108000,NumeroVani=3,NumeroBagni=1 },
                    new Appartamento { Codice="A015",Indirizzo="Via Emilia 55",Cap="41100",Citta="Modena",Superficie=62,Prezzo=95000,NumeroVani=3,NumeroBagni=1 },
                    new Appartamento { Codice="A016",Indirizzo="Via Gramsci 15",Cap="43100",Citta="Parma",Superficie=58,Prezzo=88000,NumeroVani=3,NumeroBagni=1 },
                    new Appartamento { Codice="A017",Indirizzo="Viale della Repubblica 30",Cap="47900",Citta="Rimini",Superficie=70,Prezzo=120000,NumeroVani=3,NumeroBagni=2 },
                    // Ville
                    new Villa { Codice="V001",Indirizzo="Via Collina 1",Cap="10020",Citta="Torino",Superficie=150,Prezzo=350000,NumeroVani=6,NumeroBagni=3,DimensioneGiardino=500 },
                    new Villa { Codice="V002",Indirizzo="Strada Panoramica 8",Cap="16100",Citta="Genova",Superficie=200,Prezzo=520000,NumeroVani=7,NumeroBagni=4,DimensioneGiardino=800 },
                    new Villa { Codice="V003",Indirizzo="Via Appia Nuova 200",Cap="00100",Citta="Roma",Superficie=250,Prezzo=600000,NumeroVani=7,NumeroBagni=4,DimensioneGiardino=700 },
                    new Villa { Codice="V004",Indirizzo="Viale dei Colli 15",Cap="50100",Citta="Firenze",Superficie=180,Prezzo=420000,NumeroVani=6,NumeroBagni=3,DimensioneGiardino=400 },
                    new Villa { Codice="V005",Indirizzo="Via Posillipo 30",Cap="80100",Citta="Napoli",Superficie=220,Prezzo=480000,NumeroVani=6,NumeroBagni=3,DimensioneGiardino=300 },
                    new Villa { Codice="V006",Indirizzo="Via dei Platani 5",Cap="40100",Citta="Bologna",Superficie=160,Prezzo=380000,NumeroVani=5,NumeroBagni=3,DimensioneGiardino=350 },
                    new Villa { Codice="V007",Indirizzo="Corso Alpi 12",Cap="16100",Citta="Genova",Superficie=190,Prezzo=450000,NumeroVani=6,NumeroBagni=3,DimensioneGiardino=250 },
                    new Villa { Codice="V008",Indirizzo="Via Monte Grappa 3",Cap="20100",Citta="Milano",Superficie=280,Prezzo=750000,NumeroVani=8,NumeroBagni=4,DimensioneGiardino=600 },
                    new Villa { Codice="V009",Indirizzo="Strada della Vittoria 20",Cap="37100",Citta="Verona",Superficie=170,Prezzo=390000,NumeroVani=5,NumeroBagni=3,DimensioneGiardino=450 },
                    new Villa { Codice="V010",Indirizzo="Via delle Rose 7",Cap="35100",Citta="Padova",Superficie=155,Prezzo=340000,NumeroVani=5,NumeroBagni=2,DimensioneGiardino=300 },
                    new Villa { Codice="V011",Indirizzo="Viale Piave 18",Cap="25100",Citta="Brescia",Superficie=145,Prezzo=320000,NumeroVani=5,NumeroBagni=2,DimensioneGiardino=280 },
                    new Villa { Codice="V012",Indirizzo="Via Lunga 28",Cap="24100",Citta="Bergamo",Superficie=165,Prezzo=360000,NumeroVani=5,NumeroBagni=3,DimensioneGiardino=320 },
                    new Villa { Codice="V013",Indirizzo="Via Giardini 9",Cap="41100",Citta="Modena",Superficie=140,Prezzo=310000,NumeroVani=4,NumeroBagni=2,DimensioneGiardino=250 },
                    new Villa { Codice="V014",Indirizzo="Strada Nuova 22",Cap="43100",Citta="Parma",Superficie=150,Prezzo=330000,NumeroVani=5,NumeroBagni=2,DimensioneGiardino=300 },
                    new Villa { Codice="V015",Indirizzo="Via dei Tigli 12",Cap="23900",Citta="Lecco",Superficie=130,Prezzo=280000,NumeroVani=4,NumeroBagni=2,DimensioneGiardino=200 },
                    new Villa { Codice="V016",Indirizzo="Strada del Sole 33",Cap="09100",Citta="Cagliari",Superficie=200,Prezzo=460000,NumeroVani=6,NumeroBagni=3,DimensioneGiardino=500 }
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

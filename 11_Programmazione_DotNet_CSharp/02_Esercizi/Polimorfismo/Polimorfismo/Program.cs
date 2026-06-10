namespace Polimorfismo
{
    /// <summary>
    /// Classe principale del programma di gestione dipendenti.
    /// Gestisce il menu principale e la logica di filtraggio e visualizzazione dei dipendenti.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Metodo principale del programma.
        /// Inizializza l'elenco dei dipendenti e avvia il menu interattivo.
        /// </summary>
        static void Main(string[] args)
        {
            // Creazione della lista per contenere tutti i dipendenti
            List<Dipendente> dipendenti = new List<Dipendente>();

            // ===== AGGIUNTA AMMINISTRATIVI =====
            dipendenti.Add(new Amministrativo("Rossi", "Marco", 20, 160, Mansione.Contabile));
            dipendenti.Add(new Amministrativo("Bianchi", "Laura", 18, 160, Mansione.RisoreUmane));
            dipendenti.Add(new Amministrativo("Verdi", "Paolo", 25, 160, Mansione.Direttore));

            // ===== AGGIUNTA OPERAI NORMALI =====
            dipendenti.Add(new Operaio("Ferrari", "Antonio", 15, 160, TipoOperaio.Installatore));
            dipendenti.Add(new Operaio("Russo", "Giovanni", 14, 160, TipoOperaio.Manutentore));
            dipendenti.Add(new Operaio("Gallo", "Francesca", 16, 170, TipoOperaio.Installatore));
            dipendenti.Add(new Operaio("Conti", "Michele", 15, 160, TipoOperaio.Manutentore));

            // ===== AGGIUNTA OPERAI SPECIALIZZATI =====
            // Operaio specializzato con due missioni
            OperaioSpecializzato operarioSpec1 = new OperaioSpecializzato("Barbieri", "Carlo", 17, 160, TipoOperaio.Installatore);
            operarioSpec1.AggiungiMissione(new Missione("Piattaforma Nord", 500));
            operarioSpec1.AggiungiMissione(new Missione("Piattaforma Sud", 400));
            dipendenti.Add(operarioSpec1);

            // Operaio specializzato manutentore con una missione
            OperaioSpecializzato operarioSpec2 = new OperaioSpecializzato("Martini", "Roberto", 18, 160, TipoOperaio.Manutentore);
            operarioSpec2.AggiungiMissione(new Missione("Riparazione Piattaforma Est", 600));
            dipendenti.Add(operarioSpec2);

            // Operaio specializzato installatore con una missione
            OperaioSpecializzato operarioSpec3 = new OperaioSpecializzato("Colombo", "Alessandra", 16, 170, TipoOperaio.Installatore);
            operarioSpec3.AggiungiMissione(new Missione("Piattaforma Ovest", 550));
            dipendenti.Add(operarioSpec3);

            // ===== MENU PRINCIPALE INTERATTIVO =====
            bool continua = true;
            while (continua)
            {
                MostraMenu();
                string? scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        VisualizzaTuttiDipendenti(dipendenti);
                        break;
                    case "2":
                        VisualizzaAmministrativi(dipendenti);
                        break;
                    case "3":
                        VisualizzaOperai(dipendenti);
                        break;
                    case "4":
                        VisualizzaOperaiSpecializzati(dipendenti);
                        break;
                    case "5":
                        VisualizzaOperaiStipendioAlto(dipendenti);
                        break;
                    case "6":
                        VisualizzaOperaiManutentori(dipendenti);
                        break;
                    case "7":
                        VisualizzaSchedaDirettore(dipendenti);
                        break;
                    case "8":
                        VisualizzaTotaleStipendi(dipendenti);
                        break;
                    case "9":
                        continua = false;
                        Console.WriteLine("Arrivederci!");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

                if (continua)
                {
                    Console.WriteLine("Premi un tasto per continuare...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Visualizza il menu principale con le 9 opzioni disponibili.
        /// </summary>
        static void MostraMenu()
        {
            Console.WriteLine("=== MENU GESTIONE DIPENDENTI ===");
            Console.WriteLine("1. Visualizzare l'elenco dei dipendenti con tutti i loro dati");
            Console.WriteLine("2. Visualizzare l'elenco degli amministrativi");
            Console.WriteLine("3. Visualizzare l'elenco degli operai");
            Console.WriteLine("4. Visualizzare l'elenco degli operai specializzati");
            Console.WriteLine("5. Visualizzare l'elenco degli operai che hanno stipendio superiore a 2000,00 euro");
            Console.WriteLine("6. Visualizzare l'elenco degli operai manutentori");
            Console.WriteLine("7. Visualizzare la scheda in dettaglio del direttore amministrativo");
            Console.WriteLine("8. Visualizzare il totale degli stipendi da pagare");
            Console.WriteLine("9. Uscire dal programma");
            Console.Write("Scegli un'opzione: ");
        }

        /// <summary>
        /// Visualizza l'elenco completo di tutti i dipendenti con i loro dati.
        /// </summary>
        /// <param name="dipendenti">Lista dei dipendenti da visualizzare</param>
        static void VisualizzaTuttiDipendenti(List<Dipendente> dipendenti)
        {
            Console.Clear();
            Console.WriteLine("=== ELENCO TUTTI DIPENDENTI ===\n");
            foreach (var dipendente in dipendenti)
            {
                dipendente.Visualizza();
            }
        }

        /// <summary>
        /// Visualizza l'elenco dei dipendenti amministrativi (escludendo gli operai specializzati).
        /// </summary>
        /// <param name="dipendenti">Lista dei dipendenti da filtrare</param>
        static void VisualizzaAmministrativi(List<Dipendente> dipendenti)
        {
            Console.Clear();
            Console.WriteLine("=== ELENCO AMMINISTRATIVI ===\n");
            // Filtra solo gli amministrativi, escludendo gli operai specializzati
            var amministrativi = dipendenti.OfType<Amministrativo>().Where(a => !(a is OperaioSpecializzato)).ToList();
            if (amministrativi.Count == 0)
            {
                Console.WriteLine("Nessun amministrativo trovato.");
                return;
            }
            foreach (var admin in amministrativi)
            {
                admin.Visualizza();
            }
        }

        /// <summary>
        /// Visualizza l'elenco di tutti gli operai (inclusi gli operai specializzati).
        /// </summary>
        /// <param name="dipendenti">Lista dei dipendenti da filtrare</param>
        static void VisualizzaOperai(List<Dipendente> dipendenti)
        {
            Console.Clear();
            Console.WriteLine("=== ELENCO OPERAI ===\n");
            // Filtra tutti gli operai utilizzando OfType<Operaio>()
            var operai = dipendenti.OfType<Operaio>().ToList();
            if (operai.Count == 0)
            {
                Console.WriteLine("Nessun operaio trovato.");
                return;
            }
            foreach (var operaio in operai)
            {
                operaio.Visualizza();
            }
        }

        /// <summary>
        /// Visualizza l'elenco degli operai specializzati che effettuano missioni oceaniche.
        /// </summary>
        /// <param name="dipendenti">Lista dei dipendenti da filtrare</param>
        static void VisualizzaOperaiSpecializzati(List<Dipendente> dipendenti)
        {
            Console.Clear();
            Console.WriteLine("=== ELENCO OPERAI SPECIALIZZATI ===\n");
            // Filtra solo gli operai specializzati
            var operaiSpec = dipendenti.OfType<OperaioSpecializzato>().ToList();
            if (operaiSpec.Count == 0)
            {
                Console.WriteLine("Nessun operaio specializzato trovato.");
                return;
            }
            foreach (var operaio in operaiSpec)
            {
                operaio.Visualizza();
            }
        }

        /// <summary>
        /// Visualizza l'elenco degli operai che hanno uno stipendio superiore a 2000,00 euro.
        /// Include sia operai normali che operai specializzati.
        /// </summary>
        /// <param name="dipendenti">Lista dei dipendenti da filtrare</param>
        static void VisualizzaOperaiStipendioAlto(List<Dipendente> dipendenti)
        {
            Console.Clear();
            Console.WriteLine("=== OPERAI CON STIPENDIO > 2000,00 EURO ===\n");
            // Filtra gli operai con stipendio superiore a 2000 euro
            var operaiAlto = dipendenti.OfType<Operaio>()
                                       .Where(o => o.CalcolaStipendio() > 2000)
                                       .ToList();
            if (operaiAlto.Count == 0)
            {
                Console.WriteLine("Nessun operaio con stipendio superiore a 2000,00 euro.");
                return;
            }
            foreach (var operaio in operaiAlto)
            {
                operaio.Visualizza();
            }
        }

        /// <summary>
        /// Visualizza l'elenco degli operai manutentori (escludendo gli installatori).
        /// Include sia operai normali che operai specializzati manutentori.
        /// </summary>
        /// <param name="dipendenti">Lista dei dipendenti da filtrare</param>
        static void VisualizzaOperaiManutentori(List<Dipendente> dipendenti)
        {
            Console.Clear();
            Console.WriteLine("=== ELENCO OPERAI MANUTENTORI ===\n");
            // Filtra gli operai il cui tipo è Manutentore
            var manutentori = dipendenti.OfType<Operaio>()
                                        .Where(o => o.Tipo == TipoOperaio.Manutentore)
                                        .ToList();
            if (manutentori.Count == 0)
            {
                Console.WriteLine("Nessun operaio manutentore trovato.");
                return;
            }
            foreach (var manutentore in manutentori)
            {
                manutentore.Visualizza();
            }
        }

        /// <summary>
        /// Visualizza la scheda dettagliata del direttore amministrativo.
        /// </summary>
        /// <param name="dipendenti">Lista dei dipendenti dove cercare il direttore</param>
        static void VisualizzaSchedaDirettore(List<Dipendente> dipendenti)
        {
            Console.Clear();
            Console.WriteLine("=== SCHEDA DIRETTORE AMMINISTRATIVO ===\n");
            // Cerca il primo amministrativo con mansione Direttore
            var direttore = dipendenti.OfType<Amministrativo>()
                                     .FirstOrDefault(a => a.Mansione == Mansione.Direttore);
            if (direttore == null)
            {
                Console.WriteLine("Nessun direttore trovato.");
                return;
            }
            direttore.Visualizza();
        }

        /// <summary>
        /// Calcola e visualizza il totale degli stipendi da pagare a tutti i dipendenti.
        /// </summary>
        /// <param name="dipendenti">Lista dei dipendenti per il calcolo totale</param>
        static void VisualizzaTotaleStipendi(List<Dipendente> dipendenti)
        {
            Console.Clear();
            Console.WriteLine("=== TOTALE STIPENDI DA PAGARE ===\n");
            // Calcola la somma di tutti gli stipendi utilizzando il polimorfismo
            decimal totale = 0;
            foreach (var dipendente in dipendenti)
            {
                totale += dipendente.CalcolaStipendio();
            }
            Console.WriteLine($"Totale stipendi: {totale:C}");
            Console.WriteLine();
        }
    }
}

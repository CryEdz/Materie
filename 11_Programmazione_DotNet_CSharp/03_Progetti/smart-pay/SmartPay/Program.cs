using SmartPay.Dominio;

namespace SmartPay
{
    /// <summary>
    /// Classe di test e simulazione del sistema di pagamento SmartPay.
    /// 
    /// Scopo:
    /// - Dimostrare il funzionamento completo del sistema
    /// - Evidenziare il polimorfismo: stessi metodi, implementazioni diverse
    /// - Testare sia pagamenti con carta che bonifici
    /// - Simulare scenari realistici di e-commerce
    /// 
    /// Il test implementa il Principle of Substitutability:
    /// la variabile _metodoPagamento può referenziare qualsiasi classe
    /// che eredita da MetodoPagamento, senza cambiare la logica del carrello.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                     SISTEMA SMARTPAY v1.0                         ║");
            Console.WriteLine("║              Gestione Pagamenti Carrello Elettronico              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝\n");

            // ========== SCENARIO 1: Pagamento con Carta di Credito ==========
            Console.WriteLine("▶ SCENARIO 1: Pagamento con Carta di Credito");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────\n");
            EseguiTestCartaCredito();

            Console.WriteLine("\n");

            // ========== SCENARIO 2: Pagamento con Bonifico Bancario ==========
            Console.WriteLine("▶ SCENARIO 2: Pagamento con Bonifico Bancario");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────\n");
            EseguiTestBonifico();

            Console.WriteLine("\n");

            // ========== SCENARIO 3: Polimorfismo Dimostrato ==========
            Console.WriteLine("▶ SCENARIO 3: Dimostrazione del Polimorfismo");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────\n");
            EseguiTestPolimorfismo();

            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  Fine della Simulazione                           ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝\n");

            Console.WriteLine("Premere un tasto per terminare...");
            Console.ReadKey();
        }

        /// <summary>
        /// Test 1: Pagamento con Carta di Credito
        /// 
        /// Flusso:
        /// 1. Crea un carrello
        /// 2. Aggiunge articoli
        /// 3. Crea un pagamento con carta
        /// 4. Imposta il metodo di pagamento
        /// 5. Esegue il pagamento
        /// 6. Stampa il risultato
        /// </summary>
        static void EseguiTestCartaCredito()
        {
            // Creazione del carrello
            Carrello carrello = new Carrello();
            Console.WriteLine("✓ Carrello creato");

            // Aggiunta di articoli
            carrello.AggiungiArticolo(29.99m, "Libro 'Clean Code'");
            carrello.AggiungiArticolo(15.50m, "Libro 'Design Patterns'");
            carrello.AggiungiArticolo(12.99m, "Libro 'SOLID Principles'");
            Console.WriteLine("✓ Articoli aggiunti al carrello");

            // Riepilogo del carico
            Console.WriteLine($"\nArticoli: {carrello.ObtieniDescrizioneCarico()}");
            Console.WriteLine($"Importo totale: €{carrello.ObtieniImportoTotale():F2}\n");

            // Creazione del pagamento con carta di credito
            MetodoPagamento pagamentoCartaCredito = new PagamentoCartaCredito(
                carrello.ObtieniImportoTotale(),
                "Mario Rossi",
                "4532"
            );
            Console.WriteLine("✓ Metodo di pagamento creato: Carta di Credito");
            Console.WriteLine($"  Titolare: Mario Rossi");
            Console.WriteLine($"  Ultimi 4 digit: ****4532\n");

            // Impostazione del metodo di pagamento
            carrello.ImpostaMetodoPagamento(pagamentoCartaCredito);
            Console.WriteLine("✓ Metodo di pagamento impostato nel carrello\n");

            // Esecuzione del pagamento
            Console.WriteLine("⧖ Elaborazione del pagamento...");
            bool risultato = carrello.EffettuaPagamento();
            Console.WriteLine();

            // Stampa del risultato
            if (risultato)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✓ PAGAMENTO RIUSCITO ✓");
                Console.ResetColor();
                Console.WriteLine($"  Metodo: {pagamentoCartaCredito.ObtieniNomeMetodo()}");
                Console.WriteLine($"  Importo: €{pagamentoCartaCredito.ObtieniImporto():F2}");
                Console.WriteLine($"  Stato: {pagamentoCartaCredito.ObtieniStato()}");
                Console.WriteLine($"  ID Transazione: {pagamentoCartaCredito.ObtieniIdTransazione()}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✗ PAGAMENTO FALLITO ✗");
                Console.ResetColor();
                Console.WriteLine($"  Metodo: {pagamentoCartaCredito.ObtieniNomeMetodo()}");
                Console.WriteLine($"  Importo: €{pagamentoCartaCredito.ObtieniImporto():F2}");
                Console.WriteLine($"  Stato: {pagamentoCartaCredito.ObtieniStato()}");
            }

            Console.WriteLine($"\n{carrello.ToString()}");
        }

        /// <summary>
        /// Test 2: Pagamento con Bonifico Bancario
        /// 
        /// Flusso:
        /// 1. Crea un carrello
        /// 2. Aggiunge articoli
        /// 3. Crea un pagamento con bonifico
        /// 4. Imposta il metodo di pagamento
        /// 5. Esegue il pagamento
        /// 6. Stampa il risultato con tempo di elaborazione
        /// </summary>
        static void EseguiTestBonifico()
        {
            // Creazione del carrello
            Carrello carrello = new Carrello();
            Console.WriteLine("✓ Carrello creato");

            // Aggiunta di articoli
            carrello.AggiungiArticolo(50.00m, "Monitor 27 pollici");
            carrello.AggiungiArticolo(120.00m, "Tastiera meccanica");
            Console.WriteLine("✓ Articoli aggiunti al carrello");

            // Riepilogo del carico
            Console.WriteLine($"\nArticoli: {carrello.ObtieniDescrizioneCarico()}");
            Console.WriteLine($"Importo totale: €{carrello.ObtieniImportoTotale():F2}\n");

            // Creazione del pagamento con bonifico
            MetodoPagamento pagamentoBonifico = new PagamentoBonifico(
                carrello.ObtieniImportoTotale(),
                "Luigi Bianchi",
                "IT60X0542811101000000123456",
                "IT70G0100003100009101234567",
                "Acquisto attrezzature informatiche"
            );
            Console.WriteLine("✓ Metodo di pagamento creato: Bonifico Bancario");
            Console.WriteLine($"  Mittente: Luigi Bianchi");
            Console.WriteLine($"  Causale: Acquisto attrezzature informatiche\n");

            // Impostazione del metodo di pagamento
            carrello.ImpostaMetodoPagamento(pagamentoBonifico);
            Console.WriteLine("✓ Metodo di pagamento impostato nel carrello\n");

            // Esecuzione del pagamento
            Console.WriteLine("⧖ Elaborazione del bonifico...");
            bool risultato = carrello.EffettuaPagamento();
            Console.WriteLine();

            // Stampa del risultato
            if (risultato)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✓ BONIFICO ACCETTATO ✓");
                Console.ResetColor();
                Console.WriteLine($"  Metodo: {pagamentoBonifico.ObtieniNomeMetodo()}");
                Console.WriteLine($"  Importo: €{pagamentoBonifico.ObtieniImporto():F2}");
                Console.WriteLine($"  Stato: {pagamentoBonifico.ObtieniStato()}");
                Console.WriteLine($"  ID Transazione: {pagamentoBonifico.ObtieniIdTransazione()}");

                // Dettagli specifici del bonifico
                PagamentoBonifico bonus = (PagamentoBonifico)pagamentoBonifico;
                Console.WriteLine($"  Giorni di elaborazione stimati: {bonus.ObtieniGiorniElaborazione()}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✗ BONIFICO RIFIUTATO ✗");
                Console.ResetColor();
                Console.WriteLine($"  Metodo: {pagamentoBonifico.ObtieniNomeMetodo()}");
                Console.WriteLine($"  Importo: €{pagamentoBonifico.ObtieniImporto():F2}");
                Console.WriteLine($"  Stato: {pagamentoBonifico.ObtieniStato()}");
            }

            Console.WriteLine($"\n{carrello.ToString()}");
        }

        /// <summary>
        /// Test 3: Dimostrazione del Polimorfismo
        /// 
        /// Questo test evidenzia come il codice del carrello non conosce
        /// il tipo concreto del metodo di pagamento.
        /// 
        /// Principio dimostrato:
        /// - Liskov Substitution Principle: qualsiasi implementazione di
        ///   MetodoPagamento può essere usata in place di MetodoPagamento
        /// - Open/Closed Principle: il carrello è chiuso alla modifica
        ///   ma aperto all'estensione (nuovi metodi di pagamento)
        /// </summary>
        static void EseguiTestPolimorfismo()
        {
            Console.WriteLine("Questo test dimostra come il POLIMORFISMO consente di trattare");
            Console.WriteLine("diversi metodi di pagamento in modo uniforme.\n");

            // Array di metodi di pagamento diversi (simulato con due variabili separate)
            // In C# normalmente useremmo un array, ma il vincolo vieta le collezioni
            // Quindi dimostriamo il concetto con due pagamenti gestiti allo stesso modo

            decimal importo = 100.00m;

            // Primo metodo: Carta di Credito
            MetodoPagamento metodo1 = new PagamentoCartaCredito(importo, "Antonio Verdi", "5678");
            Console.WriteLine($"Metodo 1: {metodo1.ObtieniNomeMetodo()}");
            Console.WriteLine($"  Tipo: {metodo1.GetType().Name}");
            Console.WriteLine($"  Importo: €{metodo1.ObtieniImporto():F2}");

            // Secondo metodo: Bonifico
            MetodoPagamento metodo2 = new PagamentoBonifico(
                importo,
                "Francesca Neri",
                "IT80X0300203280000000000000",
                "IT90Y0076015500000000700003",
                "Pagamento fattura"
            );
            Console.WriteLine($"\nMetodo 2: {metodo2.ObtieniNomeMetodo()}");
            Console.WriteLine($"  Tipo: {metodo2.GetType().Name}");
            Console.WriteLine($"  Importo: €{metodo2.ObtieniImporto():F2}");

            Console.WriteLine("\n" + new string('─', 70));
            Console.WriteLine("Osservazione fondamentale:");
            Console.WriteLine("─────────────────────────");
            Console.WriteLine("Entrambi gli oggetti sono di tipo MetodoPagamento (polimorfismo)");
            Console.WriteLine("ma hanno tipi concreti diversi (PagamentoCartaCredito e PagamentoBonifico)");
            Console.WriteLine("\nIl carrello può gestire qualsiasi implementazione di MetodoPagamento");
            Console.WriteLine("senza conoscerne il tipo concreto. Questo è il potere del polimorfismo!");
            Console.WriteLine("─" + new string('─', 70));

            Console.WriteLine($"\nMetodo 1 è di tipo MetodoPagamento: {metodo1 is MetodoPagamento}");
            Console.WriteLine($"Metodo 1 è di tipo PagamentoCartaCredito: {metodo1 is PagamentoCartaCredito}");
            Console.WriteLine($"\nMetodo 2 è di tipo MetodoPagamento: {metodo2 is MetodoPagamento}");
            Console.WriteLine($"Metodo 2 è di tipo PagamentoBonifico: {metodo2 is PagamentoBonifico}");
        }
    }
}


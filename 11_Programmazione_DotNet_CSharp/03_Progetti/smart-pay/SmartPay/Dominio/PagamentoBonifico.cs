namespace SmartPay.Dominio
{
    /// <summary>
    /// Implementazione concreta di MetodoPagamento per i bonifici bancari.
    /// 
    /// Responsabilità:
    /// - Simulare il processo di pagamento tramite bonifico bancario
    /// - Gestire dati specifici dell'iban e del beneficiario
    /// - Emulare la verifica del conto bancario
    /// 
    /// Vincoli rispettati:
    /// - Non utilizza collezioni
    /// - Estende la classe astratta MetodoPagamento
    /// - Implementa il metodo astratto ProcessaPagamento()
    /// 
    /// Note:
    /// I bonifici sono tipicamente più lenti delle carte di credito
    /// La simulazione riflette questa caratteristica
    /// </summary>
    public class PagamentoBonifico : MetodoPagamento
    {
        /// <summary>
        /// IBAN del conto mittente (memorizzato parzialmente per privacy)
        /// </summary>
        private string _ibanMittente;

        /// <summary>
        /// Nome del proprietario del conto mittente
        /// </summary>
        private string _nomeMittente;

        /// <summary>
        /// IBAN del conto beneficiario
        /// </summary>
        private string _ibanBeneficiario;

        /// <summary>
        /// Causale del bonifico
        /// </summary>
        private string _causale;

        /// <summary>
        /// Numero di giorni previsti per l'elaborazione del bonifico
        /// </summary>
        private int _giorniElaborazione;

        /// <summary>
        /// Costruttore che inizializza il pagamento tramite bonifico
        /// </summary>
        /// <param name="importo">Importo da pagare</param>
        /// <param name="nomeMittente">Nome del proprietario del conto mittente</param>
        /// <param name="ibanMittente">IBAN del conto mittente (formato ITXX0123456789...)</param>
        /// <param name="ibanBeneficiario">IBAN del conto beneficiario</param>
        /// <param name="causale">Motivo/descrizione del bonifico</param>
        public PagamentoBonifico(decimal importo, string nomeMittente, string ibanMittente, 
                                 string ibanBeneficiario, string causale)
            : base(importo)
        {
            if (string.IsNullOrWhiteSpace(nomeMittente))
                throw new ArgumentException("Il nome del mittente non può essere vuoto.", nameof(nomeMittente));

            if (string.IsNullOrWhiteSpace(ibanMittente) || !ValidaIban(ibanMittente))
                throw new ArgumentException("IBAN mittente non valido.", nameof(ibanMittente));

            if (string.IsNullOrWhiteSpace(ibanBeneficiario) || !ValidaIban(ibanBeneficiario))
                throw new ArgumentException("IBAN beneficiario non valido.", nameof(ibanBeneficiario));

            if (string.IsNullOrWhiteSpace(causale))
                throw new ArgumentException("La causale non può essere vuota.", nameof(causale));

            _nomeMittente = nomeMittente;
            _ibanMittente = ibanMittente;
            _ibanBeneficiario = ibanBeneficiario;
            _causale = causale;
            _giorniElaborazione = 0; // Verrà impostato dopo l'elaborazione
        }

        /// <summary>
        /// Implementazione specifica della logica di pagamento tramite bonifico.
        /// 
        /// Flusso di simulazione:
        /// 1. Valida i dati bancari
        /// 2. Verifica disponibilità dei fondi
        /// 3. Contatta il sistema interbancario (simulato)
        /// 4. Registra la transazione nel circuito bancario
        /// 5. Calcola il tempo di elaborazione
        /// 6. Ritorna l'esito
        /// </summary>
        /// <returns>true se il bonifico è stato accettato, false altrimenti</returns>
        protected override bool ProcessaPagamento()
        {
            // Validazione dei dati bancari
            if (!ValidaDatiBancari())
            {
                RegistraErrore("Dati bancari non validi");
                return false;
            }

            // Verifica disponibilità dei fondi
            if (!VerificaFondiDisponibili())
            {
                RegistraErrore("Fondi insufficienti nel conto");
                return false;
            }

            // Contatto al sistema interbancario
            if (!ContattaSistemaInterbancario())
            {
                RegistraErrore("Errore nella comunicazione con il sistema bancario");
                return false;
            }

            // Registrazione nel circuito bancario
            RegistraBonifico();

            // Calcolo del tempo di elaborazione (simulato)
            CalcolaTempoElaborazione();

            return true;
        }

        /// <summary>
        /// Validazione semplificata di un IBAN italiano
        /// </summary>
        private bool ValidaIban(string iban)
        {
            // Controllo: lunghezza minima, comincia con IT
            if (string.IsNullOrEmpty(iban) || iban.Length < 15)
                return false;

            if (!iban.StartsWith("IT", StringComparison.OrdinalIgnoreCase))
                return false;

            // Nella realtà si userebbe l'algoritmo mod-97
            // Per semplicità didattica, accettiamo il formato base
            return true;
        }

        /// <summary>
        /// Valida la completezza dei dati bancari
        /// </summary>
        private bool ValidaDatiBancari()
        {
            // Controlli di base
            return !string.IsNullOrEmpty(_nomeMittente) &&
                   !string.IsNullOrEmpty(_ibanMittente) &&
                   !string.IsNullOrEmpty(_ibanBeneficiario) &&
                   !string.IsNullOrEmpty(_causale);
        }

        /// <summary>
        /// Simula il controllo dei fondi disponibili
        /// </summary>
        private bool VerificaFondiDisponibili()
        {
            // Simulazione: 92% di probabilità di fondi sufficienti
            bool fondiSufficenti = new Random().Next(100) < 92;
            return fondiSufficenti;
        }

        /// <summary>
        /// Simula il contatto con il sistema interbancario (SWIFT, SEPA, ecc.)
        /// </summary>
        private bool ContattaSistemaInterbancario()
        {
            // Simulazione: i bonifici sono più lenti, quindi aggiungiamo un ritardo
            System.Threading.Thread.Sleep(150);

            // Simulazione: 96% di probabilità di successo
            bool successo = new Random().Next(100) < 96;
            return successo;
        }

        /// <summary>
        /// Simula la registrazione del bonifico nel circuito bancario
        /// </summary>
        private void RegistraBonifico()
        {
            // In un sistema reale, qui salveremmo su database e spediremmo al circuito interbancario
        }

        /// <summary>
        /// Calcola il tempo stimato di elaborazione del bonifico
        /// </summary>
        private void CalcolaTempoElaborazione()
        {
            // I bonifici SEPA in UE: 1 giorno lavorativo
            // Simulazione: tra 1 e 3 giorni lavorativi
            _giorniElaborazione = new Random().Next(1, 4);
        }

        /// <summary>
        /// Registra un messaggio di errore
        /// </summary>
        private void RegistraErrore(string messaggio)
        {
            // In un sistema reale, qui scriveremmo su log
        }

        /// <summary>
        /// Restituisce il nome descrittivo del metodo
        /// </summary>
        public override string ObtieniNomeMetodo() => "Bonifico Bancario";

        /// <summary>
        /// Restituisce il numero di giorni di elaborazione stimato
        /// </summary>
        public int ObtieniGiorniElaborazione() => _giorniElaborazione;

        /// <summary>
        /// Restituisce i dettagli del bonifico (mascherati per privacy)
        /// </summary>
        public string ObtieniDettagliBonifico()
        {
            string ibanMaskerato = MascheraIban(_ibanMittente);
            return $"Da: {_nomeMittente} ({ibanMaskerato}) | Causale: {_causale}";
        }

        /// <summary>
        /// Maschera un IBAN per motivi di privacy
        /// </summary>
        private string MascheraIban(string iban)
        {
            if (iban.Length < 4)
                return "****";
            return iban.Substring(0, 2) + "**" + iban.Substring(iban.Length - 4);
        }

        /// <summary>
        /// Override di ToString per includere dettagli del bonifico
        /// </summary>
        public override string ToString()
        {
            return $"{base.ToString()} | Dettagli: {ObtieniDettagliBonifico()} | Giorni: {_giorniElaborazione}";
        }
    }
}

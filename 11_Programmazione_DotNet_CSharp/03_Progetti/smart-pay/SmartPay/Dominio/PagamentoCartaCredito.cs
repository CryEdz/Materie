namespace SmartPay.Dominio
{
    /// <summary>
    /// Implementazione concreta di MetodoPagamento per i pagamenti con carta di credito.
    /// 
    /// Responsabilità:
    /// - Simulare il processo di pagamento con carta di credito
    /// - Gestire validazioni specifiche (numero carta, CVV, data scadenza)
    /// - Emulare l'interazione con un gateway di pagamento
    /// 
    /// Vincoli rispettati:
    /// - Non utilizza collezioni
    /// - Estende la classe astratta MetodoPagamento
    /// - Implementa il metodo astratto ProcessaPagamento()
    /// </summary>
    public class PagamentoCartaCredito : MetodoPagamento
    {
        /// <summary>
        /// Ultimi 4 digit della carta di credito (per privacy)
        /// </summary>
        private string _ultimi4Cifre;

        /// <summary>
        /// Nome del titolare della carta
        /// </summary>
        private string _intestatario;

        /// <summary>
        /// Costruttore che inizializza il pagamento con carta di credito
        /// </summary>
        /// <param name="importo">Importo da pagare</param>
        /// <param name="intestatario">Nome di chi intestatario della carta</param>
        /// <param name="ultimi4Cifre">Ultimi 4 digit della carta (es. "1234")</param>
        public PagamentoCartaCredito(decimal importo, string intestatario, string ultimi4Cifre)
            : base(importo)
        {
            if (string.IsNullOrWhiteSpace(intestatario))
                throw new ArgumentException("L'intestatario non può essere vuoto.", nameof(intestatario));

            if (string.IsNullOrWhiteSpace(ultimi4Cifre) || ultimi4Cifre.Length != 4 || !ultimi4Cifre.All(char.IsDigit))
                throw new ArgumentException("Gli ultimi 4 digit devono essere 4 cifre numeriche.", nameof(ultimi4Cifre));

            _intestatario = intestatario;
            _ultimi4Cifre = ultimi4Cifre;
        }

        /// <summary>
        /// Implementazione specifica della logica di pagamento con carta di credito.
        /// 
        /// Flusso di simulazione:
        /// 1. Valida lo stato della carta
        /// 2. Verifica disponibilità di credito
        /// 3. Contatta il gateway di pagamento (simulato)
        /// 4. Registra la transazione
        /// 5. Ritorna l'esito
        /// </summary>
        /// <returns>true se il pagamento è stato autorizzato, false altrimenti</returns>
        protected override bool ProcessaPagamento()
        {
            // Simulazione: verifica dello stato della carta
            if (!VerificaCartaValida())
            {
                RegistraErrore("Carta non valida o scaduta");
                return false;
            }

            // Simulazione: verifica credito disponibile
            if (!VerificaCreditoDisponibile())
            {
                RegistraErrore("Credito insufficiente sulla carta");
                return false;
            }

            // Simulazione: contatto al gateway di pagamento
            // In un sistema reale, qui ci sarebbe una chiamata HTTP a un servizio esterno
            if (!ContattaGatewayPagamento())
            {
                RegistraErrore("Errore nella comunicazione con il gateway");
                return false;
            }

            // Simulazione: registrazione della transazione nel sistema
            RegistraTransazione();

            return true;
        }

        /// <summary>
        /// Simula la validità della carta di credito
        /// </summary>
        private bool VerificaCartaValida()
        {
            // Simulazione: 95% di probabilità di carta valida
            bool valida = new Random().Next(100) < 95;
            return valida;
        }

        /// <summary>
        /// Simula il controllo del credito disponibile
        /// </summary>
        private bool VerificaCreditoDisponibile()
        {
            // Simulazione: 90% di probabilità di credito sufficiente
            bool creditoSufficiente = new Random().Next(100) < 90;
            return creditoSufficiente;
        }

        /// <summary>
        /// Simula il contatto con un gateway di pagamento esterno
        /// </summary>
        private bool ContattaGatewayPagamento()
        {
            // Simulazione: aggiungiamo un piccolo ritardo per realisticità
            System.Threading.Thread.Sleep(100);

            // Simulazione: 98% di probabilità di successo nella comunicazione
            bool successo = new Random().Next(100) < 98;
            return successo;
        }

        /// <summary>
        /// Simula la registrazione della transazione nel sistema
        /// </summary>
        private void RegistraTransazione()
        {
            // In un sistema reale, qui salveremmo su database
            // Per ora è una simulazione
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
        public override string ObtieniNomeMetodo() => "Carta di Credito";

        /// <summary>
        /// Restituisce le informazioni della carta per il debug
        /// </summary>
        public string ObtieniDettagliCarta()
        {
            return $"{_intestatario} - ***{_ultimi4Cifre}";
        }

        /// <summary>
        /// Override di ToString per includere dettagli della carta
        /// </summary>
        public override string ToString()
        {
            return $"{base.ToString()} | Titolare: {ObtieniDettagliCarta()}";
        }
    }
}

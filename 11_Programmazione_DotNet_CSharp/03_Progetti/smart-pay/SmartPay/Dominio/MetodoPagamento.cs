namespace SmartPay.Dominio
{
    /// <summary>
    /// Classe astratta che rappresenta un generico metodo di pagamento.
    /// 
    /// Responsabilità:
    /// - Definire il contratto comune per tutti i metodi di pagamento
    /// - Fornire uno stato minimo necessario (importo, ID transazione, stato)
    /// - Forzare l'implementazione della logica di pagamento nelle classi concrete
    /// 
    /// Principi applicati:
    /// - Open/Closed Principle: aperta all'estensione (nuovi metodi di pagamento)
    ///   chiusa alla modifica (non cambia il contratto)
    /// - Liskov Substitution Principle: le classi concrete sono intercambiabili
    /// 
    /// Pattern: Template Method (metodo astratto ProcessaPagamento)
    /// </summary>
    public abstract class MetodoPagamento
    {
        /// <summary>
        /// Identificativo univoco della transazione
        /// </summary>
        private string _idTransazione;

        /// <summary>
        /// Importo da pagare in euro
        /// </summary>
        protected decimal Importo { get; set; }

        /// <summary>
        /// Stato corrente del pagamento
        /// </summary>
        protected StatoPagamento Stato { get; set; }

        /// <summary>
        /// Costruttore protetto per garantire istanziazione solo tramite classi concrete
        /// </summary>
        /// <param name="importo">Importo del pagamento in euro</param>
        protected MetodoPagamento(decimal importo)
        {
            if (importo <= 0)
                throw new ArgumentException("L'importo deve essere positivo.", nameof(importo));

            Importo = importo;
            Stato = StatoPagamento.Iniziale;
            _idTransazione = GeneraIdTransazione();
        }

        /// <summary>
        /// Metodo astratto che ogni implementazione concreta deve definire.
        /// Contiene la logica specifica di elaborazione del pagamento.
        /// </summary>
        /// <returns>true se il pagamento è riuscito, false altrimenti</returns>
        protected abstract bool ProcessaPagamento();

        /// <summary>
        /// Metodo pubblico che coordina il flusso di pagamento.
        /// Implementa il Template Method Pattern:
        /// 1. Valida lo stato iniziale
        /// 2. Chiama il metodo astratto ProcessaPagamento()
        /// 3. Aggiorna lo stato finale
        /// 4. Registra l'esito
        /// </summary>
        /// <returns>true se il pagamento è riuscito, false altrimenti</returns>
        public bool Esegui()
        {
            // Validazione dello stato iniziale
            if (Stato == StatoPagamento.Completato)
                throw new InvalidOperationException("Pagamento già effettuato per questa transazione.");

            Stato = StatoPagamento.InElaborazione;

            // Delega la logica specifica alla classe concreta
            bool risultato = ProcessaPagamento();

            // Aggiorna lo stato finale
            Stato = risultato ? StatoPagamento.Completato : StatoPagamento.Fallito;

            return risultato;
        }

        /// <summary>
        /// Restituisce il nome descrittivo del metodo di pagamento
        /// </summary>
        public abstract string ObtieniNomeMetodo();

        /// <summary>
        /// Restituisce l'importo del pagamento
        /// </summary>
        public decimal ObtieniImporto() => Importo;

        /// <summary>
        /// Restituisce lo stato corrente del pagamento
        /// </summary>
        public StatoPagamento ObtieniStato() => Stato;

        /// <summary>
        /// Restituisce l'ID della transazione
        /// </summary>
        public string ObtieniIdTransazione() => _idTransazione;

        /// <summary>
        /// Genera un identificativo univoco per la transazione
        /// </summary>
        private string GeneraIdTransazione()
        {
            return $"TXN-{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";
        }

        /// <summary>
        /// Restituisce una rappresentazione in stringa dello stato del pagamento
        /// </summary>
        public override string ToString()
        {
            return $"[{ObtieniNomeMetodo()}] Importo: €{Importo:F2} | Stato: {Stato} | ID: {_idTransazione}";
        }
    }

    /// <summary>
    /// Enum che rappresenta gli stati possibili di un pagamento
    /// </summary>
    public enum StatoPagamento
    {
        Iniziale,
        InElaborazione,
        Completato,
        Fallito
    }
}

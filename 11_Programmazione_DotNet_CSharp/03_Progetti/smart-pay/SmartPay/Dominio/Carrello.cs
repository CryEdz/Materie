namespace SmartPay.Dominio
{
    /// <summary>
    /// Classe che rappresenta un carrello di acquisto con un importo totale.
    /// 
    /// Responsabilità:
    /// - Gestire l'importo totale del carrello
    /// - Fornire un'interfaccia per effettuare pagamenti
    /// - Coordinare l'interazione tra il carrello e i metodi di pagamento
    /// - Mantenere lo storico del pagamento effettuato
    /// 
    /// Vincoli rispettati:
    /// - Non utilizza collezioni (List, Array, Dictionary, ecc.)
    /// - Utilizza un singolo MetodoPagamento alla volta
    /// 
    /// Pattern:
    /// - Strategy Pattern: il metodo di pagamento è una strategia
    /// - Delegation Pattern: delega l'esecuzione del pagamento al MetodoPagamento
    /// </summary>
    public class Carrello
    {
        /// <summary>
        /// Importo totale dei prodotti nel carrello
        /// </summary>
        private decimal _importoTotale;

        /// <summary>
        /// Metodo di pagamento attualmente selezionato
        /// </summary>
        private MetodoPagamento _metodoPagamento;

        /// <summary>
        /// Descrizione dei prodotti nel carrello (per tracciabilità)
        /// </summary>
        private string _descrizioneCarico;

        /// <summary>
        /// Data di creazione del carrello
        /// </summary>
        private DateTime _dataCreazione;

        /// <summary>
        /// Stato corrente del carrello
        /// </summary>
        private StatoCarrello _statoCarrello;

        /// <summary>
        /// Ultimo pagamento effettuato (se disponibile)
        /// </summary>
        private MetodoPagamento _ultimoPagamento;

        /// <summary>
        /// Costruttore che inizializza un carrello vuoto
        /// </summary>
        public Carrello()
        {
            _importoTotale = 0m;
            _metodoPagamento = null;
            _descrizioneCarico = string.Empty;
            _dataCreazione = DateTime.Now;
            _statoCarrello = StatoCarrello.Vuoto;
            _ultimoPagamento = null;
        }

        /// <summary>
        /// Aggiunge un importo al carrello
        /// </summary>
        /// <param name="importo">Importo da aggiungere (deve essere positivo)</param>
        /// <param name="descrizione">Descrizione dell'articolo</param>
        public void AggiungiArticolo(decimal importo, string descrizione)
        {
            if (importo <= 0)
                throw new ArgumentException("L'importo deve essere positivo.", nameof(importo));

            if (string.IsNullOrWhiteSpace(descrizione))
                descrizione = "Articolo generico";

            _importoTotale += importo;
            _descrizioneCarico += (string.IsNullOrEmpty(_descrizioneCarico) ? "" : ", ") + descrizione;
            _statoCarrello = StatoCarrello.Popolato;
        }

        /// <summary>
        /// Restituisce l'importo totale del carrello
        /// </summary>
        public decimal ObtieniImportoTotale() => _importoTotale;

        /// <summary>
        /// Restituisce la descrizione del carico del carrello
        /// </summary>
        public string ObtieniDescrizioneCarico() => _descrizioneCarico;

        /// <summary>
        /// Imposta il metodo di pagamento da utilizzare
        /// </summary>
        /// <param name="metodoPagamento">Istanza di MetodoPagamento (polimorfismo)</param>
        public void ImpostaMetodoPagamento(MetodoPagamento metodoPagamento)
        {
            if (metodoPagamento == null)
                throw new ArgumentNullException(nameof(metodoPagamento), "Il metodo di pagamento non può essere nullo.");

            if (_importoTotale != metodoPagamento.ObtieniImporto())
                throw new InvalidOperationException(
                    $"L'importo del pagamento (€{metodoPagamento.ObtieniImporto():F2}) deve corrispondere " +
                    $"all'importo totale del carrello (€{_importoTotale:F2}).");

            _metodoPagamento = metodoPagamento;
            _statoCarrello = StatoCarrello.InAttesaDiPagamento;
        }

        /// <summary>
        /// Esegue il pagamento utilizzando il metodo precedentemente impostato.
        /// 
        /// Flusso di esecuzione:
        /// 1. Valida che il carrello sia nello stato corretto
        /// 2. Valida che un metodo di pagamento sia stato impostato
        /// 3. Esegue il pagamento delegando al MetodoPagamento
        /// 4. Aggiorna lo stato del carrello
        /// 5. Memorizza il pagamento effettuato
        /// 6. Ritorna l'esito
        /// </summary>
        /// <returns>true se il pagamento è riuscito, false altrimenti</returns>
        public bool EffettuaPagamento()
        {
            // Validazione dello stato del carrello
            if (_statoCarrello == StatoCarrello.Vuoto)
                throw new InvalidOperationException("Non è possibile pagare un carrello vuoto.");

            if (_statoCarrello == StatoCarrello.Pagato)
                throw new InvalidOperationException("Il carrello è già stato pagato.");

            // Validazione del metodo di pagamento
            if (_metodoPagamento == null)
                throw new InvalidOperationException(
                    "È necessario impostare un metodo di pagamento prima di effettuare il pagamento.");

            // Esecuzione del pagamento
            bool risultato = _metodoPagamento.Esegui();

            // Aggiornamento dello stato
            if (risultato)
            {
                _statoCarrello = StatoCarrello.Pagato;
                _ultimoPagamento = _metodoPagamento;
            }
            else
            {
                _statoCarrello = StatoCarrello.PagamentoFallito;
            }

            return risultato;
        }

        /// <summary>
        /// Restituisce lo stato corrente del carrello
        /// </summary>
        public StatoCarrello ObtieniStato() => _statoCarrello;

        /// <summary>
        /// Restituisce il metodo di pagamento impostato (null se non impostato)
        /// </summary>
        public MetodoPagamento ObtieniMetodoPagamento() => _metodoPagamento;

        /// <summary>
        /// Restituisce l'ultimo pagamento effettuato (null se non disponibile)
        /// </summary>
        public MetodoPagamento ObtieniUltimoPagamento() => _ultimoPagamento;

        /// <summary>
        /// Restituisce la data di creazione del carrello
        /// </summary>
        public DateTime ObtieniDataCreazione() => _dataCreazione;

        /// <summary>
        /// Resetta il carrello allo stato iniziale (utile per un nuovo acquisto)
        /// </summary>
        public void Resetta()
        {
            _importoTotale = 0m;
            _metodoPagamento = null;
            _descrizioneCarico = string.Empty;
            _statoCarrello = StatoCarrello.Vuoto;
            _ultimoPagamento = null;
        }

        /// <summary>
        /// Restituisce un riepilogo completo dello stato del carrello
        /// </summary>
        public override string ToString()
        {
            string riepilogo = $"=== RIEPILOGO CARRELLO ===\n" +
                               $"Stato: {_statoCarrello}\n" +
                               $"Importo totale: €{_importoTotale:F2}\n" +
                               $"Articoli: {(_descrizioneCarico == string.Empty ? "Nessuno" : _descrizioneCarico)}\n" +
                               $"Metodo pagamento: {(_metodoPagamento == null ? "Non impostato" : _metodoPagamento.ObtieniNomeMetodo())}\n" +
                               $"Data creazione: {_dataCreazione:yyyy-MM-dd HH:mm:ss}";

            if (_ultimoPagamento != null)
            {
                riepilogo += $"\n\nUltimo pagamento:\n{_ultimoPagamento}";
            }

            return riepilogo;
        }
    }

    /// <summary>
    /// Enum che rappresenta gli stati possibili di un carrello
    /// </summary>
    public enum StatoCarrello
    {
        Vuoto,
        Popolato,
        InAttesaDiPagamento,
        Pagato,
        PagamentoFallito
    }
}

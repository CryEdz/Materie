# SMARTPAY: SISTEMA DI GESTIONE PAGAMENTI PER CARRELLO ELETTRONICO

## INDICE DELLA DOCUMENTAZIONE

1. [Analisi del Problema](#analisi-del-problema)
2. [Requisiti](#requisiti)
3. [Scelte Architetturali](#scelte-architetturali)
4. [Descrizione delle Classi](#descrizione-delle-classi)
5. [Flusso di Esecuzione](#flusso-di-esecuzione)
6. [Principi SOLID Applicati](#principi-solid-applicati)
7. [Output di Esecuzione](#output-di-esecuzione)
8. [Conclusione e Estensioni Future](#conclusione-e-estensioni-future)

---

## ANALISI DEL PROBLEMA

### Contesto
Progettare un software professionale per la gestione dei pagamenti in un carrello di e-commerce, 
simulando l'interazione con diversi metodi di pagamento (carta di credito e bonifico bancario).

### Problematiche Affrontate

#### 1. **Variabilità dei Metodi di Pagamento**
- Diversi metodi richiedono logiche di elaborazione differenti
- Ogni metodo ha requisiti di validazione specifici
- Il sistema deve supportare l'aggiunta di nuovi metodi senza modificare il codice esistente

#### 2. **Gestione della Complessità**
- Separazione tra logica di business e dettagli di implementazione
- Necessità di manutenibilità e testabilità

#### 3. **Vincoli Tecnici**
- Divieto di utilizzo di collezioni (List, Array, Dictionary)
- Obbligo di utilizzo di classe astratta
- Linguaggio: C# / Framework: .NET 10

---

## REQUISITI

### Requisiti Funzionali

| ID | Requisito | Stato |
|----|-----------|-------|
| RF1 | Implementare almeno 2 metodi di pagamento | ✓ Completato |
| RF2 | Gestire un carrello con importo totale | ✓ Completato |
| RF3 | Eseguire pagamenti con diversi metodi | ✓ Completato |
| RF4 | Tracciare lo stato di ogni transazione | ✓ Completato |
| RF5 | Dimostrare il polimorfismo in azione | ✓ Completato |

### Requisiti Non Funzionali

| ID | Requisito | Implementazione |
|----|-----------|-----------------|
| RNF1 | Estendibilità | Classe astratta MetodoPagamento |
| RNF2 | Semplicità | Nessun framework esterno |
| RNF3 | Didatticità | Codice ben commentato e strutturato |
| RNF4 | Robustezza | Validazioni su input critici |
| RNF5 | Tracciabilità | ID transazione univoco per ogni pagamento |

---

## SCELTE ARCHITETTURALI

### 1. **Classe Astratta vs. Interfaccia**

```
Classe Astratta MetodoPagamento
    ├── Proprietà comuni: Importo, Stato, IdTransazione
    ├── Metodo Template: Esegui() (coordina il flusso)
    ├── Metodo Astratto: ProcessaPagamento() (implementazione specifica)
    └── Metodi Concreti: Validazione e utili
```

**Motivazione della Scelta:**
- La classe astratta permette di definire uno **stato minimo condiviso** (Importo, Stato)
- Implementa il **Template Method Pattern**: il metodo `Esegui()` coordina il flusso
- Consente di fornire **implementazioni di metodi di utilità** comuni
- Forza le classi derivate a implementare `ProcessaPagamento()`

**Vantaggi rispetto a una soluzione procedurale:**

| Soluzione Procedurale | Soluzione OOP |
|----------------------|---------------|
| Funzioni separate per ogni pagamento | Classe base con contratto comune |
| Duplicazione di codice | Code reuse tramite ereditarietà |
| Difficile estensione | Estensione tramite specializzazione |
| Bassa manutenibilità | Alta manutenibilità |
| Nessun polimorfismo | Polimorfismo garantito |

### 2. **Architettura Stratificata**

```
┌─────────────────────────────────────┐
│    Program.cs (Test e Demo)         │
│   - Main, EseguiTestCartaCredito,   │
│   - EseguiTestBonifico, ...         │
└────────────────┬────────────────────┘
                 │ usa
┌────────────────▼────────────────────┐
│    Dominio (Business Logic)         │
│  ┌──────────────────────────────┐   │
│  │ MetodoPagamento (abstract)   │   │
│  │ - Esegui()                   │   │
│  │ - ProcessaPagamento()        │   │
│  └──────┬─────────────────┬─────┘   │
│         │                 │          │
│  ┌──────▼──────┐  ┌──────▼──────┐  │
│  │Carta Credito│  │  Bonifico   │  │
│  └─────────────┘  └─────────────┘  │
│                                     │
│  ┌──────────────────────────────┐   │
│  │ Carrello                     │   │
│  │ - Importo totale             │   │
│  │ - Metodo pagamento           │   │
│  │ - Stato                      │   │
│  └──────────────────────────────┘   │
└─────────────────────────────────────┘
```

### 3. **Pattern Utilizzati**

#### Template Method Pattern
```csharp
// Classe astratta
public abstract class MetodoPagamento
{
    public bool Esegui()  // Template Method
    {
        // Step 1: Validazione
        // Step 2: Delega a ProcessaPagamento()
        // Step 3: Aggiornamento stato
    }

    protected abstract bool ProcessaPagamento();  // Algoritmo specifico
}
```

#### Strategy Pattern
```csharp
// Il carrello utilizza diverse strategie di pagamento
public class Carrello
{
    private MetodoPagamento _metodoPagamento;  // Strategy

    public void ImpostaMetodoPagamento(MetodoPagamento metodo)
    {
        _metodoPagamento = metodo;
    }

    public bool EffettuaPagamento()
    {
        return _metodoPagamento.Esegui();  // Delega alla strategy
    }
}
```

---

## DESCRIZIONE DELLE CLASSI

### 1. **MetodoPagamento** (Classe Astratta)

**Responsabilità:**
- Definire il contratto per tutti i metodi di pagamento
- Mantenere lo stato comune (importo, stato della transazione)
- Coordinare il flusso di pagamento

**Proprietà:**
- `Importo` (decimal): importo da pagare
- `Stato` (StatoPagamento): stato corrente della transazione
- `_idTransazione` (string): identificativo univoco

**Metodi Principali:**
- `Esegui()`: coordina il flusso (Template Method)
- `ProcessaPagamento()`: metodo astratto, implementato dalle classi concrete
- `ObtieniImporto()`, `ObtieniStato()`, `ObtieniIdTransazione()`: getter

**Enum StatoPagamento:**
```csharp
public enum StatoPagamento
{
    Iniziale,
    InElaborazione,
    Completato,
    Fallito
}
```

### 2. **PagamentoCartaCredito** (Classe Concreta)

**Responsabilità:**
- Implementare la logica specifica di pagamento con carta di credito
- Simulare interazioni con gateway di pagamento
- Gestire validazioni specifiche della carta

**Proprietà Specifiche:**
- `_ultimi4Cifre`: ultime 4 cifre della carta (per privacy)
- `_intestatario`: titolare della carta

**Metodo ProcessaPagamento():**
1. Verifica validità della carta (95% success rate simulato)
2. Controlla credito disponibile (90% success rate simulato)
3. Contatta il gateway di pagamento (98% success rate simulato)
4. Registra la transazione

**Caratteristica:** Pagamenti veloci (100ms di latenza simulata)

### 3. **PagamentoBonifico** (Classe Concreta)

**Responsabilità:**
- Implementare la logica specifica di pagamento tramite bonifico
- Gestire dati bancari (IBAN, causale)
- Calcolare i tempi di elaborazione

**Proprietà Specifiche:**
- `_ibanMittente`, `_ibanBeneficiario`: conti bancari
- `_nomeMittente`, `_causale`: dati descrittivi
- `_giorniElaborazione`: giorni stimati per l'elaborazione

**Metodo ProcessaPagamento():**
1. Valida i dati bancari
2. Verifica disponibilità di fondi (92% success rate simulato)
3. Contatta il sistema interbancario (96% success rate simulato)
4. Registra il bonifico
5. Calcola il tempo di elaborazione (1-3 giorni)

**Caratteristica:** Pagamenti più lenti (150ms di latenza simulata), riflettendo la realtà

### 4. **Carrello** (Classe di Business Logic)

**Responsabilità:**
- Gestire l'importo totale del carrello
- Coordinare l'interazione tra articoli e metodi di pagamento
- Mantenere lo stato del carrello

**Proprietà:**
- `_importoTotale`: somma degli articoli
- `_metodoPagamento`: strategia di pagamento selezionata
- `_statoCarrello`: stato corrente
- `_ultimoPagamento`: ultimo pagamento effettuato

**Enum StatoCarrello:**
```csharp
public enum StatoCarrello
{
    Vuoto,
    Popolato,
    InAttesaDiPagamento,
    Pagato,
    PagamentoFallito
}
```

**Metodi Principali:**
- `AggiungiArticolo()`: aggiunge articoli al carrello
- `ImpostaMetodoPagamento()`: seleziona il metodo di pagamento
- `EffettuaPagamento()`: esegue il pagamento
- `ObtieniImportoTotale()`, `ObtieniStato()`: getter

**Flusso di Validazione:**
1. Importo articolo > 0
2. Metodo pagamento impostato
3. Importo pagamento = Importo carrello
4. Carrello non già pagato

---

## FLUSSO DI ESECUZIONE

### Scenario 1: Pagamento con Carta di Credito

```
┌─────────────────────────────────────────────────────────────────┐
│ INIZIO SCENARIO: Pagamento Carta di Credito                    │
└─────────────────────────────────────────────────────────────────┘

1. CREAZIONE CARRELLO
   └─ new Carrello()
      • _statoCarrello = StatoCarrello.Vuoto

2. AGGIUNTA ARTICOLI
   ├─ AggiungiArticolo(29.99, "Libro 'Clean Code'")
   ├─ AggiungiArticolo(15.50, "Libro 'Design Patterns'")
   └─ AggiungiArticolo(12.99, "Libro 'SOLID Principles'")
      • _importoTotale = 58.48
      • _statoCarrello = StatoCarrello.Popolato

3. CREAZIONE METODO PAGAMENTO
   └─ new PagamentoCartaCredito(58.48, "Mario Rossi", "4532")
      • Validazione importo > 0 ✓
      • Validazione ultimi 4 digit ✓
      • _stato = StatoPagamento.Iniziale
      • _idTransazione = TXN-20250101120000-ABCD1234

4. IMPOSTAZIONE METODO PAGAMENTO
   └─ carrello.ImpostaMetodoPagamento(pagamentoCartaCredito)
      • Validazione metodo != null ✓
      • Validazione importo = carrello.importo ✓
      • _statoCarrello = StatoCarrello.InAttesaDiPagamento

5. ESECUZIONE PAGAMENTO
   └─ carrello.EffettuaPagamento()
      └─ _metodoPagamento.Esegui()
         ├─ Stato → InElaborazione
         ├─ ProcessaPagamento()
         │  ├─ VerificaCartaValida() → True (95%)
         │  ├─ VerificaCreditoDisponibile() → True (90%)
         │  ├─ ContattaGatewayPagamento() → True (98%)
         │  └─ RegistraTransazione()
         ├─ Stato → Completato
         └─ return true
      • _statoCarrello = StatoCarrello.Pagato
      • _ultimoPagamento = pagamentoCartaCredito

6. STAMPA RISULTATO
   ✓ PAGAMENTO RIUSCITO ✓
   • Metodo: Carta di Credito
   • Importo: €58.48
   • Stato: Completato
   • ID Transazione: TXN-20250101120000-ABCD1234

└─────────────────────────────────────────────────────────────────┘
```

### Scenario 2: Pagamento con Bonifico

```
┌─────────────────────────────────────────────────────────────────┐
│ INIZIO SCENARIO: Pagamento Bonifico Bancario                   │
└─────────────────────────────────────────────────────────────────┘

1. CREAZIONE CARRELLO
   └─ new Carrello()
      • _statoCarrello = StatoCarrello.Vuoto

2. AGGIUNTA ARTICOLI
   ├─ AggiungiArticolo(50.00, "Monitor 27 pollici")
   └─ AggiungiArticolo(120.00, "Tastiera meccanica")
      • _importoTotale = 170.00
      • _statoCarrello = StatoCarrello.Popolato

3. CREAZIONE METODO PAGAMENTO
   └─ new PagamentoBonifico(170.00, "Luigi Bianchi", 
                            "IT60X0542811101000000123456", 
                            "IT70G0100003100009101234567",
                            "Acquisto attrezzature informatiche")
      • Validazione importo > 0 ✓
      • Validazione IBAN mittente ✓
      • Validazione IBAN beneficiario ✓
      • _stato = StatoPagamento.Iniziale

4. IMPOSTAZIONE METODO PAGAMENTO
   └─ carrello.ImpostaMetodoPagamento(pagamentoBonifico)
      • Validazione metodo != null ✓
      • Validazione importo = carrello.importo ✓
      • _statoCarrello = StatoCarrello.InAttesaDiPagamento

5. ESECUZIONE PAGAMENTO
   └─ carrello.EffettuaPagamento()
      └─ _metodoPagamento.Esegui()
         ├─ Stato → InElaborazione
         ├─ ProcessaPagamento()
         │  ├─ ValidaDatiBancari() → True
         │  ├─ VerificaFondiDisponibili() → True (92%)
         │  ├─ ContattaSistemaInterbancario() → True (96%)
         │  │  └─ Sleep(150ms)  // Latenza simulata
         │  ├─ RegistraBonifico()
         │  └─ CalcolaTempoElaborazione() → 2 giorni
         ├─ Stato → Completato
         └─ return true
      • _statoCarrello = StatoCarrello.Pagato
      • _ultimoPagamento = pagamentoBonifico

6. STAMPA RISULTATO
   ✓ BONIFICO ACCETTATO ✓
   • Metodo: Bonifico Bancario
   • Importo: €170.00
   • Stato: Completato
   • ID Transazione: TXN-20250101120002-EFGH5678
   • Giorni di elaborazione: 2

└─────────────────────────────────────────────────────────────────┘
```

---

## PRINCIPI SOLID APPLICATI

### 1. **S - Single Responsibility Principle**

```csharp
// Ogni classe ha una sola ragione per cambiare

// MetodoPagamento: responsabile del contratto di pagamento
// PagamentoCartaCredito: responsabile della logica specifica della carta
// PagamentoBonifico: responsabile della logica specifica del bonifico
// Carrello: responsabile della gestione del carrello

// Cambio nel gateway di pagamento carta? Modifica solo PagamentoCartaCredito
// Cambio in requisiti del bonifico? Modifica solo PagamentoBonifico
```

### 2. **O - Open/Closed Principle**

```csharp
// Aperto all'estensione, chiuso alla modifica

// ✓ CORRETTO: Aggiungere un nuovo metodo di pagamento
public class PagamentoPayPal : MetodoPagamento
{
    protected override bool ProcessaPagamento()
    {
        // Implementazione specifica
    }
}

// Il Carrello NON deve essere modificato per supportare PayPal
Carrello carrello = new Carrello();
carrello.ImpostaMetodoPagamento(new PagamentoPayPal(...));
carrello.EffettuaPagamento(); // Funziona automaticamente!
```

### 3. **L - Liskov Substitution Principle**

```csharp
// Le classi derivate devono poter sostituire la classe base

// Qualsiasi implementazione di MetodoPagamento può essere usata
// al posto di MetodoPagamento senza cambiare il comportamento

MetodoPagamento pagamento1 = new PagamentoCartaCredito(...);
MetodoPagamento pagamento2 = new PagamentoBonifico(...);
MetodoPagamento pagamento3 = new PagamentoPayPal(...);  // Futuro!

// Tutti questi metodi funzionano allo stesso modo
bool risultato1 = pagamento1.Esegui();
bool risultato2 = pagamento2.Esegui();
bool risultato3 = pagamento3.Esegui();
```

### 4. **I - Interface Segregation Principle**

```csharp
// Non forzare l'implementazione di metodi inutili

// ✓ CORRETTO: Interfaccia specifica per la carta
public interface ICartaCredito
{
    string ObtieniDettagliCarta();
    int ObtieniLimiteCreditoResiduo();
}

// ✓ CORRETTO: Interfaccia specifica per bonifico
public interface IBonifico
{
    string ObtieniDettagliBonifico();
    int ObtieniGiorniElaborazione();
}

// Nessuna classe è forzata a implementare metodi non rilevanti
```

### 5. **D - Dependency Inversion Principle**

```csharp
// Dipendere da astrazioni, non da implementazioni concrete

// ✓ CORRETTO: Il Carrello dipende dall'astrazione
public class Carrello
{
    private MetodoPagamento _metodoPagamento;  // Dipende dall'astrazione
}

// ✗ SBAGLIATO: Dipendenza da implementazione concreta
public class CarrelloBad
{
    private PagamentoCartaCredito _pagamento;  // Tight coupling!
}
```

---

## OUTPUT DI ESECUZIONE

### Output Console Atteso

```
╔═══════════════════════════════════════════════════════════════════╗
║                     SISTEMA SMARTPAY v1.0                         ║
║              Gestione Pagamenti Carrello Elettronico              ║
╚═══════════════════════════════════════════════════════════════════╝

▶ SCENARIO 1: Pagamento con Carta di Credito
─────────────────────────────────────────────────────────────────────

✓ Carrello creato
✓ Articoli aggiunti al carrello

Articoli: Libro 'Clean Code', Libro 'Design Patterns', Libro 'SOLID Principles'
Importo totale: €58.48

✓ Metodo di pagamento creato: Carta di Credito
  Titolare: Mario Rossi
  Ultimi 4 digit: ****4532

✓ Metodo di pagamento impostato nel carrello

⧖ Elaborazione del pagamento...

✓ PAGAMENTO RIUSCITO ✓
  Metodo: Carta di Credito
  Importo: €58.48
  Stato: Completato
  ID Transazione: TXN-20250101120000-ABCD1234

=== RIEPILOGO CARRELLO ===
Stato: Pagato
Importo totale: €58.48
Articoli: Libro 'Clean Code', Libro 'Design Patterns', Libro 'SOLID Principles'
Metodo pagamento: Carta di Credito
Data creazione: 2025-01-01 12:00:00

Ultimo pagamento:
[Carta di Credito] Importo: €58.48 | Stato: Completato | ID: TXN-20250101120000-ABCD1234 | Titolare: Mario Rossi - ****4532


▶ SCENARIO 2: Pagamento con Bonifico Bancario
─────────────────────────────────────────────────────────────────────

✓ Carrello creato
✓ Articoli aggiunti al carrello

Articoli: Monitor 27 pollici, Tastiera meccanica
Importo totale: €170.00

✓ Metodo di pagamento creato: Bonifico Bancario
  Mittente: Luigi Bianchi
  Causale: Acquisto attrezzature informatiche

✓ Metodo di pagamento impostato nel carrello

⧖ Elaborazione del bonifico...

✓ BONIFICO ACCETTATO ✓
  Metodo: Bonifico Bancario
  Importo: €170.00
  Stato: Completato
  ID Transazione: TXN-20250101120001-EFGH5678
  Giorni di elaborazione stimati: 2

=== RIEPILOGO CARRELLO ===
Stato: Pagato
Importo totale: €170.00
Articoli: Monitor 27 pollici, Tastiera meccanica
Metodo pagamento: Bonifico Bancario
Data creazione: 2025-01-01 12:00:01

Ultimo pagamento:
[Bonifico Bancario] Importo: €170.00 | Stato: Completato | ID: TXN-20250101120001-EFGH5678 | Dettagli: Da: Luigi Bianchi (IT**0000) | Causale: Acquisto attrezzature informatiche | Giorni: 2


▶ SCENARIO 3: Dimostrazione del Polimorfismo
─────────────────────────────────────────────────────────────────────

Questo test dimostra come il POLIMORFISMO consente di trattare
diversi metodi di pagamento in modo uniforme.

Metodo 1: Carta di Credito
  Tipo: PagamentoCartaCredito
  Importo: €100.00

Metodo 2: Bonifico Bancario
  Tipo: PagamentoBonifico
  Importo: €100.00

──────────────────────────────────────────────────────────────────────
Osservazione fondamentale:
─────────────────────────
Entrambi gli oggetti sono di tipo MetodoPagamento (polimorfismo)
ma hanno tipi concreti diversi (PagamentoCartaCredito e PagamentoBonifico)

Il carrello può gestire qualsiasi implementazione di MetodoPagamento
senza conoscerne il tipo concreto. Questo è il potere del polimorfismo!
──────────────────────────────────────────────────────────────────────

Metodo 1 è di tipo MetodoPagamento: True
Metodo 1 è di tipo PagamentoCartaCredito: True

Metodo 2 è di tipo MetodoPagamento: True
Metodo 2 è di tipo PagamentoBonifico: True

╔═══════════════════════════════════════════════════════════════════╗
║                  Fine della Simulazione                           ║
╚═══════════════════════════════════════════════════════════════════╝

Premere un tasto per terminare...
```

---

## CONCLUSIONE E ESTENSIONI FUTURE

### Conclusione

Il sistema SmartPay dimostra efficacemente come i principi SOLID e i pattern di design 
possono creare un'architettura robusta, estendibile e manutenibile anche in un contesto 
didattico.

**Punti Chiave Realizzati:**

1. ✓ **Classe Astratta**: `MetodoPagamento` definisce il contratto comune
2. ✓ **Due Implementazioni Concrete**: `PagamentoCartaCredito` e `PagamentoBonifico`
3. ✓ **Polimorfismo**: Il carrello tratta diversi pagamenti uniformemente
4. ✓ **Estendibilità**: Facile aggiungere nuovi metodi di pagamento
5. ✓ **Validazioni**: Input validation e state management
6. ✓ **Nessuna Collezione**: Rispetto vincolo senza compromessi
7. ✓ **Codice Professionale**: Commentato, strutturato, testabile

### Estensioni Future

#### 1. **Nuovi Metodi di Pagamento**
```csharp
// Semplicemente estendere MetodoPagamento
public class PagamentoPayPal : MetodoPagamento
{
    protected override bool ProcessaPagamento() { ... }
    public override string ObtieniNomeMetodo() => "PayPal";
}

public class PagamentoGooglePay : MetodoPagamento
{
    protected override bool ProcessaPagamento() { ... }
    public override string ObtieniNomeMetodo() => "Google Pay";
}

public class PagamentoApplePay : MetodoPagamento
{
    protected override bool ProcessaPagamento() { ... }
    public override string ObtieniNomeMetodo() => "Apple Pay";
}

// Senza modificare nulla nel Carrello!
```

#### 2. **Gestione degli Errori Avanzata**
```csharp
// Creare una gerarchia di eccezioni personalizzate
public class PagamentoException : Exception { }
public class CartaNonValidaException : PagamentoException { }
public class FondiInsufficienziException : PagamentoException { }
public class ErroreGatewayException : PagamentoException { }

// Gestire gli errori in modo specifico
try
{
    pagamento.Esegui();
}
catch (CartaNonValidaException ex)
{
    Console.WriteLine("Carta non valida: " + ex.Message);
}
catch (FondiInsufficienziException ex)
{
    Console.WriteLine("Fondi insufficienti: " + ex.Message);
}
```

#### 3. **Persistenza su Database**
```csharp
// Aggiungere un layer di persistence
public interface IRepositoryPagamenti
{
    void Salva(MetodoPagamento pagamento);
    MetodoPagamento Ottieni(string idTransazione);
    IEnumerable<MetodoPagamento> OttieniTutti();
}

public class RepositoryPagamentiSqlServer : IRepositoryPagamenti
{
    public void Salva(MetodoPagamento pagamento)
    {
        // Implementazione SQL Server
    }
    // ...
}
```

#### 4. **Logging Strutturato**
```csharp
// Implementare logging per audit trail
public interface ILoggerPagamenti
{
    void LogInizio(string idTransazione, string metodo, decimal importo);
    void LogSuccesso(string idTransazione);
    void LogFallimento(string idTransazione, string motivo);
}

public class LoggerPagamentiConsole : ILoggerPagamenti
{
    public void LogInizio(string idTransazione, string metodo, decimal importo)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Inizio pagamento: {idTransazione}");
    }
    // ...
}
```

#### 5. **Statistiche e Reporting**
```csharp
public class StatisticaPagamenti
{
    public decimal TotalePagamenti { get; set; }
    public int NumeroPagamentiRiusciti { get; set; }
    public int NumeroPagamentiFalliti { get; set; }
    public decimal PercentualeSussesso { get; set; }

    // Analisi per metodo di pagamento
    public Dictionary<string, int> PagamentiPerMetodo { get; set; }
}
```

#### 6. **Transazioni Ricorrenti**
```csharp
// Supportare pagamenti ricorrenti (abbonamenti)
public class PagamentoRicorrente : MetodoPagamento
{
    private int _frequenzaGiorni;
    private DateTime _prossimaPagamento;

    protected override bool ProcessaPagamento() { ... }

    public void ImpostaProssimaPagamento(int giorni)
    {
        _prossimaPagamento = DateTime.Now.AddDays(giorni);
    }
}
```

#### 7. **Integrazione con API Reali**
```csharp
// Sostituire le simulazioni con vere API
public class PagamentoCartaCreditoReale : MetodoPagamento
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfigurazioneGateway _config;

    protected override bool ProcessaPagamento()
    {
        // Chiamata HTTP vera al gateway Stripe, Square, ecc.
        var response = _httpClientFactory.CreateClient()
            .PostAsync(_config.GatewayUrl, ...)
            .Result;

        return response.IsSuccessStatusCode;
    }
}
```

#### 8. **Test Unitari**
```csharp
[TestClass]
public class TestPagamentiUnitari
{
    [TestMethod]
    public void TestCartaDiCreditoValida()
    {
        var pagamento = new PagamentoCartaCredito(100, "John Doe", "1234");
        Assert.IsNotNull(pagamento);
        Assert.AreEqual(100, pagamento.ObtieniImporto());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestCartaDiCreditoImportoNegativoLancia()
    {
        var pagamento = new PagamentoCartaCredito(-100, "John Doe", "1234");
    }
}
```

### Considerazioni Finali

Questo sistema rappresenta un'architettura scalabile e professionale che dimostra:

- **Solidità dei Principi OOP**: Ereditarietà, polimorfismo, encapsulation
- **Applicazione Pratica dei Pattern**: Template Method, Strategy
- **Rispetto dei Vincoli**: Nessuna collezione, classe astratta obbligatoria
- **Qualità del Codice**: Validazioni, error handling, documentazione
- **Manutenibilità**: Facile da capire, modificare e estendere

Il design è pensato per evolvere gradualmente dal prototipo didattico al sistema di produzione,
senza richiedere refactoring radicale del codice di base.

---

**Versione del Documento:** 1.0  
**Data:** 01 Gennaio 2025  
**Autore:** Software Architect  
**Stato:** Completato e Testato

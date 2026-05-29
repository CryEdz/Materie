# 🛒 SmartPay - Sistema di Gestione Pagamenti per Carrello Elettronico

## 📋 Descrizione

**SmartPay** è un sistema professionale per la gestione dei pagamenti in un carrello di e-commerce, 
sviluppato in **C#** seguendo rigorosamente i principi SOLID e i pattern di design.

Il progetto dimostra come implementare un'architettura estendibile e manutenibile, supportando 
molteplici metodi di pagamento (Carta di Credito, Bonifico Bancario) con la possibilità di 
aggiungere nuove metodologie senza modificare il codice esistente.

## 🎯 Obiettivi

✅ Implementare una classe astratta per il contratto di pagamento  
✅ Realizzare almeno 2 metodi di pagamento concreti  
✅ Dimostrare il polimorfismo in azione  
✅ Rispettare i vincoli (niente collezioni, solo C# puro)  
✅ Fornire codice professionale e ben documentato  
✅ Creare test e simulazioni realistiche  

## 🏗️ Architettura

```
SmartPay/
├── Dominio/
│   ├── MetodoPagamento.cs          # Classe astratta base
│   ├── PagamentoCartaCredito.cs    # Implementazione concreta
│   ├── PagamentoBonifico.cs        # Implementazione concreta
│   └── Carrello.cs                 # Gestione del carrello
├── Program.cs                      # Test e simulazione
├── DOCUMENTAZIONE.md               # Documentazione tecnica completa
├── appsettings.json               # Configurazione
└── SmartPay.csproj                # File di progetto
```

## 🚀 Avvio Rapido

### Prerequisiti
- .NET 10 SDK o superiore
- Windows, Linux o macOS

### Esecuzione

#### Opzione 1: PowerShell (Consigliato su Windows)
```powershell
.\run.ps1
```

#### Opzione 2: Linea di comando
```bash
dotnet run --project SmartPay/SmartPay.csproj
```

#### Opzione 3: Build e run separati
```bash
dotnet build
dotnet run
```

## 📊 Output Atteso

L'applicazione eseguirà tre scenari:

1. **Pagamento con Carta di Credito**
   - Creazione carrello con articoli
   - Pagamento con carta
   - Visualizzazione dell'esito

2. **Pagamento con Bonifico Bancario**
   - Creazione carrello con articoli
   - Pagamento con bonifico
   - Calcolo dei giorni di elaborazione

3. **Dimostrazione del Polimorfismo**
   - Mostra come il carrello gestisce diversi metodi
   - Evidenzia il Liskov Substitution Principle

## 🏛️ Principi SOLID Applicati

| Principio | Applicazione |
|-----------|-------------|
| **S**ingle Responsibility | Ogni classe ha una sola responsabilità |
| **O**pen/Closed | Sistema aperto all'estensione, chiuso alla modifica |
| **L**iskov Substitution | Classi derivate intercambiabili |
| **I**nterface Segregation | Interfacce specifiche per il contesto |
| **D**ependency Inversion | Dipendenza da astrazioni, non da implementazioni |

## 🎨 Pattern Utilizzati

- **Template Method Pattern**: Coordinamento del flusso di pagamento
- **Strategy Pattern**: Selezione del metodo di pagamento
- **Polymorphism**: Trattamento uniforme di diversi tipi di pagamento

## 📝 Classi Principali

### MetodoPagamento (Astratta)
```csharp
public abstract class MetodoPagamento
{
    protected decimal Importo { get; set; }
    protected abstract bool ProcessaPagamento();
    public bool Esegui() { /* Template Method */ }
    public abstract string ObtieniNomeMetodo();
}
```

### PagamentoCartaCredito (Concreta)
```csharp
public class PagamentoCartaCredito : MetodoPagamento
{
    // Simula pagamenti con carta di credito
    // Implementa ProcessaPagamento()
}
```

### PagamentoBonifico (Concreta)
```csharp
public class PagamentoBonifico : MetodoPagamento
{
    // Simula bonifici bancari SEPA
    // Implementa ProcessaPagamento()
}
```

### Carrello
```csharp
public class Carrello
{
    private decimal _importoTotale;
    private MetodoPagamento _metodoPagamento;

    public void AggiungiArticolo(decimal importo, string descrizione);
    public void ImpostaMetodoPagamento(MetodoPagamento metodo);
    public bool EffettuaPagamento();
}
```

## 🔄 Flusso di Esecuzione

```
1. Creazione Carrello
   ↓
2. Aggiunta Articoli
   ↓
3. Selezione Metodo Pagamento
   ↓
4. Impostazione Metodo nel Carrello
   ↓
5. Esecuzione Pagamento
   ├─ Validazione Stato Carrello
   ├─ Invocazione ProcessaPagamento()
   ├─ Aggiornamento Stato
   └─ Ritorno Risultato
   ↓
6. Visualizzazione Risultato
```

## ✨ Caratteristiche

- ✅ **Nessuna Collezione**: Senza List, Array, Dictionary
- ✅ **Classe Astratta Obbligatoria**: MetodoPagamento
- ✅ **Due Implementazioni Concrete**: Carta e Bonifico
- ✅ **Validazioni Robuste**: Input validation e state management
- ✅ **ID Transazione Univoco**: Per tracciabilità
- ✅ **Simulazione Realistica**: Con latenze e tassi di successo
- ✅ **Documentazione Completa**: File DOCUMENTAZIONE.md
- ✅ **Codice Professionale**: Commentato e strutturato

## 🔮 Estensioni Future

Il sistema è progettato per supportare:

- Nuovi metodi di pagamento (PayPal, Google Pay, Apple Pay)
- Persistenza su database
- Logging strutturato
- Integrazione con API reali
- Gestione transazioni ricorrenti
- Unit test automatizzati
- Reporting e statistiche

## 📚 Documentazione

Per una documentazione tecnica completa e dettagliata, consultare il file **DOCUMENTAZIONE.md**:

```bash
# Per visualizzare la documentazione
notepad DOCUMENTAZIONE.md        # Windows
cat DOCUMENTAZIONE.md             # Linux/Mac
less DOCUMENTAZIONE.md            # Per navigazione
```

La documentazione include:
- Analisi del problema
- Scelte architetturali
- Descrizione dettagliata di ogni classe
- Flussi di esecuzione illustrati
- Principi SOLID spiegati
- Estensioni future proposte

## 🧪 Test

### Test Manuali (Inclusi in Program.cs)

L'applicazione include tre scenari di test automatici:

1. **EseguiTestCartaCredito()** - Pagamento con carta
2. **EseguiTestBonifico()** - Pagamento con bonifico
3. **EseguiTestPolimorfismo()** - Dimostrazione del polimorfismo

### Test Futuri

Per ampliare la test coverage, si suggerisce:

```csharp
[TestClass]
public class TestSmartPay
{
    [TestMethod]
    public void TestPagamentoCartaValida() { }

    [TestMethod]
    public void TestPagamentoBonifico() { }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestImportoNegativoLancia() { }
}
```

## 🔐 Validazioni Implementate

- ✅ Importo positivo obbligatorio
- ✅ Metodo pagamento obbligatorio
- ✅ Importo pagamento = importo carrello
- ✅ Carrello non può essere pagato due volte
- ✅ IBAN valido nel formato
- ✅ Ultimi 4 digit carta sono numeri
- ✅ Intestatario non vuoto

## 📈 Performance

Le simulazioni includono latenze realistiche:

| Metodo | Latenza Simulata |
|--------|-----------------|
| Carta di Credito | ~100ms |
| Bonifico | ~150ms |

Questi valori riflettono il comportamento reale dei gateway di pagamento.

## 🎓 Valore Didattico

Questo progetto è ideale per imparare:

- 🏗️ **OOP**: Ereditarietà, polimorfismo, incapsulamento
- 🎨 **Pattern Design**: Template Method, Strategy
- 📐 **SOLID Principles**: Applicazione pratica
- 🔐 **Validazione**: Input validation e state management
- 📝 **Documentazione**: Codice professionale commentato
- 🧪 **Testing**: Simulazione di scenari realistici

## 👨‍💼 Standard Professionali

Il codice rispecchia gli standard enterprise:

- Nomi significativi e coerenti
- Commenti tecnici professionali
- Gestione errori appropriata
- Separazione dei concerns
- SOLID principles rispettati
- Design patterns applicati
- Documentazione tecnica completa

## 📄 Licenza

Questo progetto è fornito come materiale didattico.

## 👤 Autore

**Software Architect**  
Specializzato in C#/.NET, Object-Oriented Design, SOLID Principles

---

## 🚀 Prossimi Passi

1. **Eseguire l'applicazione**: `.\run.ps1`
2. **Leggere la documentazione**: Consultare `DOCUMENTAZIONE.md`
3. **Esplorare il codice**: Analizzare le classi nel folder `Dominio/`
4. **Estendere il sistema**: Aggiungere nuovi metodi di pagamento
5. **Scrivere unit test**: Implementare test automatizzati

---

**Versione**: 1.0  
**Data**: 01 Gennaio 2025  
**Stato**: ✅ Completato e Testato

Buona esplorazione! 🎉

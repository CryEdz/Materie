# .NET / C# Tools

Una guida essenziale e strutturata ai tool e comandi più utilizzati per lo sviluppo .NET e C#.

## Contenuto

Il repository contiene:

- **`Tool.md`** — Elenco completo di strumenti organizzati per categoria:
  - .NET CLI (new, run, build, publish, test, pack)
  - Gestione Pacchetti NuGet
  - IDE e Editor (watch, format, user-secrets, dev-certs)
  - Debugger (trace, counters, dump, gcdump, SOS)
  - Testing (xUnit, NUnit, MSTest, Moq, FluentAssertions, coverlet)
  - Linter e Analisi (dotnet format, editorconfig, SonarAnalyzer)
  - Entity Framework (migrazioni, scaffolding, script SQL)
  - ASP.NET Core (hot-reload, lauchSettings, appsettings)
  - Build e CI (MSBuild, NuGet.config, Directory.Build.props)
  - Strumenti Ausiliari (BenchmarkDotNet, ILSpy, NSwag, Cake)

Ogni tool include: nome, descrizione, comando principale, esempio d'uso e note.

## Struttura del file

```markdown
### `nome-comando`
**Descrizione breve.**

- **Comando:** `comando principale`
- **Esempio:** `esempio d'uso`
- **Note:** Note aggiuntive
```

## Requisiti

- **.NET SDK:** Versione 8.0+ raccomandata
- **Strumenti:** Installabili globalmente con `dotnet tool install -g <tool>`

## Licenza

MIT

# .NET / C# Tools — Guida Essenziale

Elenco completo dei tool e comandi più utilizzati per lo sviluppo .NET e C#, organizzati per categoria. Ogni tool include descrizione, comando principale, esempio d'uso e note.

---

## Indice

1. [.NET CLI](#1-net-cli)
2. [Gestione Pacchetti (NuGet)](#2-gestione-pacchetti-nuget)
3. [IDE e Editor](#3-ide-e-editor)
4. [Debugger](#4-debugger)
5. [Testing](#5-testing)
6. [Linter e Analisi](#6-linter-e-analisi)
7. [Entity Framework](#7-entity-framework)
8. [ASP.NET Core](#8-aspnet-core)
9. [Build e CI](#9-build-e-ci)
10. [Strumenti Ausiliari](#10-strumenti-ausiliari)

---

## 1. .NET CLI

### `dotnet new`
**Crea un nuovo progetto, soluzione o file da un template.**

- **Comando:** `dotnet new <template> [opzioni]`
- **Esempio:** `dotnet new webapi -n MyApi --use-controllers`
- **Template comuni:**
  - `console` — applicazione console
  - `webapi` — API RESTful (minimal o controllers)
  - `mvc` — applicazione MVC
  - `classlib` — libreria di classi
  - `xunit` / `nunit` / `mstest` — progetti test
  - `blazorwasm` / `blazorserver` — Blazor
  - `worker` — Worker Service
- **Opzioni:** `-n` (nome), `-o` (output directory), `--framework net8.0`

### `dotnet run`
**Compila ed esegue il progetto corrente.**

- **Comando:** `dotnet run [opzioni] [-- additional-args]`
- **Esempio:** `dotnet run --project src/MyApp -- --urls=http://localhost:5000`
- **Note:** `--project` specifica il path del progetto

### `dotnet build`
**Compila il progetto e le sue dipendenze.**

- **Comando:** `dotnet build [opzioni]`
- **Esempio:** `dotnet build -c Release --no-restore`
- **Opzioni:** `-c` (configuration: Debug/Release), `--no-restore`, `-o` (output)

### `dotnet publish`
**Pubblica l'applicazione per la distribuzione.**

- **Comando:** `dotnet publish [opzioni]`
- **Esempio:** `dotnet publish -c Release -o ./publish --self-contained true -r win-x64`
- **Opzioni:** `--self-contained`, `-r` (runtime identifier), `--no-self-contained`, `-o`

### `dotnet restore`
**Ripristina i pacchetti NuGet e le dipendenze del progetto.**

- **Comando:** `dotnet restore [opzioni]`
- **Esempio:** `dotnet restore src/MyApp.sln`

### `dotnet clean`
**Pulisce gli output della build.**

- **Comando:** `dotnet clean [opzioni]`
- **Esempio:** `dotnet clean -c Release`

### `dotnet test`
**Esegue i test unitari nel progetto.**

- **Comando:** `dotnet test [opzioni]`
- **Esempio:** `dotnet test --filter "FullyQualifiedName~Integration" --logger "trx;LogFileName=test_results.trx"`

### `dotnet pack`
**Crea un pacchetto NuGet (.nupkg) dal progetto.**

- **Comando:** `dotnet pack [opzioni]`
- **Esempio:** `dotnet pack -c Release -o ./nupkg`

### `dotnet nuget push`
**Carica un pacchetto NuGet su un feed.**

- **Comando:** `dotnet nuget push <file.nupkg> [opzioni]`
- **Esempio:** `dotnet nuget push *.nupkg --api-key <key> --source https://api.nuget.org/v3/index.json`

### `dotnet tool install`
**Installa uno strumento .NET globale o locale.**

- **Comando:** `dotnet tool install <package> [opzioni]`
- **Esempio:** `dotnet tool install -g dotnet-ef` (globale)
- **Esempio:** `dotnet tool install dotnet-format --local` (locale)

### `dotnet tool list`
**Elenca gli strumenti .NET installati.**

- **Comando:** `dotnet tool list -g` (globali)
- **Esempio:** `dotnet tool list --local` (locali)

### `dotnet workload list`
**Gestisce carichi di lavoro .NET (MAUI, Blazor Hybrid, ecc.).**

- **Comando:** `dotnet workload list`
- **Esempio:** `dotnet workload install maui`

### `dotnet --info`
**Mostra informazioni dettagliate sull'SDK e runtime .NET.**

- **Comando:** `dotnet --info`
- **Esempio:** `dotnet --list-sdks` (versioni SDK installate)

---

## 2. Gestione Pacchetti (NuGet)

### `dotnet add package`
**Aggiunge un riferimento a un pacchetto NuGet.**

- **Comando:** `dotnet add <progetto> package <pacchetto> [opzioni]`
- **Esempio:** `dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0`

### `dotnet remove package`
**Rimuove un riferimento a un pacchetto NuGet.**

- **Comando:** `dotnet remove <progetto> package <pacchetto>`
- **Esempio:** `dotnet remove src/MyApp/MyApp.csproj package Newtonsoft.Json`

### `dotnet list package`
**Elenca i riferimenti ai pacchetti del progetto.**

- **Comando:** `dotnet list <progetto> package [opzioni]`
- **Esempio:** `dotnet list package --outdated` (versioni più recenti disponibili)
- **Esempio:** `dotnet list package --vulnerable` (pacchetti con vulnerabilità note)

### `dotnet nuget list source`
**Elenca le sorgenti NuGet configurate.**

- **Comando:** `dotnet nuget list source`
- **Note:** Configurazione in `NuGet.config`

### `dotnet nuget add source`
**Aggiunge una sorgente NuGet.**

- **Comando:** `dotnet nuget add source <url> -n <nome>`
- **Esempio:** `dotnet nuget add source https://pkgs.dev.azure.com/... -n AzureDevOps`

### `nuget.exe`
**CLI classica di NuGet (precede dotnet CLI).**

- **Comando:** `nuget <comando> [opzioni]`
- **Esempio:** `nuget install packages.config -OutputDirectory packages`

---

## 3. IDE e Editor

### `dotnet dev-certs`
**Gestione certificati di sviluppo HTTPS per ASP.NET Core.**

- **Comando:** `dotnet dev-certs https --trust`
- **Esempio:** `dotnet dev-certs https --clean --trust`

### `dotnet user-secrets`
**Gestione segreti di sviluppo (user secrets).**

- **Comando:** `dotnet user-secrets <comando> [opzioni]`
- **Esempio:** `dotnet user-secrets set "ConnectionStrings:Default" "Server=localhost"`

### `dotnet watch`
**Watch mode — ricompila e riavvia al cambiamento dei file.**

- **Comando:** `dotnet watch [opzioni] [comando]`
- **Esempio:** `dotnet watch run --project src/MyApi`
- **Note:** Supporta `dotnet watch test`, `dotnet watch run`

### `dotnet format`
**Formattatore di codice per progetti .NET.**

- **Comando:** `dotnet format [opzioni]`
- **Esempio:** `dotnet format src/ --verify-no-changes` (controlla senza modificare)
- **Note:** Include analizzatori .NET SDK style analyzers

### `dotnet codeanalysis`
**Analisi statica del codice con .NET Roslyn analyzers.**

- **Attivazione:** `<EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>` nel .csproj
- **Comando:** Compilazione con warning come errori

---

## 4. Debugger

### `dotnet run --debug`
**Avvia l'applicazione con debugger attaccabile.**

- **Comando:** `dotnet run --debug`
- **Note:** Restituisce un URI per connettere un debugger remoto

### `dotnet trace`
**Tracing di applicazioni .NET in esecuzione (EventPipe).**

- **Comando:** `dotnet trace collect --process-id <pid> --providers Microsoft-Windows-DotNETRuntime`
- **Esempio:** `dotnet trace collect -p 1234 -o trace.nettrace`

### `dotnet counters`
**Monitoraggio di contatori di performance in tempo reale.**

- **Comando:** `dotnet counters monitor --process-id <pid>`
- **Esempio:** `dotnet counters monitor -p 1234`

### `dotnet dump`
**Acquisizione e analisi di dump di processo .NET.**

- **Comando:** `dotnet dump collect --process-id <pid>`
- **Esempio:** `dotnet dump analyze <dump-file>` (analisi interattiva)

### `dotnet gcdump`
**Acquisizione di dump GC (garbage collector).**

- **Comando:** `dotnet gcdump collect --process-id <pid>`
- **Esempio:** `dotnet gcdump collect -p 1234`

### `dotnet sos`
**Estensione per debug nativo (WinDbg, LLDB) per .NET.**

- **Comando (in debugger):** `!dumpheap`, `!clrstack`, `!do <object>`

---

## 5. Testing

### `dotnet test`
**Esegue i test con il runner predefinito.**

- **Comando:** `dotnet test [opzioni]`
- **Esempio:** `dotnet test --configuration Release --filter "Category=Unit"`

### `xUnit`
**Framework testing moderno per .NET (più diffuso).**

- **Installazione:** `dotnet add package xunit`
- **Esempio:**
  ```csharp
  public class MathTests
  {
      [Fact]
      public void Add_ShouldReturnSum()
      {
          Assert.Equal(5, Calculator.Add(2, 3));
      }

      [Theory]
      [InlineData(1, 2, 3)]
      [InlineData(10, 20, 30)]
      public void Add_ShouldReturnSum_Theory(int a, int b, int expected)
      {
          Assert.Equal(expected, Calculator.Add(a, b));
      }
  }
  ```

### `NUnit`
**Framework testing maturo e ricco di funzionalità.**

- **Installazione:** `dotnet add package nunit`
- **Esempio:**
  ```csharp
  [TestFixture]
  public class MathTests
  {
      [Test]
      public void Add_ShouldReturnSum()
      {
          Assert.That(Calculator.Add(2, 3), Is.EqualTo(5));
      }
  }
  ```

### `MSTest`
**Framework testing di Microsoft.**

- **Installazione:** `dotnet add package MSTest.TestFramework`
- **Esempio:**
  ```csharp
  [TestClass]
  public class MathTests
  {
      [TestMethod]
      public void Add_ShouldReturnSum()
      {
          Assert.AreEqual(5, Calculator.Add(2, 3));
      }
  }
  ```

### `Moq`
**Framework di mocking per .NET.**

- **Installazione:** `dotnet add package Moq`
- **Esempio:**
  ```csharp
  var mockRepo = new Mock<IRepository>();
  mockRepo.Setup(r => r.GetById(1)).Returns(new User { Id = 1 });
  var service = new UserService(mockRepo.Object);
  ```

### `FluentAssertions`
**Assertions leggibili e fluenti per test.**

- **Installazione:** `dotnet add package FluentAssertions`
- **Esempio:**
  ```csharp
  result.Should().Be(5).And.BePositive();
  list.Should().HaveCount(3).And.ContainItemsAssignableTo<int>();
  ```

### `coverlet`
**Code coverage per .NET.**

- **Installazione:** `dotnet add package coverlet.collector`
- **Comando:** `dotnet test --collect:"XPlat Code Coverage"`
- **Report:** `reportgenerator -reports:coverage.cobertura.xml -targetdir:coverage-report`

---

## 6. Linter e Analisi

### `dotnet format`
**Formattazione automatica basata su editorconfig e analizzatori.**

- **Comando:** `dotnet format [opzioni]`
- **Esempio:** `dotnet format --verify-no-changes --severity error`

### `.editorconfig`
**Configurazione delle regole di stile e formattazione.**

- **Esempio:**
  ```ini
  root = true
  [*]
  indent_style = space
  indent_size = 4
  [*.cs]
  dotnet_naming_rule.types_and_namespaces_should_be_pascalcase.severity = error
  ```

### `SonarAnalyzer`
**Analisi statica avanzata (sonarlint integration).**

- **Installazione:** `dotnet add package SonarAnalyzer.CSharp`
- **Note:** Rileva code smell, bug, vulnerabilità di sicurezza

### `Roslyn Analyzers`
**Analizzatori integrati nel .NET SDK.**

- **Attivazione:** `<AnalysisMode>Recommended</AnalysisMode>` in .csproj
- **Altri:** `<AnalysisMode>All</AnalysisMode>` (tutti), `MinimumRecommended`, `Minimum`

---

## 7. Entity Framework

### `dotnet ef`
**Strumento CLI per Entity Framework Core.**

- **Installazione:** `dotnet tool install -g dotnet-ef`

### `dotnet ef migrations add`
**Crea una nuova migrazione dal modello dati.**

- **Comando:** `dotnet ef migrations add <nome> [opzioni]`
- **Esempio:** `dotnet ef migrations add InitialCreate --context AppDbContext`

### `dotnet ef database update`
**Applica le migrazioni al database.**

- **Comando:** `dotnet ef database update [opzioni]`
- **Esempio:** `dotnet ef database update --connection "Server=localhost;Database=MyDb"`

### `dotnet ef dbcontext scaffold`
**Genera modello da database esistente (reverse engineering).**

- **Comando:** `dotnet ef dbcontext scaffold <connection-string> <provider>`
- **Esempio:** `dotnet ef dbcontext scaffold "Server=localhost;Database=MyDb" Microsoft.EntityFrameworkCore.SqlServer`

### `dotnet ef migrations list`
**Elenca le migrazioni con stato (applicata/in sospeso).**

- **Comando:** `dotnet ef migrations list [opzioni]`
- **Esempio:** `dotnet ef migrations list --context AppDbContext`

### `dotnet ef migrations remove`
**Rimuove l'ultima migrazione (non applicata).**

- **Comando:** `dotnet ef migrations remove [opzioni]`
- **Esempio:** `dotnet ef migrations remove --force`

### `dotnet ef migrations script`
**Genera script SQL dalle migrazioni.**

- **Comando:** `dotnet ef migrations script [opzioni]`
- **Esempio:** `dotnet ef migrations script --output script.sql`

### `dotnet ef database drop`
**Elimina il database corrente.**

- **Comando:** `dotnet ef database drop [opzioni]`
- **Esempio:** `dotnet ef database drop --force --context AppDbContext`

---

## 8. ASP.NET Core

### `dotnet watch run`
**Avvio con hot-reload per sviluppo ASP.NET Core.**

- **Comando:** `dotnet watch run --project src/MyApi`
- **Note:** Riavvio automatico al salvataggio dei file

### `dotnet dev-certs https --trust`
**Configurazione certificato HTTPS di sviluppo.**

- **Comando:** `dotnet dev-certs https --trust`
- **Esempio:** `dotnet dev-certs https --clean --trust`

### `launchSettings.json`
**Configurazione profili di avvio (Kestrel, IIS Express, variabili ambiente).**

- **Path:** `Properties/launchSettings.json`
- **Esempio:**
  ```json
  {
    "profiles": {
      "MyApi": {
        "applicationUrl": "https://localhost:5001;http://localhost:5000",
        "environmentVariables": { "ASPNETCORE_ENVIRONMENT": "Development" }
      }
    }
  }
  ```

### `appsettings.json`
**Configurazione dell'applicazione (JSON).**

- **Path:** `appsettings.json`, `appsettings.Development.json`
- **Esempio:**
  ```json
  {
    "ConnectionStrings": {
      "Default": "Server=localhost;Database=MyDb"
    },
    "Logging": {
      "LogLevel": { "Default": "Information" }
    }
  }
  ```

### `dotnet user-secrets`
**Override della configurazione per sviluppo locale (non committata).**

- **Comando:** `dotnet user-secrets set "ApiKey" "test-key-123"`
- **Path archiviazione:** `%APPDATA%\Microsoft\UserSecrets\`

---

## 9. Build e CI

### `dotnet msbuild`
**Esecuzione diretta di MSBuild per build avanzate.**

- **Comando:** `dotnet msbuild <file.sln> [opzioni]`
- **Esempio:** `dotnet msbuild -t:Restore;Build -p:Configuration=Release`

### `dotnet restore` con feed privati
**Restauro pacchetti da sorgenti multiple.**

- **Configurazione:** `NuGet.config`
- **Esempio NuGet.config:**
  ```xml
  <configuration>
    <packageSources>
      <clear />
      <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
      <add key="myfeed" value="https://myfeed.pkgs.visualstudio.com/_packaging/feed/nuget/v3/index.json" />
    </packageSources>
  </configuration>
  ```

### `dotnet test --collect:"XPlat Code Coverage"`
**Esecuzione test con code coverage in CI.**

- **Comando completo:**
  ```
  dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings
  ```
- **Report:** `reportgenerator -reports:**/coverage.cobertura.xml -targetdir:coverage -reporttypes:Html`

### `Directory.Build.props`
**Proprietà di build condivise tra progetti in una directory.**

- **Esempio:**
  ```xml
  <Project>
    <PropertyGroup>
      <TargetFramework>net8.0</TargetFramework>
      <Nullable>enable</Nullable>
      <ImplicitUsings>enable</ImplicitUsings>
      <AnalysisMode>Recommended</AnalysisMode>
    </PropertyGroup>
  </Project>
  ```

---

## 10. Strumenti Ausiliari

### `dotnet outdated`
**Trova pacchetti NuGet con versioni obsolete.**

- **Installazione:** `dotnet tool install -g dotnet-outdated`
- **Comando:** `dotnet outdated`

### `dotnet-format` (locally)
**Formattatore di codice per CI/CD.**

- **Installazione:** `dotnet tool install -g dotnet-format`
- **Comando:** `dotnet format --check`

### `dotnet-script`
**Esecuzione di script C# senza progetto (.csx).**

- **Installazione:** `dotnet tool install -g dotnet-script`
- **Comando:** `dotnet script script.csx`
- **Esempio script.csx:**
  ```csharp
  #r "nuget: Newtonsoft.Json"
  Console.WriteLine("Hello from script!");
  ```

### `dotnet-repl`
**REPL interattivo per C# (.NET Interactive).**

- **Installazione:** `dotnet tool install -g dotnet-repl`
- **Comando:** `dotnet-repl`

### `ILSpy` / `dnSpy`
**Decompilatore .NET per ispezione di assembly IL.**

- **dnSpy:** Debugger + decompilatore per .NET Framework/Core
- **ILSpy:** Decompilatore standalone con supporto C# e IL

### `BenchmarkDotNet`
**Framework per benchmarking di performance .NET.**

- **Installazione:** `dotnet add package BenchmarkDotNet`
- **Esempio:**
  ```csharp
  [SimpleJob(RuntimeMoniker.Net80)]
  public class MyBenchmark
  {
      [Benchmark]
      public void TestMethod() { ... }
  }
  ```

### `NSwag` / `Swashbuckle`
**Generazione di client API e documentazione Swagger/OpenAPI.**

- **NSwag CLI:**
  ```
  dotnet tool install -g NSwag.ConsoleCore
  nswag openapi2csclient /input:swagger.json /output:ApiClient.cs
  ```
- **Swashbuckle:** Integrazione Swagger in ASP.NET Core

### `dotnet-svcutil`
**Strumento per generare client WCF da metadati.**

- **Installazione:** `dotnet tool install -g dotnet-svcutil`
- **Comando:** `dotnet-svcutil http://service.example.com?wsdl`

### `cake` (C# Make)
**Script di build in C# con sintassi DSL.**

- **Comando:** `dotnet cake build.cake`
- **Installazione:** `dotnet tool install -g cake.tool`

---

## Licenza

MIT

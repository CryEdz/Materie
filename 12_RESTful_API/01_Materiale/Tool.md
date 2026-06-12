# RESTful API Tools — Guida Essenziale

Elenco completo dei tool e comandi più utilizzati per progettazione, sviluppo, test e documentazione di API RESTful, organizzati per categoria. Ogni tool include descrizione, comando principale, esempio d'uso e note.

---

## Indice

1. [Client HTTP](#1-client-http)
2. [Framework per API](#2-framework-per-api)
3. [Documentazione e Specifiche (OpenAPI)](#3-documentazione-e-specifiche-openapi)
4. [Testing API](#4-testing-api)
5. [Mock e Virtualizzazione](#5-mock-e-virtualizzazione)
6. [Autenticazione e Sicurezza](#6-autenticazione-e-sicurezza)
7. [Performance e Carico](#7-performance-e-carico)
8. [API Gateway e Proxy](#8-api-gateway-e-proxy)
9. [Strumenti Ausiliari](#9-strumenti-ausiliari)

---

## 1. Client HTTP

### `curl`
**Client HTTP a riga di comando universale (sviluppo e debug API).**

- **Comando:** `curl [opzioni] <URL>`
- **Esempio (GET):** `curl -X GET https://api.example.com/users -H "Authorization: Bearer token123"`
- **Esempio (POST JSON):** `curl -X POST https://api.example.com/users -H "Content-Type: application/json" -d '{"name":"Mario"}'`
- **Opzioni utili:** `-i` (headers), `-v` (verbose), `-o file`, `-L` (follow redirect), `-u user:pass` (Basic Auth), `-k` (SSL no verify), `--connect-timeout`, `--max-time`

### `httpie`
**Client HTTP moderno con sintassi semplificata e output colorato.**

- **Comando:** `http [comando] <URL> [opzioni]`
- **Esempio (GET):** `http https://api.example.com/users Authorization:'Bearer token123'`
- **Esempio (POST):** `http POST https://api.example.com/users name=Mario email=mario@example.com`
- **Esempio (download):** `http -d https://example.com/file.zip`

### `wget`
**Download ricorsivo e non interattivo di risorse HTTP.**

- **Comando:** `wget [opzioni] <URL>`
- **Esempio:** `wget --header="Authorization: Bearer token" https://api.example.com/export.csv`

### `httpx` (Python)
**Client HTTP moderno con supporto HTTP/2, async e interfaccia simile a requests.**

- **Installazione:** `pip install httpx`
- **Esempio:**
  ```python
  import httpx
  resp = httpx.get("https://api.example.com/users", headers={"Authorization": "Bearer token"})
  ```

### `Insomnia` (GUI)
**Client API con interfaccia grafica per test, debugging e automazione.**

- **Note:** Supporta GraphQL, gRPC, WebSocket, autenticazione, environment variables, code generation

---

## 2. Framework per API

### ASP.NET Core Web API (C#)
**Framework Microsoft per API RESTful su .NET.**

- **Comando:** `dotnet new webapi -n MyApi --use-controllers`
- **Template:** `dotnet new webapi` (minimal API) o `--use-controllers` (Controller-based)
- **Esempio controller:**
  ```csharp
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
      [HttpGet]
      public IActionResult GetAll() => Ok(new[] { new User { Name = "Mario" } });
  }
  ```

### FastAPI (Python)
**Framework moderno per API RESTful in Python (async, OpenAPI automatico).**

- **Installazione:** `pip install fastapi uvicorn`
- **Avvio:** `uvicorn main:app --reload`
- **Esempio:**
  ```python
  from fastapi import FastAPI
  app = FastAPI()
  @app.get("/users")
  async def get_users():
      return [{"name": "Mario"}]
  ```

### Express.js (Node.js)
**Framework web per Node.js minimale e flessibile.**

- **Installazione:** `npm install express`
- **Esempio:**
  ```javascript
  const express = require('express')
  const app = express()
  app.get('/users', (req, res) => res.json([{ name: 'Mario' }]))
  app.listen(3000)
  ```

### Spring Boot (Java)
**Framework enterprise per API RESTful in Java/JVM.**

- **Installazione:** `curl -s start.spring.io/starter.zip -d type=gradle-project -d language=java -o myapi.zip`
- **Esempio:**
  ```java
  @RestController
  @RequestMapping("/users")
  public class UserController {
      @GetMapping
      public List<User> getUsers() { return List.of(new User("Mario")); }
  }
  ```

### Django REST Framework (Python)
**Estensione Django per API RESTful robuste e batteries-included.**

- **Installazione:** `pip install djangorestframework`
- **Esempio:**
  ```python
  class UserViewSet(viewsets.ModelViewSet):
      queryset = User.objects.all()
      serializer_class = UserSerializer
  ```

### Gin (Go)
**Framework HTTP veloce per API RESTful in Go.**

- **Installazione:** `go get github.com/gin-gonic/gin`
- **Esempio:**
  ```go
  r := gin.Default()
  r.GET("/users", func(c *gin.Context) { c.JSON(200, gin.H{"name": "Mario"}) })
  ```

---

## 3. Documentazione e Specifiche (OpenAPI)

### OpenAPI / Swagger
**Specifica standard per descrivere API RESTful (OpenAPI 3.x).**

- **Formato:** YAML o JSON
- **URL specifica:** `/swagger/v1/swagger.json`
- **UI interattiva:** Swagger UI (es. `https://petstore.swagger.io`)

### Swagger UI
**Interfaccia web per visualizzare e testare API da specifica OpenAPI.**

- **Path tipico:** `/swagger` o `/swagger/index.html`
- **Esempio:** `docker run -p 80:8080 -e SWAGGER_JSON=/spec/openapi.yaml -v $(pwd):/spec swaggerapi/swagger-ui`

### Swagger Editor
**Editor web per scrivere specifiche OpenAPI con preview live.**

- **URL:** https://editor.swagger.io
- **Docker:** `docker run -p 80:8080 swaggerapi/swagger-editor`

### Swashbuckle (ASP.NET Core)
**Integrazione Swagger in ASP.NET Core (generazione automatica).**

- **Installazione:** Pacchetto `Swashbuckle.AspNetCore`
- **Configurazione:**
  ```csharp
  builder.Services.AddSwaggerGen();
  app.UseSwagger();
  app.UseSwaggerUI();
  ```

### NSwag
**Tool per generare client API e server stub da specifica Swagger/OpenAPI.**

- **Installazione:** `dotnet tool install -g NSwag.ConsoleCore`
- **Comando:** `nswag openapi2csclient /input:swagger.json /output:ApiClient.cs /namespace:MyApp.Client`

### Redoc
**Documentazione API alternativa a Swagger UI (design pulito, tre colonne).**

- **URL:** https://redocly.com/redoc
- **Docker:** `docker run -p 80:80 -e SPEC_URL=http://host/openapi.yaml redocly/redoc`

### `openapi-generator`
**Generatore di client, server e documentazione da specifica OpenAPI.**

- **Comando:** `openapi-generator generate -i openapi.yaml -g csharp-netcore -o ./client`
- **Installazione:** `npm install @openapitools/openapi-generator-cli -g`
- **Linguaggi:** 50+ (Java, C#, Python, TypeScript, Go, Rust, ecc.)

### `spectral`
**Linter per specifiche OpenAPI/AsyncAPI.**

- **Comando:** `spectral lint openapi.yaml`
- **Installazione:** `npm install -g @stoplight/spectral-cli`
- **Regole:** Decine di regole built-in + custom rules

### `swagger-cli`
**Tool per validazione, bundle e trasformazione di specifiche OpenAPI.**

- **Comando:** `swagger-cli validate openapi.yaml`
- **Esempio:** `swagger-cli bundle openapi.yaml --outfile bundled.yaml --type yaml`

---

## 4. Testing API

### Postman
**Piattaforma per sviluppo e testing di API (GUI + CLI).**

- **Funzioni:** Collection runner, environment variables, pre-request scripts, test scripts (JavaScript), mock server, monitor
- **CLI:** `newman run collection.json -e environment.json`

### `newman`
**CLI per esecuzione di collection Postman (CI/CD).**

- **Comando:** `newman run <collection> [opzioni]`
- **Esempio:** `newman run my-collection.json -e prod-env.json --reporters cli,junit --reporter-junit-export results.xml`
- **Installazione:** `npm install -g newman`

### Bruno
**Client API open-source con file di request salvati in plain text (git-friendly).**

- **Note:** Alternativa a Postman, ogni request è un file `.bru`
- **Funzioni:** Environment, pre-request/test script, CI integration

### REST Client (VS Code)
**Estensione VS Code per eseguire request HTTP dal file `.http`.**

- **Formato file .http:**
  ```
  GET https://api.example.com/users
  Authorization: Bearer {{token}}
  ```
- **Esecuzione:** Click su "Send Request" nell'editor

### Supertest (Node.js)
**Libreria per test di API HTTP in Node.js/Express.**

- **Installazione:** `npm install supertest --save-dev`
- **Esempio (Jest):**
  ```javascript
  const request = require('supertest')
  const app = require('../app')
  test('GET /users', async () => {
    await request(app).get('/users').expect(200).expect([{ name: 'Mario' }])
  })
  ```

### pytest + httpx (Python)
**Testing API in Python con pytest.**

- **Esempio:**
  ```python
  def test_get_users(client):
      response = client.get("/users")
      assert response.status_code == 200
  ```

### WebApplicationFactory (.NET)
**Test integration per ASP.NET Core (in-memory server).**

- **Esempio:**
  ```csharp
  var factory = new WebApplicationFactory<Program>();
  var client = factory.CreateClient();
  var response = await client.GetAsync("/users");
  response.EnsureSuccessStatusCode();
  ```

---

## 5. Mock e Virtualizzazione

### WireMock
**Libreria per mock di API HTTP (Java, .NET).**

- **Configurazione:**
  ```java
  stubFor(get(urlPathEqualTo("/users")).willReturn(aResponse().withStatus(200).withBody("[]")))
  ```
- **.NET:** `WireMock.Net` pacchetto NuGet

### Mockoon
**Tool GUI per creare mock server API in pochi click (standalone, multi-piattaforma).**

- **URL:** https://mockoon.com
- **Esempio:** Crea route, definisce response, usa template dinamici

### JSON Server
**Mock REST API da file JSON (Node.js, zero configurazione).**

- **Comando:** `npx json-server --watch db.json --port 3000`
- **db.json:**
  ```json
  { "users": [{ "id": 1, "name": "Mario" }] }
  ```
- **Endpoint generati:** `GET /users`, `POST /users`, `PUT /users/1`, `DELETE /users/1`

### Postman Mock Server
**Mock server integrato in Postman (da collection).**

- **Creazione:** `Postman > Mock Servers > Create New`

### Stoplight Prism
**Mock server OpenAPI (valida richieste/risposte contro la specifica).**

- **Comando:** `prism mock openapi.yaml`
- **Installazione:** `npm install -g @stoplight/prism-cli`

---

## 6. Autenticazione e Sicurezza

### `jwt.io`
**Debugger online per token JWT (decodifica header/payload/verify signature).**

- **URL:** https://jwt.io

### `jwt-cli`
**Tool CLI per creazione, firma e verifica token JWT.**

- **Installazione:** `npm install -g jwt-cli`
- **Comando:** `jwt encode --secret "mysecret" '{"sub":"123","role":"admin"}'`

### OAuth2 Proxy
**Proxy reverse per autenticazione OAuth2/OIDC.**

- **Comando:** `oauth2-proxy --provider=google --client-id=... --email-domain=example.com --upstream=http://localhost:8080`

### Keycloak
**Identity and Access Management (OAuth2, OpenID Connect, SAML).**

- **Avvio Docker:** `docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:latest start-dev`

### `openssl`
**Generazione certificati e chiavi per API HTTPS e JWT.**

- **Esempio:** `openssl req -x509 -newkey rsa:4096 -keyout key.pem -out cert.pem -days 365 -nodes`

### `hashicorp vault`
**Gestione segreti e token API per microservizi.**

- **Comando:** `vault kv put secret/api/api-key value=my-secret-key`

---

## 7. Performance e Carico

### `ab` (ApacheBench)
**Strumento per benchmark HTTP semplice.**

- **Comando:** `ab -n 1000 -c 10 https://api.example.com/users`
- **Report:** Requests/sec, time per request, transfer rate

### `wrk`
**Benchmark HTTP moderno con supporto Lua scripting.**

- **Comando:** `wrk -t12 -c400 -d30s https://api.example.com/users`
- **Installazione:** `brew install wrk` (macOS) o da sorgente

### `hey`
**Benchmark HTTP semplice (scritto in Go, alternativa a ab/wrk).**

- **Comando:** `hey -n 1000 -c 10 https://api.example.com/users`
- **Installazione:** `go install github.com/rakyll/hey@latest`

### `k6`
**Strumento di test di carico moderno con scripting JavaScript.**

- **Comando:** `k6 run script.js`
- **Esempio script.js:**
  ```javascript
  import http from 'k6/http';
  export default function () { http.get('https://api.example.com/users'); }
  export let options = { vus: 10, duration: '30s' };
  ```

### `artillery`
**Test di carico per API con configurazione YAML dichiarativa.**

- **Installazione:** `npm install -g artillery`
- **Comando:** `artillery run load-test.yml`
- **Configurazione:**
  ```yaml
  config: { target: 'https://api.example.com', phases: [{ duration: 60, arrivalRate: 5 }] }
  scenarios: [{ flow: [{ get: { url: '/users' } }] }]
  ```

### `jmeter`
**Tool di test di carico GUI-based (Apache).**

- **Comando:** `jmeter -n -t test-plan.jmx -l results.jtl`
- **Note:** Supporta API REST, SOAP, JDBC, JMS, FTP

### `vegeta`
**Benchmark HTTP costante (CLI semplice e veloce).**

- **Comando:** `echo "GET https://api.example.com/users" | vegeta attack -rate=100 -duration=30s | vegeta report`
- **Installazione:** `go install github.com/tsenart/vegeta@latest`

---

## 8. API Gateway e Proxy

### NGINX
**Reverse proxy, load balancer e API gateway.**

- **Configurazione (reverse proxy):**
  ```nginx
  location /api/ {
      proxy_pass http://backend:5000/;
      proxy_set_header Host $host;
  }
  ```

### Traefik
**API gateway dinamico con auto-discovery (Docker, Kubernetes).**

- **Avvio:** `docker run -p 80:80 -p 8080:8080 traefik --api.insecure=true --providers.docker`

### Kong
**API gateway enterprise-ready con plugin (autenticazione, rate limiting, logging).**

- **Avvio Docker:** `docker run -p 8000:8000 kong/kong-gateway`
- **Plugin:** Key Auth, OAuth2, Rate Limiting, IP Restriction, CORS, Logging

### Ocelot (.NET)
**API gateway per .NET (leggero, configurabile via JSON).**

- **Installazione:** NuGet `Ocelot`
- **Configurazione ocelot.json:**
  ```json
  {
    "Routes": [{ "DownstreamPathTemplate": "/users", "DownstreamScheme": "https", "DownstreamHostAndPorts": [{ "Host": "localhost", "Port": 5001 }], "UpstreamPathTemplate": "/api/users" }]
  }
  ```

### YARP (.NET)
**Reverse proxy .NET Microsoft (Yet Another Reverse Proxy).**

- **Installazione:** NuGet `Yarp.ReverseProxy`
- **Configurazione:** Tramite `appsettings.json` con route e cluster

### `socat`
**Multipurpose relay per inoltro connessioni TCP (utile per forwarding API).**

- **Comando:** `socat TCP-LISTEN:8080,fork TCP:localhost:5000`

---

## 9. Strumenti Ausiliari

### `jq`
**Processore JSON da riga di comando (filtraggio, trasformazione).**

- **Comando:** `jq [opzioni] <filtro> [file]`
- **Esempio:** `curl https://api.example.com/users | jq '.[] | {name, email}'`
- **Esempio:** `jq '.data | group_by(.category) | length' data.json`

### `yq`
**Processore YAML da riga di comando (stile jq).**

- **Comando:** `yq eval <espressione> <file>`
- **Esempio:** `yq eval '.info.title' openapi.yaml`

### `jsonschema`
**Validatore JSON Schema per richieste/risposte API.**

- **Installazione:** `npm install -g jsonschema`
- **Comando:** `jsonschema -i data.json schema.json`

### `json-server-auth`
**JSON Server con autenticazione JWT integrata.**

- **Comando:** `npx json-server-auth db.json --port 3000`

### `ngrok`
**Tunnel per esporre API locale su Internet (webhook testing, demo).**

- **Comando:** `ngrok http 3000`
- **Note:** Genera URL pubblico `https://abc123.ngrok.io`

### `localtunnel`
**Alternativa open-source a ngrok per esporre API locale.**

- **Comando:** `npx localtunnel --port 3000`

### `httpbin`
**Servizio di test per debug di client HTTP (echo request, status code, header).**

- **URL:** https://httpbin.org
- **Comando/Docker:** `docker run -p 80:80 kennethreitz/httpbin`
- **Endpoint utili:** `/anything`, `/status/404`, `/delay/3`, `/headers`, `/ip`

### `requestbin`
**Endpoint temporaneo per ispezionare richieste HTTP in entrata (webhook testing).**

- **URL:** https://requestbin.com

### `mockapi.io`
**Generatore di API mock online (CRUD automatico da schema).**

- **URL:** https://mockapi.io
- **Note:** Crea API RESTful con risorse personalizzabili

---

## Licenza

MIT

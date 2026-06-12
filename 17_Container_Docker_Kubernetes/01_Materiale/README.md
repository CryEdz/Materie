# Docker & Kubernetes Tools

Una guida essenziale e strutturata ai tool più utilizzati per la containerizzazione con Docker e l'orchestrazione con Kubernetes.

## Contenuto

Il repository contiene:

- **`Tool.md`** — Elenco completo di tool e comandi per Docker e Kubernetes organizzati per categoria:
  - Docker: Gestione Container
  - Docker: Immagini e Registry
  - Docker: Networking
  - Docker: Volumi e Storage
  - Dockerfile: Istruzioni
  - Docker Compose
  - Docker Swarm
  - Kubernetes: Pod e Deployment
  - Kubernetes: Service e Networking
  - Kubernetes: Storage
  - Kubernetes: Configurazione e Secreti
  - Kubernetes: Workload Avanzati
  - Kubernetes: Diagnostica e Debug
  - Kubernetes: RBAC e Sicurezza
  - Helm: Package Manager
  - Strumenti Ausiliari

Ogni tool include: nome, descrizione, comando principale, esempio d'uso e note.

## Struttura del file

```markdown
### `nome-tool`
**Descrizione breve.**

- **Comando:** `comando principale`
- **Esempio:** `esempio d'uso`
- **Note:** Note aggiuntive
```

## Requisiti

- **Docker:** Installazione di Docker Engine (docker.io) o Docker Desktop
- **Kubernetes:** Minikube, kind, k3s/k3d o cluster remoto con `kubectl` configurato
- **Helm:** CLI Helm installata per la sezione dedicata (opzionale)

## Licenza

MIT

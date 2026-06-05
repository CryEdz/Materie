# Prompt guida — 17_Container_Docker_Kubernetes

Questo file è una versione "implementata" del `TEMPLATE_PROMPT.md` presente nella cartella.

Contesto: `17_Container_Docker_Kubernetes/labs/<subpath>`

Obiettivo: generare o revisionare Dockerfile, `docker-compose.yml` o manifest Kubernetes (YAML) per il lab specifico e fornire istruzioni di deploy locale (comandi `docker` / `docker compose` / `kubectl`).

Richiedo: i file di configurazione (Dockerfile, compose, manifest) e la lista dei comandi esatti necessari per avviare l'ambiente in locale.

Esempio di richiesta da utilizzare in una singola lab (sostituire `<subpath>`):

- **Contesto**: `17_Container_Docker_Kubernetes/labs/17-Docker_compose`
- **Obiettivo**: scrivi un `docker-compose.yml` che lancia un'app web e un database Postgres, esponendo la porta 8080 e collegando i volumi persistenti.
- **Output richiesto**: `docker-compose.yml`, comandi per build/avvio (`docker compose up --build -d`), e comandi per debug/log.

---
Per generare `PROMPT.md` in tutte le lab automaticamente, esegui lo script `generate_prompts.py` nella stessa cartella.

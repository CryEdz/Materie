# Docker & Kubernetes Tools — Guida Essenziale

Elenco completo dei tool e comandi più utilizzati per container Docker e orchestrazione Kubernetes, organizzati per categoria. Ogni tool include nome, descrizione, comando principale, esempio d'uso e note.

---

## Indice

1. [Docker — Gestione Container](#1-docker--gestione-container)
2. [Docker — Immagini e Registry](#2-docker--immagini-e-registry)
3. [Docker — Networking](#3-docker--networking)
4. [Docker — Volumi e Storage](#4-docker--volumi-e-storage)
5. [Dockerfile — Istruzioni](#5-dockerfile--istruzioni)
6. [Docker Compose](#6-docker-compose)
7. [Docker Swarm](#7-docker-swarm)
8. [Kubernetes — Pod e Deployment](#8-kubernetes--pod-e-deployment)
9. [Kubernetes — Service e Networking](#9-kubernetes--service-e-networking)
10. [Kubernetes — Storage](#10-kubernetes--storage)
11. [Kubernetes — Configurazione e Secreti](#11-kubernetes--configurazione-e-secreti)
12. [Kubernetes — Workload Avanzati](#12-kubernetes--workload-avanzati)
13. [Kubernetes — Diagnostica e Debug](#13-kubernetes--diagnostica-e-debug)
14. [Kubernetes — RBAC e Sicurezza](#14-kubernetes--rbac-e-sicurezza)
15. [Helm — Package Manager](#15-helm--package-manager)
16. [Strumenti Ausiliari](#16-strumenti-ausiliari)

---

## 1. Docker — Gestione Container

### `docker run`
**Crea e avvia un container a partire da un'immagine.**

- **Comando:** `docker run [opzioni] immagine [comando]`
- **Esempio:** `docker run -d --name web -p 80:80 nginx:alpine`
- **Opzioni comuni:** `-d` (detached), `--name`, `-p` (port mapping), `-e` (env var), `-v` (volume), `--rm` (auto-rimuovi)

### `docker ps`
**Elenca i container in esecuzione.**

- **Comando:** `docker ps [opzioni]`
- **Esempio:** `docker ps -a` (tutti i container, anche fermati)
- **Note:** `-a` mostra anche i container stoppati, `-q` solo ID, `--filter` per filtrare

### `docker start` / `docker stop` / `docker restart`
**Avvia, ferma o riavvia uno o più container.**

- **Comando:** `docker start|stop|restart [opzioni] container [container...]`
- **Esempio:** `docker stop web && docker start web`

### `docker pause` / `docker unpause`
**Sospende o riprende tutti i processi in un container.**

- **Comando:** `docker pause|unpause container`
- **Esempio:** `docker pause redis`

### `docker rm`
**Rimuove uno o più container.**

- **Comando:** `docker rm [opzioni] container [container...]`
- **Esempio:** `docker rm -f web` (`-f` forza la rimozione anche se in esecuzione)

### `docker rename`
**Rinomina un container esistente.**

- **Comando:** `docker rename container nuovo_nome`
- **Esempio:** `docker rename web web-v2`

### `docker update`
**Aggiorna la configurazione di un container in esecuzione.**

- **Comando:** `docker update [opzioni] container`
- **Esempio:** `docker update --memory 512m --cpus 2 web`

### `docker logs`
**Mostra i log di un container.**

- **Comando:** `docker logs [opzioni] container`
- **Esempio:** `docker logs -f --tail 100 web` (follow + ultime 100 righe)
- **Note:** `-f` (follow), `--tail N` (ultime N righe), `-t` (timestamp)

### `docker exec`
**Esegue un comando all'interno di un container in esecuzione.**

- **Comando:** `docker exec [opzioni] container comando`
- **Esempio:** `docker exec -it web /bin/sh`
- **Note:** `-i` (interattivo), `-t` (TTY), `-u` (utente), `-w` (working directory)

### `docker stats`
**Mostra statistiche live di CPU, memoria, rete e I/O per container.**

- **Comando:** `docker stats [opzioni] [container...]`
- **Esempio:** `docker stats --no-stream web db`
- **Note:** `--no-stream` per un singolo snapshot

### `docker top`
**Mostra i processi in esecuzione all'interno di un container.**

- **Comando:** `docker top container [ps_options]`
- **Esempio:** `docker top web aux`

### `docker inspect`
**Mostra informazioni dettagliate su container, immagini o volumi in formato JSON.**

- **Comando:** `docker inspect [opzioni] nome|id [nome|id...]`
- **Esempio:** `docker inspect web | jq '.[0].NetworkSettings.IPAddress'`
- **Note:** `--format '{{ .State.Status }}'` per output formattato

### `docker port`
**Mostra i mapping delle porte per un container.**

- **Comando:** `docker port container [porta_privata]`
- **Esempio:** `docker port web 80`

### `docker diff`
**Mostra le modifiche al filesystem di un container rispetto all'immagine base.**

- **Comando:** `docker diff container`
- **Esempio:** `docker diff web`

### `docker wait`
**Blocca fino a quando un container non termina e ne restituisce il codice d'uscita.**

- **Comando:** `docker wait container [container...]`
- **Esempio:** `docker wait job-container`

---

## 2. Docker — Immagini e Registry

### `docker images`
**Elenca le immagini disponibili localmente.**

- **Comando:** `docker images [opzioni] [repository[:tag]]`
- **Esempio:** `docker images --filter "dangling=true"`
- **Note:** `-a` (tutte), `--filter`, `--format`, `-q` (solo ID)

### `docker pull`
**Scarica un'immagine dal registry.**

- **Comando:** `docker pull [opzioni] nome_immagine[:tag]`
- **Esempio:** `docker pull nginx:1.25-alpine`
- **Note:** Di default usa Docker Hub; supporta registry privati con `registry.example.com/image`

### `docker push`
**Carica un'immagine su un registry.**

- **Comando:** `docker push [opzioni] nome_immagine[:tag]`
- **Esempio:** `docker push myuser/myapp:latest`
- **Note:** Richiede `docker login` prima del push

### `docker build`
**Costruisce un'immagine da un Dockerfile.**

- **Comando:** `docker build [opzioni] percorso`
- **Esempio:** `docker build -t myapp:1.0 .`
- **Note:** `-t` (tag), `-f` (Dockerfile path), `--no-cache`, `--build-arg`

### `docker tag`
**Assegna un tag a un'immagine esistente.**

- **Comando:** `docker tag sorgente[:tag] destinazione[:tag]`
- **Esempio:** `docker tag nginx:latest myregistry.local/nginx:prod`

### `docker rmi`
**Rimuove una o più immagini locali.**

- **Comando:** `docker rmi [opzioni] immagine [immagine...]`
- **Esempio:** `docker rmi -f $(docker images -q dangling=true)`
- **Note:** `-f` forza la rimozione

### `docker history`
**Mostra la cronologia dei layer di un'immagine.**

- **Comando:** `docker history [opzioni] immagine`
- **Esempio:** `docker history --no-trunc nginx:alpine`

### `docker save`
**Salva una o più immagini in un archivio tar.**

- **Comando:** `docker save [opzioni] immagine [immagine...]`
- **Esempio:** `docker save -o myapp.tar myapp:1.0`

### `docker load`
**Carica un'immagine da un archivio tar.**

- **Comando:** `docker load [opzioni]`
- **Esempio:** `docker load -i myapp.tar`

### `docker export`
**Esporta il filesystem di un container come archivio tar.**

- **Comando:** `docker export [opzioni] container`
- **Esempio:** `docker export -o web-fs.tar web`

### `docker import`
**Crea un'immagine dal filesystem di un container esportato.**

- **Comando:** `docker import [opzioni] file|URL|- [repository[:tag]]`
- **Esempio:** `docker import web-fs.tar myapp:imported`

### `docker commit`
**Crea un'immagine dalle modifiche di un container.**

- **Comando:** `docker commit [opzioni] container [repository[:tag]]`
- **Esempio:** `docker commit -m "Added curl" web web-with-curl`
- **Note:** Sconsigliato in favore di Dockerfile riproducibile

### `docker login` / `docker logout`
**Autenticazione su un registry Docker.**

- **Comando:** `docker login [opzioni] [server]`
- **Esempio:** `docker login myregistry.com -u user --password-stdin`
- **Note:** `--password-stdin` da stdin (più sicuro)

### `docker search`
**Cerca immagini su Docker Hub.**

- **Comando:** `docker search [opzioni] termine`
- **Esempio:** `docker search --limit 10 --filter stars=1000 nginx`

### `docker system df`
**Mostra l'uso del disco di Docker (immagini, container, volumi, build cache).**

- **Comando:** `docker system df [opzioni]`
- **Esempio:** `docker system df -v`

### `docker system prune`
**Rimuove risorse inutilizzate (container, immagini, volumi, network).**

- **Comando:** `docker system prune [opzioni]`
- **Esempio:** `docker system prune -a --volumes` (rimuove tutto l'inutilizzato)

---

## 3. Docker — Networking

### `docker network ls`
**Elenca le reti Docker.**

- **Comando:** `docker network ls [opzioni]`
- **Esempio:** `docker network ls --filter driver=bridge`
- **Driver:** `bridge` (default), `host`, `overlay` (Swarm), `macvlan`, `none`

### `docker network create`
**Crea una nuova rete Docker.**

- **Comando:** `docker network create [opzioni] nome`
- **Esempio:** `docker network create --driver bridge --subnet 172.20.0.0/16 mynet`
- **Note:** `--driver`, `--subnet`, `--gateway`, `--ip-range`, `-o` (opzioni driver)

### `docker network connect`
**Collega un container esistente a una rete.**

- **Comando:** `docker network connect [opzioni] rete container`
- **Esempio:** `docker network connect --ip 172.20.0.10 mynet web`

### `docker network disconnect`
**Disconnette un container da una rete.**

- **Comando:** `docker network disconnect [opzioni] rete container`
- **Esempio:** `docker network disconnect mynet web`

### `docker network inspect`
**Mostra dettagli di una rete Docker.**

- **Comando:** `docker network inspect [opzioni] rete [rete...]`
- **Esempio:** `docker network inspect bridge`

### `docker network rm`
**Rimuove una o più reti Docker.**

- **Comando:** `docker network rm rete [rete...]`
- **Esempio:** `docker network rm mynet`

### `docker network prune`
**Rimuove tutte le reti inutilizzate.**

- **Comando:** `docker network prune [opzioni]`
- **Esempio:** `docker network prune -f`

---

## 4. Docker — Volumi e Storage

### `docker volume ls`
**Elenca i volumi Docker.**

- **Comando:** `docker volume ls [opzioni]`
- **Esempio:** `docker volume ls --filter dangling=true`

### `docker volume create`
**Crea un volume Docker.**

- **Comando:** `docker volume create [opzioni] nome`
- **Esempio:** `docker volume create --driver local --opt type=btrfs myvol`

### `docker volume inspect`
**Mostra dettagli di un volume Docker.**

- **Comando:** `docker volume inspect [opzioni] volume [volume...]`
- **Esempio:** `docker volume inspect myvol`

### `docker volume rm`
**Rimuove uno o più volumi Docker.**

- **Comando:** `docker volume rm [opzioni] volume [volume...]`
- **Esempio:** `docker volume rm myvol`

### `docker volume prune`
**Rimuove tutti i volumi inutilizzati.**

- **Comando:** `docker volume prune [opzioni]`
- **Esempio:** `docker volume prune -a -f`

### `docker cp`
**Copia file/directory tra container e filesystem host.**

- **Comando:** `docker cp [opzioni] sorgente destinazione`
- **Esempio:** `docker cp web:/etc/nginx/nginx.conf ./` (container -> host)
- **Esempio:** `docker cp ./index.html web:/usr/share/nginx/html/` (host -> container)

---

## 5. Dockerfile — Istruzioni

### `FROM`
**Imposta l'immagine base per la build.**

- **Sintassi:** `FROM [--platform=<piattaforma>] immagine[:tag] [AS nome_stadio]`
- **Esempio:** `FROM node:20-alpine AS build`
- **Note:** `AS nome` per multi-stage build

### `RUN`
**Esegue un comando durante la build, creando un nuovo layer.**

- **Sintassi:** `RUN [opzioni] comando`
- **Esempio:** `RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*`
- **Note:** Preferire `RUN ["executable", "arg1", "arg2"]` (forma exec, evita shell injection)

### `CMD`
**Definisce il comando predefinito all'avvio del container.**

- **Sintassi:** `CMD ["eseguibile", "arg1", "arg2"]` (forma exec, preferita)
- **Esempio:** `CMD ["node", "server.js"]`
- **Note:** Può essere sovrascritto da `docker run`

### `ENTRYPOINT`
**Configura il container come eseguibile (non sovrascrivibile da CLI senza `--entrypoint`).**

- **Sintassi:** `ENTRYPOINT ["eseguibile", "arg1", "arg2"]`
- **Esempio:** `ENTRYPOINT ["nginx", "-g", "daemon off;"]`
- **Note:** `CMD` diventa argomento default di `ENTRYPOINT`

### `COPY`
**Copia file/directory dalla build context all'immagine.**

- **Sintassi:** `COPY [--chown=<utente>:<gruppo>] sorgente... destinazione`
- **Esempio:** `COPY --chown=node:node package*.json ./app/`
- **Note:** Supporta wildcard, percorsi relativi alla build context

### `ADD`
**Come COPY, ma supporta URL remote e estrazione automatica di archivi tar.**

- **Sintassi:** `ADD [--chown=<utente>:<gruppo>] sorgente... destinazione`
- **Esempio:** `ADD https://example.com/app.tar.gz /opt/`
- **Note:** Preferire `COPY` per file locali (più prevedibile)

### `ENV`
**Imposta variabili d'ambiente persistenti nell'immagine.**

- **Sintassi:** `ENV chiave=valore [chiave=valore...]`
- **Esempio:** `ENV NODE_ENV=production PORT=3000`
- **Note:** Ereditate dai container figli

### `ARG`
**Variabile disponibile solo durante la build (build-time).**

- **Sintassi:** `ARG nome[=valore_default]`
- **Esempio:** `ARG VERSION=latest`
- **Note:** Passata con `docker build --build-arg VERSION=1.0`

### `EXPOSE`
**Documenta la porta su cui il container ascolta (non la pubblica automaticamente).**

- **Sintassi:** `EXPOSE porta[/protocollo]`
- **Esempio:** `EXPOSE 80/tcp`
- **Note:** Mero documento informativo; usare `-p` in `docker run`

### `WORKDIR`
**Imposta la directory di lavoro per i comandi successivi (RUN, CMD, ENTRYPOINT, COPY, ADD).**

- **Sintassi:** `WORKDIR /percorso`
- **Esempio:** `WORKDIR /usr/src/app`

### `USER`
**Imposta l'utente con cui eseguire i comandi successivi (RUN, CMD, ENTRYPOINT).**

- **Sintassi:** `USER <utente>[:<gruppo>]`
- **Esempio:** `USER node`
- **Note:** Best practice: non eseguire come root

### `VOLUME`
**Crea un mount point per volumi esterni.**

- **Sintassi:** `VOLUME ["/percorso"]`
- **Esempio:** `VOLUME ["/data"]`
- **Note:** Docker monterà automaticamente un volume anonimo se non specificato

### `LABEL`
**Aggiunge metadati all'immagine in formato chiave=valore.**

- **Sintassi:** `LABEL <chiave>=<valore> [<chiave>=<valore>...]`
- **Esempio:** `LABEL maintainer="team@example.com" version="1.0"`

### `SHELL`
**Cambia la shell predefinita per i comandi RUN in forma shell.**

- **Sintassi:** `SHELL ["eseguibile", "parametri"]`
- **Esempio:** `SHELL ["powershell", "-Command"]`

### `HEALTHCHECK`
**Definisce un comando per verificare lo stato di salute del container.**

- **Sintassi:** `HEALTHCHECK [opzioni] CMD comando`
- **Esempio:** `HEALTHCHECK --interval=30s --timeout=3s --retries=3 CMD curl -f http://localhost/ || exit 1`
- **Note:** Opzioni: `--interval`, `--timeout`, `--start-period`, `--retries`

### `ONBUILD`
**Aggiunge un'istruzione trigger per quando l'immagine viene usata come base da un altro Dockerfile.**

- **Sintassi:** `ONBUILD istruzione`
- **Esempio:** `ONBUILD COPY . /app`
- **Note:** Non si possono concatenare `ONBUILD`

### `.dockerignore`
**Esclude file/directory dalla build context (riduce dimensione e migliora cache).**

- **Pattern:** Stessa sintassi di `.gitignore`
- **Esempio:**
  ```
  node_modules/
  .git/
  *.md
  Dockerfile
  ```

---

## 6. Docker Compose

### `docker compose up`
**Crea e avvia i container definiti nel compose file.**

- **Comando:** `docker compose up [opzioni] [servizio...]`
- **Esempio:** `docker compose up -d --build` (background + ricostruzione immagini)
- **Note:** `-d` (detached), `--build` (ricostruisce), `--scale web=3` (scaling)

### `docker compose down`
**Ferma e rimuove container, reti e, opzionalmente, volumi e immagini.**

- **Comando:** `docker compose down [opzioni]`
- **Esempio:** `docker compose down -v --rmi all` (rimuove volumi e immagini)

### `docker compose logs`
**Mostra i log di tutti i servizi o di uno specifico.**

- **Comando:** `docker compose logs [opzioni] [servizio...]`
- **Esempio:** `docker compose logs -f web` (follow del servizio web)

### `docker compose ps`
**Elenca i container gestiti dal compose file.**

- **Comando:** `docker compose ps [opzioni]`
- **Esempio:** `docker compose ps --services`

### `docker compose exec`
**Esegue un comando in un container di un servizio in esecuzione.**

- **Comando:** `docker compose exec [opzioni] servizio comando`
- **Esempio:** `docker compose exec db psql -U postgres`

### `docker compose run`
**Esegue un comando one-off in un nuovo container del servizio.**

- **Comando:** `docker compose run [opzioni] servizio comando`
- **Esempio:** `docker compose run --rm web npm test`

### `docker compose build`
**Costruisce o ricostruisce le immagini dei servizi.**

- **Comando:** `docker compose build [opzioni] [servizio...]`
- **Esempio:** `docker compose build --no-cache web`

### `docker compose pull`
**Scarica le immagini per i servizi definiti.**

- **Comando:** `docker compose pull [opzioni] [servizio...]`
- **Esempio:** `docker compose pull --include-deps`

### `docker compose push`
**Carica le immagini dei servizi sul registry.**

- **Comando:** `docker compose push [opzioni] [servizio...]`
- **Esempio:** `docker compose push`

### `docker compose restart`
**Riavvia i container dei servizi specificati.**

- **Comando:** `docker compose restart [opzioni] [servizio...]`
- **Esempio:** `docker compose restart web`

### `docker compose stop` / `docker compose start`
**Ferma o avvia i container senza rimuoverli.**

- **Comando:** `docker compose stop|start [opzioni] [servizio...]`
- **Esempio:** `docker compose stop web && docker compose start web`

### `docker compose config`
**Valida e mostra la configurazione risolta del compose file.**

- **Comando:** `docker compose config [opzioni]`
- **Esempio:** `docker compose config --services` (solo nomi servizi)

### `docker compose top`
**Mostra i processi in esecuzione nei container.**

- **Comando:** `docker compose top [servizio...]`
- **Esempio:** `docker compose top`

### `docker compose images`
**Elenca le immagini usate dai servizi.**

- **Comando:** `docker compose images [opzioni] [servizio...]`
- **Esempio:** `docker compose images -q`

### `docker compose version`
**Mostra la versione di Docker Compose.**

- **Comando:** `docker compose version`
- **Esempio:** `docker compose version --short`

---

## 7. Docker Swarm

### `docker swarm init`
**Inizializza un cluster Swarm (nodo manager).**

- **Comando:** `docker swarm init [opzioni]`
- **Esempio:** `docker swarm init --advertise-addr 192.168.1.10`
- **Note:** Restituisce il token per unire i worker

### `docker swarm join`
**Unisce un nodo come worker o manager a uno Swarm esistente.**

- **Comando:** `docker swarm join [opzioni] host:porta`
- **Esempio:** `docker swarm join --token SWMTKN-... 192.168.1.10:2377`

### `docker swarm leave`
**Rimuove il nodo corrente dallo Swarm.**

- **Comando:** `docker swarm leave [opzioni]`
- **Esempio:** `docker swarm leave --force`

### `docker swarm update`
**Aggiorna la configurazione dello Swarm.**

- **Comando:** `docker swarm update [opzioni]`
- **Esempio:** `docker swarm update --autolock=true`

### `docker node ls`
**Elenca i nodi dello Swarm.**

- **Comando:** `docker node ls [opzioni]`
- **Esempio:** `docker node ls`

### `docker node promote` / `docker node demote`
**Promuove o degrada un nodo a manager/worker.**

- **Comando:** `docker node promote|demote nodo [nodo...]`
- **Esempio:** `docker node promote node2`

### `docker node update`
**Aggiorna i metadati di un nodo (label, availability).**

- **Comando:** `docker node update [opzioni] nodo`
- **Esempio:** `docker node update --label-add type=worker node1`

### `docker service create`
**Crea un nuovo servizio Swarm.**

- **Comando:** `docker service create [opzioni] immagine [comando]`
- **Esempio:** `docker service create --name web --replicas 3 -p 80:80 nginx`
- **Note:** `--replicas`, `--network`, `--mount`, `--config`, `--secret`, `--mode global|replicated`

### `docker service ls`
**Elenca i servizi Swarm.**

- **Comando:** `docker service ls [opzioni]`
- **Esempio:** `docker service ls`

### `docker service ps`
**Elenca i task (container) di un servizio.**

- **Comando:** `docker service ps [opzioni] servizio`
- **Esempio:** `docker service ps web`

### `docker service scale`
**Scala il numero di repliche di un servizio.**

- **Comando:** `docker service scale servizio=repliche [servizio=repliche...]`
- **Esempio:** `docker service scale web=5`

### `docker service update`
**Aggiorna un servizio Swarm (rolling update).**

- **Comando:** `docker service update [opzioni] servizio`
- **Esempio:** `docker service update --image nginx:1.25 --update-parallelism 2 web`
- **Note:** `--image`, `--replicas`, `--env-add`, `--limit-cpu`, `--rollback`

### `docker service rollback`
**Annulla l'ultimo aggiornamento di un servizio.**

- **Comando:** `docker service rollback [opzioni] servizio`
- **Esempio:** `docker service rollback web`

### `docker service rm`
**Rimuove uno o più servizi Swarm.**

- **Comando:** `docker service rm servizio [servizio...]`
- **Esempio:** `docker service rm web`

### `docker stack deploy`
**Distribuisce uno stack Compose su Swarm.**

- **Comando:** `docker stack deploy [opzioni] stack_name`
- **Esempio:** `docker stack deploy -c docker-compose.yml myapp`
- **Note:** Usa il formato Compose file versione 3.x

### `docker stack ls`
**Elenca gli stack Swarm.**

- **Comando:** `docker stack ls [opzioni]`
- **Esempio:** `docker stack ls`

### `docker stack services`
**Elenca i servizi in uno stack.**

- **Comando:** `docker stack services [opzioni] stack_name`
- **Esempio:** `docker stack services myapp`

### `docker stack rm`
**Rimuove uno stack e tutti i suoi servizi.**

- **Comando:** `docker stack rm stack_name [stack_name...]`
- **Esempio:** `docker stack rm myapp`

### `docker secret create`
**Crea un secret Swarm da stdin o file.**

- **Comando:** `docker secret create [opzioni] nome file|stdin`
- **Esempio:** `echo "mypassword" | docker secret create db_pass -`

### `docker secret ls`
**Elenca i secret Swarm.**

- **Comando:** `docker secret ls [opzioni]`
- **Esempio:** `docker secret ls`

### `docker config create`
**Crea una configurazione Swarm.**

- **Comando:** `docker config create [opzioni] nome file`
- **Esempio:** `docker config create nginx.conf ./nginx.conf`

### `docker config ls`
**Elenca le configurazioni Swarm.**

- **Comando:** `docker config ls [opzioni]`
- **Esempio:** `docker config ls`

---

## 8. Kubernetes — Pod e Deployment

### `kubectl run`
**Esegue un pod con una specifica immagine (comando rapido).**

- **Comando:** `kubectl run nome --image=immagine [opzioni]`
- **Esempio:** `kubectl run nginx --image=nginx --restart=Never --port=80`
- **Note:** Uso prevalente per debug; in produzione preferire file YAML

### `kubectl create deployment`
**Crea un deployment.**

- **Comando:** `kubectl create deployment nome --image=immagine [opzioni]`
- **Esempio:** `kubectl create deployment web --image=nginx:alpine --replicas=3`

### `kubectl get pods`
**Elenca i pod in un namespace.**

- **Comando:** `kubectl get pods [opzioni]`
- **Esempio:** `kubectl get pods -o wide --all-namespaces`
- **Note:** `-o wide` (IP e nodo), `-o yaml` (manifest completo), `--watch` (segui)

### `kubectl get deployments`
**Elenca i deployment.**

- **Comando:** `kubectl get deployments [opzioni]`
- **Esempio:** `kubectl get deployments -o json`

### `kubectl describe pod`
**Mostra dettagli estesi di un pod (eventi, stato, condizioni).**

- **Comando:** `kubectl describe pod <pod-name> [opzioni]`
- **Esempio:** `kubectl describe pod web-5d4f8d9f6-abcde`

### `kubectl apply`
**Crea o aggiorna risorse da file YAML/JSON (dichiarativo).**

- **Comando:** `kubectl apply -f <file.yaml> [opzioni]`
- **Esempio:** `kubectl apply -f deployment.yaml -n production`
- **Note:** `-f` può essere file, directory o URL

### `kubectl create -f`
**Crea risorse da file (imperativo).**

- **Comando:** `kubectl create -f <file.yaml> [opzioni]`
- **Esempio:** `kubectl create -f pod.yaml --save-config`

### `kubectl delete`
**Elimina risorse.**

- **Comando:** `kubectl delete <tipo>/<nome> [opzioni]`
- **Esempio:** `kubectl delete pod web-5d4f8d9f6-abcde --grace-period=0 --force`
- **Note:** Supporta `-f` (da file), `-l` (label selector)

### `kubectl scale`
**Modifica il numero di repliche di un deployment/ReplicaSet/StatefulSet.**

- **Comando:** `kubectl scale <tipo>/<nome> --replicas=N`
- **Esempio:** `kubectl scale deployment/web --replicas=5`

### `kubectl autoscale`
**Crea un HorizontalPodAutoscaler automatico.**

- **Comando:** `kubectl autoscale <tipo>/<nome> [opzioni]`
- **Esempio:** `kubectl autoscale deployment/web --min=2 --max=10 --cpu-percent=80`

### `kubectl rollout status`
**Mostra lo stato di un rollout in corso.**

- **Comando:** `kubectl rollout status <tipo>/<nome> [opzioni]`
- **Esempio:** `kubectl rollout status deployment/web`

### `kubectl rollout history`
**Mostra la cronologia dei rollout.**

- **Comando:** `kubectl rollout history <tipo>/<nome> [opzioni]`
- **Esempio:** `kubectl rollout history deployment/web --revision=2`

### `kubectl rollout undo`
**Annulla un rollout alla revisione precedente o specifica.**

- **Comando:** `kubectl rollout undo <tipo>/<nome> [opzioni]`
- **Esempio:** `kubectl rollout undo deployment/web --to-revision=2`

### `kubectl rollout restart`
**Riavvia i pod (rolling restart) senza modificare la spec.**

- **Comando:** `kubectl rollout restart <tipo>/<nome>`
- **Esempio:** `kubectl rollout restart deployment/web`

### `kubectl set image`
**Aggiorna l'immagine di un deployment/pod.**

- **Comando:** `kubectl set image <tipo>/<nome> container=nuova_immagine`
- **Esempio:** `kubectl set image deployment/web nginx=nginx:1.25 --record`

### `kubectl edit`
**Modifica una risorsa direttamente con l'editor predefinito.**

- **Comando:** `kubectl edit <tipo>/<nome> [opzioni]`
- **Esempio:** `kubectl edit deployment/web`

### `kubectl patch`
**Applica modifiche parziali a una risorsa (JSON patch o strategic merge).**

- **Comando:** `kubectl patch <tipo>/<nome> -p '<json_patch>'`
- **Esempio:** `kubectl patch pod web -p '{"spec":{"containers":[{"name":"nginx","image":"nginx:1.25"}]}}'`

### `kubectl label`
**Aggiunge, aggiorna o rimuove label da risorse.**

- **Comando:** `kubectl label <tipo>/<nome> <chiave>=<valore> [opzioni]`
- **Esempio:** `kubectl label pod/web-abcde version=stable --overwrite`

### `kubectl annotate`
**Aggiunge, aggiorna o rimuove annotazioni da risorse.**

- **Comando:** `kubectl annotate <tipo>/<nome> <chiave>=<valore> [opzioni]`
- **Esempio:** `kubectl annotate deployment/web description="Web frontend"`

---

## 9. Kubernetes — Service e Networking

### `kubectl expose`
**Crea un Service da un deployment/pod esistente.**

- **Comando:** `kubectl expose <tipo>/<nome> [opzioni]`
- **Esempio:** `kubectl expose deployment web --port=80 --target-port=8080 --type=ClusterIP`
- **Tipi:** `ClusterIP` (default), `NodePort`, `LoadBalancer`, `ExternalName`

### `kubectl get services`
**Elenca i Service.**

- **Comando:** `kubectl get services [opzioni]`
- **Esempio:** `kubectl get svc -o wide`

### `kubectl describe service`
**Mostra dettagli di un Service (endpoint, selector, porte).**

- **Comando:** `kubectl describe service <nome>`
- **Esempio:** `kubectl describe svc web-service`

### `kubectl get endpoints`
**Elenca gli endpoint (pod) a cui un Service instrada il traffico.**

- **Comando:** `kubectl get endpoints [opzioni]`
- **Esempio:** `kubectl get endpoints web-service`

### `kubectl get ingress`
**Elenca le risorse Ingress.**

- **Comando:** `kubectl get ingress [opzioni]`
- **Esempio:** `kubectl get ingress -A`

### `kubectl describe ingress`
**Mostra dettagli di un Ingress (regole, backend, TLS).**

- **Comando:** `kubectl describe ingress <nome>`
- **Esempio:** `kubectl describe ingress my-ingress`

### `kubectl port-forward`
**Forward di porte locali verso un pod o service.**

- **Comando:** `kubectl port-forward <tipo>/<nome> <locale>:<remota>`
- **Esempio:** `kubectl port-forward svc/web-service 8080:80`
- **Note:** Utile per debug senza esporre pubblicamente

### `kubectl proxy`
**Avvia un proxy verso l'API server Kubernetes in locale.**

- **Comando:** `kubectl proxy [opzioni]`
- **Esempio:** `kubectl proxy --port=8001 --address=0.0.0.0`

---

## 10. Kubernetes — Storage

### `kubectl get pv`
**Elenca i PersistentVolume.**

- **Comando:** `kubectl get pv [opzioni]`
- **Esempio:** `kubectl get pv -o wide`

### `kubectl get pvc`
**Elenca i PersistentVolumeClaim.**

- **Comando:** `kubectl get pvc [opzioni]`
- **Esempio:** `kubectl get pvc --all-namespaces`

### `kubectl get storageclass`
**Elenca le StorageClass disponibili.**

- **Comando:** `kubectl get storageclass [opzioni]`
- **Esempio:** `kubectl get sc`
- **Note:** Lo StorageClass predefinito ha l'annotazione `storageclass.kubernetes.io/is-default-class=true`

### `kubectl describe pv`
**Mostra dettagli di un PersistentVolume (capacity, access modes, reclaim policy).**

- **Comando:** `kubectl describe pv <nome>`
- **Esempio:** `kubectl describe pv pvc-abc123`
- **Access Modes:** `ReadWriteOnce` (RWO), `ReadOnlyMany` (ROX), `ReadWriteMany` (RWX)
- **Reclaim Policy:** `Retain`, `Recycle`, `Delete`

### `kubectl describe pvc`
**Mostra dettagli di un PersistentVolumeClaim (status, volume bound, richieste).**

- **Comando:** `kubectl describe pvc <nome>`
- **Esempio:** `kubectl describe pvc data-claim`

### `kubectl describe storageclass`
**Mostra dettagli di una StorageClass (provisioner, parametri).**

- **Comando:** `kubectl describe storageclass <nome>`
- **Esempio:** `kubectl describe sc standard`

---

## 11. Kubernetes — Configurazione e Secreti

### `kubectl get configmap`
**Elenca i ConfigMap.**

- **Comando:** `kubectl get configmap [opzioni]`
- **Esempio:** `kubectl get cm -n production`

### `kubectl create configmap`
**Crea un ConfigMap da file, directory o valori letterali.**

- **Comando:** `kubectl create configmap <nome> [opzioni]`
- **Esempio:** `kubectl create configmap app-config --from-file=config.properties --from-literal=env=prod`

### `kubectl describe configmap`
**Mostra dettagli di un ConfigMap.**

- **Comando:** `kubectl describe configmap <nome>`
- **Esempio:** `kubectl describe cm app-config`

### `kubectl get secret`
**Elenca i Secret.**

- **Comando:** `kubectl get secret [opzioni]`
- **Esempio:** `kubectl get secrets`

### `kubectl create secret generic`
**Crea un Secret da file o valori letterali.**

- **Comando:** `kubectl create secret generic <nome> [opzioni]`
- **Esempio:** `kubectl create secret generic db-credentials --from-literal=username=admin --from-literal=password=s3cret`
- **Tipi:** `generic`, `tls`, `docker-registry`

### `kubectl create secret tls`
**Crea un Secret TLS da certificato e chiave.**

- **Comando:** `kubectl create secret tls <nome> --cert=cert.pem --key=key.pem`
- **Esempio:** `kubectl create secret tls tls-secret --cert=tls.crt --key=tls.key`

### `kubectl describe secret`
**Mostra dettagli di un Secret (nasconde i valori).**

- **Comando:** `kubectl describe secret <nome>`
- **Esempio:** `kubectl describe secret db-credentials`

### `kubectl get secret -o yaml`
**Mostra il Secret in YAML con valori base64-encoded.**

- **Comando:** `kubectl get secret <nome> -o yaml`
- **Esempio:** `kubectl get secret db-credentials -o yaml`

### `echo <base64> | base64 --decode`
**Decodifica un valore base64 da un Secret.**

- **Comando:** `echo <valore_base64> | base64 --decode`
- **Esempio:** `echo YWRtaW4= | base64 --decode` (output: `admin`)

---

## 12. Kubernetes — Workload Avanzati

### `kubectl get statefulset`
**Elenca gli StatefulSet.**

- **Comando:** `kubectl get statefulset [opzioni]`
- **Esempio:** `kubectl get sts`

### `kubectl get daemonset`
**Elenca i DaemonSet.**

- **Comando:** `kubectl get daemonset [opzioni]`
- **Esempio:** `kubectl get ds -A`

### `kubectl get job`
**Elenca i Job.**

- **Comando:** `kubectl get job [opzioni]`
- **Esempio:** `kubectl get jobs --watch`

### `kubectl create job`
**Crea un Job da un comando.**

- **Comando:** `kubectl create job <nome> --image=immagine -- comando`
- **Esempio:** `kubectl create job backup --image=busybox -- wget https://example.com/backup`

### `kubectl get cronjob`
**Elenca i CronJob.**

- **Comando:** `kubectl get cronjob [opzioni]`
- **Esempio:** `kubectl get cj`

### `kubectl create cronjob`
**Crea un CronJob.**

- **Comando:** `kubectl create cronjob <nome> --image=immagine --schedule="<cron>" -- comando`
- **Esempio:** `kubectl create cronjob nightly-backup --image=busybox --schedule="0 2 * * *" -- /backup.sh`

### `kubectl get hpa`
**Elenca gli HorizontalPodAutoscaler.**

- **Comando:** `kubectl get hpa [opzioni]`
- **Esempio:** `kubectl get hpa -A`

### `kubectl describe hpa`
**Mostra dettagli di un HPA (metriche, target, attuale).**

- **Comando:** `kubectl describe hpa <nome>`
- **Esempio:** `kubectl describe hpa web-hpa`

### `kubectl get pdb`
**Elenca i PodDisruptionBudget.**

- **Comando:** `kubectl get pdb [opzioni]`
- **Esempio:** `kubectl get pdb -A`

---

## 13. Kubernetes — Diagnostica e Debug

### `kubectl logs`
**Mostra i log di un pod o container.**

- **Comando:** `kubectl logs <pod> [-c <container>] [opzioni]`
- **Esempio:** `kubectl logs -f --tail=100 -l app=web`
- **Note:** `-f` (follow), `--tail=N`, `--since=1h`, `-l` (label selector), `--all-containers`

### `kubectl exec`
**Esegue un comando in un container di un pod.**

- **Comando:** `kubectl exec [-it] <pod> [-c <container>] -- comando`
- **Esempio:** `kubectl exec -it web-5d4f8d9f6-abcde -- /bin/sh`

### `kubectl cp`
**Copia file/directory da/a un container in un pod.**

- **Comando:** `kubectl cp [opzioni] <sorgente> <destinazione>`
- **Esempio:** `kubectl cp myapp/config.json default/web-pod:/app/config.json`

### `kubectl top pod`
**Mostra l'uso di CPU e memoria dei pod.**

- **Comando:** `kubectl top pod [opzioni]`
- **Esempio:** `kubectl top pod -A --sort-by=cpu`
- **Note:** Richiede metrics-server nel cluster

### `kubectl top node`
**Mostra l'uso di CPU e memoria dei nodi.**

- **Comando:** `kubectl top node [opzioni]`
- **Esempio:** `kubectl top node`

### `kubectl get events`
**Elenca gli eventi recenti nel cluster, utili per diagnosticare problemi.**

- **Comando:** `kubectl get events [opzioni]`
- **Esempio:** `kubectl get events --sort-by='.lastTimestamp' | tail -20`

### `kubectl describe node`
**Mostra dettagli di un nodo (risorse, pod allocati, condizioni).**

- **Comando:** `kubectl describe node <nodo>`
- **Esempio:** `kubectl describe node minikube`

### `kubectl cluster-info`
**Mostra informazioni sul cluster Kubernetes (indirizzo API, DNS).**

- **Comando:** `kubectl cluster-info [opzioni]`
- **Esempio:** `kubectl cluster-info dump` (dump diagnostico completo)

### `kubectl api-resources`
**Elenca tutte le risorse API disponibili nel cluster.**

- **Comando:** `kubectl api-resources [opzioni]`
- **Esempio:** `kubectl api-resources -o wide --namespaced=true`

### `kubectl api-versions`
**Elenca le versioni API disponibili.**

- **Comando:** `kubectl api-versions`
- **Esempio:** `kubectl api-versions | sort`

### `kubectl explain`
**Mostra la documentazione e la struttura di una risorsa Kubernetes.**

- **Comando:** `kubectl explain <risorsa> [opzioni]`
- **Esempio:** `kubectl explain deployment.spec.template.spec.containers`

### `kubectl debug`
**Crea un pod di debug temporaneo per diagnosticare un pod esistente.**

- **Comando:** `kubectl debug <pod> [opzioni]`
- **Esempio:** `kubectl debug -it web-5d4f8d9f6-abcde --image=busybox --copy-to=web-debug`
- **Note:** Feature alpha/graduated in versioni recenti di Kubernetes

---

## 14. Kubernetes — RBAC e Sicurezza

### `kubectl create serviceaccount`
**Crea un ServiceAccount.**

- **Comando:** `kubectl create serviceaccount <nome> [opzioni]`
- **Esempio:** `kubectl create serviceaccount my-app-sa`

### `kubectl get serviceaccount`
**Elenca i ServiceAccount.**

- **Comando:** `kubectl get serviceaccount [opzioni]`
- **Esempio:** `kubectl get sa`

### `kubectl create role`
**Crea un ruolo RBAC in un namespace.**

- **Comando:** `kubectl create role <nome> --verb=<verbi> --resource=<risorse> [opzioni]`
- **Esempio:** `kubectl create role pod-reader --verb=get,list,watch --resource=pods`

### `kubectl create clusterrole`
**Crea un ClusterRole (non legato a namespace).**

- **Comando:** `kubectl create clusterrole <nome> --verb=<verbi> --resource=<risorse>`
- **Esempio:** `kubectl create clusterrole node-reader --verb=get,list --resource=nodes`

### `kubectl create rolebinding`
**Collega un Role a un utente/gruppo/ServiceAccount in un namespace.**

- **Comando:** `kubectl create rolebinding <nome> --role=<role> --user=<utente> [opzioni]`
- **Esempio:** `kubectl create rolebinding pod-reader-binding --role=pod-reader --serviceaccount=default:my-app-sa`

### `kubectl create clusterrolebinding`
**Collega un ClusterRole a un utente/gruppo/ServiceAccount a livello cluster.**

- **Comando:** `kubectl create clusterrolebinding <nome> --clusterrole=<role> --user=<utente>`
- **Esempio:** `kubectl create clusterrolebinding cluster-admin-binding --clusterrole=cluster-admin --user=admin@example.com`

### `kubectl auth can-i`
**Verifica se un utente/ServiceAccount può eseguire un'azione su una risorsa.**

- **Comando:** `kubectl auth can-i <verbo> <risorsa> [opzioni]`
- **Esempio:** `kubectl auth can-i create deployments --as system:serviceaccount:default:my-app-sa`

### `kubectl get podsecuritypolicy`
**Elenca le PodSecurityPolicy.**

- **Comando:** `kubectl get psp [opzioni]`
- **Esempio:** `kubectl get psp`
- **Note:** Deprecato in favore di Pod Security Admission (K8s 1.23+)

---

## 15. Helm — Package Manager

### `helm repo add`
**Aggiunge un repository Helm.**

- **Comando:** `helm repo add [nome] [url]`
- **Esempio:** `helm repo add bitnami https://charts.bitnami.com/bitnami`

### `helm repo list`
**Elenca i repository Helm configurati.**

- **Comando:** `helm repo list`
- **Esempio:** `helm repo list`

### `helm repo update`
**Aggiorna la cache dei repository Helm.**

- **Comando:** `helm repo update`
- **Esempio:** `helm repo update`

### `helm search repo`
**Cerca chart nei repository configurati.**

- **Comando:** `helm search repo [keyword] [opzioni]`
- **Esempio:** `helm search repo nginx --versions`

### `helm search hub`
**Cerca chart su Artifact Hub.**

- **Comando:** `helm search hub [keyword]`
- **Esempio:** `helm search hub wordpress`

### `helm install`
**Installa un chart Helm.**

- **Comando:** `helm install [nome_release] [chart] [opzioni]`
- **Esempio:** `helm install my-release bitnami/nginx --set replicaCount=3 --namespace webapp --create-namespace`
- **Note:** `--values values.yaml`, `--set key=value`, `--namespace`

### `helm upgrade`
**Aggiorna una release esistente.**

- **Comando:** `helm upgrade [release] [chart] [opzioni]`
- **Esempio:** `helm upgrade my-release bitnami/nginx --set image.tag=1.25`

### `helm rollback`
**Torna a una revisione precedente di una release.**

- **Comando:** `helm rollback [release] [revisione] [opzioni]`
- **Esempio:** `helm rollback my-release 2`

### `helm list`
**Elenca le release installate.**

- **Comando:** `helm list [opzioni]`
- **Esempio:** `helm list -A` (tutti i namespace)

### `helm uninstall`
**Disinstalla una release Helm.**

- **Comando:** `helm uninstall [release] [opzioni]`
- **Esempio:** `helm uninstall my-release --namespace webapp`

### `helm status`
**Mostra lo stato di una release.**

- **Comando:** `helm status [release] [opzioni]`
- **Esempio:** `helm status my-release`

### `helm history`
**Mostra la cronologia delle revisioni di una release.**

- **Comando:** `helm history [release] [opzioni]`
- **Esempio:** `helm history my-release`

### `helm get values`
**Mostra i valori configurati per una release.**

- **Comando:** `helm get values [release] [opzioni]`
- **Esempio:** `helm get values my-release`

### `helm get manifest`
**Mostra i manifest Kubernetes generati da una release.**

- **Comando:** `helm get manifest [release] [opzioni]`
- **Esempio:** `helm get manifest my-release`

### `helm create`
**Crea la struttura di un nuovo chart Helm.**

- **Comando:** `helm create [nome]`
- **Esempio:** `helm create my-app`
- **Struttura generata:**
  ```
  my-app/
  ├── Chart.yaml
  ├── values.yaml
  ├── charts/
  ├── templates/
  │   ├── _helpers.tpl
  │   ├── deployment.yaml
  │   ├── service.yaml
  │   └── hpa.yaml
  └── .helmignore
  ```

### `helm package`
**Pacchettizza un chart in un archivio `.tgz`.**

- **Comando:** `helm package [chart_dir] [opzioni]`
- **Esempio:** `helm package ./my-app`

### `helm lint`
**Valida un chart Helm per errori e best practice.**

- **Comando:** `helm lint [chart_dir] [opzioni]`
- **Esempio:** `helm lint ./my-app`

### `helm template`
**Renderizza i template di un chart localmente (senza installare).**

- **Comando:** `helm template [nome] [chart] [opzioni]`
- **Esempio:** `helm template my-release bitnami/nginx --output-dir ./rendered`

### `helm dependency build`
**Scarica le dipendenze di un chart.**

- **Comando:** `helm dependency build [chart]`
- **Esempio:** `helm dependency build ./my-app`

### `helm dependency update`
**Aggiorna le dipendenze basandosi su Chart.yaml.**

- **Comando:** `helm dependency update [chart]`
- **Esempio:** `helm dependency update ./my-app`

---

## 16. Strumenti Ausiliari

### `kubectx`
**Cambia rapidamente contesto tra cluster Kubernetes.**

- **Comando:** `kubectx [nome_contesto]`
- **Esempio:** `kubectx minikube`
- **Installazione:** `sudo snap install kubectx` o download manuale

### `kubens`
**Cambia rapidamente namespace predefinito.**

- **Comando:** `kubens [nome_namespace]`
- **Esempio:** `kubens production`
- **Installazione:** Incluso con kubectx

### `kubectl krew`
**Plugin manager per kubectl (estensione dei comandi).**

- **Comando:** `kubectl krew install <plugin>`
- **Esempio:** `kubectl krew install ctx ns tree`
- **Installazione:** `(cd /tmp && curl -fsSLO https://github.com/kubernetes-sigs/krew/releases/latest/download/krew.tar.gz && tar zxvf krew.tar.gz && ./krew install krew)`

### `kubectl tree`
**Mostra gerarchia delle risorse (plugin krew).**

- **Comando:** `kubectl tree <tipo>/<nome>`
- **Esempio:** `kubectl tree deployment web`
- **Installazione:** `kubectl krew install tree`

### `kubectl neat`
**Rimuove campi superflui dall'output di `kubectl get -o yaml` (plugin krew).**

- **Comando:** `kubectl neat [-f file.yaml]`
- **Esempio:** `kubectl get pod web -o yaml | kubectl neat`
- **Installazione:** `kubectl krew install neat`

### `kind` (Kubernetes in Docker)
**Cluster Kubernetes multi-nodo in container Docker per sviluppo locale.**

- **Comando:** `kind [comando] [opzioni]`
- **Esempio:** `kind create cluster --name test --config kind-config.yaml`
- **Note:** Ideale per test locali e CI; supporta High Availability

### `minikube`
**Cluster Kubernetes locale mono-nodo (VM o container).**

- **Comando:** `minikube [comando] [opzioni]`
- **Esempio:** `minikube start --cpus=4 --memory=8g --driver=docker`
- **Note:** Dashboard inclusa (`minikube dashboard`), supporta addon

### `k3s`
**Kubernetes leggero per IoT/Edge e sviluppo locale.**

- **Comando:** `k3s server|agent [opzioni]`
- **Esempio:** `curl -sfL https://get.k3s.io | sh -`
- **Note:** Binario singolo, richiede meno di 512 MB RAM

### `k3d`
**K3s in Docker — cluster K8s minimali per sviluppo locale.**

- **Comando:** `k3d cluster create [nome] [opzioni]`
- **Esempio:** `k3d cluster create mycluster --servers 1 --agents 2 -p "8080:80@loadbalancer"`
- **Installazione:** `wget -q -O - https://raw.githubusercontent.com/k3d-io/k3d/main/install.sh | bash`

### `ctr` / `nerdctl`
**CLI per containerd (alternativa a Docker CLI).**

- **Comando:** `nerdctl [comando] [opzioni]`
- **Esempio:** `nerdctl run -d --name nginx nginx:alpine`
- **Note:** `nerdctl` è compatibile con la sintassi Docker CLI

### `crictl`
**CLI per runtime container CRI (usato da kubelet per debug).**

- **Comando:** `crictl [comando] [opzioni]`
- **Esempio:** `crictl ps -a`
- **Note:** Utile per debug su nodi Kubernetes che usano containerd/CRI-O

### `buildah`
**Costruisce immagini OCI/Docker senza Docker daemon.**

- **Comando:** `buildah [comando] [opzioni]`
- **Esempio:** `buildah bud -t myapp .`
- **Note:** Parte del progetto Podman; non richiede demone

### `podman`
**Alternativa a Docker senza demone (rootless).**

- **Comando:** `podman [comando] [opzioni]`
- **Esempio:** `podman run -d --name web -p 80:80 nginx`
- **Note:** Sintassi compatibile con Docker; supporta pod

### `skopeo`
**Gestione e ispezione immagini container in registry remoti (senza pull).**

- **Comando:** `skopeo [comando] [opzioni]`
- **Esempio:** `skopeo inspect docker://docker.io/nginx:alpine`
- **Note:** Copia, firma e verifica immagini tra registry

### `dive`
**Strumento per esplorare i layer di un'immagine Docker.**

- **Comando:** `dive [immagine]`
- **Esempio:** `dive nginx:alpine`
- **Note:** Analizza spazio per layer e suggerisce ottimizzazioni

### `k9s`
**Terminale UI per la gestione di cluster Kubernetes.**

- **Comando:** `k9s [opzioni]`
- **Esempio:** `k9s -n production`
- **Note:** Supporta Vim-like keybindings, filtri, drill-down

### `kubescape`
**Scanner di sicurezza per cluster Kubernetes (CIS benchmark).**

- **Comando:** `kubescape scan [opzioni]`
- **Esempio:** `kubescape scan framework nsa --verbose`
- **Installazione:** `curl -s https://raw.githubusercontent.com/kubescape/kubescape/master/install.sh | /bin/bash`

### `popeye`
**Sanity check per cluster Kubernetes (best practice e configurazioni errate).**

- **Comando:** `popeye [opzioni]`
- **Esempio:** `popeye --cluster minikube`

### `stern`
**Tail multi-pod e multi-container dei log Kubernetes con colorazione.**

- **Comando:** `stern <pattern> [opzioni]`
- **Esempio:** `stern -n production "web-*" --since 10m`
- **Note:** Supporta regex pattern, colorazione per container

### `yq`
**Parser/editor YAML da riga di comando (come jq per YAML).**

- **Comando:** `yq [opzioni] <espressione> [file]`
- **Esempio:** `yq eval '.spec.replicas = 5' deployment.yaml --inplace`
- **Installazione:** `pip install yq` o binario precompilato

### `kustomize`
**Personalizzazione nativa dei manifest Kubernetes (template-free).**

- **Comando:** `kustomize build [directory] [opzioni]`
- **Esempio:** `kustomize build overlays/production/ | kubectl apply -f -`
- **Note:** Integrato in `kubectl apply -k`

---

## Licenza

Questo documento è distribuito con licenza MIT. Libero da usare, modificare e distribuire.
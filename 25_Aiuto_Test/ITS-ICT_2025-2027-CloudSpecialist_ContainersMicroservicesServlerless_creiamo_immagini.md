# ITS-ICT_2025-2027-CloudSpecialist_ContainersMicroservicesServlerless_creiamo_immagini

## Pagina 1

Cloud SpecialistUnità Formativa (UF): Containers Microservizi ServerlessDocente: Denis MaggiorottoTitolo argomento: Creiamo immagini con Docker


## Pagina 2

Creare un container Docker con Node.js

## Pagina 3

Il Dockerfile
32
FROM image: Inizializza la builde setta l’immagine base sulla quale vengono eseguite le istruzioni che seguono.Es: FROM ubuntu:15.1RUN command: esegue un comando in un nuovo livello, sopra a quelli dell’immagine corrente e ne esegue la commit. L’immagine risultante viene usata dalle prossime istruzioni contenute nel Dockerfile.Es: RUN yuminstallhttpd

## Pagina 4

Il Dockerfile
33
EXPOSE port: informa Dockerche il container è in ascolto sulle porte di rete specificate in fase di runtime. È possibile specificare se la porta è in ascolto su TCP o UDP e il valore predefinito è TCP se il protocollo non è specificato.Es: EXPOSE 80EXPOSE 80/tcpENV key[=value]: Serve a settare una variabile d’ambiente che sarà disponibile all’interno del container. E’ possibile effettuare l’overraiddel valore dal comando dockerrun.Es:

## Pagina 5

Il Dockerfile
34
COPY srcdest : copia nuovi file o directory da <src> e li aggiunge al filesystemdel container nel percorso <dest>Es: COPY app/appADD srcdest : copia nuovi file o directory da <src> e li aggiunge al filesystemdel container nel percorso <dest>.A differenza di COPY, con ADD srcpuò essere una URL, in secondo luogo, è possibile estrarre un file tar dall'origine direttamente nella destinazione.Es: ADD http://myhost.com/file.txt/app

## Pagina 6

Il Dockerfile
35
USER user[:group]: imposta il nome utente (o UID) e il gruppo utente (o GID) da utilizzare durante l'esecuzione dell'immagine e per tutte le istruzioni RUN, CMD ed ENTRYPOINT che lo seguono nel DockerfileEs:USER oracle:oracleWORKDIR dir : imposta la directory di lavoro per tutte le istruzioni RUN, CMD, ENTRYPOINT, COPY e ADD che seguono nel DockerfileEs: WORKDIR /app

## Pagina 7

Il Dockerfile
36
ARG nome[=valore di default]: definisce una variabile che gli utenti possono passare in fase di compilazione con il comando dockerbuildutilizzando il flag--build-arg<varname>=<valore>.Es:ARG user=user1

## Pagina 8

Il Dockerfile
37
VOLUME path: crea un punto di mountcon il nome specificato e lo contrassegna come contenente volumi montati esternamente. I volumi esterni verranno poi montati dall’istruzione dockerrunEs:VOLUME /myvolLABEL chiave=’’valore’’ : aggiunge metadati a un'immagine. Una LABEL è una coppia chiave-valore. Es: LABEL version="1.0"

## Pagina 9

Il Dockerfile
38
ENTRYPOINT commandparam1 param2: Consente di configurare il processo che verrà eseguito dentro al container. Questo processo non potràessere modificato dal comando dockerrun.Es: ENTRYPOINT /usr/sbin/apache2ctl –D FOREGROUNDCMD commandparam1 param2: Consente di configurare il processo che verrà eseguito dentro al container. Questo processo potràessere modificato dal comando dockerrun.Es: CMD /usr/sbin/apache2ctl –D FOREGROUND

## Pagina 10

Il Dockerfile
39
Dockerfilereferencehttps://docs.docker.com/engine/reference/builder/

## Pagina 11

LAB
40
https://github.com/sunnyvale-academy/ITS-ICT_ContainersLab 06 –Node.jscontainers

## Pagina 12

Creare un container Dockercon Java

## Pagina 13

LAB
42
https://github.com/sunnyvale-academy/ITS-ICT_ContainersLab 07 –Java containers

## Pagina 14

Assignment
43
https://github.com/sunnyvale-academy/ITS-ICT_ContainersAssignment01 –Create a Redisserver image
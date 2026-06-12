# ITS-ICT_2025-2027-CloudSpecialist_ContainersMicroservicesServlerless_DockerCompose

## Pagina 1

Software DeveloperUnità Formativa (UF): Containers, Microservizi -ServerlessDocente: Denis MaggiorottoTitolo argomento: Docker Compose


## Pagina 2

DockerCompose


## Pagina 3

Cos’è DockerCompose
135
DockerCompose è uno strumento per definire ed eseguire applicazioni compose (multi-container) tramite Docker.Le applicazioni multi-container vengono definite «ascode» all’interno di uno o più file docker-compose.yamlper poi essere eseguite (o terminate) con un singolo comando.

## Pagina 4

Funzionalità
136
Tramite DockerCompose è possibile:
Eseguire ambienti applicativi multipli su di un singolo hostPreservare i dati in volumi quando i container vengono creatiRi-creare solo i container che sono cambiatiDefinire variabili che possono poi essere richiamate nel docker-compose.yamlfileSuddividere le dichiarazioni in file multipli

## Pagina 5

Verifica versione
137
Con Dockerfor Desktop, l’utility DockerCompose è già installataSu Linux invece:$ sudocurl-L "https://github.com/docker/compose/releases/download/1.25.5/docker-compose-$(uname-s)-$(uname-m)" -o /usr/local/bin/docker-composesudochmod+x /usr/local/bin/docker-compose

## Pagina 6

Verifica
138
$ docker-compose–versiondocker-composeversion1.25.4, build 8d51620a

## Pagina 7

Prima di DockerCompose
139
$ dockerbuild-t myapp.$ dockernetwork create frontend$ dockernetwork create backend$ dockerrun-d --network backendredis:alpine$ dockerrun-d -p5000:5000 --network frontend--namemy-applicationmyapp$ dockernetwork connectbackendmy-application

## Pagina 8

Con DockerCompose
140
$ docker-compose up

## Pagina 9

Nel file docker-compose.yaml
141
VersionServices-> Build-> Image-> Environment-> Ports-> VolumesVolumesNetworks

## Pagina 10

Esempio di docker-compose.yaml
142


## Pagina 11

Comandi utili
143
$ docker-compose upAvvio (aggiungere –d per background mode)
$ docker-compose psVerifica container in esecuzione
$ docker-compose logsVerifica dei logs
$ docker-compose downStop dei container e rimozione

## Pagina 12

Tutti i comandi docker-compose
144
build    Buildor rebuild services help     Get help on a command kill     Kill containers logs     View output from containers port     Print the public port for a port binding psList containers pull     Pulls service images rmRemove stopped containers run      Runa one-off command scale    Set number of containers for a service start    Startservices stop     Stopservices restart  Restartservices up       Create and start containers

## Pagina 13

Buildo image
145
E’ possibile referenziare un’immagine esistente
E’ possibile generare una nuova immagine

## Pagina 14

Depends_on
146
Determina le dipendenze tra container

## Pagina 15

Networks
147
Creazione delle networks
Utilizzo delle networks

## Pagina 16

Environment
148
E’ possibile definire variabili d’ambiente


## Pagina 17

Restart
149
Politica di restart:-No-Always-On-failure-Unless-stopped


## Pagina 18

Volumes
150Creazione dei volumi
Utilizzo dei volumi


## Pagina 19

LAB
151
https://github.com/sunnyvale-academy/ITS-ICT_Containers
Lab 17 –DockerComposeAssignment04 -Multicontainerapplicationwith DockerCompose
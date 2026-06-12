# ITS-ICT_2025-2027-CloudSpecialist_ContainersMicroservicesServlerless_kubernetes_intro

## Pagina 1

Software DeveloperUnità Formativa (UF): Containers, Microservizi -ServerlessDocente: Denis MaggiorottoTitolo argomento: Introduzione a kubernetes


## Pagina 2

KubernetesL’orchestratore di container per eccellenza


## Pagina 3

154
Dal monolite ai micro servizi


## Pagina 4

155
Lo sviluppo diventa agile


## Pagina 5

156
WaterfallVs Agile


## Pagina 6

157
Il movimento DevOps


## Pagina 7

158
I principi del DevOps(CALMS)


## Pagina 8

159
Gli strumenti del DevOps(solo una piccola parte)


## Pagina 9

160
Le applicazioni diventano multi container (microservices)


## Pagina 10

Troppi container?
161


## Pagina 11

Perché Kubernetes
162


## Pagina 12

Cos’è Kubernetes
163
Kubernetesis an open sourcecontainer orchestration engine for automating deployment, scaling, and management of containerized applications. The open sourceproject is hosted by the Cloud Native Computing Foundation.


## Pagina 13

Kubernetesdal 2017 è il secondo progetto OO dopo Linux
164


## Pagina 14

LAB
165
https://github.com/sunnyvale-academy/ITS-ICT_Containers
Lab 18 –Kubernetes

## Pagina 15

L’architettura di Kubernetesed il Pod

## Pagina 16

L’architettura di Kubernetes
167


## Pagina 17

L’architettura di Kubernetes
168


## Pagina 18

L’architettura di Kubernetes
169


## Pagina 19

L’architettura di Kubernetes
170


## Pagina 20

Eseguire un’applicazione su Kubernetes
171


## Pagina 21

KubernetesAPIs
172


## Pagina 22

KubernetesAPIs
173


## Pagina 23

KubernetesAPIs
174


## Pagina 24

KubernetesAPIs
175


## Pagina 25

Minikube
176


## Pagina 26

Pods
177


## Pagina 27

Multi container Pods
178
E’ possibile inserire più di un Container all’interno del Pod.Questa pratica è utile per avere uno o più Containers che supportano il Container principale (Sidecar pattern)


## Pagina 28

Podsreplicas
179
Quando il carico utente aumenta, la pratica comune è quella di aumentare il fattore di replica dei Pod(le istanze) e non il numero di container in un singolo Pod

## Pagina 29

Runningthe first Pod
180


## Pagina 30

Runningthe first Pod
181


## Pagina 31

Podscon YAML
182
Ogni risorsa Kubernetespuò esser descritta in YAML, la cui struttura di base è formata dalle seguenti chiavi (tutte obbligatorie) 

## Pagina 32

Podscon YAML
183
apiVersionrappresenta la versione delle API che useremo per creare la nostra risorsa (in questo caso un Pod). E’ necessario specificare l’apiVersioncorretta per ogni risorsa (vedi tabella).


## Pagina 33

Podscon YAML
184
kindrappresenta il tipo di risorsa da creare. In questo caso il Pod


## Pagina 34

Podscon YAML
185
metadataracchiude delle informazioni fondamentali per il Pod. Qui vediamo il nome (obbligatorio) ed una label(app). Parleremo delle labelin seguito.


## Pagina 35

Podscon YAML
186
spec(specification)racchiude i containers che il Podavrà al suo interno. La struttura di specdipende dal tipo di risorsa (in questo caso Pod).


## Pagina 36

Podscon YAML
187
$ kubectlcreate –f pod-definition.yml


## Pagina 37

Altri Podscon YAML
188
Single containerMulti container

## Pagina 38

LAB
189
https://github.com/sunnyvale-academy/ITS-ICT_Containers
Lab 19 –Pod

## Pagina 39

ReplicationController, ReplicaSete Deployment

## Pagina 40

Podlifecycle(Podstatus)
191


## Pagina 41

ReplicationController(deprecato in favore di ReplicaSet)
192


## Pagina 42

ReplicationController
193


## Pagina 43

ReplicationController
194


## Pagina 44

ReplicationController
195
Per specificare il numero di repliche aggiungiamo:

## Pagina 45

ReplicationController
196
$ kubectlcreate –f rc-definition.yml
$ kubectlget replicationcontroller
$ kubectlget pods

## Pagina 46

LAB
197
https://github.com/sunnyvale-academy/ITS-ICT_Containers
Lab 20 –ReplicationController

## Pagina 47

ReplicaSet
198


## Pagina 48

ReplicaSet
199
Con il Selector, ReplicaSetpuò anche gestire Podche non ha creato


## Pagina 49

ReplicaSet
200
$ kubectlcreate –f replicaset-definition-definition.yml
$ kubectlget replicaset
$ kubectlget pods

## Pagina 50

Labelsand Selectors
201


## Pagina 51

Labelsand Selectors
202
tier
tier

## Pagina 52

Labelsand Selectors
203


## Pagina 53

Labelsand Selectors
204


## Pagina 54

Labelsand Selectors
205


## Pagina 55

Scaling
206
$ kubectlreplace –f replicaset-definition.yml


## Pagina 56

Scaling
207
$ kubectlscale –replicas=6 replicaset-definition.yml$ kubectlscale –replicas=6 replicasetmyapp-replicaset

## Pagina 57

LAB
208
https://github.com/sunnyvale-academy/ITS-ICT_Containers
Lab 21 –ReplicaSet
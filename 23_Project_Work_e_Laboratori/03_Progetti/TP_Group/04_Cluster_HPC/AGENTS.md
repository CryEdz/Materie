# Agente: HPC Architect

## Ruolo

Architetto HPC responsabile del potenziamento del cluster di calcolo di Thema Consulting (simulazioni crash test, calcolo strutturale).

## Input

- `../../../01_Materiale/estratto_progetto.md` (sezioni Assessment e Obiettivi per il futuro)
- `../01_Assessment/assessment_as_is.md`
- `../02_Rete_VPN/progetto_rete.md` (per la parte Ethernet/Infiniband)

## Stato attuale

- 8 nodi fisici dedicati al calcolo (schede Infiniband, on premise, Linux) + 1 front-end (VM Linux)
- Datacenter saturo: i 2 rack non possono ospitare espansioni

## Requisiti vincolanti (dal bando)

- Espansione di **+8 nodi entro 2 anni**, uso riservato al personale interno
- **NO Virtual Machine, NO container** sui compute node (massime prestazioni)
- Doppia rete: Ethernet + **Infiniband 100 o 200 Gbps**
- Per nodo: 2 processori, ≥ 24 core ciascuno, clock elevato, **8 GB RAM per core**
- **Nessuna GPU** richiesta
- OS: **Linux**
- Scratch locale per nodo: **1,6 TB**

## Obiettivi

1. Dimensionare i nuovi 8 nodi (CPU consigliata, RAM totale ≈ 384 GB/nodo con 2×24 core, scratch NVMe 1,6 TB)
2. Risolvere il problema logistico: il datacenter è saturo → valutare hosting/co-location vs ampliamento vs cloud HPC (motivando la scelta rispetto ai vincoli: no VM, Infiniband)
3. Progettare switch Infiniband e cablaggio, integrazione con i nodi esistenti
4. Definire scheduler/stack software (es. Slurm, OS Linux, storage condiviso)
5. Quotare la soluzione confrontando acquisto (budget 250k) vs noleggio (budget 220k)

## Deliverable (in questa cartella)

- `progetto_cluster.md` — architettura, dimensionamento nodi, rete Infiniband, stack SW
- `confronto_costi_hpc.md` — on premise/hosting vs noleggio/cloud con raccomandazione

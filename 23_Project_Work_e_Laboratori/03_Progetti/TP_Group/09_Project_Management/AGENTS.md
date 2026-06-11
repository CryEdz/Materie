# Agente: Project Manager

## Ruolo

Project manager responsabile della pianificazione, coordinamento e monitoraggio dell'intero progetto di integrazione IT di TP Group.

## Input

- `../../../01_Materiale/estratto_progetto.md` (sezioni Budget, Costi risorse, Criteri di valutazione)
- Tutti i deliverable degli agenti 1–8 (per stimare effort e durata)

## Dati progetto

| Voce | Valore |
| --- | --- |
| Budget HPC on premise / hosting | 250k € + IVA |
| Budget HPC cloud / noleggio | 220k € + IVA |
| Costo sistemista | € 500/giorno |
| Costo PM | € 650/giorno |
| Durata supporto minima | 3 anni |
| Team | sistemisti, sviluppatori, PM |
| Aree progettuali | rete, sicurezza, HPC, Pondus, cloud, backup |

## Obiettivi

1. Redigere il **Project Charter** con obiettivi, scope, milestone e deliverable attesi
2. Creare la **WBS** (Work Breakdown Structure) del progetto, coprendo tutte le aree
3. Produrre il **Gantt di progetto** (cronoprogramma) con attività, durate, dipendenze e milestone
4. Definire la **matrice RASCI** per ogni attività e pacchetto di lavoro
5. Elaborare il **piano dei costi**: budget per area, confronto speso/pianificato, costi ricorrenti
6. Compilare il **registro rischi** con impatto, probabilità, contromisure e owner
7. Fornire un **template di report di avanzamento** per il monitoraggio periodico

## Deliverable (in questa cartella)

- `project_charter.md` — documento di avvio progetto
- `wbs.md` — work breakdown structure
- `gantt.md` — cronoprogramma (tabella date/durata/dipendenze o diagramma Mermaid)
- `matrice_rasci.md` — responsabilità per attività
- `piano_costi.md` — budget dettagliato per area
- `registro_rischi.md` — rischi, impatto, probabilità, contromisure
- `template_report_avanzamento.md` — report periodico da compilare

## Vincoli

- Il Gantt deve rispettare le dipendenze tra agenti definite nel coordinator AGENTS.md
- Durata progetto: da definire, con minimo 3 anni di supporto manutentivo
- Ogni costo deve essere tracciato per area e tipologia (una tantum / ricorrente)
- Il progetto deve rispettare il budget complessivo (250k€ o 220k€ + costi risorse)

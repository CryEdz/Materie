# Gantt di Progetto — TP Group

## Cronoprogramma (6 mesi)

```mermaid
gantt
    title Gantt TP Group — Integrazione IT
    dateFormat  YYYY-MM-DD
    axisFormat  %b

    section Assessment
    A1 Censimento asset             :a1, 2026-07-01, 10d
    A2 Gap analysis                  :a2, after a1, 10d

    section Rete VPN
    R1 Progettazione rete           :r1, after a2, 10d
    R2 Acquisto HW rete             :r2, after r1, 5d
    R3 Installazione e cablaggio    :r3, after r2, 10d
    R4 Configurazione + test        :r4, after r3, 10d

    section Sicurezza ISO 27001
    S1 Gap analysis ISO             :s1, after r1, 10d
    S2 Politiche sicurezza          :s2, after s1, 10d
    S3 Implementazione              :s3, after s2, 15d
    S4 Audit                        :s4, after s3, 5d

    section Cluster HPC
    H1 Dimensionamento              :h1, after a2, 10d
    H2 Acquisto HW HPC              :h2, after h1, 15d
    H3 Installazione hosting        :h3, after h2, 10d
    H4 Configurazione + test        :h4, after h3, 15d

    section Pondus
    P1 Preparazione VM              :p1, after s2, 10d
    P2 Migrazione DB + app          :p2, after p1, 10d
    P3 Configurazione HA            :p3, after p2, 5d
    P4 Test e dismissione           :p4, after p3, 10d

    section Cloud Migration
    C1 VPN GCP + GCDS               :c1, after r4, 10d
    C2 Migrazione servizi           :c2, after c1, 15d
    C3 Integrazione finale          :c3, after c2, 10d

    section Backup DR
    B1 Acquisto NAS                 :b1, after r2, 5d
    B2 Configurazione backup        :b2, after b1 + s3, 10d
    B3 Procedure DR + test          :b3, after b2 + c2, 10d

    section Offerta
    O1 Raccolta contributi          :o1, after a2, 120d
    O2 Redazione offerta            :o2, after b3, 15d
    O3 Consegna                     :o3, after o2, 5d

    section Project Management
    M1 Pianificazione               :m1, 2026-07-01, 10d
    M2 Coordinamento                :m2, after m1, 120d
    M3 Chiusura                    :m3, after o3, 5d
```

## Tabella attività

| Attività | Inizio | Fine | Durata | Dipendenze |
| --- | --- | --- | --- | --- |
| **Mese 1** | | | | |
| Assessment | G1 | G3 | 20g | — |
| Progettazione rete | G3 | G4 | 10g | Assessment |
| Gap analysis ISO | G3 | G4 | 10g | Progettazione rete |
| Dimensionamento HPC | G3 | G4 | 10g | Assessment |
| **Mese 2** | | | | |
| Acquisto HW rete | G4 | G5 | 5g | Progettazione rete |
| Installazione rete | G5 | G6 | 10g | Acquisto HW rete |
| Politiche sicurezza | G5 | G6 | 10g | Gap analysis ISO |
| Acquisto HPC | G5 | G6 | 15g | Dimensionamento HPC |
| Acquisto NAS backup | G5 | G5 | 5g | Acquisto HW rete |
| **Mese 3** | | | | |
| Configurazione rete | G6 | G7 | 10g | Installazione rete |
| Implementazione sicurezza | G7 | G8 | 15g | Politiche sicurezza |
| Installazione HPC | G7 | G8 | 10g | Acquisto HPC |
| Configurazione backup | G8 | G9 | 10g | Implementazione sicurezza |
| VPN GCP + GCDS | G7 | G8 | 10g | Configurazione rete |
| **Mese 4** | | | | |
| Test rete | G8 | G8 | 5g | Configurazione rete |
| Audit sicurezza | G10 | G10 | 5g | Implementazione sicurezza |
| Configurazione HPC | G9 | G10 | 15g | Installazione HPC |
| Preparazione VM Pondus | G8 | G9 | 10g | Implementazione sicurezza |
| Migrazione servizi cloud | G9 | G10 | 15g | VPN GCP + GCDS |
| **Mese 5** | | | | |
| Benchamark HPC | G11 | G11 | 5g | Configurazione HPC |
| Migrazione Pondus | G10 | G11 | 10g | Preparazione VM |
| HA Pondus + test | G11 | G12 | 15g | Migrazione Pondus |
| Integrazione cloud | G11 | G12 | 10g | Migrazione servizi |
| Procedure DR | G11 | G12 | 10g | Configurazione backup |
| **Mese 6** | | | | |
| Redazione offerta | G13 | G14 | 15g | Tutti completati |
| Consegna e chiusura | G14 | G14 | 5g | Offerta |

**Legenda:** G = mese, es. G1 = inizio mese 1, G3 = fine mese 1

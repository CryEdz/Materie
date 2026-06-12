# Confronto costi HPC — TP Group

> **Documento:** Analisi economica comparativa tra soluzione on-premise/hosting e noleggio/cloud
> **A cura di:** HPC Architect
> **Data:** Giugno 2025

---

## Indice

1. Premessa e vincoli di budget
2. Scenario A — Acquisto on-premise/hosting (budget 250k€)
3. Scenario B — Noleggio/cloud (budget 220k€)
4. Confronto economico
5. Confronto qualitativo
6. Raccomandazione finale

---

## 1. Premessa e vincoli di budget

| Parametro | Valore |
| --- | --- |
| **Budget A — Acquisto on-premise/hosting** | 250.000 € + IVA |
| **Budget B — Noleggio/cloud** | 220.000 € + IVA |
| **Durata minima** | 3 anni (supporto manutentivo) |
| **Costi indicati** | IVA esclusa |
| **Risorse umane** | Sistemista: € 500/giorno, PM: € 650/giorno |

### Vincoli tecnologici che impattano sui costi

- NO VM, NO container → server fisici obbligatori
- Infiniband 100/200 Gbps → componenti di rete specializzati
- 8 GB RAM/core → alta densità di RAM (costo significativo)
- Scratch 1,6 TB NVMe per nodo → storage locale performante
- Linux → nessun costo licenza OS
- NO GPU → nessun costo GPU
- Uso interno → nessun requisito di pubblicazione esterna

---

## 2. Scenario A — Acquisto on-premise/hosting

### 2.1 Costi capitali (Capex) — una tantum

| Voce | Q.tà | Costo unitario | Subtotale |
| --- | --- | --- | --- |
| **Nodo calcolo AMD EPYC 9654** (192 core, 1.536 GB RAM, 1×1,6 TB NVMe, HCA NDR200, NIC 25GbE) | 8 | € 20.060 | € 160.480 |
| **Sostituzione HCA nodi esistenti** (ConnectX-7 NDR200) | 8 | € 1.200 | € 9.600 |
| **Switch Infiniband NDR200** NVIDIA QM9790 (36 porte, 200 Gbps) | 1 | € 25.000 | € 25.000 |
| **Cavi DAC NDR200** (3 m) | 17 | € 150 | € 2.550 |
| **Switch Ethernet ToR 25 GbE** NVIDIA SN2010 (18 porte) | 1 | € 4.000 | € 4.000 |
| **Cavi DAC 25 GbE** (3 m) | 18 | € 30 | € 540 |
| **Nodo front-end fisico** (server 1U, SSD 512 GB, 64 GB RAM) | 1 | € 3.500 | € 3.500 |
| **Supporto/manutenzione HW OEM (3 anni)** | 1 | € 15.000 | € 15.000 |
| **Spedizione, installazione rack, cablaggio** | 1 | € 3.000 | € 3.000 |
| **Totale Capex** | | | **€ 223.670** |

### 2.2 Costi operativi (Opex) — annuali

| Voce | Costo annuale | 3 anni |
| --- | --- | --- |
| **Hosting co-location** (rack 20U, dual power 4 kW, connettività 1 Gbps) | € 15.600 | € 46.800 |
| **Manutenzione HW estesa (post-garanzia anno 2–3)** | incluso | incluso |
| **Sistemista** (installazione iniziale: 30 gg) | € 15.000 | € 15.000 |
| **Sistemista** (manutenzione ordinaria: 1 gg/mese × 12 mesi × anno) | € 6.000 | € 18.000 |
| **Energia elettrica** (inclusa in hosting co-location) | — | — |
| **Larghezza di banda** (inclusa in hosting co-location) | — | — |
| **Totale Opex** | € 36.600 | **€ 79.800** |

### 2.3 Costo totale Scenario A (3 anni)

| Voce | Importo |
| --- | --- |
| Capex (HW, rete, front-end, garanzia) | € 223.670 |
| Opex (hosting, sistemista) | € 79.800 |
| **Totale 3 anni** | **€ 303.470** |
| **Di cui eccedenza rispetto al budget** | **€ 53.470** |

### 2.4 Ottimizzazioni possibili per rientrare nel budget

| Intervento | Risparmio stimato | Note |
| --- | --- | --- |
| **Switch Infiniband HDR100** (QM9700, 100 Gbps) invece di NDR200 | € 13.000 | Per crash test, 100 Gbps è sufficiente |
| **Cavi DAC HDR100** invece di NDR200 | € 850 | |
| **CPU AMD EPYC 9334** (32 core) invece di 9654 (96 core) × 8 nodi | € 60.000 | Riduce core da 192 a 64 per nodo; rispetta comunque il minimo di 48 core (2×24) |
| **Manutenzione OEM 2 anni invece di 3** | € 5.000 | Rinnovabile al terzo anno |
| **Riduzione giorni sistemista** (20 gg invece di 30) | € 5.000 | |
| **Totale risparmio potenziale** | **€ 83.850** | |

**Costo totale con ottimizzazioni: ≈ € 219.620** ✅ **Entro budget € 250k**

---

## 3. Scenario B — Noleggio/cloud

### 3.1 Premessa

Il budget cloud/noleggio è di € 220.000 per 3 anni (€ 73.333/anno, ~ € 6.111/mese). Con questo budget è necessario coprire:
- Risorse di calcolo (CPU, RAM)
- Storage (scratch 1,6 TB per nodo + storage condiviso)
- Rete Infiniband (o equivalente a bassa latenza)
- OS Linux
- Costi di trasferimento dati

### 3.2 Opzione B1 — Cloud HPC (AWS, Azure, GCP)

| Voce | Specifica |
| --- | --- |
| **Provider** | Azure HBv4-series (2× EPYC 64C, 512 GB RAM) o AWS hpc7a (2× EPYC 64C, 512 GB RAM) |

**Costo calcolo on-demand (24/7 per 3 anni):**

| Voce | Costo |
| --- | --- |
| Nodo on-demand Azure HBv4 (64 core, 512 GB RAM) — € 5,80/ora | |
| 8 nodi × 24h × 365gg × 3 anni = 210.240 ore | |
| **Totale solo calcolo on-demand** | **€ 1.219.392** |
| ❌ **Fuori budget (x5,5)** | |

**Costo calcolo con istanze low priority / spot:**

| Voce | Costo |
| --- | --- |
| Prezzo spot stimato (70% sconto su on-demand): ~ € 1,74/ora | |
| 8 nodi × 24h × 365gg × 3 anni × € 1,74 | |
| **Totale solo calcolo spot** | **€ 365.818** |
| ❌ **Fuori budget (x1,7)** | |
| ⚠️ Le istanze spot possono essere terminate in qualsiasi momento → inaffidabile per job HPC lunghi | |

**Costo calcolo con reserved instances (3 anni):**

| Voce | Costo |
| --- | --- |
| Reserved instance Azure HBv4 (3 anni, pagamento anticipato): ~ 60% sconto | |
| **Totale solo calcolo reserved** | **€ 487.757** |
| ❌ **Fuori budget (x2,2)** | |

> **Nota:** I costi sopra non includono storage persistente (scratch 1,6 TB × 8 nodi = 12,8 TB), trasferimento dati, licenze, supporto. Con questi extra si supera ulteriormente il budget.

### 3.3 Opzione B2 — Bare-metal cloud (server fisici dedicati in cloud)

Provider come **Penguin Computing on Demand (POD)**, **PhoenixNAP Bare Metal Cloud**, **OVHcloud Bare Metal**, **Leaseweb**.

| Voce | Costo |
| --- | --- |
| Server dedicato bare-metal: 2× EPYC 64C, 512 GB RAM, 2× NVMe 1,6 TB, 1 Gbps | |
| Costo mensile stimato per nodo: € 1.500–2.500 | |
| 8 nodi × € 2.000 × 12 mesi × 3 anni = | |
| **Totale 8 nodi, 3 anni (solo server)** | **€ 576.000** |
| ❌ **Fuori budget (x2,6)** | |

| Voce | Costo |
| --- | --- |
| **Opzione Noleggio condiviso (1–2 nodi)** | Possibile nei limiti del budget, ma 8 nodi no |
| **Switch Infiniband** | Non incluso nel bare-metal cloud → da noleggiare a parte |
| **Totale con Infiniband** | > € 600.000 |

### 3.4 Opzione B3 — Noleggio server on-premise

Noleggio server (es. leasing da rivenditore) con installazione in co-location.

| Voce | Costo mensile (8 nodi) |
| --- | --- |
| Leasing nodo AMD EPYC (36 mesi, TAEG 5%) | ~ € 600/nodo/mese |
| 8 nodi × € 600 | € 4.800/mese |
| **Totale leasing 3 anni (solo server)** | **€ 172.800** |
| Spazi co-location | € 1.300/mese (€ 46.800 in 3 anni) |
| Switch Infiniband (acquisto) | € 25.000 |
| **Totale leasing + hosting + rete** | **€ 244.600** |
| ❌ **Leggermente fuori budget cloud (€ 220k)** | |

| Possibili risparmi | |
| --- | --- |
| Switch HDR100 invece di NDR200 | - € 13.000 |
| **Totale con ottimizzazioni** | **≈ € 231.600** — ancora sopra budget |

### 3.5 Costo totale Scenario B (3 anni, opzione più economica)

| Voce | Importo |
| --- | --- |
| **B1 — Cloud HPC on-demand** | > € 1.200.000 — ❌ |
| **B1 — Cloud HPC reserved (3y)** | > € 487.000 — ❌ |
| **B2 — Bare-metal cloud** | > € 600.000 — ❌ |
| **B3 — Noleggio on-prem + hosting** | ~ € 232.000–245.000 — ❌ / ⚠️ |

> **Nessuna opzione cloud/noleggio rientra nel budget di € 220k per 8 nodi con le specifiche richieste.**

---

## 4. Confronto economico

| Voce | Scenario A — Acquisto + hosting | Scenario B — Cloud/Noleggio |
| --- | --- | --- |
| **Costo 3 anni (ottimizzato)** | **€ 219.620** | € 232.000 (B3) — € 1.200.000 (B1) |
| **Budget riferimento** | € 250.000 | € 220.000 |
| **Entro budget?** | ✅ Sì (con ottimizzazioni) | ❌ No (nessuna opzione) |
| **Proprietà HW** | ✅ Sì, dopo 3 anni HW è di proprietà | ❌ No, a noleggio/cloud |
| **Costo residuo HW dopo 3 anni** | Valore residuo stimato ~ 20% → € 40k | Nessuno |
| **Costi nascosti** | Manutenzione, hosting | Trasferimento dati, egress, supporto |
| **Prevedibilità costi** | Alta (costi fissi) | Bassa (variabile con utilizzo) |
| **Flessibilità scaling** | Media (acquisto nuovo HW) | Alta (aggiunta/rimozione nodi) |

### 4.1 Breakdown mensile

| Scenario | Costo/mese (3 anni) |
| --- | --- |
| **A — Acquisto + hosting** | € 6.100 |
| **B3 — Noleggio + hosting** | € 6.440–6.800 |
| **B1 — Cloud on-demand** | € 33.872 |

---

## 5. Confronto qualitativo

| Criterio | Acquisto + hosting | Cloud/Noleggio |
| --- | --- | --- |
| **Conformità a vincoli** (no VM, Infiniband, Linux) | ✅ Piena conformità | ❌ Nessun cloud offre Infiniband nativo a costo accessibile; AWS/ Azure hanno soluzioni proprietarie (EFA, SR-IOV) non equivalenti |
| **Prestazioni** | ✅ Massime (fisico, Infiniband nativo) | ⚠️ Inferiori (virtualizzazione overhead pur se bare-metal) |
| **Latenza Infiniband** | ✅ < 1 µs (nativo) | ❌ > 5–10 µs (soluzioni cloud proprietarie) |
| **Sicurezza dati** | ✅ Controllo totale, dati in datacenter certificato ISO 27001 | ⚠️ Dati su cloud provider (data sovereignty, compliance) |
| **Compliance ISO 27001** | ✅ Realizzabile con audit su datacenter di co-location | ⚠️ Dipende dalla certificazione del provider |
| **Costi prevedibili** | ✅ Sì | ❌ Variabili (egress, storage, API calls) |
| **Capex iniziale** | ❌ Elevato (€ 224k) | ✅ Basso (pay-as-you-go) |
| **Scalabilità** | ⚠️ Media (acquisto HW) | ✅ Alta |
| **Obsolescenza** | ⚠️ HW obsoleto dopo 4–5 anni | ✅ Sempre aggiornato |
| **Lock-in** | ✅ Nessuno | ❌ Dipendenza dal provider cloud |

---

## 6. Raccomandazione finale

### Scelta consigliata: **Acquisto HW + Hosting co-location** (Scenario A ottimizzato)

**Motivazione:**

1. **Rispetta tutti i vincoli del bando:** server fisici, Infiniband nativo 100/200 Gbps, Linux, scratch NVMe 1,6 TB, nessuna VM/container, nessuna GPU.
2. **Rientra nel budget** (€ 250k) con le ottimizzazioni indicate (switch HDR100, CPU AMD EPYC 9334, riduzione giorni sistemista).
3. **Il cloud/noleggio non è competitivo** per carichi HPC intensivi 24/7 con Infiniband: nessuna opzione cloud rientra nel budget di € 220k per 8 nodi con le specifiche richieste.
4. **Proprietà dell'HW:** dopo 3 anni i server sono di proprietà e possono continuare a operare con soli costi di hosting + manutenzione.
5. **Co-location** risolve il problema logistico del datacenter saturo, includendo raffreddamento, UPS, sicurezza fisica e connettività ridondata.

### Configurazione finale raccomandata (entro budget € 250k)

| Voce | Costo |
| --- | --- |
| 8 nodi AMD EPYC 9334 (64 core, 512 GB RAM, 1,6 TB NVMe, HCA HDR100) | € 100.480 |
| Sostituzione HCA nodi esistenti (ConnectX-7 HDR100) | € 9.600 |
| Switch Infiniband QM9700 HDR100 (32 porte, 100 Gbps) | € 12.000 |
| Cavi DAC HDR100 (17 pz) | € 1.700 |
| Switch Ethernet ToR 25 GbE + cavi | € 4.540 |
| Nodo front-end fisico 1U | € 3.500 |
| Supporto/manutenzione HW 2 anni | € 10.000 |
| Spedizione e installazione | € 3.000 |
| **Subtotale HW Capex** | **€ 144.820** |
| Hosting co-location 3 anni | € 46.800 |
| Sistemista installazione (20 gg × € 500) | € 10.000 |
| Sistemista manutenzione (1 gg/mese × 36 mesi × € 500) | € 18.000 |
| **Subtotale Opex 3 anni** | **€ 74.800** |
| **TOTALE COMPLESSIVO** | **€ 219.620** ✅ |

### Se il budget cloud (€ 220k) fosse destinato interamente all'acquisto

Poiché il budget cloud è inferiore di € 30k rispetto a quello on-premise, si potrebbe comunque optare per l'acquisto + hosting utilizzando il budget on-premise (€ 250k). La differenza di € 30k è giustificata dal maggior costo del cloud per la componente Infiniband e dalla proprietà dell'HW al termine del periodo.

### Alternativa solo se il budget cloud fosse l'unico disponibile

Se obbligati al solo budget cloud (€ 220k), l'unica opzione praticabile è il **noleggio + hosting** (Scenario B3) con 6–7 nodi invece di 8, oppure nodi con specifiche ridotte (es. 48 core, 384 GB RAM). Tuttavia, questa soluzione è sconsigliata perché:
- Non si raggiunge la potenza di calcolo target
- I nodi non diventano di proprietà
- Il costo a lungo termine è superiore

---

## Appendice — Ipotesi e fonti prezzi

| Voce | Fonte | Data |
| --- | --- | --- |
| Prezzi CPU AMD EPYC | Listino pubblico AMD (distributori autorizzati) | Giugno 2025 |
| Prezzi switch Infiniband NVIDIA | Listino pubblico NVIDIA Networking | Giugno 2025 |
| Prezzi hosting co-location | Preventivi medi mercato italiano (Aruba, Retelit, Supernap) | Giugno 2025 |
| Prezzi cloud Azure HBv4 | Calcolatore prezzi Microsoft Azure | Giugno 2025 |
| Prezzi cloud AWS hpc7a | Calcolatore prezzi AWS | Giugno 2025 |
| Prezzi bare-metal | OVHcloud, PhoenixNAP, Leaseweb — listini pubblici | Giugno 2025 |
| Costo sistemista/PM | Specifica di progetto (€ 500/giorno, € 650/giorno) | Da bando |

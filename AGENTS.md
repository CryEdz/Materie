# Mappatura agenti per le directory del workspace "Materie"

Questo file descrive quale agente usare (suggerito) per ogni area/modulo della cartella `Materie` e come invocarlo per attività comuni.

Linee guida rapide
- Usa l'agente indicato quando lavori nelle rispettive directory (es. debugging, esercizi, suggerimenti, spiegazioni).
- Per eseguire un subagent: fornisci all'agente il contesto (cartella, obiettivo, file rilevanti).

Mappatura consigliata

- 00_Amministrazione_Corso: `project-work-mentor` (documentazione, processi, consegne)
- 01_Inglese_Tecnico: `english-tech-mentor` (esercizi linguistici, CV/LinkedIn tecnici)
- 02_Orientamento_e_Soft_Skills: `project-work-mentor` (soft skills, pianificazione)
- 03_Parita_e_Non_Discriminazione: `project-work-mentor`
- 04_Sicurezza_sul_Lavoro: `project-work-mentor`
- 05_Fondamenti_ICT: `coding-coach-its` (concetti base, esempi didattici)
- 06_Reti_e_Sicurezza_Informatica: `network-security-trainer` (reti, sicurezza, esercizi di troubleshooting)
- 07_Version_Control_Git: `coding-coach-its` / `Explore` (flussi Git, esercizi pratici)
- 08_Basi_di_Dati_SQL_NoSQL: `database-sql-coach` (modellazione, query, ottimizzazione)
- 09_Programmazione_C_CPP: `coding-coach-its` (algoritmi, codice C/C++)
- 10_Programmazione_Python: `coding-coach-its` (script, esercizi Python)
- 11_Programmazione_DotNet_CSharp: `dotnet-api-tutor` (C#, .NET, API)
- 12_RESTful_API: `dotnet-api-tutor` / `coding-coach-its` (API design, esempi)
- 13_Cloud_AWS: `cloud-lab-tutor` (AWS labs, deployment)
- 14_Cloud_Azure: `cloud-lab-tutor` (Azure labs, Functions, App Service)
- 15_Cloud_GCP: `cloud-lab-tutor` (GCP labs, Cloud Run, Compute)
- 16_Linux_Server_e_Amministrazione: `linux-sysadmin-lab` (amministrazione Linux)
- 17_Container_Docker_Kubernetes: `cloud-lab-tutor` / `linux-sysadmin-lab` (Docker, Kubernetes)
- 18_Microsoft_365_SharePoint: `project-work-mentor` (procedure, documentazione SharePoint)
- 19_Virtualizzazione: `project-work-mentor` / `linux-sysadmin-lab`
- 20_Data_Analytics_Visualization: `data-analytics-coach` (analisi, visualizzazioni, dashboard)
- 21_Internet_of_Things: `iot-edge-lab` (scenario IoT, telemetria)
- 22_AI_e_Prompt_Engineering: `coding-coach-its` / `Explore` (prompt, esempi, best practice)
- 23_Project_Work_e_Laboratori: `project-work-mentor` (organizzazione project work)
- 24_Stage_Professionale: `project-work-mentor` (stage, portfolio)
- tools/: `Explore` (script e strumenti vari)

Esempi d'uso rapido

- Richiedere aiuto su un esercizio Python in `10_Programmazione_Python`:
  - Agente: `coding-coach-its`
  - Prompt suggerito: "Sono nella cartella `10_Programmazione_Python/02_Esercizi/ES1`. Spiega come risolvere l'esercizio X e suggerisci test unitari."

- Richiedere setup Azure Functions in `14_Cloud_Azure`:
  - Agente: `cloud-lab-tutor`
  - Prompt suggerito: "Contesto: `14_Cloud_Azure/02_Esercizi`. Voglio eseguire localmente le Azure Functions. Elenca i comandi e verifica `requirements.txt`."

- Chiedere analisi di schema SQL in `08_Basi_di_Dati_SQL_NoSQL`:
  - Agente: `database-sql-coach`
  - Prompt suggerito: "Analizza lo schema in `08_Basi_di_Dati_SQL_NoSQL/03_Progetti/db.sql` e suggerisci indici e normalizzazione." 

Buone pratiche

- Fornisci sempre il percorso relativo e i file chiave quando chiedi al subagent di analizzare codice o configurazioni.
- Specifica l'obiettivo (es. 'ottimizza query', 'scrivi test', 'spiega concetti') per avere risposte mirate.
- Per lavoro offline o in aula, preferisci `Explore` per riconoscere rapidamente file e punti di interesse.

Hai bisogno che generi automaticamente template di prompt per ogni directory o che aggiunga riferimenti a questo file nel `README.md` principale?
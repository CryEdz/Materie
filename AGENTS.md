# Mappatura agenti per le directory del workspace "Materie"

Questo file descrive quale agente usare (suggerito) per ogni area/modulo della cartella `Materie` e come invocarlo per attività comuni.

## Routing dinamico basato sul prompt

Devi analizzare la richiesta dell'utente e invocare automaticamente il subagent appropriato con `@nome-agente` in base al **contenuto della domanda**, non solo alla directory corrente.

Mappa contenuto -> agente:

| Cosa chiede l'utente | Agente da invocare |
|---|---|
| C#, .NET, ASP.NET, API RESTful in .NET, Entity Framework, WPF, MAUI, LINQ | `@dotnet-api-tutor` |
| Programmazione generale, algoritmi, strutture dati, Python, C, C++, JavaScript, TypeScript, fondamenti ICT, Git, esercizi didattici | `@coding-coach-its` |
| SQL, NoSQL, modellazione dati, query, indici, normalizzazione, MongoDB, Redis | `@database-sql-coach` |
| Project work, documentazione, processi, pianificazione, soft skills, stage/portfolio, CV, SharePoint, parità, sicurezza lavoro, virtualizzazione | `@project-work-mentor` |
| Inglese tecnico, traduzioni, CV/LinkedIn in inglese, terminologia IT, colloqui in inglese | `@english-tech-mentor` |
| Reti, sicurezza informatica, firewall, crittografia, troubleshooting di rete, OWASP | `@network-security-trainer` |
| AWS, Azure, GCP, Docker, Kubernetes, deployment cloud, server Linux | `@cloud-lab-tutor` |
| Analisi dati, visualizzazioni, dashboard, Python (pandas, matplotlib), Power BI, data science | `@data-analytics-coach` |
| IoT, sensori, MQTT, telemetria, edge computing | `@iot-edge-lab` |
| Esplorazione veloce del codice, ricerca file, lettura rapida, "trova", "dov'è", strutture del progetto | `@explore` |
| AI, prompt engineering, intelligenza artificiale, LLM | `@coding-coach-its` |

## Regole di routing

1. **Se la richiesta è ambigua o generica**, usa `@coding-coach-its` (copre la maggior parte dei casi base).
2. **Se chiede esplorazione rapida** (trovare file, cercare definizioni, riassumere), usa `@explore` perché è più veloce (modello leggero).
3. **Se il contesto è misto** (es. "query SQL in C#"), dai priorità all'argomento principale e, se necessario, cita entrambi.
4. **Non aggiungere commenti "ho invocato X"** nella risposta se non strettamente necessario.
5. **Quando invochi un subagent, passa tutto il contesto** necessario: directory, file rilevanti, obiettivo.

## Mappatura directory -> contesto (informativa)

Le directory servono solo per capire il contesto del progetto. Il routing effettivo si basa sul prompt.

- `00_Amministrazione_Corso` -> project-work-mentor
- `01_Inglese_Tecnico` -> english-tech-mentor
- `02_Orientamento_e_Soft_Skills` -> project-work-mentor
- `03_Parita_e_Non_Discriminazione` -> project-work-mentor
- `04_Sicurezza_sul_Lavoro` -> project-work-mentor
- `05_Fondamenti_ICT` -> coding-coach-its
- `06_Reti_e_Sicurezza_Informatica` -> network-security-trainer
- `07_Version_Control_Git` -> coding-coach-its / explore
- `08_Basi_di_Dati_SQL_NoSQL` -> database-sql-coach
- `09_Programmazione_C_CPP` -> coding-coach-its
- `10_Programmazione_Python` -> coding-coach-its
- `11_Programmazione_DotNet_CSharp` -> dotnet-api-tutor
- `12_RESTful_API` -> dotnet-api-tutor / coding-coach-its
- `13_Cloud_AWS` -> cloud-lab-tutor
- `14_Cloud_Azure` -> cloud-lab-tutor
- `15_Cloud_GCP` -> cloud-lab-tutor
- `16_Linux_Server_e_Amministrazione` -> cloud-lab-tutor
- `17_Container_Docker_Kubernetes` -> cloud-lab-tutor
- `18_Microsoft_365_SharePoint` -> project-work-mentor
- `19_Virtualizzazione` -> project-work-mentor
- `20_Data_Analytics_Visualization` -> data-analytics-coach
- `21_Internet_of_Things` -> iot-edge-lab
- `22_AI_e_Prompt_Engineering` -> coding-coach-its
- `23_Project_Work_e_Laboratori` -> project-work-mentor
- `24_Stage_Professionale` -> project-work-mentor
- `tools/` -> explore
# Template prompt per subagents — Workspace Materie

Questo file contiene template pronti all'uso per invocare i subagents suggeriti in `AGENTS.md`. Copia il template e sostituisci i valori tra <>.

---

00_Amministrazione_Corso
- Agente: project-work-mentor
- Template:
  "Contesto: sono nella cartella `00_Amministrazione_Corso/<subpath>`.
  Obiettivo: <es. creare piano lezioni / verificare scadenze / creare checklist>.
  File chiave: <elenco file>. 
  Richiedo: <cosa vuoi che l'agente faccia: es. 'scrivi un piano settimanale in markdown', 'genera email di comunicazione'>.
  Vincoli: <es. lunghezza, data di scadenza, formato markdown>.
  Output atteso: <es. file `plan.md` o testo pronto per email>."

01_Inglese_Tecnico
- Agente: english-tech-mentor
- Template:
  "Contesto: `01_Inglese_Tecnico/<subpath>`.
  Obiettivo: <es. correggi testo tecnico / prepara esercizi / crea lettura guidata>.
  File chiave: <file.md o esercizio>.
  Richiedo: <es. correzione, traduzione, esempi di esercizi con soluzioni>.
  Output atteso: <testo corretto + note didattiche>."

02_Orientamento_e_Soft_Skills
- Agente: project-work-mentor
- Template:
  "Contesto: `02_Orientamento_e_Soft_Skills/<subpath>`.
  Obiettivo: <es. creare attività di gruppo / valutazione competenze>.
  Richiedo: <materiale, rubriche, esercizi pratici>.
  Output atteso: <scheda attività in markdown>."

03_Parita_e_Non_Discriminazione
- Agente: project-work-mentor
- Template: come 02, focalizzato su policy e materiale didattico.

04_Sicurezza_sul_Lavoro
- Agente: project-work-mentor
- Template: "Contesto: `04_Sicurezza_sul_Lavoro/...`. Obiettivo: <checklist sicurezza / schede procedure>. Richiedo: <lista controlli in formato checklist>."

05_Fondamenti_ICT
- Agente: coding-coach-its
- Template:
  "Contesto: `05_Fondamenti_ICT/<subpath>`.
  Obiettivo: spiega il concetto <nome> con esempio pratico e mini-esercizio.
  Richiedo: spiegazione breve, esempio di codice, esercizio di verifica e soluzioni.
  Output: markdown con sezione teoria, esempio, esercizio, soluzione."

06_Reti_e_Sicurezza_Informatica
- Agente: network-security-trainer
- Template:
  "Contesto: `06_Reti_e_Sicurezza_Informatica/<subpath>`.
  Obiettivo: analizza il problema di rete o suggerisci configurazione firewall/ACL.
  File chiave: <config, pcap, topologia>.
  Richiedo: passi dettagliati per troubleshooting + comandi."

07_Version_Control_Git
- Agente: coding-coach-its / Explore
- Template:
  "Contesto: `07_Version_Control_Git/<subpath>`.
  Obiettivo: spiega flusso Git richiesto (feature/release), correggi conflitto, o rivedi commit history.
  Richiedo: comandi passo-passo e best practice."

08_Basi_di_Dati_SQL_NoSQL
- Agente: database-sql-coach
- Template:
  "Contesto: `08_Basi_di_Dati_SQL_NoSQL/<subpath>`.
  Obiettivo: analizza schema/query, suggerisci indici e normalizzazione.
  File chiave: <schema.sql, queries.sql>.
  Richiedo: suggerimenti di ottimizzazione e query riscritte."

09_Programmazione_C_CPP
- Agente: coding-coach-its
- Template:
  "Contesto: `09_Programmazione_C_CPP/<subpath>`.
  Obiettivo: rivedi codice, rileva bug, suggerisci miglioramenti di performance.
  Richiedo: patch o snippet correttivo e test di compilazione."

10_Programmazione_Python
- Agente: coding-coach-its
- Template:
  "Contesto: `10_Programmazione_Python/<subpath>`.
  Obiettivo: implementa funzione X seguendo requisiti Y.
  File chiave: <script.py, requirements.txt>.
  Richiedo: codice completo, test unitari e istruzioni per esecuzione."

11_Programmazione_DotNet_CSharp
- Agente: dotnet-api-tutor
- Template:
  "Contesto: `11_Programmazione_DotNet_CSharp/<subpath>`.
  Obiettivo: rivedi controller/servizio, aggiungi endpoint REST o migliora DI.
  Richiedo: snippet C#, possibili test e comandi `dotnet` per build/run."

12_RESTful_API
- Agente: dotnet-api-tutor / coding-coach-its
- Template:
  "Contesto: `12_RESTful_API/<subpath>`.
  Obiettivo: definisci API spec (OpenAPI) o implementa endpoint.
  Richiedo: spec OpenAPI + esempi di request/response e stub server."

13_Cloud_AWS
- Agente: cloud-lab-tutor
- Template:
  "Contesto: `13_Cloud_AWS/<subpath>`.
  Obiettivo: setup risorse per laboratorio (es. S3, Lambda, IAM) o deploy.
  File chiave: <template CloudFormation/Terraform>.
  Richiedo: passi, costi stimati e comandi AWS CLI."

14_Cloud_Azure
- Agente: cloud-lab-tutor
- Template:
  "Contesto: `14_Cloud_Azure/<subpath>`.
  Obiettivo: eseguire Azure Functions localmente e deploy su App Service.
  File chiave: `requirements.txt`, `host.json`, function app files.
  Richiedo: comandi `func` e check list pre-deploy."

15_Cloud_GCP
- Agente: cloud-lab-tutor
- Template: simile ad AWS ma con comandi `gcloud`, Cloud Run, Compute Engine.

16_Linux_Server_e_Amministrazione
- Agente: linux-sysadmin-lab
- Template:
  "Contesto: `16_Linux_Server_e_Amministrazione/<subpath>`.
  Obiettivo: script di automazione, hardening, o troubleshooting servizio.
  Richiedo: comandi shell, script e checklist di verifica."

17_Container_Docker_Kubernetes
- Agente: cloud-lab-tutor / linux-sysadmin-lab
- Template:
  "Contesto: `17_Container_Docker_Kubernetes/<subpath>`.
  Obiettivo: Dockerfile, compose o manifest K8s e istruzioni per deploy locale.
  Richiedo: file di configurazione e comandi `docker`/`kubectl`."

18_Microsoft_365_SharePoint
- Agente: project-work-mentor
- Template: procedure, guide utente, template documenti SharePoint.

19_Virtualizzazione
- Agente: linux-sysadmin-lab / project-work-mentor
- Template: setup hypervisor, immagini VM, requisiti HW.

20_Data_Analytics_Visualization
- Agente: data-analytics-coach
- Template:
  "Contesto: `20_Data_Analytics_Visualization/<subpath>`.
  Obiettivo: analizza dataset, proponi visualizzazioni e pipeline ETL.
  File chiave: <dataset.csv, notebook.ipynb>.
  Richiedo: notebook con analisi e grafici."

21_Internet_of_Things
- Agente: iot-edge-lab
- Template: scenario IoT, protocolli, formato telemetria, esempi di codice client/server.

22_AI_e_Prompt_Engineering
- Agente: coding-coach-its / Explore
- Template:
  "Contesto: `22_AI_e_Prompt_Engineering/<subpath>`.
  Obiettivo: ottimizza prompt, genera esempi ed esercizi di prompt engineering.
  Richiedo: prompt riformulati e spiegazioni sul perché funzionano."

23_Project_Work_e_Laboratori
- Agente: project-work-mentor
- Template: gestione progetto, roadmap, deliverable e criteri di valutazione.

24_Stage_Professionale
- Agente: project-work-mentor
- Template: preparazione CV/portfolio, lettera di presentazione, checklist stage.

tools/
- Agente: Explore
- Template: "Contesto: `tools/<subpath>`.
  Obiettivo: rivedi script/utilità, documenta l'uso e suggerisci miglioramenti.
  Richiedo: README aggiornato e esempi d'uso."

---

Vuoi che crei anche singoli file template pronti per copia/incolla in ogni cartella (es. `TEMPLATE_PROMPT.md` dentro ogni sottocartella), oppure ti basta questo file centrale?
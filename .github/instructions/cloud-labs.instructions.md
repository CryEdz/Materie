---
description: "Usa queste regole per laboratori cloud e container: AWS, Azure, GCP, Docker, Kubernetes, Terraform."
applyTo:
  - "13_Cloud_AWS/**"
  - "14_Cloud_Azure/**"
  - "15_Cloud_GCP/**"
  - "17_Container_Docker_Kubernetes/**"
---
# Linee guida Cloud Labs

## Principi
- Security by default: minimo privilegio, segreti fuori dal codice, cifratura attiva.
- Cost awareness: scegli risorse minime e spegnimento automatico ove possibile.
- Reproducibilita: preferisci Infrastructure as Code e configurazioni versionate.

## Output richiesto nei task cloud
- Architettura sintetica (componenti e flusso dati).
- Comandi o file necessari per replicare il laboratorio.
- Checklist finale: deploy, test, cleanup risorse.

## Container e Kubernetes
- Immagini piccole, base ufficiali e versioni pin.
- Evita processi root nei container quando possibile.
- Specifica readiness e liveness probe nei manifest.

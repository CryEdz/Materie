# Virtualizzazione Tools

Una guida essenziale e strutturata ai tool e comandi più utilizzati per la virtualizzazione di sistemi e infrastrutture.

## Contenuto

Il repository contiene:

- **`Tool.md`** — Elenco completo di strumenti organizzati per categoria:
  - Hypervisor Tipo 2 (VirtualBox, VMware Workstation/Fusion, Parallels)
  - Hypervisor Tipo 1 (ESXi/vSphere, Hyper-V, Proxmox, KVM/libvirt, XCP-ng)
  - Virtualizzazione a Livello OS (Docker, Podman, LXC/LXD, containerd)
  - Emulatori (QEMU, UTM, Bochs, DOSBox)
  - Gestione e Automazione (Vagrant, Packer, Terraform, Ansible)
  - Formati Immagine e Conversione (qemu-img, virt-sparsify, virt-resize)
  - Networking Virtuale (bridge, NAT, Open vSwitch)
  - Storage Virtuale (thin provisioning, snapshot, pass-through)
  - Cloud e Ibrida (AWS EC2, Azure VM, Google Compute Engine)
  - Strumenti Ausiliari (virt-viewer, virt-top, V2V Converter)

Ogni tool include: nome, descrizione, comando principale, esempio d'uso e note.

## Struttura del file

```markdown
### `nome-tool`
**Descrizione breve.**

- **Comando:** `comando principale`
- **Esempio:** `esempio d'uso`
- **Note:** Note aggiuntive
```

## Requisiti

- **Hypervisor:** VirtualBox (gratuito), VMware, Hyper-V, KVM (a seconda dell'ambiente)
- **Altri strumenti:** Installabili singolarmente (Vagrant, Packer, Terraform, QEMU, ecc.)

## Licenza

MIT

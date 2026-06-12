# Virtualizzazione Tools — Guida Essenziale

Elenco completo dei tool e comandi più utilizzati per la virtualizzazione di sistemi e infrastrutture, organizzati per categoria. Ogni tool include descrizione, comando principale, esempio d'uso e note.

---

## Indice

1. [Hypervisor di Tipo 2 (Hosted)](#1-hypervisor-di-tipo-2-hosted)
2. [Hypervisor di Tipo 1 (Bare Metal)](#2-hypervisor-di-tipo-1-bare-metal)
3. [Virtualizzazione a Livello OS (Container)](#3-virtualizzazione-a-livello-os-container)
4. [Emulatori](#4-emulatori)
5. [Gestione e Automazione](#5-gestione-e-automazione)
6. [Formati Immagine e Conversione](#6-formati-immagine-e-conversione)
7. [Networking Virtuale](#7-networking-virtuale)
8. [Storage Virtuale](#8-storage-virtuale)
9. [Cloud e Ibrida](#9-cloud-e-ibrida)
10. [Strumenti Ausiliari](#10-strumenti-ausiliari)

---

## 1. Hypervisor di Tipo 2 (Hosted)

### VirtualBox
**Hypervisor open-source di Oracle per desktop (Windows, macOS, Linux).**

- **Comando:** `VBoxManage [comando] [opzioni]`
- **Esempio (creazione VM):**
  ```
  VBoxManage createvm --name "UbuntuVM" --ostype Ubuntu_64 --register
  VBoxManage modifyvm "UbuntuVM" --memory 2048 --cpus 2
  VBoxManage createhd --filename "UbuntuVM.vdi" --size 20000
  VBoxManage storagectl "UbuntuVM" --name "SATA" --add sata
  VBoxManage storageattach "UbuntuVM" --storagectl "SATA" --port 0 --device 0 --type hdd --medium "UbuntuVM.vdi"
  VBoxManage startvm "UbuntuVM" --type headless
  ```
- **Comandi utili:**
  - `VBoxManage list vms` — elenca VM
  - `VBoxManage list runningvms` — VM in esecuzione
  - `VBoxManage controlvm <vm> poweroff` — spegne VM
  - `VBoxManage snapshot <vm> take <nome>` — snapshot
  - `VBoxManage clonevm <vm> --name <clone>` — clona VM
- **Guest Additions:** `VBoxManage guestcontrol <vm> run --exe /path/to/VBoxGuestAdditions.iso`

### VMware Workstation / Fusion
**Hypervisor commerciale VMware per desktop (Workstation su Windows/Linux, Fusion su macOS).**

- **CLI:** `vmrun [comando] [opzioni]`
- **Comandi comuni:**
  ```
  vmrun start "path/to/vm.vmx" nogui
  vmrun list
  vmrun stop "path/to/vm.vmx" hard
  vmrun snapshot "path/to/vm.vmx" snap_name
  vmrun revertToSnapshot "path/to/vm.vmx" snap_name
  vmrun clone "path/to/vm.vmx" "path/to/clone.vmx" full -cloneName=CloneVM
  vmrun runProgramInGuest "path/to/vm.vmx" -interactive -activeWindow "/usr/bin/echo" "hello"
  ```

### VMware Player
**Versione gratuita di VMware Workstation per uso personale/istruttivo.**

- **Note:** Interfaccia GUI, CLI limitata rispetto a Workstation
- **Utilizzo:** Aprire file `.vmx` per eseguire VM create con Workstation

### Parallels Desktop
**Hypervisor per macOS con integrazione nativa Apple Silicon.**

- **CLI:** `prlctl [comando] [opzioni]`
- **Esempio:**
  ```
  prlctl create "Ubuntu" --distribution ubuntu --location ./Ubuntu.pvm
  prlctl start "Ubuntu"
  prlctl list -a
  prlctl snapshot "Ubuntu" --name "before-update"
  prlctl stop "Ubuntu" --kill
  ```

---

## 2. Hypervisor di Tipo 1 (Bare Metal)

### VMware ESXi / vSphere
**Hypervisor enterprise bare-metal di VMware.**

- **Gestione:** vSphere Client (GUI web) o `esxcli` (CLI)
- **Comandi esxcli:**
  ```
  esxcli vm process list
  esxcli vm process kill --type=force --world-id=<id>
  esxcli network vm list
  esxcli storage core device list
  esxcli hardware memory get
  ```
- **Note:** vCenter Server per gestione centralizzata di più host ESXi

### Microsoft Hyper-V
**Hypervisor bare-metal integrato in Windows Server e Windows Pro/Enterprise.**

- **Comando (PowerShell):** `Get-Command -Module Hyper-V`
- **Esempi PowerShell:**
  ```powershell
  New-VM -Name "Ubuntu" -MemoryStartupBytes 2GB -BootDevice VHD
  New-VHD -Path "C:\VMs\Ubuntu.vhdx" -SizeBytes 20GB
  Add-VMHardDiskDrive -VMName "Ubuntu" -Path "C:\VMs\Ubuntu.vhdx"
  Start-VM -Name "Ubuntu"
  Get-VM | Where-Object {$_.State -eq "Running"}
  Checkpoint-VM -Name "Ubuntu" -SnapshotName "BeforeUpdate"
  Set-VM -Name "Ubuntu" -ProcessorCount 4 -MemoryStartupBytes 4GB
  ```
- **Gestione:** Hyper-V Manager (GUI) o Windows Admin Center

### Proxmox VE
**Piattaforma open-source per virtualizzazione (KVM + LXC) e storage.**

- **Accesso:** Interfaccia web su `https://<host>:8006`
- **Comandi CLI:**
  ```
  qm create 100 --name ubuntu-vm --memory 2048 --cores 2
  qm start 100
  qm list
  qm snapshot 100 pre-update
  qm rollback 100 pre-update
  qm stop 100
  pct list                   (container LXC)
  pveversion                 (versione Proxmox)
  ```
- **Note:** Cluster nativo, backup integrato, Ceph storage

### KVM (Kernel-based Virtual Machine)
**Hypervisor bare-metal integrato nel kernel Linux.**

- **Gestione:** `virt-manager` (GUI), `virsh` (CLI), `libvirt`
- **Comandi virsh:**
  ```
  virsh list --all
  virsh start ubuntu-vm
  virsh shutdown ubuntu-vm
  virsh snapshot-create-as ubuntu-vm pre-update
  virsh snapshot-list ubuntu-vm
  virsh edit ubuntu-vm
  virsh domiflist ubuntu-vm
  virsh dominfo ubuntu-vm
  ```
- **Note:** Usa `virt-install` per creazione VM da CLI:
  ```
  virt-install --name ubuntu-vm --ram 2048 --vcpus 2 --disk size=20 --cdrom ubuntu.iso --os-variant ubuntu22.04
  ```

### XCP-ng
**Piattaforma hypervisor open-source (fork di Citrix XenServer).**

- **Gestione:** `xe` CLI o Xen Orchestra (web UI)
- **Comandi xe:**
  ```
  xe vm-list
  xe vm-start vm=ubuntu-vm
  xe vm-shutdown vm=ubuntu-vm
  xe snapshot-list vm=ubuntu-vm
  ```
- **Note:** Compatibile con Xen Orchestra per backup, backup continuity

---

## 3. Virtualizzazione a Livello OS (Container)

### Docker
**Piattaforma container per sviluppo, distribuzione ed esecuzione di applicazioni.**

- **Comando:** `docker [comando] [opzioni]`
- **Documentazione completa:** Vedi sezione Docker in `17_Container_Docker_Kubernetes`
- **Esempi base:**
  ```
  docker run -d --name nginx -p 80:80 nginx
  docker pull ubuntu:22.04
  docker build -t myapp .
  docker compose up -d
  ```

### Podman
**Alternativa a Docker senza demone (rootless, supporta pod).**

- **Comando:** `podman [comando] [opzioni]`
- **Esempio:** `podman run -d --name nginx -p 80:80 nginx`
- **Note:** Sintassi compatibile con Docker; supporta Kubernetes YAML generation: `podman generate kube mypod > pod.yaml`

### LXC / LXD
**Container di sistema (virtualizzazione a livello OS) per ambienti completi.**

- **Comando (LXD):** `lxc [comando] [opzioni]`
- **Esempio:**
  ```
  lxc launch ubuntu:22.04 my-container
  lxc list
  lxc exec my-container -- bash
  lxc config set my-container limits.memory 2GB
  lxc snapshot my-container snap1
  lxc stop my-container
  lxc delete my-container
  lxc image list
  ```
- **Note:** LXD fornisce API REST, storage pooling, clustering

### containerd
**Runtime container industriale (usato da Docker e Kubernetes).**

- **CLI:** `ctr` (base) / `nerdctl` (Docker-compatible)
- **Esempio (nerdctl):** `nerdctl run -d --name nginx nginx:alpine`
- **Note:** Runtime predefinito in Kubernetes 1.24+

---

## 4. Emulatori

### QEMU
**Emulatore di processori e macchine completo (supporta KVM per accelerazione).**

- **Comando:** `qemu-system-x86_64 [opzioni]`
- **Esempio (KVM accelerato):**
  ```
  qemu-system-x86_64 -enable-kvm -m 2048 -cpu host -smp 2 \
    -drive file=ubuntu.qcow2,format=qcow2 \
    -netdev user,id=net0 -device e1000,netdev=net0
  ```
- **Opzioni utili:** `-m` (memoria), `-smp` (CPU), `-vnc` (accesso remoto), `-snapshot` (senza scrivere), `-nic` (rete)
- **Formati supportati:** qcow2, raw, vmdk, vhd, vhdx, qed

### QEMU Guest Agent
**Servizio dentro la VM per comunicazione host-guest.**

- **Esempio:**
  ```
  qemu-system-x86_64 ... -device virtio-serial -chardev socket,path=/tmp/qga.sock,server,nowait,id=qga0 -device virtserialport,chardev=qga0,name=org.qemu.guest_agent.0
  ```

### UTM
**QEMU GUI ottimizzato per macOS (Apple Silicon e Intel).**

- **Note:** Interfaccia drag-and-drop, supporto macOS, Windows, Linux guest

### Bochs
**Emulatore x86/x86-64 leggero per debugging di sistemi operativi.**

- **Comando:** `bochs -f bochsrc.txt`

### DOSBox
**Emulatore DOS per esecuzione di vecchi giochi e applicazioni DOS.**

- **Comando:** `dosbox -c "mount c ." -c "c:" -c "dir"`

---

## 5. Gestione e Automazione

### Vagrant
**Tool per creazione e gestione di ambienti di sviluppo virtualizzati (provider: VirtualBox, VMware, Hyper-V, Docker, libvirt).**

- **Comando:** `vagrant [comando]`
- **Esempio:**
  ```
  vagrant init ubuntu/jammy64
  vagrant up
  vagrant ssh
  vagrant halt
  vagrant destroy
  vagrant status
  vagrant snapshot push
  vagrant package --output mybox.box
  ```
- **Vagrantfile:**
  ```ruby
  Vagrant.configure("2") do |config|
    config.vm.box = "ubuntu/jammy64"
    config.vm.network "forwarded_port", guest: 80, host: 8080
    config.vm.provider "virtualbox" do |vb|
      vb.memory = "2048"
      vb.cpus = 2
    end
    config.vm.provision "shell", inline: "apt-get update && apt-get install -y nginx"
  end
  ```

### Packer
**Tool per creazione di immagini macchina identiche per più piattaforme.**

- **Comando:** `packer build [opzioni] template.pkr.hcl`
- **Configurazione (HCL):**
  ```hcl
  source "virtualbox-iso" "ubuntu" {
    iso_url = "ubuntu-22.04.iso"
    ssh_username = "ubuntu"
    shutdown_command = "sudo shutdown -P now"
  }
  build { sources = ["source.virtualbox-iso.ubuntu"] }
  ```
- **Output formati:** VirtualBox (.vdi), VMware (.vmdk), Hyper-V (.vhdx), AWS AMI, GCP, Azure

### Terraform
**Infrastructure as Code per provisioning di risorse (VM, cloud, network).**

- **Comando:** `terraform init && terraform apply`
- **Esempio (vSphere):**
  ```hcl
  resource "vsphere_virtual_machine" "vm" {
    name = "web-server"
    resource_pool_id = data.vsphere_resource_pool.pool.id
    datastore_id = data.vsphere_datastore.datastore.id
    num_cpus = 2
    memory = 2048
    guest_id = "ubuntu64Guest"
    disk { label = "disk0", size = 20 }
    network_interface { network_id = data.vsphere_network.network.id }
  }
  ```

### Ansible
**Automazione configurazione e orchestrazione (agentless, SSH).**

- **Comando:** `ansible-playbook -i inventory playbook.yml`
- **Esempio (provisioning VM):**
  ```yaml
  - hosts: all
    tasks:
      - name: Install nginx
        apt: name=nginx state=present
      - name: Start service
        service: name=nginx state=started enabled=yes
  ```

### SaltStack
**Automazione server e orchestrazione (master/minion o agentless).**

- **Comando:** `salt '*' test.ping`

---

## 6. Formati Immagine e Conversione

### `qemu-img`
**Tool per creazione, conversione e gestione di immagini disco.**

- **Comando:** `qemu-img [comando] [opzioni]`
- **Esempi:**
  ```
  qemu-img create -f qcow2 disk.qcow2 20G
  qemu-img convert -f vmdk -O qcow2 source.vmdk target.qcow2
  qemu-img info disk.qcow2
  qemu-img resize disk.qcow2 +10G
  qemu-img snapshot -l disk.qcow2
  ```
- **Formati:** raw, qcow2, qed, vmdk (VMware), vdi (VirtualBox), vhd/vhdx (Hyper-V), iso

### `VBoxManage clonehd` / `VBoxManage modifyhd`
**Conversione e gestione dischi VirtualBox.**

- **Esempio:**
  ```
  VBoxManage clonehd source.vdi target.vmdk --format VMDK
  VBoxManage modifyhd disk.vdi --resize 30000
  VBoxManage modifymedium disk.vdi --compact
  ```

### `qemu-nbd`
**Monta immagini qcow2 come dispositivi a blocchi (NBD).**

- **Comando:**
  ```
  sudo modprobe nbd max_part=8
  sudo qemu-nbd --connect=/dev/nbd0 disk.qcow2
  sudo mount /dev/nbd0p1 /mnt
  sudo qemu-nbd --disconnect /dev/nbd0
  ```

### `virt-sparsify`
**Riduce la dimensione delle immagini disco (elimina spazio non utilizzato).**

- **Comando:** `virt-sparsify --compress source.qcow2 target.qcow2`

### `virt-resize`
**Ridimensiona immagini disco con filesystem.**

- **Comando:** `virt-resize --expand /dev/sda1 source.qcow2 target.qcow2`

### `virt-rescue`
**Avvia VM in modalità recovery per riparazione filesystem.**

- **Comando:** `virt-rescue -d ubuntu-vm`

---

## 7. Networking Virtuale

### VirtualBox Network Types
**Tipi di rete supportati da VirtualBox:**

- **NAT** — Default, VM condivide IP host
- **Bridged** — VM sulla stessa rete fisica dell'host (IP proprio)
- **Host-Only** — Rete isolata tra host e VM
- **Internal** — Rete isolata tra VM (senza host)
- **NAT Network** — NAT condiviso tra più VM

### `VBoxManage natnetwork`
**Configurazione reti NAT in VirtualBox.**

```
VBoxManage natnetwork add --netname natnet1 --network "192.168.100.0/24" --enable
VBoxManage natnetwork modify --netname natnet1 --dhcp on
VBoxManage natnetwork start --netname natnet1
```

### `virsh net-*`
**Gestione reti virtuali con libvirt.**

- **Esempio:**
  ```
  virsh net-list
  virsh net-start default
  virsh net-edit default
  virsh net-dumpxml default
  ```
- **Configurazione bridge Linux:**
  ```xml
  <network>
    <name>br0</name>
    <forward mode="bridge"/>
    <bridge name="br0"/>
  </network>
  ```

### `ovs-vsctl` (Open vSwitch)
**Switch virtuale programmabile per VM e container.**

- **Comando:** `ovs-vsctl [comando]`
- **Esempio:**
  ```
  ovs-vsctl add-br ovs-br0
  ovs-vsctl add-port ovs-br0 eth0
  ovs-vsctl list-ports ovs-br0
  ovs-vsctl set bridge ovs-br0 stp_enable=true
  ```

### MAC Address Management
**Generazione e modifica indirizzi MAC per VM.**

- **Generazione:** `VBoxManage modifyvm "VM" --macaddress1 080027123456`
- **Random:** `od -An -N6 -tx1 /dev/urandom | sed -e 's/^ *//' -e 's/ */:/g' -e 's/:$//'`

---

## 8. Storage Virtuale

### Tipi di Storage
**Formati di storage virtuali comuni:**

- **RAW** — Copia raw del disco, massime performance
- **qcow2** — QEMU Copy-On-Write (snapshot, compressione, crittografia)
- **VMDK** — VMware Virtual Machine Disk
- **VHD/VHDX** — Microsoft Virtual Hard Disk
- **VDI** — VirtualBox Disk Image

### Storage Thin Provisioning
**Allocazione dinamica dello spazio su disco.**

- **qcow2:** Le allocazioni native sono thin
- **VMDK:** `vmkfstools -c 20G -d thin disk.vmdk`
- **Hyper-V:** `New-VHD -Path disk.vhdx -SizeBytes 20GB -Dynamic`

### Snapshot
**Punto di ripristino per VM.**

- **VirtualBox:** `VBoxManage snapshot <vm> take <nome>`
- **VMware:** `vmrun snapshot "vm.vmx" snap_name`
- **Hyper-V:** `Checkpoint-VM -Name <vm> -SnapshotName <nome>`
- **KVM/QEMU:** `virsh snapshot-create-as <vm> <nome>`
- **Note:** Non sostituiscono i backup; la catena di snapshot degrada le performance

### Storage Pass-Through
**Accesso diretto a dispositivi di storage fisici dalla VM.**

- **VirtualBox:** `VBoxManage storagectl "VM" --name "SATA" --add sata --controller IntelAhci`
- **KVM:** `-device virtio-blk-pci,drive=system -drive file=/dev/sdb,if=none,id=system`

---

## 9. Cloud e Ibrida

### AWS EC2
**Virtualizzazione cloud AWS (istanze, AMI, storage EBS).**

- **Comando (AWS CLI):**
  ```
  aws ec2 run-instances --image-id ami-0c55b159cbfafe1f0 --instance-type t3.medium --key-name my-key --security-group-ids sg-123
  aws ec2 describe-instances
  aws ec2 start-instances --instance-ids i-123
  aws ec2 stop-instances --instance-ids i-123
  ```

### Azure Virtual Machines
**Virtualizzazione cloud Microsoft Azure.**

- **Comando (Azure CLI):**
  ```
  az vm create --resource-group myRG --name myVM --image UbuntuLTS --admin-username azureuser --generate-ssh-keys
  az vm list
  az vm start --resource-group myRG --name myVM
  az vm deallocate --resource-group myRG --name myVM
  ```
- **Azure Migrate:** Tool per migrazione VM on-premise -> Azure

### Google Compute Engine
**Virtualizzazione cloud Google Cloud Platform.**

- **Comando (gcloud):**
  ```
  gcloud compute instances create my-instance --zone=us-east1-b --machine-type=e2-medium --image-family=ubuntu-2204-lts --image-project=ubuntu-os-cloud
  gcloud compute instances list
  gcloud compute instances start my-instance
  gcloud compute instances stop my-instance
  ```

---

## 10. Strumenti Ausiliari

### `virt-viewer`
**Client SPICE/VNC per connessione a console VM.**

- **Comando:** `virt-viewer -c qemu:///system ubuntu-vm`

### `virt-top`
**Monitoraggio risorse VM in tempo reale (stile top per VM).**

- **Comando:** `virt-top`
- **Mostra:** CPU, memoria, storage per ogni VM

### `gnome-boxes`
**Interfaccia GUI GNOME per gestione VM (QEMU/libvirt).**

- **Comando:** `gnome-boxes`
- **Note:** Semplice per utenti desktop

### `xencenter` / `xcp-ng-center`
**Console di amministrazione per XenServer/XCP-ng (Windows).**

- **Note:** Gestione grafica di pool, VM, storage, networking

### `Windows Admin Center`
**Piattaforma di amministrazione browser-based per infrastruttura Windows.**

- **URL:** https://aka.ms/windowsadmincenter
- **Gestione:** Hyper-V, file server, performance monitor, eventi

### `StarWind V2V Converter`
**Conversione di formati immagine tra VirtualBox, VMware, Hyper-V.**

- **Note:** Gratuito, supporta VMDK, VHD/VHDX, QCOW2, RAW

### `Convert-McImage` (PowerShell)
**Script PowerShell per conversione immagini disco.**

- **Esempio:**
  ```powershell
  Convert-VHD -Path source.vhd -DestinationPath target.vhdx -VHDType Dynamic
  ```

### `Win32 Disk Imager`
**Scrittura immagini ISO/IMG su dispositivi USB (utile per boot disk VM).**

- **Comando:** GUI per scrivere immagini su chiavette USB

---

## Licenza

MIT

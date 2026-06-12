# Git Tools — Guida Essenziale

Elenco completo dei comandi Git più utilizzati per il versionamento del codice, organizzati per categoria. Ogni comando include descrizione, sintassi ed esempio d'uso.

---

## Indice

1. [Configurazione](#1-configurazione)
2. [Repository — Creazione e Clonazione](#2-repository--creazione-e-clonazione)
3. [Modifiche e Commit](#3-modifiche-e-commit)
4. [Branch e Merge](#4-branch-e-merge)
5. [Remote e Sincronizzazione](#5-remote-e-sincronizzazione)
6. [Ispezione e Log](#6-ispezione-e-log)
7. [Stash](#7-stash)
8. [Reset e Revert](#8-reset-e-revert)
9. [Tag](#9-tag)
10. [Rebase e Cherry-Pick](#10-rebase-e-cherry-pick)
11. [Submodule](#11-submodule)
12. [Bisect e Debug](#12-bisect-e-debug)
13. [Gitignore e Attributi](#13-gitignore-e-attributi)
14. [Hook](#14-hook)
15. [Worktree](#15-worktree)
16. [Strumenti Ausiliari](#16-strumenti-ausiliari)

---

## 1. Configurazione

### `git config`
**Imposta o visualizza le variabili di configurazione di Git.**

- **Comando:** `git config [opzioni] [chiave] [valore]`
- **Esempio:** `git config --global user.name "Mario Rossi"`
- **Livelli:** `--system` (macchina), `--global` (utente), `--local` (repository)
- **Esempio:** `git config --global user.email mario@example.com`
- **Esempio:** `git config --list` (mostra tutta la configurazione)

### `git config --global core.editor`
**Imposta l'editor predefinito per i messaggi di commit.**

- **Comando:** `git config --global core.editor "code --wait"`
- **Esempio:** `git config --global core.editor "nano"`

### `git config --global alias`
**Crea alias personalizzati per comandi Git frequenti.**

- **Comando:** `git config --global alias.<nome> "<comando>"`
- **Esempio:** `git config --global alias.lg "log --oneline --graph --all --decorate"`

### `git config --global init.defaultBranch`
**Imposta il nome del branch predefinito per `git init`.**

- **Comando:** `git config --global init.defaultBranch main`
- **Esempio:** `git config --global init.defaultBranch main`

---

## 2. Repository — Creazione e Clonazione

### `git init`
**Inizializza un nuovo repository Git in una directory.**

- **Comando:** `git init [opzioni] [directory]`
- **Esempio:** `git init --initial-branch=main my-project`
- **Note:** Crea la directory `.git/` con il database degli oggetti

### `git clone`
**Clona un repository remoto in locale.**

- **Comando:** `git clone [opzioni] <url> [directory]`
- **Esempio:** `git clone --depth 1 https://github.com/user/repo.git`
- **Note:** `--depth 1` (shallow clone, solo ultimo commit), `--branch` (branch specifico)

### `git clone --recurse-submodules`
**Clona il repository e inizializza tutti i submodule.**

- **Comando:** `git clone --recurse-submodules <url>`
- **Esempio:** `git clone --recurse-submodules https://github.com/user/repo.git`

### `git worktree`
**Gestisce più working tree collegati allo stesso repository.**

- **Comando:** `git worktree add <path> <branch>`
- **Esempio:** `git worktree add ../hotfix feature/hotfix`
- **Note:** Utile per lavorare su più branch contemporaneamente

---

## 3. Modifiche e Commit

### `git add`
**Aggiunge modifiche all'area di staging (index) per il prossimo commit.**

- **Comando:** `git add [opzioni] <file|pattern>`
- **Esempio:** `git add -A` (tutte le modifiche, include nuovi file e cancellazioni)
- **Esempio:** `git add src/*.ts` (solo file TypeScript in src/)
- **Esempio:** `git add -p` (interattivo, seleziona singole hunk)

### `git commit`
**Crea un commit con le modifiche presenti nell'area di staging.**

- **Comando:** `git commit [opzioni]`
- **Esempio:** `git commit -m "feat: add login endpoint"` (messaggio inline)
- **Esempio:** `git commit -am "fix: typo in README"` (add + commit per file tracciati)
- **Esempio:** `git commit --amend -m "nuovo messaggio"` (modifica ultimo commit)

### `git restore`
**Ripristina file nell'area di lavoro o nell'index (alternativa moderna a checkout/reset).**

- **Comando:** `git restore [opzioni] <file>`
- **Esempio:** `git restore --staged file.txt` (rimuove da staging ma mantiene modifiche)
- **Esempio:** `git restore file.txt` (annulla modifiche non staged)

### `git mv`
**Sposta o rinomina un file tracciato da Git.**

- **Comando:** `git mv <sorgente> <destinazione>`
- **Esempio:** `git mv README.md docs/README.md`

### `git rm`
**Rimuove un file dal repository e (opzionalmente) dal filesystem.**

- **Comando:** `git rm [opzioni] <file>`
- **Esempio:** `git rm --cached config.local.json` (rimuove dal tracking ma non cancella il file)
- **Esempio:** `git rm -r old-directory/` (rimuove ricorsivamente)

### `git clean`
**Rimuove file non tracciati dalla working directory.**

- **Comando:** `git clean [opzioni]`
- **Esempio:** `git clean -fd` (rimuove file e directory non tracciati)
- **Note:** `-n` (dry-run, mostra cosa verrebbe rimosso)

---

## 4. Branch e Merge

### `git branch`
**Elenca, crea o elimina branch.**

- **Comando:** `git branch [opzioni] [nome]`
- **Esempio:** `git branch feature/login` (crea nuovo branch)
- **Esempio:** `git branch -d feature/login` (cancella branch)
- **Esempio:** `git branch -a` (lista tutti i branch, locali e remoti)
- **Esempio:** `git branch -m vecchio-nome nuovo-nome` (rinomina branch)

### `git switch`
**Cambia branch (alternativa moderna a checkout).**

- **Comando:** `git switch [opzioni] <branch>`
- **Esempio:** `git switch feature/login`
- **Esempio:** `git switch -c new-feature` (crea e passa al nuovo branch)

### `git checkout`
**Cambia branch o ripristina file (comando tradizionale).**

- **Comando:** `git checkout [opzioni] <branch|commit> [-- <file>]`
- **Esempio:** `git checkout main` (passa al branch main)
- **Esempio:** `git checkout -b feature/login` (crea e passa al nuovo branch)
- **Esempio:** `git checkout HEAD~2 -- file.txt` (ripristina file da un commit precedente)

### `git merge`
**Unisce la cronologia di un branch nel branch corrente.**

- **Comando:** `git merge [opzioni] <branch>`
- **Esempio:** `git merge --no-ff feature/login` (merge con commit esplicito)
- **Esempio:** `git merge --squash feature/login` (comprime tutti i commit in uno)
- **Tipi merge:** `--ff` (fast-forward), `--no-ff` (merge commit), `--squash` (squash)

### `git mergetool`
**Avvia uno strumento esterno per risolvere conflitti di merge.**

- **Comando:** `git mergetool [opzioni]`
- **Esempio:** `git mergetool`
- **Note:** Configurabile con `git config merge.tool <tool>`

### `git log --merge`
**Mostra i commit in conflitto durante un merge.**

- **Comando:** `git log --merge`
- **Esempio:** `git log --merge -p`

---

## 5. Remote e Sincronizzazione

### `git remote`
**Gestisce i repository remoti collegati.**

- **Comando:** `git remote [opzioni]`
- **Esempio:** `git remote -v` (mostra URL remoti con dettagli)
- **Esempio:** `git remote add origin https://github.com/user/repo.git`
- **Esempio:** `git remote set-url origin git@github.com:user/repo.git` (cambia URL)

### `git push`
**Carica i commit locali sul repository remoto.**

- **Comando:** `git push [opzioni] <remote> <branch>`
- **Esempio:** `git push origin main`
- **Esempio:** `git push --tags` (carica i tag)
- **Esempio:** `git push -u origin feature/login` (imposta upstream tracking)
- **Esempio:** `git push --force-with-lease origin main` (force push sicuro)

### `git pull`
**Scarica e integra le modifiche dal remoto nel branch corrente.**

- **Comando:** `git pull [opzioni] <remote> <branch>`
- **Esempio:** `git pull origin main`
- **Note:** Equivale a `git fetch` + `git merge`; usare `--rebase` per pull con rebase

### `git fetch`
**Scarica oggetti e riferimenti da un repository remoto senza fare merge.**

- **Comando:** `git fetch [opzioni] <remote>`
- **Esempio:** `git fetch origin`
- **Esempio:** `git fetch --prune` (rimuove riferimenti remoti eliminati)
- **Esempio:** `git fetch origin feature/login:feature/login` (fetch e checkout locale)

### `git remote prune`
**Rimuove i riferimenti a branch remoti che non esistono più.**

- **Comando:** `git remote prune <remote>`
- **Esempio:** `git remote prune origin`

---

## 6. Ispezione e Log

### `git status`
**Mostra lo stato del working tree (modifiche, staging, untracked).**

- **Comando:** `git status [opzioni]`
- **Esempio:** `git status -s` (output breve, una riga per file)

### `git log`
**Mostra la cronologia dei commit.**

- **Comando:** `git log [opzioni] [revisione..revisione]`
- **Esempio:** `git log --oneline --graph --all --decorate` (albero compatto)
- **Esempio:** `git log -p -2` (mostra diff degli ultimi 2 commit)
- **Esempio:** `git log --author="Mario" --since="2024-01-01" --until="2024-12-31"`
- **Esempio:** `git log --grep="fix:"` (cerca nei messaggi di commit)
- **Esempio:** `git log --diff-filter=M -- src/` (solo file modificati)

### `git diff`
**Mostra le differenze tra varie versioni del codice.**

- **Comando:** `git diff [opzioni] [<path>]`
- **Esempio:** `git diff` (modifiche non ancora staged)
- **Esempio:** `git diff --staged` (modifiche staged, pronte per il commit)
- **Esempio:** `git diff main..feature/login` (differenze tra due branch)
- **Esempio:** `git diff HEAD~1 HEAD` (ultima modifica)

### `git show`
**Mostra dettagli di un oggetto Git (commit, tag, albero).**

- **Comando:** `git show [opzioni] [oggetto]`
- **Esempio:** `git show HEAD` (ultimo commit)
- **Esempio:** `git show --stat HEAD` (solo file modificati e statistiche)

### `git blame`
**Mostra chi ha modificato ogni riga di un file e in quale commit.**

- **Comando:** `git blame [opzioni] <file>`
- **Esempio:** `git blame -L 10,30 src/app.ts` (righe 10-30)
- **Esempio:** `git blame -w -C src/app.ts` (ignora spazi, rileva copie)

### `git shortlog`
**Riassume i log raggruppati per autore.**

- **Comando:** `git shortlog [opzioni]`
- **Esempio:** `git shortlog -sn` (numero di commit per autore)

### `git describe`
**Descrive un commit con il tag più vicino più suffisso.**

- **Comando:** `git describe [opzioni] [commit]`
- **Esempio:** `git describe --tags --abbrev=0` (ultimo tag)

### `git count-objects`
**Mostra statistiche sul database degli oggetti Git.**

- **Comando:** `git count-objects [opzioni]`
- **Esempio:** `git count-objects -v`

---

## 7. Stash

### `git stash`
**Salva temporaneamente le modifiche non committate e ripulisce il working tree.**

- **Comando:** `git stash [opzioni]`
- **Esempio:** `git stash push -m "WIP: refactoring in corso"`
- **Esempio:** `git stash -u` (include file non tracciati)

### `git stash list`
**Elenca gli stash salvati.**

- **Comando:** `git stash list [opzioni]`
- **Esempio:** `git stash list --format="%gd - %gs"`

### `git stash apply`
**Applica uno stash senza rimuoverlo dalla lista.**

- **Comando:** `git stash apply [opzioni] [stash@{n}]`
- **Esempio:** `git stash apply stash@{1}`

### `git stash pop`
**Applica lo stash più recente e lo rimuove dalla lista.**

- **Comando:** `git stash pop [opzioni] [stash@{n}]`
- **Esempio:** `git stash pop`

### `git stash drop`
**Rimuove uno stash dalla lista.**

- **Comando:** `git stash drop [stash@{n}]`
- **Esempio:** `git stash drop stash@{0}`

### `git stash clear`
**Rimuove tutti gli stash.**

- **Comando:** `git stash clear`
- **Esempio:** `git stash clear`

### `git stash branch`
**Crea un branch a partire da uno stash.**

- **Comando:** `git stash branch <nome_branch> [stash@{n}]`
- **Esempio:** `git stash branch feature/stash-recovery stash@{0}`

---

## 8. Reset e Revert

### `git reset`
**Resetta l'HEAD e/o l'area di staging a uno stato precedente.**

- **Comando:** `git reset [opzioni] [commit] [-- <file>]`
- **Esempio:** `git reset --soft HEAD~1` (annulla commit, lascia modifiche staged)
- **Esempio:** `git reset --mixed HEAD~1` (default: annulla commit e staging)
- **Esempio:** `git reset --hard HEAD~1` (annulla commit e modifiche)
- **Esempio:** `git reset HEAD -- file.txt` (unstage file)

### `git revert`
**Crea un nuovo commit che annulla le modifiche di un commit specifico.**

- **Comando:** `git revert [opzioni] <commit>`
- **Esempio:** `git revert --no-edit HEAD` (annulla ultimo commit)
- **Esempio:** `git revert -m 1 <merge-commit>` (revert di un merge commit)

### `git checkout -- <file>`
**Annulla le modifiche locali a un file (ripristina all'ultimo commit).**

- **Comando:** `git checkout -- <file>`
- **Esempio:** `git checkout -- src/config.ts`

---

## 9. Tag

### `git tag`
**Crea, elenca o elimina tag (annotati o leggeri).**

- **Comando:** `git tag [opzioni] [<nome>] [<commit>]`
- **Esempio:** `git tag -a v1.0.0 -m "Release 1.0.0"` (tag annotato)
- **Esempio:** `git tag -d v1.0.0-beta` (elimina tag locale)
- **Esempio:** `git tag --list "v2.*"` (filtra tag con pattern)

### `git push --tags`
**Carica i tag sul repository remoto.**

- **Comando:** `git push origin --tags`
- **Esempio:** `git push origin v1.0.0` (singolo tag)

### `git push --delete origin <tag>`
**Elimina un tag remoto.**

- **Comando:** `git push --delete origin <tag>`
- **Esempio:** `git push --delete origin v1.0.0-beta`

---

## 10. Rebase e Cherry-Pick

### `git rebase`
**Riapplica i commit del branch corrente su un altro commit base.**

- **Comando:** `git rebase [opzioni] <nuova-base>`
- **Esempio:** `git rebase main` (riapplica i commit feature su main)
- **Esempio:** `git rebase -i HEAD~3` (interactive: squash, reword, reorder)
- **Esempio:** `git rebase --onto main feature/base feature/new`
- **Note:** Riscrive la cronologia; non usare su branch pubblici

### `git rebase --abort` / `--continue` / `--skip`
**Gestisce un rebase in corso.**

- **Comando:** `git rebase --abort` (annulla), `--continue` (prosegue), `--skip` (salta conflitto)
- **Esempio:** `git rebase --continue` (dopo aver risolto un conflitto)

### `git cherry-pick`
**Applica uno o più commit specifici sul branch corrente.**

- **Comando:** `git cherry-pick [opzioni] <commit> [<commit>...]`
- **Esempio:** `git cherry-pick abc123 def456` (applica due commit)
- **Esempio:** `git cherry-pick -n abc123` (senza creare commit automaticamente)

### `git cherry`
**Mostra i commit presenti in un branch ma non in un altro.**

- **Comando:** `git cherry [opzioni] <upstream> [<head>]`
- **Esempio:** `git cherry main feature/login`

---

## 11. Submodule

### `git submodule add`
**Aggiunge un submodule al repository corrente.**

- **Comando:** `git submodule add [opzioni] <url> [<path>]`
- **Esempio:** `git submodule add https://github.com/user/lib.git libs/shared`

### `git submodule update`
**Aggiorna i submodule allo stato registrato nel superprogetto.**

- **Comando:** `git submodule update [opzioni] [--recursive]`
- **Esempio:** `git submodule update --init --recursive`
- **Note:** `--remote` (aggiorna all'ultimo commit del branch remoto)

### `git submodule foreach`
**Esegue un comando in ogni submodule.**

- **Comando:** `git submodule foreach <comando>`
- **Esempio:** `git submodule foreach git checkout main`

### `git submodule status`
**Mostra lo stato di ogni submodule (commit corrente).**

- **Comando:** `git submodule status [opzioni]`
- **Esempio:** `git submodule status --recursive`

---

## 12. Bisect e Debug

### `git bisect`
**Ricerca binaria per trovare il commit che ha introdotto un bug.**

- **Comando:** `git bisect start [<buono> <cattivo>]`
- **Esempio:**
  ```
  git bisect start HEAD v1.0.0
  git bisect bad              # commit corrente è cattivo
  git bisect good             # v1.0.0 è buono
  git bisect good/bad         # continua fino a trovare il commit colpevole
  git bisect reset            # termina la sessione
  ```
- **Note:** `git bisect run <script>` per automazione completa

### `git grep`
**Cerca pattern nel repository (più veloce di grep su filesystem).**

- **Comando:** `git grep [opzioni] <pattern> [<percorso>]`
- **Esempio:** `git grep -n "TODO" -- src/`
- **Esempio:** `git grep --count "function" v1.0.0`

### `git rev-parse`
**Converte un riferimento (branch, tag, HEAD~n) in hash SHA.**

- **Comando:** `git rev-parse [opzioni] <riferimento>`
- **Esempio:** `git rev-parse HEAD`
- **Esempio:** `git rev-parse --short HEAD` (abbreviazione)

### `git reflog`
**Mostra la cronologia degli spostamenti di HEAD (riferimenti locali).**

- **Comando:** `git reflog [opzioni]`
- **Esempio:** `git reflog --date=iso`
- **Note:** Salva i movimenti di HEAD anche dopo reset/amend

### `git fsck`
**Verifica l'integrità del database degli oggetti Git.**

- **Comando:** `git fsck [opzioni]`
- **Esempio:** `git fsck --full --no-dangling`

### `git gc`
**Pulisce e ottimizza il repository (garbage collection).**

- **Comando:** `git gc [opzioni]`
- **Esempio:** `git gc --aggressive --prune=now`

---

## 13. Gitignore e Attributi

### `.gitignore`
**File che specifica pattern di file da ignorare (non tracciare).**

- **Pattern:**
  ```
  node_modules/
  *.log
  .env
  build/
  !important.log
  ```
- **Note:** I file già tracciati non sono influenzati dal .gitignore

### `git check-ignore`
**Verifica se un file è ignorato dalle regole .gitignore.**

- **Comando:** `git check-ignore [opzioni] <file>`
- **Esempio:** `git check-ignore -v .env`

### `git update-index --skip-worktree`
**Ignora modifiche locali a un file tracciato (non committa le modifiche).**

- **Comando:** `git update-index --skip-worktree <file>`
- **Esempio:** `git update-index --skip-worktree config.json`
- **Note:** Utile per file di configurazione locali

### `git update-index --assume-unchanged`
**Dichiara a Git che un file tracciato non è cambiato (per performance).**

- **Comando:** `git update-index --assume-unchanged <file>`
- **Esempio:** `git update-index --assume-unchanged large-file.bin`

### `.gitattributes`
**File che definisce attributi per file (normalizzazione EOL, diff, LFS).**

- **Contenuto tipico:**
  ```
  *.txt text
  *.png binary
  *.sh text eol=lf
  *.ps1 text eol=crlf
  ```

---

## 14. Hook

### `git hooks`
**Script automatici in `.git/hooks/` eseguiti su eventi Git.**

- **Hook disponibili:**
  - `pre-commit` — prima del commit (lint, test)
  - `prepare-commit-msg` — modifica messaggio di commit
  - `commit-msg` — valida messaggio di commit
  - `post-commit` — dopo il commit (notifiche)
  - `pre-push` — prima del push (test, build)
  - `pre-rebase` — prima del rebase
  - `post-merge` — dopo il merge
  - `pre-auto-gc` — prima della garbage collection

### `git config core.hooksPath`
**Cambia la directory degli hook (per hook condivisi nel repository).**

- **Comando:** `git config core.hooksPath .githooks`
- **Esempio:** `git config core.hooksPath .githooks`
- **Note:** Utile per versionare gli hook con il codice

---

## 15. Worktree

### `git worktree add`
**Aggiunge un nuovo working tree collegato al repository.**

- **Comando:** `git worktree add <path> [<branch>]`
- **Esempio:** `git worktree add ../hotfix feature/hotfix`
- **Note:** I worktree condividono lo stesso database degli oggetti

### `git worktree list`
**Elenca i worktree associati al repository.**

- **Comando:** `git worktree list`
- **Esempio:** `git worktree list --porcelain`

### `git worktree remove`
**Rimuove un worktree.**

- **Comando:** `git worktree remove <path>`
- **Esempio:** `git worktree remove ../hotfix`
- **Note:** `--force` per forzare la rimozione anche con modifiche

### `git worktree lock` / `git worktree unlock`
**Blocca/sblocca un worktree per prevenire la rimozione accidentale.**

- **Comando:** `git worktree lock <path> [--reason <motivo>]`
- **Esempio:** `git worktree lock ../hotfix --reason "in uso da altro terminale"`

---

## 16. Strumenti Ausiliari

### `gh` (GitHub CLI)
**Interfaccia a riga di comando per GitHub (issue, PR, repo, azioni).**

- **Comando:** `gh <comando> [opzioni]`
- **Esempio:** `gh pr create --title "feat: add login" --body "Descrizione"`
- **Esempio:** `gh issue list --label bug`
- **Esempio:** `gh repo clone user/repo`

### `hub`
**Estensione di Git per integrazione con GitHub (predecessore di gh).**

- **Comando:** `hub <comando> [opzioni]`
- **Esempio:** `hub pull-request`
- **Note:** Può essere usato come alias: `git config --global alias.pr 'hub pull-request'`

### `git-lfs` (Large File Storage)
**Gestione di file grandi con Git usando puntatori e storage esterno.**

- **Comando:** `git lfs <comando> [opzioni]`
- **Esempio:** `git lfs track "*.psd"` (traccia file Photoshop)
- **Esempio:** `git lfs migrate import --everything --include="*.zip"`

### `tig`
**Interfaccia testuale per Git (TUI per log, diff, blame).**

- **Comando:** `tig [opzioni] [percorso]`
- **Esempio:** `tig` (cronologia interattiva)
- **Esempio:** `tig blame src/app.ts`

### `lazygit`
**Interfaccia TUI moderna per Git con gestione di staging, branch, commit.**

- **Comando:** `lazygit`
- **Esempio:** `lazygit`
- **Note:** Gestione con tasti e menu intuitivi

### `git-extras`
**Estensioni Git per comandi di alto livello (changelog, effort, contrib).**

- **Comando:** `git <comando-extra>`
- **Esempio:** `git changelog` (genera changelog)
- **Esempio:** `git effort` (mostra sforzo per file)
- **Esempio:** `git contrib` (contributi degli autori)

### `diff-so-fancy`
**Miglioramento visivo per output di `git diff`.**

- **Comando:** `git diff | diff-so-fancy`
- **Installazione:** `npm install -g diff-so-fancy`
- **Configurazione:** `git config --global core.pager "diff-so-fancy | less --tabs=4 -RFX"`

### `git-flow`
**Estensione per workflow Git con branch model (feature, release, hotfix).**

- **Comando:** `git flow <comando> [opzioni]`
- **Esempio:** `git flow feature start login`
- **Esempio:** `git flow release finish v1.0.0`
- **Note:** Definisce convenzioni per nome branch e merge

### `pre-commit`
**Framework per la gestione di hook Git pre-commit condivisi.**

- **Comando:** `pre-commit install && pre-commit run --all-files`
- **Configurazione:** File `.pre-commit-config.yaml`
- **Esempio:**
  ```yaml
  repos:
    - repo: https://github.com/pre-commit/pre-commit-hooks
      rev: v4.5.0
      hooks:
        - id: trailing-whitespace
        - id: end-of-file-fixer
        - id: check-yaml
  ```

---

## Licenza

MIT

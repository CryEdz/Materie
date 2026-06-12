# Python Tools — Guida Essenziale

Elenco completo dei tool e comandi più utilizzati per la programmazione in Python, organizzati per categoria. Ogni tool include descrizione, comando principale, esempio d'uso e note.

---

## Indice

1. [Interprete e REPL](#1-interprete-e-repl)
2. [Gestione Pacchetti e Ambienti Virtuali](#2-gestione-pacchetti-e-ambienti-virtuali)
3. [Debugger](#3-debugger)
4. [Linter e Formattatori](#4-linter-e-formattatori)
5. [Type Checker](#5-type-checker)
6. [Testing](#6-testing)
7. [Profiling e Performance](#7-profiling-e-performance)
8. [Documentazione](#8-documentazione)
9. [Build e Distribuzione](#9-build-e-distribuzione)
10. [Web e API](#10-web-e-api)
11. [Data Science e Analisi](#11-data-science-e-analisi)
12. [Strumenti Ausiliari](#12-strumenti-ausiliari)

---

## 1. Interprete e REPL

### `python` / `python3`
**Interprete Python standard.**

- **Comando:** `python [opzioni] [file] [args]`
- **Esempio:** `python -c "print('Hello, World!')"` (comando inline)
- **Esempio:** `python -m http.server 8080` (server HTTP semplice)
- **Esempio:** `python -i script.py` (esegue poi entra in REPL)

### `ipython`
**REPL interattivo avanzato con completamento tab, syntax highlighting, magic commands.**

- **Comando:** `ipython [opzioni]`
- **Esempio:** `ipython --matplotlib` (con supporto grafico inline)
- **Magic commands:**
  - `%timeit` — misura tempo esecuzione
  - `%debug` — post-mortem debug
  - `%run script.py` — esegue script
  - `%who` — variabili definite

### `ptpython`
**REPL migliorato con suggerimenti, completamento fuzzy e menu.**

- **Comando:** `ptpython`
- **Installazione:** `pip install ptpython`

### `bpython`
**REPL interattivo con ispezione delle funzioni e autocomplete.**

- **Comando:** `bpython`
- **Installazione:** `pip install bpython`

---

## 2. Gestione Pacchetti e Ambienti Virtuali

### `pip`
**Package manager ufficiale di Python.**

- **Comando:** `pip [comando] [opzioni]`
- **Esempio:** `pip install requests==2.31.0`
- **Esempio:** `pip install -r requirements.txt`
- **Esempio:** `pip list --outdated` (pacchetti con versioni più recenti)
- **Esempio:** `pip freeze > requirements.txt`
- **Esempio:** `pip cache purge` (pulisce cache)

### `venv`
**Ambiente virtuale integrato (standard library).**

- **Comando:** `python -m venv <directory>`
- **Esempio:**
  ```
  python -m venv .venv
  .venv\Scripts\activate   (Windows)
  source .venv/bin/activate (Unix)
  ```

### `virtualenv`
**Alternativa più flessibile a venv (supporta Python versioni multiple).**

- **Comando:** `virtualenv [opzioni] <directory>`
- **Esempio:** `virtualenv -p python3.12 .venv`

### `pipenv`
**Gestione dipendenze e ambienti integrata (Pipfile + Pipfile.lock).**

- **Comando:** `pipenv [comando]`
- **Esempio:** `pipenv install requests && pipenv shell`
- **Note:** Genera automaticamente `Pipfile.lock` per riproducibilità

### `poetry`
**Gestione dipendenze, build e pubblicazione moderna (pyproject.toml).**

- **Comando:** `poetry [comando]`
- **Esempio:**
  ```
  poetry new my-project
  poetry add requests
  poetry run python main.py
  poetry build
  poetry publish
  ```
- **Note:** Blocca le versioni in `poetry.lock`

### `conda`
**Package manager multi-linguaggio (Anaconda/Miniforge).**

- **Comando:** `conda [comando]`
- **Esempio:** `conda create -n myenv python=3.12 numpy pandas`
- **Esempio:** `conda install -c conda-forge opencv`

### `uv`
**Package manager Python estremamente veloce (Rust-based).**

- **Comando:** `uv [comando]`
- **Esempio:** `uv pip install requests`
- **Esempio:** `uv venv && uv pip sync requirements.txt`
- **Note:** Compatibile con requirements.txt e pyproject.toml

### `pipx`
**Esecuzione di applicazioni Python in ambienti isolati.**

- **Comando:** `pipx install <pacchetto>`
- **Esempio:** `pipx install black poetry pytest`
- **Note:** I pacchetti installati sono disponibili globalmente senza conflitti

---

## 3. Debugger

### `pdb`
**Debugger integrato (standard library).**

- **Comando:** `python -m pdb script.py`
- **Esempio (punto di arresto nel codice):**
  ```python
  import pdb; pdb.set_trace()
  ```
- **Python 3.7+:** `breakpoint()` (built-in, richiama pdb di default)

### `ipdb`
**Debugger con interfaccia IPython (autocomplete, syntax highlight).**

- **Comando:** `ipdb script.py`
- **Esempio:** `import ipdb; ipdb.set_trace()`

### `pdb++`
**Drop-in replacement per pdb con interfaccia migliorata.**

- **Comando:** `python -m pdbpp script.py`
- **Installazione:** `pip install pdbpp`

### `debugpy`
**Debugger per Visual Studio Code (protocollo DAP).**

- **Comando:** `python -m debugpy --listen 5678 --wait-for-client script.py`
- **Note:** Usato da VS Code per debugging remoto

### `PuDB`
**Debugger TUI con interfaccia a schermo intero.**

- **Comando:** `python -m pudb script.py`
- **Installazione:** `pip install pudb`

---

## 4. Linter e Formattatori

### `pylint`
**Linter completo con analisi statica, stile e convenzioni.**

- **Comando:** `pylint [opzioni] <file|modulo>`
- **Esempio:** `pylint --max-line-length=120 src/`
- **Note:** Configurazione in `.pylintrc` o `pyproject.toml`

### `flake8`
**Linter veloce che combina pycodestyle, pyflakes e McCabe.**

- **Comando:** `flake8 [opzioni] <file|directory>`
- **Esempio:** `flake8 --max-complexity=10 src/`

### `ruff`
**Linter estremamente veloce scritto in Rust (compatibile con flake8).**

- **Comando:** `ruff [comando] [opzioni]`
- **Esempio:** `ruff check src/ --fix`
- **Esempio:** `ruff format src/` (formatta codice)
- **Note:** Supporta centinaia di regole con correzione automatica

### `black`
**Formattatore automatico di codice "opinionato" (zero configurazione).**

- **Comando:** `black [opzioni] <file|directory>`
- **Esempio:** `black --line-length 100 src/`
- **Note:** Formatta in-place; supporto pyproject.toml

### `autopep8`
**Formattatore automatico basato su pycodestyle.**

- **Comando:** `autopep8 [opzioni] <file>`
- **Esempio:** `autopep8 --in-place --aggressive --max-line-length 120 script.py`

### `yapf`
**Formattatore configurabile di Google (supporta vari stili).**

- **Comando:** `yapf [opzioni] <file>`
- **Esempio:** `yapf --style='{based_on_style: google, column_limit: 120}' -i script.py`

### `isort`
**Ordina automaticamente gli import in base a standard PEP8.**

- **Comando:** `isort [opzioni] <file|directory>`
- **Esempio:** `isort --profile black src/` (compatibile con Black)

### `bandit`
**Scanner di sicurezza per codice Python.**

- **Comando:** `bandit [opzioni] <file|directory>`
- **Esempio:** `bandit -r src/ --severity-level high`

---

## 5. Type Checker

### `mypy`
**Type checker statico per Python (PEP 484).**

- **Comando:** `mypy [opzioni] <file|directory>`
- **Esempio:** `mypy --strict src/`
- **Note:** Supporta `pyproject.toml` per configurazione

### `pyright`
**Type checker veloce di Microsoft (usato da Pylance in VS Code).**

- **Comando:** `pyright [opzioni] <file|directory>`
- **Esempio:** `pyright src/`

### `pyre` (Pyre)
**Type checker di Meta (Instagram) per codebase grandi.**

- **Comando:** `pyre check`
- **Esempio:** `pyre --source-directory src/ check`

### `pydantic`
**Data validation usando type hints (non un type checker, ma strettamente correlato).**

- **Esempio:**
  ```python
  from pydantic import BaseModel
  class User(BaseModel):
      name: str
      age: int
  ```

---

## 6. Testing

### `unittest`
**Framework di testing integrato.**

- **Comando:** `python -m unittest discover -s tests/ -v`
- **Esempio:**
  ```python
  import unittest
  class TestMath(unittest.TestCase):
      def test_add(self):
          self.assertEqual(add(2, 3), 5)
  ```

### `pytest`
**Framework testing moderno e flessibile.**

- **Comando:** `pytest [opzioni] [file|directory]`
- **Esempio:** `pytest -v --cov=src/ tests/`
- **Esempio:** `pytest -x --pdb` (ferma al primo fallimento e apre debugger)
- **Caratteristiche:**
  - Fixture, parametrizzazione, markers, plugin
  - `pytest-cov` per code coverage
  - `pytest-mock` per mocking

### `doctest`
**Test embedded nei docstring.**

- **Comando:** `python -m doctest -v script.py`
- **Esempio:**
  ```python
  def add(a, b):
      """
      >>> add(2, 3)
      5
      """
      return a + b
  ```

### `tox`
**Esecuzione di test in ambienti multipli (Python versioni diverse).**

- **Comando:** `tox [opzioni]`
- **Configurazione (tox.ini):**
  ```ini
  [tox]
  envlist = py39, py310, py311
  [testenv]
  deps = pytest
  commands = pytest tests/
  ```

### `nox`
**Alternativa moderna a tox con configurazione Python.**

- **Comando:** `nox [opzioni]`
- **Configurazione (noxfile.py):**
  ```python
  import nox
  @nox.session(python=["3.9", "3.10", "3.11"])
  def tests(session):
      session.install("pytest")
      session.run("pytest")
  ```

### `coverage`
**Misurazione della copertura del codice.**

- **Comando:** `coverage run -m pytest && coverage report -m`
- **Esempio:** `coverage html` (genera report HTML)
- **Note:** Integrato con pytest (`--cov=`)

---

## 7. Profiling e Performance

### `cProfile`
**Profiler integrato (tempo speso per funzione).**

- **Comando:** `python -m cProfile -s cumulative script.py`
- **Analisi:** `python -m pstats profilo.prof`

### `profile`
**Profiler puro Python (più lento ma estensibile).**

- **Comando:** `python -m profile script.py`

### `line_profiler`
**Profiler riga per riga (tempo per ogni linea).**

- **Comando:** `kernprof -l -v script.py`
- **Esempio:**
  ```python
  @profile
  def funzione_lenta():
      ...
  ```

### `memory_profiler`
**Analisi dell'uso della memoria riga per riga.**

- **Comando:** `python -m memory_profiler script.py`
- **Esempio:**
  ```python
  from memory_profiler import profile
  @profile
  def funzione():
      ...
  ```

### `py-spy`
**Profiler per programmi Python in esecuzione senza modificarli (Sampling).**

- **Comando:** `py-spy record -o profile.svg -- python script.py`
- **Esempio:** `py-spy top --pid 1234` (monitoraggio live)

### `scalene`
**Profiler ad alta performance (CPU, memoria, GPU).**

- **Comando:** `scalene --html --outfile profile.html script.py`
- **Note:** Profila senza modificare il codice

### `snakeviz`
**Visualizzatore interattivo per profiler cProfile.**

- **Comando:** `snakeviz profilo.prof`

### `timeit`
**Misurazione precisa del tempo di esecuzione di piccoli snippet.**

- **Comando:** `python -m timeit -n 1000 -s "import module" "module.function()"`
- **Esempio:** `python -m timeit "'-'.join(str(n) for n in range(100))"`

---

## 8. Documentazione

### `pydoc`
**Generatore di documentazione integrato.**

- **Comando:** `python -m pydoc -p 8080` (server HTTP locale)
- **Esempio:** `python -m pydoc module` (documentazione nel terminale)

### `Sphinx`
**Generatore di documentazione potente (reStructuredText e Markdown).**

- **Comando:**
  ```
  sphinx-quickstart docs/
  sphinx-build -b html docs/ docs/_build/
  ```
- **Estensioni:** `autodoc` (da docstring), `napoleon` (Google/NumPy style), `myst` (Markdown)

### `MkDocs`
**Documentazione veloce da file Markdown.**

- **Comando:** `mkdocs serve` (live-reload) && `mkdocs build`
- **Configurazione:** `mkdocs.yml`
- **Temi:** Material for MkDocs (molto popolare)

### `pdoc`
**Generatore di documentazione API minimale da docstring.**

- **Comando:** `pdoc -o docs/ --html src/module.py`

---

## 9. Build e Distribuzione

### `setuptools`
**Tool di build e distribuzione standard.**

- **Configurazione:** `setup.py` o `setup.cfg`
- **Comando:** `python setup.py sdist bdist_wheel`

### `wheel`
**Formato di distribuzione binaria per Python.**

- **Comando:** `pip wheel --no-deps .`
- **Note:** Formato `.whl`, installazione veloce

### `build`
**Builder moderno (PEP 517) — alternativa a setup.py.**

- **Comando:** `python -m build`
- **Esempio:** `python -m build --wheel`

### `twine`
**Caricamento pacchetti su PyPI.**

- **Comando:** `twine upload --repository pypi dist/*`
- **Esempio:** `twine upload --repository testpypi dist/*`

### `flit`
**Packaging semplificato con pyproject.toml (senza setup.py).**

- **Comando:** `flit build && flit publish`

---

## 10. Web e API

### `http.server`
**Server HTTP semplice integrato (per sviluppo/test).**

- **Comando:** `python -m http.server 8080 --directory public/`

### `pip` per framework web
**Framework Python per applicazioni web.**

- **Esempio (Flask):** `pip install flask`
- **Esempio (FastAPI):** `pip install fastapi uvicorn`
- **Esempio (Django):** `pip install django`
- **Avvio veloce:**
  ```
  # FastAPI
  uvicorn main:app --reload

  # Flask
  flask --app app.py run --debug
  ```

### `httpx`
**Client HTTP moderno per Python (async support).**

- **Comando:** `pip install httpx`
- **Esempio:**
  ```python
  import httpx
  resp = httpx.get("https://api.example.com/data")
  ```

### `requests`
**Client HTTP semplice e popolare.**

- **Comando:** `pip install requests`
- **Esempio:**
  ```python
  import requests
  resp = requests.get("https://api.example.com/data")
  ```

---

## 11. Data Science e Analisi

### `jupyter`
**Notebook interattivo per analisi dati e visualizzazione.**

- **Comando:** `jupyter notebook` o `jupyter lab`
- **Esempio:** `jupyter lab --port 8888 --no-browser`
- **Estensioni:** `ipywidgets`, `jupyter-black`, `jupyter-tabnine`

### `numpy`
**Libreria per calcolo numerico e array multidimensionali.**

- **Installazione:** `pip install numpy`
- **Esempio:**
  ```python
  import numpy as np
  arr = np.array([[1, 2], [3, 4]])
  arr.mean(), arr.sum(axis=1)
  ```

### `pandas`
**Manipolazione e analisi di dati tabellari (DataFrame).**

- **Installazione:** `pip install pandas`
- **Esempio:**
  ```python
  import pandas as pd
  df = pd.read_csv("dati.csv")
  df.groupby("categoria")["valore"].mean()
  ```

### `matplotlib`
**Libreria per grafici e visualizzazioni 2D.**

- **Installazione:** `pip install matplotlib`
- **Esempio:**
  ```python
  import matplotlib.pyplot as plt
  plt.plot([1, 2, 3], [1, 4, 9])
  plt.savefig("grafico.png")
  ```

### `seaborn`
**Visualizzazione statistica basata su matplotlib (temi migliorati).**

- **Installazione:** `pip install seaborn`
- **Esempio:**
  ```python
  import seaborn as sns
  sns.boxplot(data=df, x="categoria", y="valore")
  ```

### `plotly`
**Grafici interattivi per web e notebook.**

- **Installazione:** `pip install plotly`
- **Esempio:**
  ```python
  import plotly.express as px
  px.scatter(df, x="x", y="y", color="categoria")
  ```

### `scikit-learn`
**Machine learning classico (classificazione, regressione, clustering).**

- **Installazione:** `pip install scikit-learn`
- **Esempio:**
  ```python
  from sklearn.ensemble import RandomForestClassifier
  model = RandomForestClassifier().fit(X_train, y_train)
  ```

---

## 12. Strumenti Ausiliari

### `pipdeptree`
**Mostra l'albero delle dipendenze dei pacchetti.**

- **Comando:** `pipdeptree --graph-output png > dependencies.png`

### `json.tool`
**Formattatore e validatore JSON integrato.**

- **Comando:** `python -m json.tool file.json`
- **Esempio:** `echo '{"name": "test"}' | python -m json.tool`

### `sqlite3` CLI
**Client SQLite integrato per database Python.**

- **Comando:** `python -m sqlite3 database.db "SELECT * FROM table"`

### `tokenize`
**Tokenizzatore Python integrato.**

- **Comando:** `python -m tokenize script.py`

### `ast`
**Analisi dell'albero sintattico astratto.**

- **Comando:** `python -m ast script.py` (mostra AST)

### `dis`
**Disassemblatore bytecode Python.**

- **Comando:** `python -m dis script.py`

### `virtualenvwrapper`
**Estensioni per gestione ambienti virtuali (workon, mkvirtualenv).**

- **Comando:** `workon myenv` && `mkvirtualenv -p python3.12 newenv`

### `autoenv`
**Attivazione automatica dell'ambiente virtuale entrando in directory.**

- **Note:** Usa file `.env` nella directory del progetto

---

## Licenza

MIT

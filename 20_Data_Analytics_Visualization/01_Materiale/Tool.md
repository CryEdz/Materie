# Data Analytics & Visualization Tools — Guida Essenziale

Elenco completo dei tool e comandi più utilizzati per analisi dati, visualizzazione e data science, organizzati per categoria. Ogni tool include descrizione, comando principale, esempio d'uso e note.

---

## Indice

1. [Librerie Python per Analisi Dati](#1-librerie-python-per-analisi-dati)
2. [Librerie Python per Visualizzazione](#2-librerie-python-per-visualizzazione)
3. [Notebook e Ambienti Interattivi](#3-notebook-e-ambienti-interattivi)
4. [Machine Learning](#4-machine-learning)
5. [Business Intelligence](#5-business-intelligence)
6. [Database Analitici](#6-database-analitici)
7. [ETL e Data Pipeline](#7-etl-e-data-pipeline)
8. [Time Series e Streaming](#8-time-series-e-streaming)
9. [Statistical Computing](#9-statistical-computing)
10. [Strumenti Ausiliari](#10-strumenti-ausiliari)

---

## 1. Librerie Python per Analisi Dati

### `pandas`
**Libreria per manipolazione e analisi di dati tabellari (DataFrame).**

- **Installazione:** `pip install pandas`
- **Esempio:**
  ```python
  import pandas as pd
  df = pd.read_csv("vendite.csv")
  df.groupby("prodotto")["ricavo"].sum().sort_values(ascending=False)
  df.isnull().sum()                        # valori mancanti
  df.describe()                            # statistiche descrittive
  df.pivot_table(index="regione", columns="anno", values="ricavo", aggfunc="sum")
  ```
- **Operazioni chiave:**
  - `merge()`, `concat()`, `join()` — combinazione dati
  - `groupby()`, `pivot_table()`, `crosstab()` — aggregazioni
  - `apply()`, `map()`, `transform()` — trasformazioni
  - `to_csv()`, `to_excel()`, `to_sql()` — export

### `numpy`
**Libreria per calcolo numerico e array multidimensionali.**

- **Installazione:** `pip install numpy`
- **Esempio:**
  ```python
  import numpy as np
  arr = np.array([[1, 2, 3], [4, 5, 6]])
  arr.mean(), arr.std(), arr.sum(axis=0)
  np.linspace(0, 10, 100)                 # 100 punti equidistanti
  np.random.randn(1000)                   # 1000 valori normali
  ```

### `polars`
**DataFrame library veloce scritta in Rust (API simile a pandas).**

- **Installazione:** `pip install polars`
- **Esempio:**
  ```python
  import polars as pl
  df = pl.read_csv("dati.csv")
  df.group_by("categoria").agg(pl.col("valore").mean())
  ```
- **Note:** Performance 10-100x su pandas per dataset grandi

### `vaex`
**DataFrame library per dataset out-of-core (non in RAM).**

- **Installazione:** `pip install vaex`
- **Note:** Lazy evaluation, visualizzazione integrata, supporto 1TB+ dataset

### `datatable`
**DataFrame library per dataset grandi con API R-like (H2O).**

- **Installazione:** `pip install datatable`
- **Esempio:**
  ```python
  import datatable as dt
  df = dt.fread("dati.csv")
  df[:, dt.sum(dt.f.valore), dt.by(dt.f.categoria)]
  ```

---

## 2. Librerie Python per Visualizzazione

### `matplotlib`
**Libreria base per creazione di grafici statici 2D/3D.**

- **Installazione:** `pip install matplotlib`
- **Esempio:**
  ```python
  import matplotlib.pyplot as plt
  plt.figure(figsize=(10, 6))
  plt.plot(df["data"], df["valore"], label="Serie storica", linewidth=2)
  plt.bar(df["categoria"], df["conteggio"])
  plt.scatter(df["x"], df["y"], c=df["gruppo"], cmap="viridis")
  plt.xlabel("Data"), plt.ylabel("Valore"), plt.title("Titolo"), plt.legend()
  plt.savefig("grafico.png", dpi=300, bbox_inches="tight")
  ```

### `seaborn`
**Visualizzazione statistica basata su matplotlib (temi migliorati, grafici complessi).**

- **Installazione:** `pip install seaborn`
- **Esempio:**
  ```python
  import seaborn as sns
  sns.set_theme(style="whitegrid")
  sns.boxplot(data=df, x="categoria", y="valore")
  sns.heatmap(df.corr(), annot=True, cmap="coolwarm")
  sns.pairplot(df, hue="target")
  sns.displot(df, x="valore", hue="categoria", kind="kde")
  sns.lineplot(data=df, x="data", y="valore", hue="prodotto")
  ```

### `plotly`
**Grafici interattivi per web e notebook (supporta hover, zoom, animazioni).**

- **Installazione:** `pip install plotly`
- **Esempio:**
  ```python
  import plotly.express as px
  px.scatter(df, x="x", y="y", color="categoria", size="popolazione", hover_data=["nome"])
  px.line(df, x="data", y="vendite", color="prodotto")
  px.histogram(df, x="età", nbins=30, marginal="box")
  fig = px.density_heatmap(df, x="x", y="y", z="frequenza")
  fig.write_html("chart.html")
  ```

### `bokeh`
**Libreria per visualizzazioni interattive per browser (dashboard complesse).**

- **Installazione:** `pip install bokeh`
- **Esempio:**
  ```python
  from bokeh.plotting import figure, show
  p = figure(title="Interattivo", x_axis_label="X", y_axis_label="Y")
  p.line(df["x"], df["y"], legend_label="Trend", line_width=2)
  show(p)
  ```

### `altair`
**Visualizzazione dichiarativa basata su Grammar of Graphics (Vega-Lite).**

- **Installazione:** `pip install altair`
- **Esempio:**
  ```python
  import altair as alt
  alt.Chart(df).mark_point().encode(x="x:Q", y="y:Q", color="categoria:N").interactive()
  ```

### `ggplot` (plotnine)
**Implementazione Python di Grammar of Graphics (come R ggplot2).**

- **Installazione:** `pip install plotnine`
- **Esempio:**
  ```python
  from plotnine import ggplot, aes, geom_point, labs
  ggplot(df) + aes(x="x", y="y", color="categoria") + geom_point() + labs(title="Scatter")
  ```

### `folium`
**Visualizzazione geospaziale con mappe Leaflet (OpenStreetMap).**

- **Installazione:** `pip install folium`
- **Esempio:**
  ```python
  import folium
  m = folium.Map(location=[41.9, 12.5], zoom_start=6)
  folium.Marker([41.9, 12.5], popup="Roma", tooltip="Capitale").add_to(m)
  m.save("mappa.html")
  ```

---

## 3. Notebook e Ambienti Interattivi

### Jupyter Notebook
**Ambiente interattivo web per analisi dati e documentazione mista.**

- **Comando:** `jupyter notebook`
- **Estensioni:** ipywidgets (interattività), jupyter-black (formatting), jupyter-tabnine (autocomplete)
- **Magic commands:** `%matplotlib inline`, `%timeit`, `%debug`, `%run script.py`

### JupyterLab
**IDE web next-generation per Jupyter (multi-pannello, terminale, file browser).**

- **Comando:** `jupyter lab`
- **Installazione:** `pip install jupyterlab`
- **Feature:** Debugger integrato, code console, tema dark, estensioni

### VS Code + Jupyter Extension
**Supporto notebook Jupyter direttamente in VS Code.**

- **Estensione:** Jupyter (Microsoft)
- **Note:** Variable viewer, data viewer, debugging, GitHub Copilot

### Google Colab
**Jupyter notebook sul cloud con GPU gratis (Google Drive integration).**

- **URL:** https://colab.research.google.com
- **Feature:** GPU/TPU runtime, file upload, Google Sheets integration

### `papermill`
**Parametrizzazione ed esecuzione di notebook Jupyter in batch/CI.**

- **Comando:** `papermill input.ipynb output.ipynb -p parametro valore`
- **Esempio:** `papermill report.ipynb report_executed.ipynb -p year 2024`

### `voila`
**Trasforma notebook Jupyter in applicazioni web interattive standalone.**

- **Comando:** `voila notebook.ipynb`
- **Installazione:** `pip install voila`

---

## 4. Machine Learning

### `scikit-learn`
**Libreria ML classica (classificazione, regressione, clustering, feature engineering).**

- **Installazione:** `pip install scikit-learn`
- **Esempio:**
  ```python
  from sklearn.ensemble import RandomForestClassifier
  from sklearn.model_selection import train_test_split, cross_val_score
  from sklearn.metrics import classification_report, confusion_matrix
  
  X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2)
  model = RandomForestClassifier(n_estimators=100, max_depth=10)
  model.fit(X_train, y_train)
  y_pred = model.predict(X_test)
  print(classification_report(y_test, y_pred))
  ```

### `xgboost`
**Implementazione ottimizzata di Gradient Boosting (competizioni Kaggle).**

- **Installazione:** `pip install xgboost`
- **Esempio:** `import xgboost as xgb; model = xgb.XGBClassifier(n_estimators=100, learning_rate=0.1)`

### `lightgbm`
**Gradient Boosting framework di Microsoft (veloce, basso consumo memoria).**

- **Installazione:** `pip install lightgbm`
- **Esempio:** `import lightgbm as lgb; model = lgb.LGBMClassifier(num_leaves=31)`

### `catboost`
**Gradient Boosting di Yandex (supporto nativo categorical features).**

- **Installazione:** `pip install catboost`
- **Esempio:** `from catboost import CatBoostClassifier; model = CatBoostClassifier(iterations=100)`

### `tensorflow` / `keras`
**Framework deep learning di Google.**

- **Installazione:** `pip install tensorflow`
- **Esempio:**
  ```python
  from tensorflow import keras
  model = keras.Sequential([
      keras.layers.Dense(64, activation="relu"),
      keras.layers.Dense(1, activation="sigmoid")
  ])
  model.compile(optimizer="adam", loss="binary_crossentropy")
  ```

### `pytorch`
**Framework deep learning di Meta (dynamic computation graph).**

- **Installazione:** `pip install torch`
- **Esempio:**
  ```python
  import torch
  model = torch.nn.Sequential(
      torch.nn.Linear(10, 64),
      torch.nn.ReLU(),
      torch.nn.Linear(64, 1)
  )
  ```

### `statsmodels`
**Modellazione statistica (regressioni, test ipotesi, serie temporali).**

- **Installazione:** `pip install statsmodels`
- **Esempio:**
  ```python
  import statsmodels.api as sm
  model = sm.OLS(y, sm.add_constant(X)).fit()
  print(model.summary())
  ```

### `imbalanced-learn` (imblearn)
**Tecniche per dataset sbilanciati (oversampling, undersampling).**

- **Installazione:** `pip install imbalanced-learn`
- **Esempio:** `from imblearn.over_sampling import SMOTE; X_res, y_res = SMOTE().fit_resample(X, y)`

---

## 5. Business Intelligence

### Power BI
**Piattaforma BI Microsoft per dashboard interattivi e report.**

- **Componenti:**
  - **Power BI Desktop** — creazione report (gratuito)
  - **Power BI Service** — condivisione e collaborazione cloud
  - **Power BI Report Server** — on-premise
- **Linguaggi:** DAX (misure), Power Query M (ETL)
- **Esempio DAX:**
  ```dax
  TotaleVendite = SUM(Vendite[Importo])
  VenditeYTD = TOTALYTD(SUM(Vendite[Importo]), Calendario[Data])
  ```
- **Connettori:** Excel, SQL Server, Azure, SharePoint, web API, 150+

### Tableau
**Piattaforma BI per visualizzazione dati drag-and-drop (Desktop, Server, Cloud).**

- **Componenti:** Tableau Desktop, Tableau Server, Tableau Online, Tableau Prep
- **Note:** Connettori nativi per database, cloud, file

### Looker (Google Cloud)
**Piattaforma BI moderna con LookML (modellazione semantica).**

- **Note:** LookML definisce metriche e dimensioni in modo dichiarativo

### Qlik Sense
**Piattaforma BI associativa (Qlik Associative Engine).**

- **Feature:** Data model associativo, calcoli in-memory, dashboard interattivi

### Apache Superset
**BI platform open-source (airbnb) con SQL IDE, chart builder, dashboard.**

- **Installazione:** `pip install apache-superset`
- **Comando:** `superset run -p 8088 --with-threads --reload --debugger`

### Metabase
**BI open-source facile da usare (SQL queries, dashboard, embedding).**

- **Installazione:** `java -jar metabase.jar`
- **Docker:** `docker run -p 3000:3000 metabase/metabase`

### Grafana
**Dashboard e analytics per metriche time-series (Prometheus, InfluxDB, SQL).**

- **Installazione:** Docker, binary, package manager
- **Esempio:** Dashboard per monitoring infra, business KPI, dati IoT

### Excel
**Tool BI entry-level con Power Query, Power Pivot, tabelle pivot, grafici.**

- **Feature:** Power Query (ETL), Power Pivot (modello dati), DAX, analisi what-if, solver
- **Limitazioni:** 1M righe per foglio di lavoro

---

## 6. Database Analitici

### ClickHouse
**Database OLAP column-store per analisi real-time su grandi volumi.**

- **Avvio Docker:** `docker run -p 8123:8123 clickhouse/clickhouse-server`
- **Esempio SQL:**
  ```sql
  SELECT toStartOfMonth(data) AS mese, sum(importo) AS totale
  FROM vendite
  GROUP BY mese
  ORDER BY mese
  ```
- **Note:** Performance 100-1000x su query aggregative rispetto a DB tradizionali

### DuckDB
**Database OLAP embedded (come SQLite ma per analytics).**

- **Installazione:** `pip install duckdb`
- **Esempio:**
  ```python
  import duckdb
  duckdb.sql("SELECT categoria, SUM(valore) FROM 'dati.csv' GROUP BY categoria")
  ```

### Apache Druid
**Database OLAP per eventi time-series a bassa latenza.**
- **Note:** Usato per real-time analytics, user-facing analytics

### InfluxDB
**Database time-series ottimizzato per metriche e eventi temporali.**

- **Avvio Docker:** `docker run -p 8086:8086 influxdb:2`
- **Query (Flux):** `from(bucket: "my-bucket") |> range(start: -1h) |> filter(fn: (r) => r._measurement == "temperatura")`

---

## 7. ETL e Data Pipeline

### Apache Spark
**Framework distributed per elaborazione dati batch e streaming.**

- **Comando:** `spark-submit script.py`
- **API Python (PySpark):**
  ```python
  from pyspark.sql import SparkSession
  spark = SparkSession.builder.appName("analytics").getOrCreate()
  df = spark.read.csv("dati.csv", header=True, inferSchema=True)
  df.groupBy("categoria").agg({"valore": "sum"}).show()
  ```

### dbt (data build tool)
**Strumento per trasformazione dati nel warehouse (SQL-based).**

- **Comando:** `dbt run`, `dbt test`, `dbt docs generate`
- **Configurazione (dbt_project.yml):**
  ```yaml
  models:
    my_project:
      +materialized: table
  ```
- **Note:** Trasformazioni SQL nel data warehouse, versioning, test, documentazione

### Airflow
**Piattaforma di orchestrazione per workflow di dati (DAG in Python).**

- **Comando:** `airflow webserver`, `airflow scheduler`
- **Esempio DAG:**
  ```python
  with DAG("etl_pipeline", schedule="0 6 * * *", start_date=datetime(2024,1,1)) as dag:
      extract = PythonOperator(task_id="extract", python_callable=extract_data)
      transform = PythonOperator(task_id="transform", python_callable=transform_data)
      load = PostgresOperator(task_id="load", sql="INSERT INTO target SELECT * FROM staging")
      extract >> transform >> load
  ```

### Prefect
**Alternativa moderna a Airflow con API Pythonica e cloud/self-hosted.**

- **Esempio:**
  ```python
  @flow
  def etl_pipeline():
      data = extract()
      transformed = transform(data)
      load(transformed)
  ```

### Dagster
**Orchestratore per data pipeline con asset-oriented design.**

- **Note:** Asset lineage, testabilità, integrazione dbt

### Apache Kafka
**Piattaforma streaming per dati real-time (pub/sub, log distribuito).**

- **Comando:** `kafka-console-producer --topic events --bootstrap-server localhost:9092`
- **Esempio (Python):**
  ```python
  from kafka import KafkaProducer
  producer = KafkaProducer(bootstrap_servers="localhost:9092")
  producer.send("events", b"event data")
  ```

### Apache NiFi
**Tool visuale per automazione flussi dati (drag-and-drop).**

- **Avvio Docker:** `docker run -p 8443:8443 apache/nifi`

---

## 8. Time Series e Streaming

### Prophet (Meta)
**Previsione serie temporali con cambi di stagionalità e trend.**

- **Installazione:** `pip install prophet`
- **Esempio:**
  ```python
  from prophet import Prophet
  model = Prophet(yearly_seasonality=True, weekly_seasonality=True)
  model.fit(df[["ds", "y"]])
  future = model.make_future_dataframe(periods=365)
  forecast = model.predict(future)
  ```

### statsmodels.tsa
**Modellazione statistica per serie temporali (ARIMA, SARIMA, VAR).**

- **Esempio:**
  ```python
  from statsmodels.tsa.arima.model import ARIMA
  model = ARIMA(series, order=(1, 1, 1)).fit()
  forecast = model.forecast(steps=12)
  ```

### Darts
**Libreria Python per forecasting con modelli classici e deep learning.**

- **Installazione:** `pip install darts`
- **Esempio:**
  ```python
  from darts import TimeSeries
  from darts.models import ExponentialSmoothing
  series = TimeSeries.from_dataframe(df, "data", "valore")
  model = ExponentialSmoothing().fit(series)
  forecast = model.predict(12)
  ```

### Streamlit
**Framework per costruire app dati interattive in puro Python.**

- **Installazione:** `pip install streamlit`
- **Esempio (app.py):**
  ```python
  import streamlit as st
  st.title("Dashboard Vendite")
  df = pd.read_csv("vendite.csv")
  prodotto = st.selectbox("Prodotto", df["prodotto"].unique())
  st.line_chart(df[df["prodotto"] == prodotto].set_index("data")["importo"])
  ```
- **Avvio:** `streamlit run app.py`

### Dash (Plotly)
**Framework per applicazioni analitiche web con Plotly.**

- **Installazione:** `pip install dash`
- **Avvio:** `python app.py`

### Shiny (R / Python)
**Framework per applicazioni web interattive (RStudio/Posit).**

- **Installazione Python:** `pip install shiny`
- **Avvio:** `shiny run app.py`

---

## 9. Statistical Computing

### R Language
**Linguaggio specializzato per statistica e analisi dati.**

- **Comando:** `Rscript script.R`
- **REPL:** `R`
- **Pacchetti principali:**
  - `dplyr` — manipolazione dati
  - `ggplot2` — visualizzazione
  - `tidyr` — data tidying
  - `caret` — ML
  - `shiny` — applicazioni web

### RStudio
**IDE per R (desktop e server).**

- **Feature:** Console, script editor, data viewer, plot pane, package manager

### `ggplot2`
**Grammatica della grafica per R (il gold standard per visualizzazione).**

- **Esempio:**
  ```r
  library(ggplot2)
  ggplot(df, aes(x = categoria, y = valore, fill = categoria)) +
    geom_boxplot() +
    theme_minimal() +
    labs(title = "Boxplot per categoria")
  ```

### `dplyr`
**Libreria R per manipolazione dati (grammatica pipeline).**

- **Esempio:**
  ```r
  df %>% filter(anno == 2024) %>% group_by(categoria) %>% summarise(totale = sum(valore)) %>% arrange(desc(totale))
  ```

### `tidymodels`
**Framework R per ML (alternativa moderna a caret).**

- **Pacchetti:** `parsnip`, `recipes`, `workflows`, `tune`, `yardstick`

---

## 10. Strumenti Ausiliari

### `csvkit`
**Suite di tool per manipolazione CSV da riga di comando.**

- **Installazione:** `pip install csvkit`
- **Comandi:**
  ```
  csvlook data.csv        # formatta CSV colorato
  csvstat data.csv        # statistiche colonne
  csvcut -c 1,3 data.csv  # seleziona colonne
  csvgrep -c nome -m Mario data.csv  # filtra righe
  csvsql --query "SELECT * FROM data WHERE valore > 100" data.csv
  ```

### `visidata`
**Navigatore di dati tabellari da terminale (CSV, Excel, SQL, JSON).**

- **Comando:** `visidata file.csv`

### `pandas-profiling` (ydata-profiling)
**Generazione report automatico di analisi esplorativa dati (EDA).**

- **Installazione:** `pip install ydata-profiling`
- **Esempio:**
  ```python
  from ydata_profiling import ProfileReport
  profile = ProfileReport(df, title="EDA Report", explorative=True)
  profile.to_file("report.html")
  ```

### `sweetviz`
**Generazione report EDA automatico con confronto dataset.**

- **Installazione:** `pip install sweetviz`
- **Esempio:**
  ```python
  import sweetviz as sv
  report = sv.analyze(df, target_feat="target")
  report.show_html("sweetviz_report.html")
  ```

### `great_expectations`
**Framework per data quality e validazione (expectations).**

- **Comando:** `great_expectations init`
- **Configurazione:** `expect_column_values_to_not_be_null("colonna")`

### `ipython-sql`
**Esecuzione SQL direttamente da Jupyter/IPython.**

- **Installazione:** `pip install ipython-sql`
- **Esempio in notebook:**
  ```sql
  %load_ext sql
  %sql sqlite:///database.db
  %%sql
  SELECT categoria, COUNT(*) FROM dati GROUP BY categoria
  ```

### `pandoc`
**Conversione documenti tra formati (Markdown, HTML, LaTeX, PDF, docx).**

- **Comando:** `pandoc report.md -o report.pdf --from markdown --to pdf`

### `nbconvert`
**Conversione notebook Jupyter in altri formati (HTML, PDF, slides).**

- **Comando:** `jupyter nbconvert --to html --template classic notebook.ipynb`

### `mlflow`
**Piattaforma per gestione ciclo di vita ML (tracking, model registry, deployment).**

- **Comando:** `mlflow ui`
- **Esempio:**
  ```python
  import mlflow
  with mlflow.start_run():
      mlflow.log_param("n_estimators", 100)
      mlflow.log_metric("accuracy", 0.95)
      mlflow.sklearn.log_model(model, "model")
  ```

---

## Licenza

MIT

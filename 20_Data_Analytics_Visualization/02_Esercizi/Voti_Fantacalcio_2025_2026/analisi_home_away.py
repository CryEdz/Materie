from pathlib import Path
import sys

from analizza_fantacalcio import (
    BASE_DIR,
    load_raw_data,
    build_aggregated_table,
    build_role_summary,
    build_team_summary,
    build_rankings,
    save_bar_chart,
    save_line_chart,
    dataframe_to_markdown_table,
    write_tidy_workbook,
)

import pandas as pd


FIXTURES_FILE = BASE_DIR / "fixtures.csv"


def load_fixtures(path: Path) -> pd.DataFrame:
    if not path.exists():
        sample = (
            "# fixtures.csv example: columns=round,home,away\n"
            "# 1,Inter,Juventus\n"
            "# 1,Milan,Napoli\n"
        )
        raise FileNotFoundError(
            f"File fixtures non trovato: {path}\nCreane uno con colonne 'round,home,away' (esempio in commento):\n{sample}"
        )
    df = pd.read_csv(path)
    required = {"round", "home", "away"}
    if not required.issubset(set(df.columns)):
        raise ValueError(f"Il file fixtures deve contenere le colonne: {required}")
    return df


def attach_venue(raw: pd.DataFrame, fixtures: pd.DataFrame) -> pd.DataFrame:
    # Merge to annotate home/away for each event
    fx = fixtures.copy()
    fx = fx.astype({"round": int})

    # Construct mapping per (round,team)
    map_rows = {(int(r.round), r.home): "home" for r in fx.itertuples(index=False)}
    map_rows.update({(int(r.round), r.away): "away" for r in fx.itertuples(index=False)})

    raw = raw.copy()
    raw["venue"] = raw.apply(lambda r: map_rows.get((int(r['round']), r['team'])), axis=1)
    return raw


def make_visuals_custom(raw: pd.DataFrame, aggregated: pd.DataFrame, rankings: dict, out_dir: Path) -> dict:
    out_dir.mkdir(exist_ok=True, parents=True)

    paths = {}
    top_players = rankings["player_focus"].head(10)[["Nome", "fantamedia"]].copy()
    save_bar_chart(
        top_players.sort_values("fantamedia", ascending=True),
        x="Nome",
        y="fantamedia",
        title="Top 10 giocatori per fantamedia (>=15 presenze)",
        output_path=out_dir / "top_giocatori.png",
    )
    paths["players"] = out_dir / "top_giocatori.png"

    role_summary = build_role_summary(aggregated).copy()
    save_bar_chart(
        role_summary.sort_values("fantamedia_media", ascending=True),
        x="Ruolo",
        y="fantamedia_media",
        title="Fantamedia media per ruolo",
        output_path=out_dir / "fantamedia_per_ruolo.png",
    )
    paths["roles"] = out_dir / "fantamedia_per_ruolo.png"

    team_summary = build_team_summary(raw).head(10)
    save_bar_chart(
        team_summary.sort_values("fantamedia", ascending=True),
        x="Squadra",
        y="fantamedia",
        title="Top squadre per fantamedia",
        output_path=out_dir / "top_squadre.png",
    )
    paths["teams"] = out_dir / "top_squadre.png"

    top_teams = team_summary.head(4)["Squadra"].tolist()
    team_trend = rankings["team_trend"][rankings["team_trend"]["Squadra"].isin(top_teams)]
    save_line_chart(team_trend, title="Andamento squadre top", output_path=out_dir / "andamento_top.png")
    paths["trend"] = out_dir / "andamento_top.png"

    return paths


def write_reports_custom(kind: str, raw: pd.DataFrame, aggregated: pd.DataFrame, role_summary: pd.DataFrame, team_summary: pd.DataFrame, rankings: dict, visual_paths: dict, out_dir: Path) -> None:
    out_dir.mkdir(exist_ok=True, parents=True)
    report_md = BASE_DIR / f"report_analisi_{kind}.md"

    top_players = rankings["player_focus"].head(10)
    scorers = rankings["scorers"].head(10)
    assisters = rankings["assisters"].head(10)
    disciplinary = rankings["disciplinary"].head(10)
    consistency = rankings["consistency"].head(10)

    report_analysis = f"""# Report analisi Fantacalcio 2025/2026 — {kind.upper()}

## Sintesi

- File analizzati: {raw['round'].nunique()} giornate
- Righe pulite: {len(raw):,}
- Giocatori aggregati: {len(aggregated):,}
- Squadre: {aggregated['Squadra'].nunique()}

## Top giocatori

{dataframe_to_markdown_table(top_players, ['Squadra', 'Nome', 'Ruolo', 'presenze', 'fantamedia', 'gf', 'ass'])}

## Visualizzazioni

![Top giocatori]({visual_paths['players'].as_posix()})

![Fantamedia per ruolo]({visual_paths['roles'].as_posix()})

![Top squadre]({visual_paths['teams'].as_posix()})

![Andamento squadre top]({visual_paths['trend'].as_posix()})
"""

    report_md.write_text(report_analysis, encoding="utf-8")
    # Export tidy workbook
    tidy_file = BASE_DIR / f"Fantacalcio_tidy_{kind}.xlsx"
    write_tidy_workbook(aggregated, tidy_file)


def main():
    try:
        fixtures = load_fixtures(FIXTURES_FILE)
    except Exception as e:
        print(e)
        sys.exit(2)

    raw = load_raw_data(BASE_DIR)
    raw = attach_venue(raw, fixtures)

    for kind in ["home", "away"]:
        subset = raw[raw["venue"] == kind].copy()
        if subset.empty:
            print(f"Nessun dato per {kind}")
            continue
        aggregated = build_aggregated_table(subset)
        role_summary = build_role_summary(aggregated)
        team_summary = build_team_summary(subset)
        rankings = build_rankings(subset, aggregated)

        out_dir = BASE_DIR / "output" / kind
        visuals = make_visuals_custom(subset, aggregated, rankings, out_dir)
        write_reports_custom(kind, subset, aggregated, role_summary, team_summary, rankings, visuals, out_dir)
        print(f"Analisi {kind} completata. Output in: {out_dir}")


if __name__ == "__main__":
    main()

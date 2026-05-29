from __future__ import annotations

import re
from pathlib import Path
from typing import Iterable

import pandas as pd

EXPECTED_COLUMNS = [
    "Squadra",
    "Cod.",
    "Ruolo",
    "Nome",
    "Voto",
    "Gf",
    "Gs",
    "Rp",
    "Rs",
    "Rf",
    "Au",
    "Amm",
    "Esp",
    "Ass",
    "Fantamedia",
]

NUMERIC_BONUS_COLUMNS = ["Gf", "Gs", "Rp", "Rs", "Rf", "Au", "Amm", "Esp", "Ass"]
DISCARD_PATTERNS = [
    "solo su",
    "questo file",
    "uso personale",
    "voti fantacalcio",
    "voti statistici",
    "voti italia",
]


def extract_matchday_from_name(file_path: Path) -> int:
    match = re.search(r"Giornata_(\d+)", file_path.name, flags=re.IGNORECASE)
    if not match:
        raise ValueError(f"Impossibile estrarre il numero giornata da: {file_path.name}")
    return int(match.group(1))


def normalize_vote(value: object) -> float | pd.NA:
    if pd.isna(value):
        return pd.NA
    text = str(value).strip().lower().replace(",", ".")
    if text in {"sv", "s.v.", "-", ""}:
        return pd.NA

    match = re.search(r"\d+(?:\.\d+)?", text)
    if not match:
        return pd.NA
    return float(match.group(0))


def is_team_row(row: pd.Series) -> bool:
    first_cell = row.iloc[0]
    if pd.isna(first_cell):
        return False

    first_text = str(first_cell).strip()
    if not first_text:
        return False

    lowered = first_text.lower()
    if any(token in lowered for token in DISCARD_PATTERNS):
        return False

    if lowered in {"cod.", "cod", "squadra"}:
        return False

    others_empty = row.iloc[1:].isna().all()
    is_not_numeric = not bool(re.fullmatch(r"\d+", first_text))
    return bool(others_empty and is_not_numeric)


def parse_fantacalcio_sheet(file_path: Path, sheet_name: str = "Fantacalcio") -> pd.DataFrame:
    try:
        raw = pd.read_excel(file_path, sheet_name=sheet_name, header=None)
    except Exception as exc:  # noqa: BLE001
        raise ValueError(f"Errore lettura foglio '{sheet_name}' in {file_path.name}: {exc}") from exc

    rows: list[dict[str, object]] = []
    current_team: str | None = None

    for _, row in raw.iterrows():
        if is_team_row(row):
            current_team = str(row.iloc[0]).strip()
            continue

        first_cell = str(row.iloc[0]).strip() if not pd.isna(row.iloc[0]) else ""
        if first_cell.lower() in {"cod.", "cod"}:
            continue

        if not current_team or not re.fullmatch(r"\d+", first_cell):
            continue

        player_data = {
            "Squadra": current_team,
            "Cod.": first_cell,
            "Ruolo": str(row.iloc[1]).strip() if not pd.isna(row.iloc[1]) else "",
            "Nome": str(row.iloc[2]).strip() if not pd.isna(row.iloc[2]) else "",
            "Voto": normalize_vote(row.iloc[3]),
            "Gf": row.iloc[4],
            "Gs": row.iloc[5],
            "Rp": row.iloc[6],
            "Rs": row.iloc[7],
            "Rf": row.iloc[8],
            "Au": row.iloc[9],
            "Amm": row.iloc[10],
            "Esp": row.iloc[11],
            "Ass": row.iloc[12],
            "Giornata": extract_matchday_from_name(file_path),
        }
        rows.append(player_data)

    if not rows:
        raise ValueError(f"Nessuna riga giocatore trovata in {file_path.name}")

    df = pd.DataFrame(rows)

    for col in NUMERIC_BONUS_COLUMNS:
        df[col] = pd.to_numeric(df[col], errors="coerce").fillna(0).astype("Int64")

    df["Voto"] = pd.to_numeric(df["Voto"], errors="coerce")

    # Formula Fantamedia standard fantacalcio: voto + bonus - malus.
    df["Fantamedia"] = (
        df["Voto"]
        + (3 * df["Gf"])
        - df["Gs"]
        + (3 * df["Rp"])
        - (3 * df["Rs"])
        - (2 * df["Rf"])
        - (2 * df["Au"])
        - (0.5 * df["Amm"])
        - df["Esp"]
        + df["Ass"]
    )

    return df


def find_matchday_files(base_dir: Path) -> list[Path]:
    files = sorted(
        base_dir.glob("Voti_Fantacalcio_Stagione_2025_26_Giornata_*.xlsx"),
        key=extract_matchday_from_name,
    )
    if not files:
        raise FileNotFoundError(f"Nessun file giornata trovato in {base_dir}")
    return files


def build_tidy_dataframe(matchday_files: Iterable[Path]) -> pd.DataFrame:
    all_days = [parse_fantacalcio_sheet(file_path) for file_path in matchday_files]
    full = pd.concat(all_days, ignore_index=True)

    full["Cod."] = pd.to_numeric(full["Cod."], errors="coerce").astype("Int64")
    full["Ruolo"] = full["Ruolo"].str.upper().str.strip()
    full["Nome"] = full["Nome"].str.replace(r"\s+", " ", regex=True).str.strip()
    full["Squadra"] = full["Squadra"].str.replace(r"\s+", " ", regex=True).str.strip()

    tidy = full[EXPECTED_COLUMNS].copy()
    return tidy.sort_values(by=["Squadra", "Ruolo", "Nome"], kind="stable").reset_index(drop=True)


def save_tidy_excel(tidy_df: pd.DataFrame, input_template: Path, output_file: Path) -> None:
    legend_df = pd.read_excel(input_template, sheet_name="Legenda e bonus malus")
    with pd.ExcelWriter(output_file, engine="openpyxl") as writer:
        tidy_df.to_excel(writer, sheet_name="Risultati", index=False)
        legend_df.to_excel(writer, sheet_name="Legenda e bonus malus", index=False)


def main() -> None:
    base_dir = Path(__file__).resolve().parent
    template_file = base_dir / "Fantacalcio_tidy.xlsx"
    output_file = base_dir / "Fantacalcio_tidy_output.xlsx"

    if not template_file.exists():
        raise FileNotFoundError(f"Template non trovato: {template_file}")

    matchday_files = find_matchday_files(base_dir)
    tidy = build_tidy_dataframe(matchday_files)
    save_tidy_excel(tidy, template_file, output_file)

    print(f"File generato: {output_file}")
    print(f"Righe totali: {len(tidy)}")
    print("Colonne:", ", ".join(tidy.columns))


if __name__ == "__main__":
    main()

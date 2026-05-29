<#
.SYNOPSIS
  Apre il file TEMPLATE_PROMPT.md nella cartella corrente o risalendo la gerarchia di cartelle.

.DESCRIPTION
  Cerca `TEMPLATE_PROMPT.md` a partire dalla cartella indicata (default: current directory).
  Se trovato, apre il file con `code` (CLI di VS Code). Se non trovato, apre `AGENTS_PROMPTS.md` nella root del workspace se presente.

.PARAMETER Path
  Percorso iniziale dove cercare (opzionale). Può essere una cartella o un file.

.EXAMPLE
  .\open-template-prompt.ps1
  .\open-template-prompt.ps1 ..\10_Programmazione_Python
#>
param(
    [string]
    $Path = "."
)

try {
    $start = Resolve-Path -LiteralPath $Path -ErrorAction Stop
} catch {
    Write-Host "Percorso non valido: $Path" -ForegroundColor Red
    exit 2
}

$cwd = $start.Path
$workspaceRoot = (Get-Location).Path

while ($true) {
    $candidate = Join-Path $cwd 'TEMPLATE_PROMPT.md'
    if (Test-Path $candidate) {
        Write-Host "Apro: $candidate"
        code $candidate
        exit 0
    }
    $parent = Split-Path -Path $cwd -Parent
    if ([string]::IsNullOrEmpty($parent) -or $parent -eq $cwd) { break }
    $cwd = $parent
}

# Fallback: apri AGENTS_PROMPTS.md nella root del workspace
$agentsFile = Join-Path $workspaceRoot 'AGENTS_PROMPTS.md'
if (Test-Path $agentsFile) {
    Write-Host "Nessun TEMPLATE_PROMPT.md trovato, apro: $agentsFile"
    code $agentsFile
    exit 0
}

Write-Host "Nessun TEMPLATE_PROMPT.md trovato e AGENTS_PROMPTS.md non presente in workspace." -ForegroundColor Yellow
exit 1

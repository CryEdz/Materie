<##
.SYNOPSIS
  Esporta il file `TEMPLATE_PROMPT.md` più vicino e lo copia negli appunti e in `.chat/CURRENT_TEMPLATE.md`.
.DESCRIPTION
  Cerca `TEMPLATE_PROMPT.md` a partire dalla cartella indicata (default: current directory).
  Se trovato, copia il contenuto negli appunti e scrive il file `.chat/CURRENT_TEMPLATE.md` nella root del workspace (trovata cercando `README.md` verso l'alto).
.PARAMETER Path
  Percorso iniziale dove cercare (opzionale). Può essere una cartella o un file.
.EXAMPLE
  .\export-nearest-template.ps1
  .\export-nearest-template.ps1 .\10_Programmazione_Python\02_Esercizi
#>
param(
    [string]
    $Path = "."
)

function Find-NearestFile([string]$startPath, [string]$fileName) {
    $cwd = (Resolve-Path -LiteralPath $startPath).Path
    while ($true) {
        $candidate = Join-Path $cwd $fileName
        if (Test-Path $candidate) { return $candidate }
        $parent = Split-Path -Path $cwd -Parent
        if ([string]::IsNullOrEmpty($parent) -or $parent -eq $cwd) { break }
        $cwd = $parent
    }
    return $null
}

try {
    $startResolved = Resolve-Path -LiteralPath $Path -ErrorAction Stop
} catch {
    Write-Host "Percorso non valido: $Path" -ForegroundColor Red
    exit 2
}

$startPath = $startResolved.Path
$template = Find-NearestFile -startPath $startPath -fileName 'TEMPLATE_PROMPT.md'
if (-not $template) {
    Write-Host "Nessun TEMPLATE_PROMPT.md trovato a partire da: $startPath" -ForegroundColor Yellow
    exit 1
}

# Trova la root del workspace cercando README.md verso l'alto
$workspaceRoot = Split-Path $template -Parent
$rootCandidate = Find-NearestFile -startPath $workspaceRoot -fileName 'README.md'
if ($rootCandidate) { $workspaceRoot = Split-Path $rootCandidate -Parent }

$chatDir = Join-Path $workspaceRoot '.chat'
if (-not (Test-Path $chatDir)) { New-Item -ItemType Directory -Path $chatDir | Out-Null }
$targetFile = Join-Path $chatDir 'CURRENT_TEMPLATE.md'

# Leggi contenuto e scrivi file
$content = Get-Content -Raw -LiteralPath $template
Set-Content -LiteralPath $targetFile -Value $content -Encoding UTF8

# Copia negli appunti
try {
    $content | Set-Clipboard
    $clipMsg = ' (copiato negli appunti)'
} catch {
    $clipMsg = ' (impossibile copiare negli appunti)'
}

Write-Host "TEMPLATE trovato: $template"
Write-Host "Esportato in: $targetFile$clipMsg"
exit 0

<#
.SYNOPSIS
  Monitora il consumo di token della sessione opencode corrente.
  A 130.000 token crea automaticamente uno snapshot (export) e azzera la sessione.

.DESCRIPTION
  Legge il database SQLite di opencode, calcola i token della sessione attiva,
  e se richiesto (flag -Auto) esporta la sessione in JSON e avvisa l'utente
  di iniziare una nuova sessione quando viene superata la soglia.

.PARAMETER Threshold
  Soglia token oltre cui scatta lo snapshot (default: 130000).
.PARAMETER Auto
  Se presente, esegue automaticamente lo snapshot al superamento della soglia.
.PARAMETER BackupDir
  Directory dove salvare i file JSON di snapshot (default: ./token-snapshots/).
.PARAMETER Check
  Solo controllo: mostra il consumo attuale senza fare snapshot.

.EXAMPLE
  .\token-watch.ps1 -Check
  Mostra il consumo token della sessione corrente.

.EXAMPLE
  .\token-watch.ps1 -Auto -Threshold 150000
  Monitora e fa snapshot a 150.000 token.
#>

param(
  [int]$Threshold = 130000,
  [switch]$Auto,
  [string]$BackupDir = "",
  [switch]$Check
)

$DbPath = "$env:USERPROFILE\.local\share\opencode\opencode.db"

if (-not (Test-Path -LiteralPath $DbPath)) {
  Write-Host "[token-watch] ERRORE: Database opencode non trovato in $DbPath" -ForegroundColor Red
  exit 1
}

if (-not $BackupDir) {
  $ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
  $BackupDir = Join-Path -Path (Split-Path -Parent $ScriptDir) -ChildPath "token-snapshots"
}

if (-not (Test-Path -LiteralPath $BackupDir)) {
  New-Item -ItemType Directory -Path $BackupDir -Force | Out-Null
}

$result = & opencode db "SELECT id, title, tokens_input, tokens_output, tokens_reasoning, tokens_cache_read, tokens_cache_write FROM session WHERE time_archived IS NULL ORDER BY time_updated DESC LIMIT 1;" 2>&1

$lines = @($result | Where-Object { $_ -match '^ses_' })
if ($lines.Count -eq 0) {
  Write-Host "[token-watch] Nessuna sessione attiva trovata." -ForegroundColor Yellow
  exit 0
}

$parts = $lines[0] -split "`t"
$SessionId = $parts[0]
$Title = if ($parts[1]) { $parts[1] } else { "(nessun titolo)" }
$TokensInput = [int64]($parts[2] -replace '[^0-9]', '')
$TokensOutput = [int64]($parts[3] -replace '[^0-9]', '')
$TokensReasoning = [int64]($parts[4] -replace '[^0-9]', '')
$TokensCacheRead = [int64]($parts[5] -replace '[^0-9]', '')
$TokensCacheWrite = [int64]($parts[6] -replace '[^0-9]', '')

$TotalActual = $TokensInput + $TokensOutput + $TokensReasoning
$TotalAll = $TotalActual + $TokensCacheRead + $TokensCacheWrite
$PctFull = [math]::Round(($TotalActual / $Threshold) * 100, 1)

$Width = 50
$BarLen = [math]::Max(1, [math]::Min($Width, [math]::Round(($TotalActual / $Threshold) * $Width)))
$Bar = ('#' * $BarLen) + ('-' * ($Width - $BarLen))

Write-Host ""
Write-Host "  TOKEN WATCH - Sessione: $SessionId" -ForegroundColor Cyan
Write-Host "  Titolo: $Title" -ForegroundColor Gray
Write-Host ""
Write-Host "  soglia: $Threshold token"
Write-Host "  [$Bar] $PctFull%"
Write-Host ""
Write-Host "  Input   : $("{0:N0}" -f $TokensInput)" -ForegroundColor Yellow
Write-Host "  Output  : $("{0:N0}" -f $TokensOutput)" -ForegroundColor Yellow
Write-Host "  Reasoning: $("{0:N0}" -f $TokensReasoning)" -ForegroundColor Yellow
Write-Host "  Cache RD: $("{0:N0}" -f $TokensCacheRead)" -ForegroundColor DarkYellow
Write-Host "  Cache WR: $("{0:N0}" -f $TokensCacheWrite)" -ForegroundColor DarkYellow
Write-Host "  ------------------------"
Write-Host "  TOTALE  : $("{0:N0}" -f $TotalActual) (attuali)" -ForegroundColor Green
Write-Host "  TOTALE  : $("{0:N0}" -f $TotalAll) (con cache)" -ForegroundColor DarkGreen
Write-Host ""

if ($TotalActual -ge $Threshold) {
  Write-Host "  ! SOGLIA RAGGIUNTA: $("{0:N0}" -f $TotalActual) >= $("{0:N0}" -f $Threshold)" -ForegroundColor Red
  Write-Host ""

  if ($Auto) {
    $Timestamp = Get-Date -Format "yyyyMMdd-HHmmss"
    $BackupFile = Join-Path -Path $BackupDir -ChildPath "snapshot-$SessionId-$Timestamp.json"

    Write-Host "  >> Creazione snapshot in corso..." -ForegroundColor Cyan
    & opencode export $SessionId > $BackupFile 2>$null

    if ((Get-Item -LiteralPath $BackupFile).Length -gt 0) {
      Write-Host "  >> Snapshot salvato: $BackupFile" -ForegroundColor Green
      Write-Host ""
      Write-Host "  >> AZIONE RICHIESTA: chiudi e riapri opencode per iniziare una nuova sessione." -ForegroundColor Cyan
      Write-Host "     La sessione esportata rimane nel database e puoi consultarla con:" -ForegroundColor Gray
      Write-Host "       opencode session list" -ForegroundColor Gray
      Write-Host "       opencode --session $SessionId --fork" -ForegroundColor Gray
    } else {
      Write-Host "  >> ERRORE: snapshot vuoto!" -ForegroundColor Red
    }
  } else {
    Write-Host "  >> Per creare snapshot ed azzerare, usa:" -ForegroundColor Cyan
    Write-Host "     .\token-watch.ps1 -Auto" -ForegroundColor White
    Write-Host "  >> Oppure il comando /token-snapshot in opencode" -ForegroundColor White
  }
} else {
  $Remaining = $Threshold - $TotalActual
  Write-Host "  >> $("{0:N0}" -f $Remaining) token rimanenti prima dello snapshot." -ForegroundColor Green
}

Write-Host ""

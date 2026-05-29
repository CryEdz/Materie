# Script di esecuzione del progetto SmartPay
# Questo script compila ed esegue l'applicazione

Write-Host "╔════════════════════════════════════════════════════════════════════╗" -ForegroundColor Cyan
Write-Host "║              SmartPay - Gestione Pagamenti                         ║" -ForegroundColor Cyan
Write-Host "╚════════════════════════════════════════════════════════════════════╝" -ForegroundColor Cyan
Write-Host ""

# Build del progetto
Write-Host "▶ Compilazione del progetto..." -ForegroundColor Yellow
dotnet build "SmartPay/SmartPay.csproj" -q

if ($LASTEXITCODE -ne 0) {
    Write-Host "✗ Errore durante la compilazione" -ForegroundColor Red
    exit 1
}

Write-Host "✓ Compilazione completata" -ForegroundColor Green
Write-Host ""

# Esecuzione del progetto
Write-Host "▶ Esecuzione dell'applicazione..." -ForegroundColor Yellow
Write-Host ""

dotnet run --project "SmartPay/SmartPay.csproj" --no-build

Write-Host ""
Write-Host "✓ Esecuzione completata" -ForegroundColor Green

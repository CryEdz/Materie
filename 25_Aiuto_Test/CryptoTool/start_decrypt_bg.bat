@echo off
REM Avvia decrypt.py in background (nessuna finestra console)
cd /d "%~dp0"
start /B pythonw.exe decrypt.py --watch --delete
echo Decryptor avviato in background (PID: %ERRORLEVEL%)

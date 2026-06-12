@echo off
REM Avvia encrypt.py in background (nessuna finestra console)
REM Imposta la directory di lavoro a quella dello script
cd /d "%~dp0"
start /B pythonw.exe encrypt.py --watch --delete
echo Encryptor avviato in background (PID: %ERRORLEVEL%)

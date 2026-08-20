for /f %%i in ('powershell -NoProfile -Command "Get-Date -Format yyyyMMdd-HHmmss"') do set TIMESTAMP=%%i
docker build -t consoleapp1:%TIMESTAMP% -t consoleapp1:latest ./ConsoleApp1.Service
pause
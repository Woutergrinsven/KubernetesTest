for /f %%i in ('powershell -NoProfile -Command "Get-Date -Format yyyyMMdd-HHmmss"') do set TIMESTAMP=%%i
docker build -t consoleapp2:%TIMESTAMP% -t consoleapp2:latest ./ConsoleApp2.Service
pause
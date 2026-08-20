set NAME=consoleapp2
docker stop %NAME%
docker rm %NAME%
docker run -d -p 8081:8080 --name %NAME% %NAME%:latest
pause
set NAME=consoleapp1
docker stop %NAME%
docker rm %NAME%
docker run -d -p 8080:8080 --name %NAME% %NAME%:latest
pause
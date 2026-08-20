kubectl apply -f .
pause
kubectl port-forward service/consoleapp2 8081:8080
pause
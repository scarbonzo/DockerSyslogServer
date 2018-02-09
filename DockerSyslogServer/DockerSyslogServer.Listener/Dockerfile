FROM microsoft/dotnet:2.0-runtime
ARG source
WORKDIR /app
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "DockerSyslogServer.Listener.dll", "192.168.50.225", "syslogs"]

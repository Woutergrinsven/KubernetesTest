# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["ConsoleApp2.Service.csproj", "ConsoleApp2.Service/"]
RUN dotnet restore "./ConsoleApp2.Service/ConsoleApp2.Service.csproj"

# Copy the rest of the source
COPY . .

# Publish the application
# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ConsoleApp2.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8081

ENTRYPOINT ["dotnet", "ConsoleApp2.Service.dll"]

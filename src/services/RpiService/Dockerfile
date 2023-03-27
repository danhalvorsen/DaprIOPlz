ARG NET_IMAGE=7.0-bullseye-slim
FROM mcr.microsoft.com/dotnet/aspnet:${NET_IMAGE} AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:${NET_IMAGE} AS build
WORKDIR /src
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
# Create this "restore-solution" section by running ./Create-DockerfileSolutionRestore.ps1, to optimize build cache reuse
COPY ["src/services/RpiService/RpiService.csproj", "src/services/RpiService/"]
COPY ["docker-compose.dcproj", "./"]
COPY ["LetThereBeIO.sln", "./"]
#RUN dotnet restore "..\LetThereBeIO.sln"
#RUN dotnet restore "RuleEngine.sln"
#RUN dotnet restore "src/libraries/general/libraries.csproj"
RUN dotnet restore "src/services/RpiService/RpiService.csproj"

COPY . .
WORKDIR "/src/src/services/RpiService"
# RUN dotnet build "Identity.API.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish --no-restore "RpiService.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RpiService.dll"]

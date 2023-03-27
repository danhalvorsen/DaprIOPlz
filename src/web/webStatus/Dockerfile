#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG NET_IMAGE=7.0-bullseye-slim
FROM mcr.microsoft.com/dotnet/aspnet:${NET_IMAGE} AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:${NET_IMAGE} AS build
WORKDIR /src
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/contracts/contracts/contracts.csproj", "src/contracts/contracts/"]
COPY ["src/services/RpiService/RpiService.csproj", "src/services/RpiService/"]
COPY ["src/web/webStatus/webStatus.csproj", "src/web/webStatus/"]
COPY ["docker-compose.dcproj", "./"]
COPY ["LetThereBeIO.sln", "./"]
#RUN dotnet restore "LetThereBeIO.sln"
COPY . .
WORKDIR "/src/src/web/webStatus"
FROM build AS publish
RUN dotnet publish --no-restore "webStatus.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webStatus.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MilitaryManager.Units.API/MilitaryManager.Units.API.csproj", "MilitaryManager.Units.API/"]
RUN dotnet restore "MilitaryManager.Units.API/MilitaryManager.Units.API.csproj"
COPY . .
WORKDIR "/src/MilitaryManager.Units.API"
RUN dotnet build "MilitaryManager.Units.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MilitaryManager.Units.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MilitaryManager.Units.API.dll"]
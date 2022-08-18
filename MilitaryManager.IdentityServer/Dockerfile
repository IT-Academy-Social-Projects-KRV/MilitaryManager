#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MilitaryManager.IdentityServer/MilitaryManager.IdentityServer.csproj", "MilitaryManager.IdentityServer/"]
RUN dotnet restore "MilitaryManager.IdentityServer/MilitaryManager.IdentityServer.csproj"
COPY . .
WORKDIR "/src/MilitaryManager.IdentityServer"
RUN dotnet build "MilitaryManager.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MilitaryManager.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MilitaryManager.IdentityServer.dll"]
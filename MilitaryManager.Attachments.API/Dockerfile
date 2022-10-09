#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
RUN apt-get update
RUN apt-get install fontconfig -y
RUN rm /usr/share/fonts/truetype -rf
RUN ln -s /app/wwwroot/fonts /usr/share/fonts/our-fonts
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MilitaryManager.Attachments.API/MilitaryManager.Attachments.API.csproj", "MilitaryManager.Attachments.API/"]
RUN dotnet restore "MilitaryManager.Attachments.API/MilitaryManager.Attachments.API.csproj"
COPY . .
WORKDIR "/src/MilitaryManager.Attachments.API"
RUN dotnet build "MilitaryManager.Attachments.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MilitaryManager.Attachments.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MilitaryManager.Attachments.API.dll"]
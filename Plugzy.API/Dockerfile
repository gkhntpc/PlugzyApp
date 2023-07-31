#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Plugzy.API/Plugzy.API.csproj", "Plugzy.API/"]
COPY ["Plugzy.Service/Plugzy.Service.csproj", "Plugzy.Service/"]
COPY ["Plugzy.Infrastructure/Plugzy.Infrastructure.csproj", "Plugzy.Infrastructure/"]
COPY ["Plugzy.Models/Plugzy.Models.csproj", "Plugzy.Models/"]
COPY ["Plugzy.Domain/Plugzy.Domain.csproj", "Plugzy.Domain/"]
COPY ["Plugzy.Utilities/Plugzy.Utilities.csproj", "Plugzy.Utilities/"]
RUN dotnet restore "Plugzy.API/Plugzy.API.csproj"
COPY . .
WORKDIR "/src/Plugzy.API"
RUN dotnet build "Plugzy.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Plugzy.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Plugzy.API.dll"]
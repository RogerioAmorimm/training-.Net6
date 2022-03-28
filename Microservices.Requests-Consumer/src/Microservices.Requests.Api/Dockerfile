#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices.Requests.Api/Microservices.Requests.Api.csproj", "Microservices.Requests.Api/"]
COPY ["Microservices.Infrastructure/Microservices.Infrastructure.csproj", "Microservices.Infrastructure/"]
COPY ["Microservices.Queries/Microservices.Queries.csproj", "Microservices.Queries/"]
COPY ["Microservices.Dto/Microservices.Dto.csproj", "Microservices.Dto/"]
COPY ["Microservices.Services/Microservices.Services.csproj", "Microservices.Services/"]
RUN dotnet restore -s "https://api.nuget.org/v3/index.json" "Microservices.Requests.Api/Microservices.Requests.Api.csproj"
COPY . .
WORKDIR "/src/Microservices.Requests.Api"
RUN dotnet build "Microservices.Requests.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservices.Requests.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Requests.Api.dll"]
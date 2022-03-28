#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices-Auth/Microservices.Auth.Api.csproj", "Microservices-Auth/"]
COPY ["Microservices.Ioc/Microservices.Ioc.csproj", "Microservices.Ioc/"]
COPY ["Microservices.Repositories/Microservices.Repositories.csproj", "Microservices.Repositories/"]
COPY ["Microservices.Dtos/Microservices.Dtos.csproj", "Microservices.Dtos/"]
COPY ["Microservices.Validators/Microservices.Validators.csproj", "Microservices.Validators/"]
COPY ["Microservices.Services/Microservices.Services.csproj", "Microservices.Services/"]
COPY ["Microservices.Domain/Microservices.Domain.csproj", "Microservices.Domain/"]
COPY ["Microservices.Data/Microservices.Data.csproj", "Microservices.Data/"]
COPY ["Microservices.Mappers/Microservices.Mappers.csproj", "Microservices.Mappers/"]
RUN dotnet restore -s "https://api.nuget.org/v3/index.json" "Microservices-Auth/Microservices.Auth.Api.csproj"
COPY . .
WORKDIR "/src/Microservices-Auth"
RUN dotnet build "Microservices.Auth.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservices.Auth.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Auth.Api.dll"]
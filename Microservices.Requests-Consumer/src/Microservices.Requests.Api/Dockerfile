#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Microservices.Requests.Api/Microservices.Requests.Api.csproj", "Microservices.Requests.Api/"]
RUN dotnet restore "Microservices.Requests.Api/Microservices.Requests.Api.csproj"
COPY . .
WORKDIR "/src/Microservices.Requests.Api"
RUN dotnet build "Microservices.Requests.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservices.Requests.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Requests.Api.dll"]
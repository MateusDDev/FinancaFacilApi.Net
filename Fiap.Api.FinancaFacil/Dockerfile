FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY Fiap.Api.FinancaFacil.sln .
COPY Fiap.Api.FinancaFacil/Fiap.Api.FinancaFacil.csproj Fiap.Api.FinancaFacil/

WORKDIR /src/Fiap.Api.FinancaFacil
RUN dotnet restore Fiap.Api.FinancaFacil.csproj

COPY . .

RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.Api.FinancaFacil.dll"]

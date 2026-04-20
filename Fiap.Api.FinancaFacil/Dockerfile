FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY *.sln .
COPY .config/ .config/
COPY Fiap.Api.FinancaFacil/Fiap.Api.FinancaFacil.csproj Fiap.Api.FinancaFacil/
COPY Fiap.Api.FinancaFacil/packages.lock.json Fiap.Api.FinancaFacil/

RUN dotnet tool restore
RUN dotnet restore Fiap.Api.FinancaFacil/Fiap.Api.FinancaFacil.csproj --locked-mode

COPY . .
WORKDIR /src/Fiap.Api.FinancaFacil
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.Api.FinancaFacil.dll"]
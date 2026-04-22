# Projeto - FinançaFácil API

API backend para gestão de finanças pessoais, desenvolvida com .NET 8 e C#, aplicando conceitos modernos de desenvolvimento e práticas de DevOps.

---

## 🚀 Como executar localmente com Docker

Para executar a aplicação localmente, é necessário ter instalado:

* Docker
* Docker Compose

### 1. Configurar variáveis de ambiente

Crie um arquivo `.env` na raiz do projeto com base no `.env.example`:

```env
ASPNETCORE_ENVIRONMENT=Local
CONNECTION_STRING=User Id=system;Password=123456;Data Source=db:1521/FREEPDB1
DB_PASSWORD=123456
JWT_KEY=sua-chave-super-secreta-aqui-123456789
JWT_ISSUER=Fiap.FinancaFacil.API
```

> **Atenção:** o ambiente `Local` utiliza **Oracle** como banco de dados (via container). O ambiente de produção (Render) utiliza **PostgreSQL**.

### 2. Subir os containers

```bash
docker-compose up --build
```

### 3. Acessar a aplicação

A API estará disponível em:

```
http://localhost:5000
```

A documentação Swagger estará em:

```
http://localhost:5000/swagger
```

> As migrations são aplicadas automaticamente no startup da aplicação.

---

## ⚙️ Pipeline CI/CD

O pipeline foi implementado com **GitHub Actions**, dividido em dois workflows independentes localizados em `.github/workflows/`:

### 🔹 CI — Integração Contínua (`ci.yml`)

Disparado a cada Pull Request e push nas branches `development` e `main`. Etapas:

1. Checkout do código
2. Setup do .NET 8
3. Restauração de dependências (`dotnet restore`)
4. Build da aplicação (`dotnet build`)
5. Execução dos testes automatizados (`dotnet test`)

### 🔹 Deploy (`deploy.yml`)

Disparado automaticamente após o sucesso do CI. Etapas:

1. Checkout do commit exato que disparou o CI (via `head_sha`)
2. Autenticação no Docker Hub
3. Build da imagem Docker com `no-cache` (garante resolução limpa de dependências)
4. Push da imagem para o Docker Hub
5. Deploy automático via webhook no Render

### 🔐 Environments

Dois ambientes configurados no GitHub Actions com secrets isolados:

| Branch | Ambiente | Destino |
|---|---|---|
| `development` | `staging` | Render staging |
| `main` | `production` | Render produção |

Cada ambiente possui seus próprios secrets (`DOCKER_IMAGE`, `DEPLOY_HOOK`), garantindo isolamento entre staging e produção.

---

## 🐳 Containerização

### Localização do Dockerfile

```
Fiap.Api.FinancaFacil/Dockerfile
```

### Estratégias adotadas

**Multi-stage build** — separa as etapas de build e runtime, garantindo que a imagem final contenha apenas o binário publicado e o runtime ASP.NET (~100MB), sem o SDK completo (~500MB).

**`packages.lock.json` com `--locked-mode`** — o arquivo de lock é commitado no repositório e utilizado no restore do Docker, garantindo que as versões dos pacotes NuGet resolvidas no container sejam exatamente as mesmas do ambiente local. Isso evita que o NuGet resolva versões mais recentes incompatíveis durante o build no CI.

**Tool manifest (`.config/dotnet-tools.json`)** — a versão do `dotnet-ef` é fixada em `8.0.5` via manifest local, evitando conflitos com versões globais instaladas na máquina ou no CI (a versão global mais recente é 10.x, incompatível com .NET 8).

**Separação de migrations por provider** — o projeto suporta Oracle e PostgreSQL com migrations isoladas:

```
Data/
  Migrations/
    Oracle/    ← geradas com UseOracle, usadas no ambiente Local
    Postgres/  ← geradas com UseNpgsql, usadas em staging e produção
```

**Variáveis de ambiente para configuração** — connection string, JWT e ambiente são todos injetados via variáveis externas, sem valores hardcoded na imagem.

---

## 🗄️ Estratégia de banco de dados

| Ambiente | Provider | Uso |
|---|---|---|
| `Local` | Oracle | Docker local |
| Qualquer outro | PostgreSQL | Render (staging e produção) |

O provider é selecionado automaticamente com base no `ASPNETCORE_ENVIRONMENT`. As migrations são aplicadas no startup da aplicação.

---

## 📸 Prints ou links do funcionamento

### 🔹 Deploy Staging

Ambiente de staging disponível em: https://financa-api-staging.onrender.com/swagger/index.html

### 🔹 Deploy Produção

Ambiente de produção disponível em: https://financa-api-prod.onrender.com/swagger/index.html

---

## 🛠️ Tecnologias utilizadas

### Backend
* .NET 8 / C#
* ASP.NET Core
* Entity Framework Core 8
* Oracle.EntityFrameworkCore
* Npgsql.EntityFrameworkCore.PostgreSQL
* AutoMapper
* BCrypt.Net
* JWT Bearer Authentication

### Banco de dados
* Oracle Database (ambiente local e faculdade)
* PostgreSQL (Render — staging e produção)

### DevOps
* GitHub Actions (CI/CD)
* Docker (multi-stage build)
* Docker Compose
* Docker Hub

### Infra / Deploy
* Render (staging e produção)

---

## ✅ Checklist de Entrega

| Item | OK |
|---|---|
| Projeto compactado em .ZIP com estrutura organizada | ✅ |
| Dockerfile funcional | ✅ |
| docker-compose.yml ou arquivos Kubernetes | ✅ |
| Pipeline com etapas de build, teste e deploy | ✅ |
| README.md com instruções e prints | ✅ |
| Documentação técnica com evidências (PDF ou PPT) | ✅ |
| Deploy realizado nos ambientes staging e produção | ✅ |
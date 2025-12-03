# Como rodar a API Fiap.Api.FinancaFacil

Existem duas formas principais de rodar o projeto: pelo Rider ou pelo Docker.

---

## 1. Rodando pelo Rider

1. Abra o projeto no **Rider**.
2. Selecione a configuração de execução da API (`Fiap.Api.FinancaFacil`).
3. Clique no botão **Run** (▶️).  
4. A aplicação vai iniciar e você poderá acessar o Swagger no navegador:

```

[http://localhost:5255/swagger](http://localhost:5255/swagger)

````

> Certifique-se de que o `ASPNETCORE_ENVIRONMENT` está definido como `Development` para que o Swagger apareça.

---

## 2. Rodando pelo Docker

### 2.1 Construir a imagem

No terminal, dentro da pasta do projeto (onde está o Dockerfile):

```bash
docker build -t fiap-api -f Fiap.Api.FinancaFacil/Dockerfile .
````

### 2.2 Rodar o container

Para rodar a API na porta **5255** do host:

```bash
docker run -p 5255:8080 -e "ASPNETCORE_ENVIRONMENT=Development" fiap-api
```

* `-p 5255:8080` → mapeia a porta interna do container (`8080`) para a porta do host (`5255`).
* `-e "ASPNETCORE_ENVIRONMENT=Development"` → habilita o Swagger.

Abra no navegador:

```
http://localhost:5255/swagger
```

### 2.3 Rodar em segundo plano (opcional)

```bash
docker run -d -p 5255:8080 --name fiap-api-container -e "ASPNETCORE_ENVIRONMENT=Development" fiap-api
```

* Para ver os logs:

```bash
docker logs -f fiap-api-container
```

* Para parar e remover:

```bash
docker stop fiap-api-container
docker rm fiap-api-container
```

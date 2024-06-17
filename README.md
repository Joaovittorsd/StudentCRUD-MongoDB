# StudentCRUD-MongoDB

Este projeto é uma aplicação CRUD (Create, Read, Update, Delete) utilizando MongoDB para gerenciar um banco de dados de estudantes. 
A aplicação foi desenvolvida utilizando ASP.NET Core e implementa endpoints para manipulação de dados dos estudantes.

## Endpoints

- **POST /create**: Criar um novo estudante.
- **GET /{id}**: Obter um estudante pelo ID.
- **GET /by-name/{name}**: Obter um estudante pelo nome.
- **PUT /{id}**: Atualizar um estudante pelo ID.
- **DELETE /{id}**: Deletar um estudante pelo ID.
- **GET /fetch**: Obter todos os estudantes.

## Configuração

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community)

### Configurando o Projeto

1. Clone o repositório:
   ```sh
   git clone https://github.com/Joaovittorsd/StudentCRUD-MongoDB.git
   cd StudentCRUD-MongoDB

2. Configure a string de conexão do MongoDB no arquivo `appsettings.json`:<br>
   {<br>
    "ConnectionStrings": {<br>
      "MongoDb": "mongodb://localhost:27017/StudentDB"<br>
    }
   }

3. Restaure as dependências e execute o projeto:<br>
   dotnet restore<br>
   donet run<br>

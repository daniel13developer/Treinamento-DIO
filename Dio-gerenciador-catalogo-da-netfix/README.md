<h1 align="center">Repositório para Gerenciador catálogolo de vídeos</h1>

Projeto para desenvolvimento e treinamento utilizando ferrramentas azure, implementar um gerenciador de catálogos  de filmes semelhantes aos de sistema usados site como exemplo Netflix. desenvolver dentro da plataforma Microsoft Azure, utilizaro banco de dados Cosmos DB.

## Feramentas utilizadas:
Platforma Microsofgt Azure
Microsoft Visual studio

### instalações necessárias
Azure Functions Core Tools

* Configuração do Ambiente
### Pré-requisitos
Conta na Azure
cadastro no Azure Devops

### recursos utilizados e criados na plataforma Microsoft Azure

* Create a Resource Group name: DIOFliX.
* Create API Managemnet service //name: apim-dioflix.
// Escolher no de consumo recurso menor consumo para testes.
* Create an Azure Cosmos DB (NOSQL) // Account Name: cosmosDBdiofix.
* Create a sorage account // name: stadioflix001 para teste em advanced selecionar permitir Allow anonymous.


# filmes:
### Estrutura a ser armazenada JSON

```json
{
  "titulo": "A volta dos que não foram",
  "video": "stadioflix/video/mp4",
  "thumb": "stadioflix/img/png",
  "detalhes": "Ganhador de um Oscar",
  "tipo": "Aventura"
}

```
## Criar 3 Azure functions:

#### fnPostDataStorage video.
#### fnPostDtaSotarge Thumb.

#### fnPostDatabase -> CosmoDB.
#### fnGetAllMovies -> CosmosDB.
#### fnGetMovieDetail -> CosmosDB.

## Link para o Bootcamp

Desenvolver o Front End para do site utilizando:  
Link para criação front end [Streamion](https://streamion.io/en/home/).  
Para novos conteúdos [Daniel Anrade](https://github.com/daniel13developer).






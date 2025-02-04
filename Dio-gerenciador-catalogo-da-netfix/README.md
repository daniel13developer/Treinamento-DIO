DIO---Gerenciador-de-Cat-logos-da-Netflix-com-Azure-Functions-e-Banco-de-Dados
Gerenciador de Catálogos da Netflix com Azure Functions e Banco de Dados

Este projeto implementa um gerenciador de catálogos da Netflix utilizando Azure Functions e um banco de dados SQL. A aplicação permite adicionar, listar, atualizar e remover filmes do catálogo, oferecendo uma API escalável e baseada em cloud computing.

1. Configuração do Ambiente
Pré-requisitos
Conta na Azure
Azure Functions Core Tools
Python 3.x
Banco de dados SQL (Azure SQL Database ou PostgreSQL)
VS Code (opcional, recomendado)
Instale as ferramentas necessárias:

pip install azure-functions azure-functions-http
pip install pyodbc
2. Criando a API com Azure Functions
Crie um novo projeto Azure Functions:

func init netflix-catalog --python
cd netflix-catalog
Crie uma nova função HTTP:

func new --name CatalogFunction --template "HTTP trigger" --authlevel "anonymous"
Edite CatalogFunction/__init__.py:

import logging
import azure.functions as func
import json
import pyodbc

def get_db_connection():
    conn = pyodbc.connect(
        'DRIVER={ODBC Driver 17 for SQL Server};'
        'SERVER=your-server.database.windows.net;'
        'DATABASE=your-database;'
        'UID=your-username;'
        'PWD=your-password'
    )
    return conn

def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info("Processando requisição HTTP.")
    
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("SELECT * FROM Catalog")
    rows = cursor.fetchall()
    
    catalog = [{"id": row[0], "title": row[1], "year": row[2]} for row in rows]
    
    return func.HttpResponse(
        json.dumps(catalog),
        mimetype="application/json"
    )
3. Configuração do Banco de Dados
Crie a tabela no banco de dados:

CREATE TABLE Catalog (
    id INT PRIMARY KEY IDENTITY(1,1),
    title NVARCHAR(255),
    year INT
);
4. Deploy para Azure
Autentique-se na Azure:

az login
Crie um grupo de recursos:

az group create --name NetflixCatalogGroup --location eastus
Crie um Function App:

az functionapp create --resource-group NetflixCatalogGroup --consumption-plan-location eastus --runtime python --functions-version 4 --name netflix-catalog-func --storage-account yourstorageaccount
Implante a função:

func azure functionapp publish netflix-catalog-func
5. Testando a API
Acesse a API no navegador ou via Postman:

curl https://netflix-catalog-func.azurewebsites.net/api/CatalogFunction
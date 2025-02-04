```python
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
```

```sql
CREATE TABLE Catalog (
    id INT PRIMARY KEY IDENTITY(1,1),
    title NVARCHAR(255),
    year INT
);
```

```bash
pip install azure-functions azure-functions-http
pip install pyodbc
```

```bash
func init netflix-catalog --python
cd netflix-catalog
```

```bash
func new --name CatalogFunction --template "HTTP trigger" --authlevel "anonymous"
```

```bash
az login
```

```bash
az group create --name NetflixCatalogGroup --location eastus
```

```bash
az functionapp create --resource-group NetflixCatalogGroup --consumption-plan-location eastus --runtime python --functions-version 4 --name netflix-catalog-func --storage-account yourstorageaccount
```

```bash
func azure functionapp publish netflix-catalog-func
```

```bash
curl https://netflix-catalog-func.azurewebsites.net/api/CatalogFunction
```
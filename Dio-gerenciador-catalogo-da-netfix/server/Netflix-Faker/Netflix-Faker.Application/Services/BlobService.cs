using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Netflix_Faker.Domain.Dtos;
using Netflix_Faker.Domain.Interfaces;
using Netflix_Faker.Domain.Interfaces.Repositories;

namespace Netflix_Faker.Application.Services
{
    public class BlobService : IBlobService
    {
        private readonly string _ConnectionString = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";
        private readonly ICatalogoRepository _catalogoRepository;

        public BlobService(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        public async Task<string> GetBlobUrlWithSas(string blobName, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(_ConnectionString);

            // Cria um objeto CloudBlobClient
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            var blob = container.GetBlobReference(blobName);

            var exists = await blob.ExistsAsync();
            if (!exists) return string.Empty;

            var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(1),
                Permissions = SharedAccessBlobPermissions.Read
            });

            return blob.Uri + sasToken;
        }

        public List<string> GetMany(string stringBlobNameList, string containerName)
        {
            var blobNames = stringBlobNameList.Split(',').ToList();
            var blobUrls = new List<string>();

            foreach (var blobName in blobNames)
            {
                var blobUrl = GetBlobUrlWithSas(blobName, containerName).Result;

                if (!string.IsNullOrEmpty(blobUrl))
                {
                    blobUrls.Add(blobUrl);
                }
            }

            return blobUrls;
        }

        public string GetSpecific(string blobName, string containerName)
        {
            var blobUrl = GetBlobUrlWithSas(blobName, containerName).Result;
            return blobUrl;
        }

        public async Task<string> Upload(IFormFile formFile, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(_ConnectionString);

            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();

            var blobName = formFile.FileName; // Gera um ID único
            var blob = container.GetBlockBlobReference(blobName);

            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();

            await blob.UploadFromByteArrayAsync(fileBytes, 0, fileBytes.Length);

            // Gera o SAS Token para o blob
            string sasToken = GenerateSasToken(blob);

            return blobName;
        }

        private static string GenerateSasToken(CloudBlockBlob blob)
        {
            var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(1), // Expira em 1 hora
                Permissions = SharedAccessBlobPermissions.Read // Apenas leitura
            });
            return sasToken;
        }

        public string GenerateSasUrl(string containerName, string blobName)
        {
            var blobServiceClient = new BlobServiceClient(_ConnectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(blobName);

            // Criando o SAS para o blob
            var blobSasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)  // Tempo de expiração do SAS
            };

            // Definir permissões para leitura (Read) no blob
            blobSasBuilder.SetPermissions(BlobSasPermissions.Read);

         
            var sasToken = blobSasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential("devstoreaccount1", "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==")).ToString();
            var sasUrl = blobClient.Uri.AbsoluteUri + "?" + sasToken;

            // Gerar a URL com o SAS
            var sasUri = blobClient.GenerateSasUri(blobSasBuilder);
            return sasUri.ToString();
        }

        public async Task<string> Upload(Stream fileStream, string fileName, string containerName)
        {
            // Criando a referência para a conta de armazenamento e o blob client
            var storageAccount = CloudStorageAccount.Parse(_ConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Criando ou acessando o container
            var container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();

            // Usando o nome do arquivo para o blob (pode ser modificado para gerar um ID único)
            var blob = container.GetBlockBlobReference(fileName);

            // Fazer o upload do arquivo diretamente do stream
            await blob.UploadFromStreamAsync(fileStream);

            // Gerar o SAS Token para acesso temporário ao blob
            var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(1), // Expira em 1 hora
                Permissions = SharedAccessBlobPermissions.Read // Apenas leitura
            });

            // Construir a URL do blob com o SAS Token
            var blobUrlWithSas = blob.Uri + sasToken;

            // Retornar a URL completa com o SAS Token
            return blobUrlWithSas;
        }

        public async Task<bool> Delete(string fileName, string containerName)
        {
            try
            {
                // Criando a referência para a conta de armazenamento e o blob client
                var storageAccount = CloudStorageAccount.Parse(_ConnectionString);
                var blobClient = storageAccount.CreateCloudBlobClient();

                // Criando ou acessando o container
                var container = blobClient.GetContainerReference(containerName);

                // Referência para o blob que será removido
                var blob = container.GetBlockBlobReference(fileName);

                // Tenta excluir o blob, caso ele exista
                bool deleted = await blob.DeleteIfExistsAsync();

                if (deleted)
                {
                    // Se o arquivo foi excluído com sucesso
                    return true;
                }
                else
                {
                    // Caso o arquivo não tenha sido encontrado ou não tenha sido excluído
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log ou tratamento de exceção
                Console.WriteLine($"Erro ao tentar excluir o arquivo {fileName}: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<CatalogoDTO>> GetFilmes(string containerName)
        {
            var categorias = await _catalogoRepository.GetMoviesByGenreAsync();

            foreach (var categoria in categorias)
            {
                foreach(var filme in categoria.Filmes)
                {
                    filme.Url = GenerateSasUrl(containerName, filme.Url);
                }
            }

            return categorias;
        }
    }
}



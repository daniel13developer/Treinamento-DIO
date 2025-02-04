using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Netflix_Faker.Domain.Dtos;

namespace Netflix_Faker.Domain.Interfaces
{
    public interface IBlobService
    {
        Task<string> Upload(Stream formFile, string fileName, string containerName);
        Task<string> Upload(IFormFile formFile, string containerName);
        string GetSpecific(string blobName, string containerName);
        List<string> GetMany(string stringBlobNameList, string containerName);
        Task<string> GetBlobUrlWithSas(string blobName, string containerName);
        Task<bool> Delete(string fileName, string containerName);
        Task<IEnumerable<CatalogoDTO>> GetFilmes(string containerName);
    }
}

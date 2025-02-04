using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Netflix_Faker.Domain.Interfaces;
using Netflix_Faker.Domain.Interfaces.Repositories;

namespace Netflix_Faker.Functions.Catalogo
{
    public class GetCatalogoFunction
    {
        private readonly ILogger<GetCatalogoFunction> _logger;
        private readonly ICatalogoRepository _catalogoRepository;
        private readonly IBlobService _blobService;
        private const string ContainerName = "catalogo";
        public GetCatalogoFunction(ILogger<GetCatalogoFunction> logger, ICatalogoRepository catalogoRepository, IBlobService blobService)
        {
            _logger = logger;
            _catalogoRepository = catalogoRepository;
            _blobService = blobService;
        }

        [Function("catalogo")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            //var catalogo = await _catalogoRepository.GetMoviesByGenreAsync();

            var catalogo = await _blobService.GetFilmes(ContainerName);

            return new OkObjectResult(catalogo);
        }
    }
}

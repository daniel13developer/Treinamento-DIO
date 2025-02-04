using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netflix_Faker.Domain.Dtos;
using Netflix_Faker.Domain.Entities;

namespace Netflix_Faker.Domain.Interfaces.Repositories
{
    public interface ICatalogoRepository
    { 
        // Método para adicionar um novo filme
        Task AddMovieAsync(CatalogoModel movie);

        // Método para encontrar filmes por gênero
        Task<IEnumerable<CatalogoDTO>> GetMoviesByGenreAsync();
    }
}

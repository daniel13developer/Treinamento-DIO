using Microsoft.EntityFrameworkCore;
using Netflix_Faker.Domain.Dtos;
using Netflix_Faker.Domain.Entities;
using Netflix_Faker.Domain.Interfaces.Repositories;
using Netflix_Faker.Infrastructure.Data;

public class CatalogoRepository : ICatalogoRepository
{
    private readonly AppDbContext _context;

    public CatalogoRepository(AppDbContext context)
    {
        _context = context;
    }

    // Método para adicionar um novo filme
    public async Task AddMovieAsync(CatalogoModel movie)
    {
        // Adiciona o novo filme no banco de dados
        await _context.Catalogo.AddAsync(movie);
        await _context.SaveChangesAsync(); // Salva as alterações no banco
    }

    // Método para encontrar filmes por gênero
    public async Task<IEnumerable<CatalogoModel>> GetMoviesByGenreAsync(string genre)
    {
        // Retorna filmes filtrados por gênero
        return await _context.Catalogo
            .Where(movie => movie.Genero == genre) // Filtro pelo gênero
            .ToListAsync(); // Converte para lista assíncrona
    }

    public async Task<IEnumerable<CatalogoDTO>> GetMoviesByGenreAsync()
    {
        return await _context.Catalogo
            .AsNoTracking()
            .GroupBy(x => x.Genero)
            .Select(x => new CatalogoDTO(x.Key.ToString(), x.Select(s => new FilmesDto(s.Url, s.Nome, s.Genero, s.Id)).ToList()))
            .ToListAsync();
            
    }
}
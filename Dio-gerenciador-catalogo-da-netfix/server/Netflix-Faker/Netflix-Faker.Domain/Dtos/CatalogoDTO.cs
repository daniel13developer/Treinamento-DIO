using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix_Faker.Domain.Dtos
{
    public class FilmesDto
    {
        public FilmesDto(string url, string nome, string genero, int id)
        {
            Url = url;
            Nome = nome;
            Genero = genero;
            Id = id;
        }

        public string Url { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public int Id { get; set; }
    }

    public class CatalogoDTO
    {
        public CatalogoDTO(string nomeDoGrupo, List<FilmesDto> filmes)
        {
            NomeDoGrupo = nomeDoGrupo;
            Filmes = filmes;
        }

        public string NomeDoGrupo { get; set; }
        public List<FilmesDto> Filmes { get; set; }
    }
}

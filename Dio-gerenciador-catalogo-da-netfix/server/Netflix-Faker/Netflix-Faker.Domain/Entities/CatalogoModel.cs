using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix_Faker.Domain.Entities
{
    public class CatalogoModel
    {
        public CatalogoModel()
        {
            
        }
        public CatalogoModel(string nome, string genero, string url)
        {
            Nome = nome;
            Genero = genero;
            Url = url;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Url { get; set; }
    }
}

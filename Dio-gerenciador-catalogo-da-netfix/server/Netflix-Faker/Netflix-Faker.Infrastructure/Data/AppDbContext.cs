using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Netflix_Faker.Domain.Entities;

namespace Netflix_Faker.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CatalogoModel> Catalogo { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Catalogo
            builder.Entity<CatalogoModel>()
                .HasKey(t => t.Id);  // Chave primária

            builder.Ignore<ValidationResult>();
        }
    }
}

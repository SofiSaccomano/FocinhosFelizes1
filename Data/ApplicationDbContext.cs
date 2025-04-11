using FocinhosFelizes1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FocinhosFelizes1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doador> Doadores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<RegistroDoacao> RegistroDoacoes { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Doador>().ToTable("Doadores");
            builder.Entity<Categoria>().ToTable("Categorias");
            builder.Entity<Produtos>().ToTable("Produtos");
            builder.Entity<RegistroDoacao>().ToTable("RegistroDoacoes");
            builder.Entity<Estoque>().ToTable("Estoques");
        }
    }
}
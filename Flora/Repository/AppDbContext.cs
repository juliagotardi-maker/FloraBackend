using Flora.Models;
using Microsoft.EntityFrameworkCore;

namespace Flora.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario_flora> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<MinhasCompras> MinhasCompras { get; set; }
        public DbSet<Itens> Itens { get; set; }
    }
}
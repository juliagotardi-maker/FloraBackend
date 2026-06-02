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
    }
}
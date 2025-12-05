using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Anagrafica> Anagrafiche { get; set; }
        public DbSet<TipoViolazione> TipiViolazione { get; set; }
        public DbSet<Verbale> Verbali { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData.Seed(modelBuilder);
        }

    }
}

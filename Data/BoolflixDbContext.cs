using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using csharp_boolflix.Models;

namespace csharp_boolflix.Data
{
    public class BoolflixDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<Stagione> Stagioni { get; set; }
        public DbSet<Episodio> Episodi { get; set; }
        public DbSet<Caratteristica> Caratteristiche { get; set; }
        public DbSet<Genere> Generi { get; set; }
        public DbSet<Attore> Attori { get; set; }
        public DbSet<Regia> Registi { get; set; }
        public BoolflixDbContext(DbContextOptions<BoolflixDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

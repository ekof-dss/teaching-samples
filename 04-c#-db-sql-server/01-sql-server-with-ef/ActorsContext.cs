
using Microsoft.EntityFrameworkCore;

namespace HelloConsoleEF
{
  public class ActorsContext : DbContext
  {
    public DbSet<Actor> Actor { get; set; }

    public DbSet<Country> Country { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=localhost,1433; Database=DSS.Actors; Trusted_Connection=True; TrustServerCertificate=True; Connect Timeout=10");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Country>(entity =>
      {
        entity.HasKey(e => e.CountryId);
        entity.Property(e => e.Name).IsRequired();
      });

      modelBuilder.Entity<Actor>(entity =>
      {
        entity.HasOne(d => d.Country)
          .WithMany(p => p.Actors);
      });
    }
  }
}

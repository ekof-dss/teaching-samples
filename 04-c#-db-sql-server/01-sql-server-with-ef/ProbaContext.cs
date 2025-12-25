
using Microsoft.EntityFrameworkCore;

namespace HelloConsoleEF
{
  public class ProbaContext : DbContext
  {
    public DbSet<Actor> Actor { get; set; }

    public DbSet<Country> Country { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Data Source=localhost;database=skole;User CountryId=sa;Password=MsSql@123;TrustServerCertificate=True;Encrypt=False;Connect Timeout=30");
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

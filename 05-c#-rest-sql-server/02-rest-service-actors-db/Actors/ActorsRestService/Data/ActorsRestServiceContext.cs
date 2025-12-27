using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActorsRestService.Models;

namespace ActorsRestService.Data
{
    public class ActorsRestServiceContext : DbContext
    {
        public ActorsRestServiceContext (DbContextOptions<ActorsRestServiceContext> options)
            : base(options)
        {
        }

        
        public DbSet<Actor> Actor { get; set; } = default!;

        public DbSet<Country> Country { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            { 
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Actors);
            });
        }
    }
}

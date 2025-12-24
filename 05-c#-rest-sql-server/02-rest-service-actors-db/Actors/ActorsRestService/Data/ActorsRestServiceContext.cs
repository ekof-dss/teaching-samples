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

        public DbSet<ActorsRestService.Models.Actor> Actor { get; set; } = default!;
    }
}

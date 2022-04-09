using Microsoft.EntityFrameworkCore;
using PatintIS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatintIS.Persistence
{
    public class PatintDbContext:DbContext
    {
        public PatintDbContext(DbContextOptions<PatintDbContext> options)
           : base(options)
        {
        }
        public DbSet<Patint> patints { get; set; }
    }
}

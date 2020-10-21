using Microsoft.EntityFrameworkCore;
using System;

namespace AircraftData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Aircraft> Aircrafts { get; set; }

    }

}

using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using PlantApi.Entities;

namespace PlantApi.Data
{
    public class PlantContext : DbContext
    {
        public PlantContext(DbContextOptions<PlantContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PlantGrowZone>().HasKey(pgz => new { pgz.PlantFactId, pgz.GrowZoneId });
        //}

        public DbSet<PlantFact> PlantFacts { get; set; }
        public DbSet<GrowZone> GrowZones { get; set; }
        public DbSet<PlantGrowZone> PlantGrowZones { get; set; }
    }
}
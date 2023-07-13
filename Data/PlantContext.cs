using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using PlantApi.Models;

namespace PlantApi.Data
{
    public class PlantContext : DbContext
    {
        public PlantContext(DbContextOptions<PlantContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlantGrowZone>().HasKey(PlantGrowZone => new { PlantGrowZone.Id, PlantGrowZone.GrowZoneId });
        }

        public DbSet<PlantFact> PlantFacts { get; set; }
        public DbSet<GrowZone> GrowZones { get; set; }
        public DbSet<PlantGrowZone> PlantGrowZones { get; set; }
    }
}
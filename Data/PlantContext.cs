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

        public DbSet<PlantFact> PlantFacts { get; set; }
    }
}
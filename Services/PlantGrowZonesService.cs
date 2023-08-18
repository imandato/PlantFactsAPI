using System;
using Microsoft.EntityFrameworkCore;
using PlantApi.Data;
using PlantApi.Interfaces;
using PlantApi.Entities;

namespace PlantApi.Services
{
    public class PlantGrowZonesService : IPlantGrowZonesService
    {
        private readonly PlantContext _context;

        public PlantGrowZonesService(PlantContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PlantGrowZone>> GetAllPlantGrowZones()
        {
            return await _context.PlantGrowZones.ToListAsync();
        }
        public async Task<PlantGrowZone?> GetPlantGrowZone(long id)
        {
            PlantGrowZone? plantGrowZone = await _context.PlantGrowZones.FindAsync(id);

            return plantGrowZone;
        }

        public async Task<PlantGrowZone> PutPlantGrowZone(long id, PlantGrowZone plantGrowZone)
        {

            _context.Entry(plantGrowZone).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return plantGrowZone;
        }

        public async Task<PlantGrowZone?> PostPlantGrowZone(PlantGrowZone plantGrowZone)
        {
            _context.PlantGrowZones.Add(plantGrowZone);
            await _context.SaveChangesAsync();

            return plantGrowZone;
        }

        public async Task<bool> DeletePlantGrowZone(long id)
        {
            PlantGrowZone? plantGrowZone = await _context.PlantGrowZones.FindAsync(id);

            if (plantGrowZone is not null)
            {
                _context.PlantGrowZones.Remove(plantGrowZone);
            }
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

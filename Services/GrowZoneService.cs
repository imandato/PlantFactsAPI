using System;
using Microsoft.EntityFrameworkCore;
using PlantApi.Data;
using PlantApi.Interfaces;
using PlantApi.Entities;

namespace PlantApi.Services
{
    public class GrowZoneService : IGrowZoneService
    {
        private readonly PlantContext _context;

        public GrowZoneService(PlantContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GrowZone>> GetAllGrowZones()
        {
            return await _context.GrowZones.ToListAsync();
        }
        public async Task<GrowZone?> GetGrowZone(long id)
        {
            GrowZone? growZone = await _context.GrowZones.FindAsync(id);

            return growZone;
        }

        public async Task<GrowZone> PutGrowZone(long id, GrowZone growZone)
        {

            _context.Entry(growZone).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return growZone;
        }

        public async Task<GrowZone?> PostGrowZone(GrowZone growZone)
        {
            _context.GrowZones.Add(growZone);
            await _context.SaveChangesAsync();

            return growZone;
        }

        public async Task<bool> DeleteGrowZone(long id)
        {
            GrowZone? growZone = await _context.GrowZones.FindAsync(id);

            if (growZone is not null)
            {
                _context.GrowZones.Remove(growZone);
            }
            return await _context.SaveChangesAsync() > 0;
        }  
    }
}

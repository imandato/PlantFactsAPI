using System;
using Microsoft.EntityFrameworkCore;
using PlantApi.Data;
using PlantApi.Interfaces;
using PlantApi.Models;

namespace PlantApi.Services
{
    public class PlantService : IPlantService
    {
        private readonly PlantContext _context;

        public PlantService(PlantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlantFact>> GetAllPlantFacts()
        {
            return await _context.PlantFacts.ToListAsync();
        }

        public async Task<bool> DeletePlantFact(long id)
        {

            PlantFact? plantFact = await _context.PlantFacts.FindAsync(id);

            if (plantFact is not null)
            {
                _context.PlantFacts.Remove(plantFact);
            }
            return await _context.SaveChangesAsync()>0;

        }

        public async Task<PlantFact?> GetPlantFact(long id)
        {
            PlantFact? plantFact = await _context.PlantFacts.FindAsync(id);

            return plantFact;
        }

        //public Task<PlantFact> PlantFactExists(long id)
        //{
        //    return _context.PlantFacts.Any(e => e.Id == id);
        //}

        public async Task<PlantFact?> PostPlantFact(PlantFact plantFact)
        {
            _context.PlantFacts.Add(plantFact);
            await _context.SaveChangesAsync();

            return plantFact;
        }

        public async Task<PlantFact> PutPlantFact(long id, PlantFact plantFact)
        {
            
            _context.Entry(plantFact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return plantFact;
            
            
        }
    }
}


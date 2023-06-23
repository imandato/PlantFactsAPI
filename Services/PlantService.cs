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

        //public PlantFact DeletePlantFact(long id)
        //{
        //    if (_context.PlantFacts == null)
        //    {
        //        return NotFound();
        //    }

        //    var plantFact = _context.PlantFacts.FindAsync(id);
        //    if (plantFact == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PlantFacts.Remove(plantFact);
        //    _context.SaveChangesAsync();

        //    return NoContent();
        //}

        public async Task<PlantFact?> GetPlantFact(long id)
        {
            PlantFact? plantFact = await _context.PlantFacts.FindAsync(id);

            return plantFact;
        }

        //public IEnumerable<PlantFact> GetPlantFacts()
        //{
        //    return await _context.PlantFacts.ToListAsync();
        //}

        //public PlantFact PlantFactExists(long id)
        //{
        //    return (_context.PlantFacts?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        //public async Task<PlantFact?> PostPlantFact()
        //{
        //    PlantFact? plantFact =  _context.PlantFacts.Add(plantFact);
        //    await _context.SaveChangesAsync();

        //    return plantFact;
        //}

        //public PlantFact PutPlantFact(long id, PlantFact plantFact)
        //{
        //    if (id != plantFact.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(plantFact).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlantFactExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
    }
}


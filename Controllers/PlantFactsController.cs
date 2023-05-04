using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  
using PlantApi.Data;
using PlantApi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantFactsController : ControllerBase
    {
        private readonly PlantContext _context;

        public PlantFactsController(PlantContext context)
        {
            _context = context;
        }

        // GET: all plant facts
        [HttpGet] //just for using with swagger to test
        public async Task<ActionResult<IEnumerable<PlantFact>>> GetPlantFacts()
        {

            return await _context.PlantFacts.ToListAsync();
        }

        // GET: based on id
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantFact>> GetPlantFact(long id)
        {
            if (_context.PlantFacts == null)
            {
                return NotFound();
            }
            var plantFact = await _context.PlantFacts.FindAsync(id);

            if (plantFact == null)
            {
                return NotFound();
            }
            return plantFact;
        }


        //PUT: based on id as well
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantFact(long id, PlantFact plantFact)
        {
            if (id != plantFact.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantFact).State = EntityState.Modified;

            try
            {
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantFactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<PlantFact>> PostPlantFact(PlantFact plantFact)
        {
            if (_context.PlantFacts == null)
            {
                return Problem("Entity set 'PlantContext.PlantFacts' is null.");
            }

            _context.PlantFacts.Add(plantFact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlantFact), new { id = plantFact.Id }, plantFact);
        }

        //DELETE: based on id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantFact(long id)
        {
            if (_context.PlantFacts == null)
            {
                return NotFound();
            }

            var plantFact = await _context.PlantFacts.FindAsync(id);
            if (plantFact == null)
            {
                return NotFound();
            }

            _context.PlantFacts.Remove(plantFact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //to check the plant fact in the try catch statement in PUT
        private bool PlantFactExists(long id)
        {
            return (_context.PlantFacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}


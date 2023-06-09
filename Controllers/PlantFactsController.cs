﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  
using PlantApi.Data;
using PlantApi.Interfaces;
using PlantApi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantFactsController : ControllerBase
    {
        private readonly PlantContext _context;
        private readonly IPlantService _plantService;

        public PlantFactsController(PlantContext context, IPlantService plantService)
        {
            _context = context;
            _plantService = plantService;
        }

        // GET: all plant facts
        [HttpGet] //just for using with swagger to test
        [ProducesResponseType(typeof(IEnumerable<PlantFact>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPlantFacts()
        {

            return new OkObjectResult(await _plantService.GetAllPlantFacts()); 
        }

        // GET: based on id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlantFact),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlantFact(long id)
        {

            PlantFact? plantFact = await _plantService.GetPlantFact(id);

            if (plantFact is null)
            {
                return NotFound();
            }
            return new OkObjectResult(plantFact);
        }


        //PUT: based on id as well
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PlantFact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutPlantFact(long id, PlantFact plantFact)
        {
            try
            {
                await _plantService.PutPlantFact(id, plantFact);
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
        [ProducesResponseType(typeof(PlantFact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostPlantFact(PlantFact plantFact)
        {

            await _plantService.PostPlantFact(plantFact);

            return CreatedAtAction(nameof(GetPlantFact), new { id = plantFact.Id }, null);
        }

        //DELETE: based on id
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PlantFact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePlantFact(long id)
        {
          
            PlantFact? plantFact = (PlantFact?)await _plantService.DeletePlantFact(id);

            if (plantFact == null)
            {
                return NotFound();
            }

            return new OkObjectResult(plantFact);
        }

        //to check the plant fact in the try catch statement in PUT
        private bool PlantFactExists(long id)
        {
            return (_context.PlantFacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}


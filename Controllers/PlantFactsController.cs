using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  
using PlantApi.Data;
using PlantApi.Interfaces;
using PlantApi.Entities;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantFactsController : ControllerBase
    {
        private readonly PlantContext _context;
        private readonly IPlantService _plantService;
        private readonly ILogger<PlantFactsController> _logger;

        public PlantFactsController(PlantContext context, IPlantService plantService, ILogger<PlantFactsController> logger)
        {
            _context = context;
            _plantService = plantService;
            _logger = logger;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutPlantFact(long id, PlantFact plantFact)
        {
            try
            {
                await _plantService.PutPlantFact(id, plantFact);
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                if (_plantService.GetPlantFact(id) is null)
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(dbEx, "exception happened in plant fact controller put method");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "exception happened in plant fact controller put method");
            }
          
            return NoContent();
        }

        //POST
        [HttpPost]
        [ProducesResponseType(typeof(PlantFact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostPlantFact(PlantFact plantFact)
        {
            try
            {
                await _plantService.PostPlantFact(plantFact);

                return CreatedAtAction(nameof(GetPlantFact), new { id = plantFact.Id }, null);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "exception happened in plant fact controller plant fact put method");
            }

            return NoContent();
        }

        //DELETE: based on id
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePlantFact(long id)
        {
            return new OkObjectResult(await _plantService.DeletePlantFact(id));
        }
    }
}


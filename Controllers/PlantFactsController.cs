using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  
using PlantApi.Data;
using PlantApi.Interfaces;
using PlantApi.Models;
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
                    _logger.LogError(dbEx, "exception happened in plant fact controller plant fact put method");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "exception happened in plant fact controller plant fact put method");
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
            return new OkObjectResult(await _plantService.DeletePlantFact(id));
        }

        //GROW ZONE TABLE

        // GET: all GrowZones
        [HttpGet] //just for using with swagger to test
        [ProducesResponseType(typeof(IEnumerable<GrowZone>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGrowZones()
        {

            return new OkObjectResult(await _plantService.GetAllGrowZones());
        }

        // GET: GrowZone based on id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GrowZone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGrowZone(long id)
        {

            GrowZone? growZone = await _plantService.GetGrowZone(id);

            if (growZone is null)
            {
                return NotFound();
            }
            return new OkObjectResult(growZone);
        }

        //PUT: based on id as well
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GrowZone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutGrowZone(long id, GrowZone growZone)
        {
            try
            {
                await _plantService.PutGrowZone(id, growZone);
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                if (_plantService.GetGrowZone(id) is null)
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(dbEx, "exception happened in plant fact controller Grow Zone put method");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "exception happened in plant fact controller Grow Zone put method");
            }

            return NoContent();
        }
    }
}


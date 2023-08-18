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

namespace PlantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantGrowZonesController : Controller
    {
        private readonly PlantContext _context;
        private readonly IPlantGrowZonesService _plantGrowZonesService;
        private readonly ILogger<PlantGrowZonesController> _logger;

        public PlantGrowZonesController(PlantContext context, IPlantGrowZonesService plantGrowZonesService, ILogger<PlantGrowZonesController> logger)
        {
            _context = context;
            _plantGrowZonesService = plantGrowZonesService;
            _logger = logger;
        }

        // GET: all GrowZones
        [HttpGet] //just for using with swagger to test
        [ProducesResponseType(typeof(IEnumerable<PlantGrowZone>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPlantGrowZones()
        {
            return new OkObjectResult(await _plantGrowZonesService.GetAllPlantGrowZones());
        }

        // GET: GrowZone based on id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlantGrowZone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlantGrowZone(long id)
        {

            PlantGrowZone? plantGrowZone = await _plantGrowZonesService.GetPlantGrowZone(id);

            if (plantGrowZone is null)
            {
                return NotFound();
            }
            return new OkObjectResult(plantGrowZone);
        }

        //PUT: based on id as well
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PlantGrowZone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutPlantGrowZone(long id, PlantGrowZone plantGrowZone)
        {
            try
            {
                await _plantGrowZonesService.PutPlantGrowZone(id, plantGrowZone);
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                if (_plantGrowZonesService.GetPlantGrowZone(id) is null)
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

        //POST
        [HttpPost]
        [ProducesResponseType(typeof(PlantGrowZone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostPlantGrowZone(PlantGrowZone plantGrowZone)
        {

            await _plantGrowZonesService.PostPlantGrowZone(plantGrowZone);

            return CreatedAtAction(nameof(GetPlantGrowZone), new { id = plantGrowZone.Id }, null);
        }

        //DELETE: based on id
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PlantGrowZone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePlantGrowZone(long id)
        {
            return new OkObjectResult(await _plantGrowZonesService.DeletePlantGrowZone(id));
        }
    }
}

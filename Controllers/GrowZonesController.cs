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
    public class GrowZonesController : Controller
    {
        private readonly PlantContext _context;
        private readonly IGrowZoneService _growZoneService;
        private readonly ILogger<GrowZonesController> _logger;

        public GrowZonesController(PlantContext context, IGrowZoneService growZoneService, ILogger<GrowZonesController> logger)
        {
            _context = context;
            _growZoneService = growZoneService;
            _logger = logger;
        }

        // GET: all GrowZones
        [HttpGet] //just for using with swagger to test
        [ProducesResponseType(typeof(IEnumerable<GrowZone>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGrowZones()
        {
            return new OkObjectResult(await _growZoneService.GetAllGrowZones());
        }

        // GET: GrowZone based on id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GrowZone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGrowZone(long id)
        {

            GrowZone? growZone = await _growZoneService.GetGrowZone(id);

            if (growZone is null)
            {
                return NotFound();
            }
            return new OkObjectResult(growZone);
        }

        //PUT: based on id as well
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GrowZone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutGrowZone(long id, GrowZone growZone)
            {
            try
            {
                await _growZoneService.PutGrowZone(id, growZone);
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                if (_growZoneService.GetGrowZone(id) is null)
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
        [ProducesResponseType(typeof(GrowZone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostGrowZone(GrowZone growZone)
        {

            await _growZoneService.PostGrowZone(growZone);

            return CreatedAtAction(nameof(GetGrowZone), new { id = growZone.GrowZoneId }, null);
        }

        //DELETE: based on id
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(GrowZone), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGrowZone(long id)
        {
            return new OkObjectResult(await _growZoneService.DeleteGrowZone(id));
        }        
        
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PlantApi.Data;
//using PlantApi.Models;

//namespace PlantApi.Services
//{
//	public class PlantRepository : ControllerBase
//	{

//        private readonly PlantContext _context;

//        public PlantRepository(PlantContext context)
//        {
//            _context = context;
//        }


//        public async Task<ActionResult<IEnumerable<PlantFact>>> GetPlantFacts()
//        {

//            return await _context.PlantFacts.ToListAsync();
//        }

//        public async Task<ActionResult<PlantFact>> GetPlantFact(long id)
//        {
//            if (_context.PlantFacts == null)
//            {
//                return NotFound();
//            }
//            var plantFact = await _context.PlantFacts.FindAsync(id);

//            if (plantFact == null)
//            {
//                return NotFound();
//            }
//            return plantFact;
//        }
//    }
//}


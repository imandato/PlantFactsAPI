using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using PlantApi.Data;
using PlantApi.Models;

namespace PlantApi.Interfaces
{
    public interface IPlantService
    {

        Task<IEnumerable<PlantFact>> GetAllPlantFacts();
        Task<PlantFact?> GetPlantFact(long id);
        Task<PlantFact> PutPlantFact(long id, PlantFact plantFact);
        Task<PlantFact> PostPlantFact(PlantFact plantFact);
        Task<PlantFact?> DeletePlantFact(long id);
        //bool PlantFactExists(long id);

        Task<IEnumerable<GrowZone>> GetAllGrowZones();

    }
}


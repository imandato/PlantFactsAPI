using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlantApi.Entities;

namespace PlantApi.Interfaces
{
    public interface IPlantService
    {
        Task<IEnumerable<PlantFact>> GetAllPlantFacts();
        Task<PlantFact?> GetPlantFact(long id);
        Task<PlantFact> PutPlantFact(long id, PlantFact plantFact);
        Task<PlantFact?> PostPlantFact(PlantFact plantFact);
        Task<bool> DeletePlantFact(long id);

    }
}


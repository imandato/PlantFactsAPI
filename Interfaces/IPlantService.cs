using System;
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
        //PlantFact DeletePlantFact(long id);
        //PlantFact PlantFactExists(long id);



    }
}


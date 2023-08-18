using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlantApi.Entities;

namespace PlantApi.Interfaces
{
    public interface IPlantGrowZonesService
    {
        Task<IEnumerable<PlantGrowZone>> GetAllPlantGrowZones();
        Task<PlantGrowZone?> GetPlantGrowZone(long id);
        Task<PlantGrowZone> PutPlantGrowZone(long id, PlantGrowZone plantGrowZone);
        Task<PlantGrowZone> PostPlantGrowZone(PlantGrowZone plantGrowZone);
        Task<bool> DeletePlantGrowZone(long id);  
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlantApi.Entities;

namespace PlantApi.Interfaces
{
    public interface IGrowZoneService
    {
        Task<IEnumerable<GrowZone>> GetAllGrowZones();
        Task<GrowZone?> GetGrowZone(long id);
        Task<GrowZone> PutGrowZone(long id, GrowZone growZone);
        Task<GrowZone> PostGrowZone(GrowZone growZone);
        Task<bool> DeleteGrowZone(long id);
    }
}

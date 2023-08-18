using System;
namespace PlantApi.Entities
{
	public class GrowZone
	{
        public long GrowZoneId { get; set; }
        public string? GrowZoneName { get; set; }
        public long? GrowZoneNumber { get; set; }
        public string? GrowZoneDescription { get; set; }

        public IList<PlantGrowZone>? PlantGrowZones { get; set; }
    }
}


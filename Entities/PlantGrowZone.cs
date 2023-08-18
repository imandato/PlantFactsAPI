using System;
namespace PlantApi.Entities
{
	public class PlantGrowZone
	{
        public long Id { get; set; }
        public long PlantFactId { get; set; }
        //public PlantFact? PlantFact { get; set; }

        public long GrowZoneId { get; set; }
        //public GrowZone? GrowZone { get; set; }
    }
}


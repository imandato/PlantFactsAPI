using System;
namespace PlantApi.Models
{
	public class PlantFact
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public string? ScientificName {get; set;}
		public string? Light { get; set; }
		public string? Water { get; set; }

		public IList<PlantGrowZone>? PlantGrowZones { get; set; }
        
    }

	public class GrowZone
	{
		public long GrowZoneId { get; set; }
		public string? GrowZoneName { get; set; }
		public long? GrowZoneNumber { get; set; }
        public string? GrowZoneDescription { get; set; }

        public IList<PlantGrowZone>? PlantGrowZones { get; set; }

    }

    public class PlantGrowZone
	{
		public long PlantFactId { get; set; }
		public PlantFact? PlantFact { get; set; }

		public long GrowZoneId { get; set; }
		public GrowZone? GrowZone { get; set; }

	}
}


using System;
namespace PlantApi.Entities
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
}


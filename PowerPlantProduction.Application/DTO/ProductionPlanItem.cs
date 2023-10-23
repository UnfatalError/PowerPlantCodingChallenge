using System.Text.Json.Serialization;

namespace PowerPlantProduction.Application.DTO
{
    public class ProductionPlanItem
    {
        [JsonPropertyName("name")]
        public string? PowerPlantName { get; set; }

        [JsonPropertyName("p")]
        public double LoadToProduce { get; set; }
    }
}

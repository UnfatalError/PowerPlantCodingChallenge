using System.Text.Json.Serialization;

namespace PowerPlantProduction.Application.DTO
{
    public class Payload
    {
        [JsonPropertyName("load")]
        public double Load { get; set; }

        [JsonPropertyName("fuels")]
        public FuelsInfo FuelsInfo { get; set; } = new();

        [JsonPropertyName("powerplants")]
        public List<PowerPlantDto> PowerPlants { get; set; } = new();
    }
}

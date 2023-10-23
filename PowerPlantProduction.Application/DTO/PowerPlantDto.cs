using PowerPlantProduction.Application.Enums;
using System.Text.Json.Serialization;

namespace PowerPlantProduction.Application.DTO
{
    public class PowerPlantDto
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("type")]
        public required PowerPlantType Type { get; set; }

        [JsonPropertyName("efficiency")]
        public double Efficiency { get; set; }

        [JsonPropertyName("pmin")]
        public double PMin { get; set; }

        [JsonPropertyName("pmax")]
        public double PMax { get; set; }
    }
}

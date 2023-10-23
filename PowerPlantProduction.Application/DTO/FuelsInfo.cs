using System.Text.Json.Serialization;

namespace PowerPlantProduction.Application.DTO
{
    public class FuelsInfo
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public double GasCost { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public double KerosineCost { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public double CarbonConsumptionCost { get; set; }

        [JsonPropertyName("wind(%)")]
        public double WindPercentage { get; set; }
    }
}

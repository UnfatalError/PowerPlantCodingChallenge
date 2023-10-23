using System.Text.Json.Serialization;

namespace PowerPlantProduction.Application.Enums
{
    public enum PowerPlantType
    {
        Undefined,
        [JsonPropertyName("windturbine")] WindTurbine,
        [JsonPropertyName("gasfired")] GasFired,
        [JsonPropertyName("turbojet")] Turbojet
    };
}

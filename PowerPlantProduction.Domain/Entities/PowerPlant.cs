namespace PowerPlantProduction.Domain.Entities
{
    public class PowerPlant
    {
        public string? Name { get; set; }
        public double EnergyCost { get; set; }
        public double MinProduction { get; set; }
        public double MaxProduction { get; set; }
    }
}

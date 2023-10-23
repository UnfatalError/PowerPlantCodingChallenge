namespace PowerPlantProduction.Infrastructure.Exceptions
{
    public class ProductionPlanException : Exception
    {
        public ProductionPlanException()
        {
        }

        public ProductionPlanException(string message) : base(message)
        {
        }
    }
}

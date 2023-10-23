namespace PowerPlantProduction.Infrastructure.Exceptions
{
    public class LoadExceedsMaxProductionException : ProductionPlanException
    {
        public override string Message => "The production of the power plants is insufficient for the requested load.";
    }
}

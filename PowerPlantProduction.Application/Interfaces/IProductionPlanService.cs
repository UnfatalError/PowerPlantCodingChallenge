using PowerPlantProduction.Application.DTO;

namespace PowerPlantProduction.Application.Interfaces
{
    public interface IProductionPlanService
    {
        List<ProductionPlanItem> GetProductionPlanFromPayload(Payload payload);
    }
}

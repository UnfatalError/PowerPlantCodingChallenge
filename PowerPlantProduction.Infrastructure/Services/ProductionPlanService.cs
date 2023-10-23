using AutoMapper;
using PowerPlantProduction.Application.DTO;
using PowerPlantProduction.Application.Enums;
using PowerPlantProduction.Application.Interfaces;
using PowerPlantProduction.Domain.Entities;
using PowerPlantProduction.Infrastructure.Exceptions;
using System.ComponentModel;

namespace PowerPlantProduction.Infrastructure.Services
{
    public class ProductionPlanService : IProductionPlanService
    {
        private readonly IMapper _powerPlantMapper;

        public ProductionPlanService(IMapper powerPlantMapper)
        {
            _powerPlantMapper = powerPlantMapper;
        }

        public List<ProductionPlanItem> GetProductionPlanFromPayload(Payload payload)
        {
            var powerPlants = MapPowerPlants(payload);

            ValidateData(powerPlants, payload);

            var powerPlantsForComputation = SortPowerPlantDetailsByMeritOrder(powerPlants, payload.Load);

            var productionPlan = ComputeProductionPlan(powerPlantsForComputation, payload.Load);

            return productionPlan;
        }

        private static void ValidateData(IList<PowerPlant> powerPlants, Payload payload)
        {
            if (powerPlants.Sum(pp => pp.MaxProduction) < payload.Load)
            {
                throw new LoadExceedsMaxProductionException();
            }
        }

        private IList<PowerPlant> MapPowerPlants(Payload payload)
        {
            var powerPlants = new List<PowerPlant>();

            // Has do be done like this instead of List mapping because FuelsInfo is necessary to map some members.
            foreach (var powerPlantDto in payload.PowerPlants)
            {
                var powerPlant = new PowerPlant();

                _powerPlantMapper.Map(powerPlantDto, powerPlant,
                    opt => opt.AfterMap((dto, entity) => CalculateEnergyCostAndMaxProduction(dto, entity, payload.FuelsInfo)));

                powerPlants.Add(powerPlant);
            }

            return powerPlants;
        }

        private static void CalculateEnergyCostAndMaxProduction(PowerPlantDto powerPlantDto, PowerPlant powerPlant, FuelsInfo fuelsInfo)
        {
            switch (powerPlantDto.Type)
            {
                case PowerPlantType.WindTurbine:
                    powerPlant.EnergyCost = 0;
                    powerPlant.MaxProduction = powerPlantDto.PMax * fuelsInfo.WindPercentage / 100;
                    break;
                case PowerPlantType.GasFired:
                    powerPlant.EnergyCost = fuelsInfo.GasCost / powerPlantDto.Efficiency;
                    break;
                case PowerPlantType.Turbojet:
                    powerPlant.EnergyCost = fuelsInfo.KerosineCost / powerPlantDto.Efficiency;
                    break;
                default:
                    throw new InvalidEnumArgumentException("Power plant type is invalid or undefined.");
            }
        }

        private static IEnumerable<PowerPlant> SortPowerPlantDetailsByMeritOrder(IEnumerable<PowerPlant> powerPlants, in double requestedLoad)
        {
            var sorted = powerPlants
                .OrderBy(d => d.EnergyCost)
                .ThenByDescending(d => d.MaxProduction)
                .ThenBy(d => d.MinProduction);

            return sorted;
        }

        private static List<ProductionPlanItem> ComputeProductionPlan(IEnumerable<PowerPlant> powerPlants, in double requestedLoad)
        {
            var productionPlan = new List<ProductionPlanItem>();

            if (requestedLoad == 0)
            {
                return productionPlan;
            }

            var remainingLoad = requestedLoad;

            foreach (var powerPlant in powerPlants)
            {
                var loadToProduce = Math.Min(powerPlant.MaxProduction, remainingLoad);
                loadToProduce = Math.Round(loadToProduce, 1, MidpointRounding.AwayFromZero);

                productionPlan.Add(new ProductionPlanItem
                {
                    PowerPlantName = powerPlant.Name,
                    LoadToProduce = loadToProduce
                });


                remainingLoad -= loadToProduce;
            }

            return productionPlan;
        }
    }
}
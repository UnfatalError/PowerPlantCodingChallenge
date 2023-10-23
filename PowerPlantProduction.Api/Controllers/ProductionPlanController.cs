using Microsoft.AspNetCore.Mvc;
using PowerPlantProduction.Application.DTO;
using PowerPlantProduction.Application.Interfaces;
using PowerPlantProduction.Infrastructure.Exceptions;

namespace PowerPlantProduction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionPlanController : Controller
    {
        private readonly IProductionPlanService _service;

        public ProductionPlanController(IProductionPlanService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult GetProductionPlan([FromBody] Payload payload)
        {
            try
            {
                var productionPlan = _service.GetProductionPlanFromPayload(payload);

                return Ok(productionPlan);
            }
            catch (ProductionPlanException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}

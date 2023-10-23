using PowerPlantProduction.Application.Interfaces;
using PowerPlantProduction.Infrastructure.Mappings;
using PowerPlantProduction.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IProductionPlanService, ProductionPlanService>();
    services.AddAutoMapper(typeof(PowerPlantMappingProfile));
}
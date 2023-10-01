using BuildingWorks.Services.Implementations.BuildingObjects;
using BuildingWorks.Services.Implementations.Plans;
using BuildingWorks.Services.Implementations.Providers;
using BuildingWorks.Services.Implementations.Workers;
using BuildingWorks.Services.Interfaces.BuildingObjects;
using BuildingWorks.Services.Interfaces.Plans;
using BuildingWorks.Services.Interfaces.Providers;
using BuildingWorks.Services.Interfaces.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingWorks.Services;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBuildingObjectService, BuildingObjectService>();
        services.AddScoped<IPlanService, PlanService>();
        services.AddScoped<IContractService, ContractService>();
        services.AddScoped<IMaterialService, MaterialService>();
        services.AddScoped<IProviderService, ProviderService>();
        services.AddScoped<IBrigadeService, BrigadeService>();
        services.AddScoped<IWorkerService, WorkerService>();
        services.AddScoped<IWorkerSalaryService, WorkerSalaryService>();
    }
}

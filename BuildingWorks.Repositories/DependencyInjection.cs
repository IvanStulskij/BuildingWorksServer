using BuildingWorks.Repositories.Abstractions;
using BuildingWorks.Repositories.Abstractions.BuildingObjects;
using BuildingWorks.Repositories.Abstractions.Plans;
using BuildingWorks.Repositories.Abstractions.Providers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Repositories.Common;
using BuildingWorks.Repositories.Implementations;
using BuildingWorks.Repositories.Implementations.BuildingObjects;
using BuildingWorks.Repositories.Implementations.Plans;
using BuildingWorks.Repositories.Implementations.Providers;
using BuildingWorks.Repositories.Implementations.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingWorks.Repositories;

public static class DependencyInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBuildingObjectRepository, BuildingObjectsRepository>();
        services.AddScoped<IPlanRepository, PlanRepository>();
        services.AddScoped<IContractRepository, ContractRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IProviderRepository, ProviderRepository>();
        services.AddScoped<IBrigadeRepository, BrigadeRepository>();
        services.AddScoped<IWorkerRepository, WorkerRepository>();
        services.AddScoped<IWorkerSalaryRepository, WorkerSalaryRepository>();
        services.AddScoped<IDatabaseChanges, DatabaseChanges>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();
        services.AddScoped<ISmsNotificationSender, ExternalSmsNoficationSender>();
    }
}

using BuildingWorks.Profiles.Profiles.BuildingObjects;
using BuildingWorks.Profiles.Profiles.Plans;
using BuildingWorks.Profiles.Profiles.Providers;
using BuildingWorks.Profiles.Profiles.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingWorks.Profiles;

public static class DependencyInjection
{
    public static void AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(MappedTypes);
    }

    private readonly static Type[] MappedTypes = new Type[]
    {
        typeof(BuildingObjectProfile), typeof(PlanProfile), typeof(ProviderProfile),
        typeof(MaterialProfile), typeof(ContractProfile), typeof(BrigadeProfile),
        typeof(WorkerProfile), typeof(WorkerSalaryProfile),
    };
}

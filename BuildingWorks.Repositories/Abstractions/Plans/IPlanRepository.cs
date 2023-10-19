using BuildingWorks.Infrastructure.Entities.Plans;

namespace BuildingWorks.Repositories.Abstractions.Plans;

public interface IPlanRepository : IOverviewRepository<Plan>
{
    //float CalculateCost(Guid planId);
}

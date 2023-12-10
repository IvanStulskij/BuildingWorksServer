using BuildingWorks.Infrastructure.Entities.Plans;
using BuildingWorks.Models.Overviews.Plans;

namespace BuildingWorks.Repositories.Abstractions.Plans;

public interface IPlanRepository : IOverviewRepository<Plan, PlanOverview>
{
    //float CalculateCost(Guid planId);
}

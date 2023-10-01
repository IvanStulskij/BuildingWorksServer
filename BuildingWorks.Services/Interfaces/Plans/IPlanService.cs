using BuildingWorks.Models.Overviews.Plans;
using BuildingWorks.Models.Resources.Plans;

namespace BuildingWorks.Services.Interfaces.Plans;

public interface IPlanService : IOverviewService<PlanResource, PlanOverview>
{
}

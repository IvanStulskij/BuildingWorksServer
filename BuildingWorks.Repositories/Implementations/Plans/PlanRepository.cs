using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Plans;
using BuildingWorks.Models.Overviews.Plans;
using BuildingWorks.Repositories.Abstractions.Plans;
using BuildingWorks.Repositories.Query;

namespace BuildingWorks.Repositories.Implementations.Plans;

public class PlanRepository : OverviewRepository<Plan, PlanOverview>, IPlanRepository
{
    public PlanRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<PlanOverview> IncludeHierarchy()
    {
        return Set.IncludeHierarchy().Select(x => new PlanOverview
        {
            Id = x.Id,
            BuildingObjectId = x.BuildingObjectId,
            CompleteTime = x.CompleteTime,
            Cost = x.Cost,
            IsCompleted = x.IsCompleted,
            StartDate = x.StartDate,
            PathToImage = x.PathToImage,
        });
    }
}

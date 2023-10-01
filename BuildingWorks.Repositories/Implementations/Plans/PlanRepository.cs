using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Plans;
using BuildingWorks.Repositories.Abstractions.Plans;
using BuildingWorks.Repositories.Query;

namespace BuildingWorks.Repositories.Implementations.Plans;

public class PlanRepository : OverviewRepository<Plan>, IPlanRepository
{
    public PlanRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<Plan> IncludeHierarchy()
    {
        return Set.IncludeHierarchy();
    }
}

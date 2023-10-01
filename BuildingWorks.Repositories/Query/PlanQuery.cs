using BuildingWorks.Infrastructure.Entities.Plans;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Query;

public static class PlanQuery
{
    public static IQueryable<Plan> IncludeHierarchy(this IQueryable<Plan> plans)
    {
        return plans
            .Include(plan => plan.BuildingObject);
    }
}

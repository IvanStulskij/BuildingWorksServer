using BuildingWorks.Infrastructure.Entities.Workers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Query;

public static class WorkerQuery
{
    public static IQueryable<Worker> IncludeHierarchy(this IQueryable<Worker> workers)
    {
        return workers
            .Include(worker => worker.Brigades);
    }
}

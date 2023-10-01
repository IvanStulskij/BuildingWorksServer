using BuildingWorks.Infrastructure.Entities.Workers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Query;

public static class WorkerSalaryQuery
{
    public static IQueryable<WorkerSalary> IncludeHierarchy(this IQueryable<WorkerSalary> workerSalaries)
    {
        return workerSalaries
            .Include(workerSalary => workerSalary.Worker);
    }
}

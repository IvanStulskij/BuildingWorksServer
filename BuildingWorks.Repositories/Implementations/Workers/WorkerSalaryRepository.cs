using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Repositories.Query;

namespace BuildingWorks.Repositories.Implementations.Workers;

public class WorkerSalaryRepository : OverviewRepository<WorkerSalary>, IWorkerSalaryRepository
{
    public WorkerSalaryRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<WorkerSalary> IncludeHierarchy()
    {
        return Set.IncludeHierarchy();
    }
}

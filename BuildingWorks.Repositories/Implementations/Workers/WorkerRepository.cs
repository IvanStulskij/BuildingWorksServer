using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Repositories.Query;

namespace BuildingWorks.Repositories.Implementations.Workers;

public class WorkerRepository : OverviewRepository<Worker>, IWorkerRepository
{
    public WorkerRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<Worker> IncludeHierarchy()
    {
        return Set.IncludeHierarchy();
    }
}

using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Repositories.Query;

namespace BuildingWorks.Repositories.Implementations.Workers;

public class WorkerRepository : OverviewRepository<Worker, WorkerOverview>, IWorkerRepository
{
    public WorkerRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<WorkerOverview> IncludeHierarchy()
    {
        return Set.IncludeHierarchy().Select(x => new WorkerOverview
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            MiddleName = x.MiddleName,
            Post = x.Post,
            StartWorkDate = x.StartWorkDate,
            IsBrigadier = x.BrigadierBrigadeId != null
        });
    }

    public override async Task Delete(Guid id)
    {
        
    }
}

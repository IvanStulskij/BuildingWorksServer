using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Repositories.Query;

namespace BuildingWorks.Repositories.Implementations.Workers;

public class BrigadeRepository : OverviewRepository<Brigade>, IBrigadeRepository
{
    public BrigadeRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<Brigade> IncludeHierarchy()
    {
        return Set.IncludeHierarchy();
    }
}

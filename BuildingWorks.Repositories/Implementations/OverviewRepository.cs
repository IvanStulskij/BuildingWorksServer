using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure;
using BuildingWorks.Models.Overviews;
using BuildingWorks.Repositories.Abstractions;

namespace BuildingWorks.Repositories.Implementations;

public abstract class OverviewRepository<T> : Repository<T>, IOverviewRepository<T>
    where T : Entity
{
    protected OverviewRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    public IQueryable<T> GetOverviewDisplayedData()
    {
        return IncludeHierarchy();
    }

    protected abstract IQueryable<T> IncludeHierarchy();
}

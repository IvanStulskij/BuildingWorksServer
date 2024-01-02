using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Loading;
using BuildingWorks.Repositories.Abstractions;
using BuildingWorks.Repositories.Loading;

namespace BuildingWorks.Repositories.Implementations;

public abstract class OverviewRepository<T, TOverview> : Repository<T>, IOverviewRepository<T, TOverview>
    where T : Entity
    where TOverview: Entity
{
    private readonly BuildingWorksDbContext _context;

    protected OverviewRepository(BuildingWorksDbContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<LoadResult<TOverview>> GetOverviewDisplayedData(LoadConditions loadConditions)
    {
        var data = IncludeHierarchy();
        var loader = new Loader<TOverview>(_context, new Sorter<TOverview>(), new Filter<TOverview>(), new Page<TOverview>());
        var loadedData = await loader.Load(data, loadConditions);

        return loadedData;
    }

    protected abstract IQueryable<TOverview> IncludeHierarchy();
}

using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;

namespace BuildingWorks.Repositories.Implementations.Providers;

public class ProviderRepository : OverviewRepository<Provider>, IProviderRepository
{
    public ProviderRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<Provider> IncludeHierarchy()
    {
        return Set;
    }
}

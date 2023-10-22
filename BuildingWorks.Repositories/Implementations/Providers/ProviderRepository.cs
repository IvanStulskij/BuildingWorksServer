using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations.Providers;

public class ProviderRepository : OverviewRepository<Provider>, IProviderRepository
{
    public ProviderRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<DictionaryItem>> GetShortInfos()
    {
        var providers = await Set.AsNoTracking()
            .Select(provider => new DictionaryItem
            {
                Id = provider.Id.ToString(),
                Name = provider.Name
            })
            .ToListAsync();

        return providers;
    }

    protected override IQueryable<Provider> IncludeHierarchy()
    {
        return Set;
    }
}

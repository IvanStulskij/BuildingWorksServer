using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Migrations;
using BuildingWorks.Repositories.Abstractions.Providers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations.Providers;

public class MaterialRepository : OverviewRepository<Material>, IMaterialRepository
{
    public MaterialRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<DictionaryItem>> GetShortInfos()
    {
        var dictionaryItems = await Set.Select(material => new DictionaryItem
        {
            Id = material.Id.ToString(),
            Name = material.Name
        }).ToListAsync();

        return dictionaryItems;
    }

    protected override IQueryable<Material> IncludeHierarchy()
    {
        return Set;
    }
}

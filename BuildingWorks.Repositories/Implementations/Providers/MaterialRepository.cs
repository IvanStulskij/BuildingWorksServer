using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;

namespace BuildingWorks.Repositories.Implementations.Providers;

public class MaterialRepository : OverviewRepository<Material>, IMaterialRepository
{
    public MaterialRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<Material> IncludeHierarchy()
    {
        return Set;
    }
}

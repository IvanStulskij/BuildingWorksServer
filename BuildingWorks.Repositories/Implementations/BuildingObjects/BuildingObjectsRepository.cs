using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Repositories.Abstractions.BuildingObjects;

namespace BuildingWorks.Repositories.Implementations.BuildingObjects;

public class BuildingObjectsRepository : OverviewRepository<BuildingObject>, IBuildingObjectRepository
{
    public BuildingObjectsRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<BuildingObject> IncludeHierarchy()
    {
        return Set;
    }
}
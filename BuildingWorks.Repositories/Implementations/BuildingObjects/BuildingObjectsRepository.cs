using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Repositories.Abstractions.BuildingObjects;
using BuildingWorks.Repositories.Abstractions.Plans;
using BuildingWorks.Repositories.Abstractions.Workers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations.BuildingObjects;

public class BuildingObjectsRepository : OverviewRepository<BuildingObject>, IBuildingObjectRepository
{
    private readonly IPlanRepository _plansRepository;
    private readonly IBrigadeRepository _brigadesRepository;

    public BuildingObjectsRepository(BuildingWorksDbContext context, IPlanRepository plansRepository, IBrigadeRepository brigadesRepository) : base(context)
    {
        _plansRepository = plansRepository;
        _brigadesRepository = brigadesRepository;
    }

    public float CalculateTotalCost(Guid buildingObjectId)
    {
        var buildingObject = Context.BuildingObjects
            .Include(buildingObject => buildingObject.Brigades)
            .Include(buildingObject => buildingObject.Plans)
            .FirstOrDefaultAsync(buildingObject => buildingObject.Id == buildingObjectId);

        return 0;
    }

    protected override IQueryable<BuildingObject> IncludeHierarchy()
    {
        return Set;
    }

    private float CalculatePlansCost()
    {
        return 0;
    }
}
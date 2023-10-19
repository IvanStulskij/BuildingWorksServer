using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Entities.Workers;
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

    public async Task<IEnumerable<Brigade>> GetBrigades(Guid buildingObjectId)
    {
        var buildingObject = await Set.Include(buildingObject => buildingObject.Brigades).FirstOrDefaultAsync(buildingObject => buildingObject.Id == buildingObjectId);

        if (buildingObject == null)
        {
            throw new EntityNotExistException($"Building object with id {buildingObjectId} doesn't exist in database");
        }

        return buildingObject.Brigades;
    }

    public async Task<IEnumerable<Provider>> GetProviders(Guid buildingObjectId)
    {
        var providers = await Context.BuildingObjectProvider.AsNoTracking()
            .Include(provider => provider.Provider)
            .Where(entity => entity.BuildingObjectId == buildingObjectId)
            .Select(entity => entity.Provider)
            .ToListAsync();

        return providers;
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
using BuildingWorks.Common.Constants;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Repositories.Abstractions.BuildingObjects;
using BuildingWorks.Repositories.Abstractions.Plans;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Repositories.Common;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations.BuildingObjects;

public class BuildingObjectsRepository : OverviewRepository<BuildingObject>, IBuildingObjectRepository
{
    private readonly IPlanRepository _plansRepository;
    private readonly IBrigadeRepository _brigadesRepository;
    private readonly IDatabaseChanges _databaseChanges;

    public BuildingObjectsRepository(BuildingWorksDbContext context, IPlanRepository plansRepository, IBrigadeRepository brigadesRepository, IDatabaseChanges databaseChanges) : base(context)
    {
        _plansRepository = plansRepository;
        _brigadesRepository = brigadesRepository;
        _databaseChanges = databaseChanges;
    }

    public async Task AddProvider(Guid id, Guid providerId)
    {
        var entity = new BuildingObjectProvider
        {
            BuildingObjectsId = id,
            ProvidersId = providerId,
        };

        await Context.BuildingObjectProvider.AddAsync(entity);
        await _databaseChanges.TrySaveChanges(ErrorsConstants.Messages.BuildingObjectAlreadyHasProvider);
    }

    public async Task<float> CalculateTotalCost(Guid buildingObjectId)
    {
        var buildingObject = await Set.AsNoTracking()
            .Include(buildingObject => buildingObject.Brigades)
            .Include(buildingObject => buildingObject.Plans)
            .FirstOrDefaultAsync(buildingObject => buildingObject.Id == buildingObjectId);

        return 0;
    }

    public async Task DeleteProvider(Guid id, Guid providerId)
    {
        var deletedCount = await Context.BuildingObjectProvider
            .Where(entity => entity.ProvidersId == providerId && entity.BuildingObjectsId == id)
            .ExecuteDeleteAsync();

        if (deletedCount == 0)
        {
            throw new EntityNotExistException($"Provider with id {providerId}");
        }
    }

    public async Task<IEnumerable<Brigade>> GetBrigades(Guid buildingObjectId)
    {
        var buildingObject = await Set.AsNoTracking()
            .Include(buildingObject => buildingObject.Brigades)
            .FirstOrDefaultAsync(buildingObject => buildingObject.Id == buildingObjectId);

        if (buildingObject == null)
        {
            throw new EntityNotExistException($"Building object with id {buildingObjectId} doesn't exist in database");
        }

        return buildingObject.Brigades;
    }

    public async Task<IEnumerable<Contract>> GetContracts(Guid buildingObjectId)
    {
        var buildingObject = await Set.AsNoTracking()
            .Include(buildingObject => buildingObject.Contracts)
            .FirstOrDefaultAsync(buildingObject => buildingObject.Id == buildingObjectId);

        if (buildingObject == null)
        {
            throw new EntityNotExistException($"Building object with id {buildingObjectId} doesn't exist in database");
        }

        return buildingObject.Contracts;
    }

    public async Task<IEnumerable<Provider>> GetProviders(Guid buildingObjectId)
    {
        var providers = await Context.BuildingObjectProvider.AsNoTracking()
            .Include(provider => provider.Provider)
            .Where(entity => entity.BuildingObjectsId == buildingObjectId)
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
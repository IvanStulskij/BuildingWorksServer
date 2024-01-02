using AutoMapper;
using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Loading;
using BuildingWorks.Models.Overviews;
using BuildingWorks.Models.Overviews.BuildingObjects;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.BuildingObjects;
using BuildingWorks.Repositories.Abstractions.BuildingObjects;
using BuildingWorks.Services.Interfaces.BuildingObjects;
using FluentValidation;

namespace BuildingWorks.Services.Implementations.BuildingObjects;

public class BuildingObjectService : OverviewService<BuildingObject, BuildingObjectResource, BuildingObjectOverview>, IBuildingObjectService
{
    private readonly IBuildingObjectRepository _repository;

    public BuildingObjectService(IMapper mapper, IBuildingObjectRepository repository, IValidator<BuildingObjectResource> validator) : base(mapper, repository, validator)
    {
        _repository = repository;
    }

    public async Task AddProvider(Guid buildingObjectId, Guid providerId)
    {
        await _repository.AddProvider(buildingObjectId, providerId);
    }

    public async Task DeleteProvider(Guid buildingObjectId, Guid providerId)
    {
        await _repository.DeleteProvider(buildingObjectId, providerId);
    }

    public async Task<LoadResult<BrigadeOverview>> GetBrigades(Guid buildingObjectId, LoadConditions loadConditions)
    {
        var brigades = await _repository.GetBrigades(buildingObjectId, loadConditions);

        return brigades;
    }

    public async Task<LoadResult<OrderOverview>> GetOrders(Guid buildingObjectId, LoadConditions loadConditions)
    {
        var orders = await _repository.GetOrders(buildingObjectId, loadConditions);

        return orders;
    }

    public async Task<LoadResult<ProviderOverview>> GetProviders(Guid buildingObjectId, LoadConditions loadConditions)
    {
        var providers = await _repository.GetProviders(buildingObjectId, loadConditions);

        return providers;
    }

    public async Task<IEnumerable<DictionaryItem>> GetProvidersShortInfos(Guid buildingObjectId)
    {
        var shortInfos = await _repository.GetProvidersShortInfos(buildingObjectId);

        return shortInfos;
    }
}
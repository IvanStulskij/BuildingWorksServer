using AutoMapper;
using BuildingWorks.Infrastructure.Entities;
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

    public async Task<IEnumerable<BrigadeOverview>> GetBrigades(Guid buildingObjectId)
    {
        var brigades = await _repository.GetBrigades(buildingObjectId);

        return Mapper.Map<IEnumerable<BrigadeOverview>>(brigades);
    }

    public async Task<IEnumerable<ContractOverview>> GetContracts(Guid buildingObjectId)
    {
        var contracts = await _repository.GetContracts(buildingObjectId);

        return Mapper.Map<IEnumerable<ContractOverview>>(contracts);
    }

    public async Task<IEnumerable<ProviderOverview>> GetProviders(Guid buildingObjectId)
    {
        var providers = await _repository.GetProviders(buildingObjectId);

        return Mapper.Map<IEnumerable<ProviderOverview>>(providers);
    }


}
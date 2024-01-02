using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Loading;
using BuildingWorks.Models.Overviews;
using BuildingWorks.Models.Overviews.BuildingObjects;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Overviews.Workers;

namespace BuildingWorks.Repositories.Abstractions.BuildingObjects;

public interface IBuildingObjectRepository : IOverviewRepository<BuildingObject, BuildingObjectOverview>
{
    Task<float> CalculateTotalCost(Guid buildingObjectId);
    Task<LoadResult<BrigadeOverview>> GetBrigades(Guid buildingObjectId, LoadConditions loadConditions);
    Task<LoadResult<ProviderOverview>> GetProviders(Guid buildingObjectId, LoadConditions loadConditions);
    Task<IEnumerable<DictionaryItem>> GetProvidersShortInfos(Guid buildingObjectId);
    Task AddProvider(Guid id, Guid providerId);
    Task DeleteProvider(Guid id, Guid providerId);
    Task<LoadResult<OrderOverview>> GetOrders(Guid buildingObjectId, LoadConditions loadConditions);
}

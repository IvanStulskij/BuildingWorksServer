using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Loading;
using BuildingWorks.Models.Overviews;
using BuildingWorks.Models.Overviews.BuildingObjects;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.BuildingObjects;

namespace BuildingWorks.Services.Interfaces.BuildingObjects;

public interface IBuildingObjectService : IOverviewService<BuildingObjectResource, BuildingObjectOverview>
{
    Task<LoadResult<ProviderOverview>> GetProviders(Guid buildingObjectId, LoadConditions loadConditions);
    Task<LoadResult<BrigadeOverview>> GetBrigades(Guid buildingObjectId, LoadConditions loadConditions);
    Task AddProvider(Guid buildingObjectId, Guid providerId);
    Task DeleteProvider(Guid buildingObjectId, Guid providerId);
    Task<LoadResult<OrderOverview>> GetOrders(Guid buildingObjectId, LoadConditions loadConditions);
    Task<IEnumerable<DictionaryItem>> GetProvidersShortInfos(Guid buildingObjectId);
}
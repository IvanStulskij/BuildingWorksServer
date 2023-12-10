using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews;
using BuildingWorks.Models.Overviews.BuildingObjects;

namespace BuildingWorks.Repositories.Abstractions.BuildingObjects;

public interface IBuildingObjectRepository : IOverviewRepository<BuildingObject, BuildingObjectOverview>
{
    Task<float> CalculateTotalCost(Guid buildingObjectId);
    Task<IEnumerable<Brigade>> GetBrigades(Guid buildingObjectId);
    Task<IEnumerable<Provider>> GetProviders(Guid buildingObjectId);
    Task<IEnumerable<DictionaryItem>> GetProvidersShortInfos(Guid buildingObjectId);
    Task AddProvider(Guid id, Guid providerId);
    Task DeleteProvider(Guid id, Guid providerId);
    Task<IEnumerable<OrderOverview>> GetOrders(Guid buildingObjectId);
}

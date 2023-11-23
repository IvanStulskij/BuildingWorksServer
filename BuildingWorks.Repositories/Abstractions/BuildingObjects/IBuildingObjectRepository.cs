using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Entities.Workers;

namespace BuildingWorks.Repositories.Abstractions.BuildingObjects;

public interface IBuildingObjectRepository : IOverviewRepository<BuildingObject>
{
    Task<float> CalculateTotalCost(Guid buildingObjectId);
    Task<IEnumerable<Brigade>> GetBrigades(Guid buildingObjectId);
    Task<IEnumerable<Provider>> GetProviders(Guid buildingObjectId);
    Task AddProvider(Guid id, Guid providerId);
    Task DeleteProvider(Guid id, Guid providerId);
}

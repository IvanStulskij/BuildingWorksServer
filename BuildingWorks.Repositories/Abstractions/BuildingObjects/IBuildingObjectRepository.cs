using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Entities.Workers;

namespace BuildingWorks.Repositories.Abstractions.BuildingObjects;

public interface IBuildingObjectRepository : IOverviewRepository<BuildingObject>
{
    float CalculateTotalCost(Guid buildingObjectId);
    //IEnumerable<Brigade> GetBrigades(Guid buildingObjectId);
    //IEnumerable<Provider> GetProviders(Guid buildingObjectId);
}

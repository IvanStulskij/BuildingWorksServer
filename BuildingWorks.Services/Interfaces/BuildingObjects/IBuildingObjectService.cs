using BuildingWorks.Models.Overviews.BuildingObjects;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.BuildingObjects;

namespace BuildingWorks.Services.Interfaces.BuildingObjects;

public interface IBuildingObjectService : IOverviewService<BuildingObjectResource, BuildingObjectOverview>
{
    Task<IEnumerable<ProviderOverview>> GetProviders(Guid buildingObjectId);
    Task<IEnumerable<BrigadeOverview>> GetBrigades(Guid buildingObjectId);
}
using BuildingWorks.Models.Overviews.BuildingObjects;
using BuildingWorks.Models.Resources.BuildingObjects;

namespace BuildingWorks.Services.Interfaces.BuildingObjects;

public interface IBuildingObjectService : IOverviewService<BuildingObjectResource, BuildingObjectOverview>
{
}
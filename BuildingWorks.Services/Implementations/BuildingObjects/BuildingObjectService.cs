using AutoMapper;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Models.Overviews.BuildingObjects;
using BuildingWorks.Models.Resources.BuildingObjects;
using BuildingWorks.Repositories.Abstractions.BuildingObjects;
using BuildingWorks.Services.Interfaces.BuildingObjects;

namespace BuildingWorks.Services.Implementations.BuildingObjects;

public class BuildingObjectService : OverviewService<BuildingObject, BuildingObjectResource, BuildingObjectOverview>, IBuildingObjectService
{
    public BuildingObjectService(IMapper mapper, IBuildingObjectRepository repository) : base(mapper, repository)
    {
    }
}
using BuildingWorks.Models.Overviews.BuildingObjects;
using BuildingWorks.Models.Resources.BuildingObjects;
using BuildingWorks.Services.Interfaces.BuildingObjects;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers.BuildingObjects;

[ApiController]
[Route("api/v1/[controller]")]
public class BuildingObjectController : BuildingWorksOverviewController<BuildingObjectResource, BuildingObjectOverview>
{
    public BuildingObjectController(IBuildingObjectService service) : base(service)
    {
    }
}

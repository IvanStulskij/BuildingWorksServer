using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;
using BuildingWorks.Services.Interfaces.Workers;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers.Workers;

[ApiController]
[Route("api/v1/[controller]")]
public class BrigadeController : BuildingWorksOverviewController<BrigadeResource, BrigadeOverview>
{
    public BrigadeController(IBrigadeService service) : base(service)
    {
    }
}

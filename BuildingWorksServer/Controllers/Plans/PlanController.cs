using BuildingWorks.Models.Overviews.Plans;
using BuildingWorks.Models.Resources.Plans;
using BuildingWorks.Services.Interfaces.Plans;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers.Plans;

[ApiController]
[Route("api/v1/[controller]")]
public class PlanController : BuildingWorksOverviewController<PlanResource, PlanOverview>
{
    public PlanController(IPlanService service) : base(service)
    {
    }
}

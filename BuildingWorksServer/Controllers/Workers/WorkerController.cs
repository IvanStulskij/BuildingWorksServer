using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;
using BuildingWorks.Services.Interfaces.Workers;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers.Workers;

[ApiController]
[Route("api/v1/[controller]")]
public class WorkerController : BuildingWorksOverviewController<WorkerResource, WorkerOverview>
{
    public WorkerController(IWorkerService service) : base(service)
    {
    }
}

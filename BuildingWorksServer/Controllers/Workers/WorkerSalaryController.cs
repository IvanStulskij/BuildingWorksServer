using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;
using BuildingWorks.Services.Interfaces.Workers;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers.Workers;

[ApiController]
[Route("api/v1/[controller]")]
public class WorkerSalaryController : BuildingWorksOverviewController<WorkerSalaryResource, WorkerSalaryOverview>
{
    public WorkerSalaryController(IWorkerSalaryService service) : base(service)
    {
    }
}

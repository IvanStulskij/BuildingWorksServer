using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Services.Interfaces.Providers;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers.Providers;

[ApiController]
[Route("api/v1/[controller]")]
public class ContractController : BuildingWorksOverviewController<ContractResource, ContractOverview>
{
    public ContractController(IContractService service) : base(service)
    {
    }
}

using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Services.Interfaces.Providers;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers.Providers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProviderController : BuildingWorksOverviewController<ProviderResource, ProviderOverview>
{
    private readonly IProviderService _service;

    public ProviderController(IProviderService service) : base(service)
    {
        _service = service;
    }

    [HttpGet("short-infos")]
    public async Task<IActionResult> GetShortInfos()
    {
        var shortInfos = await _service.GetShortInfos();

        return Ok(shortInfos);
    }
}

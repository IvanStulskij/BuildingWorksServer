using BuildingWorks.Models.Overviews.BuildingObjects;
using BuildingWorks.Models.Resources.BuildingObjects;
using BuildingWorks.Services.Interfaces.BuildingObjects;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers.BuildingObjects;

[ApiController]
[Route("api/v1/[controller]")]
public class BuildingObjectController : BuildingWorksOverviewController<BuildingObjectResource, BuildingObjectOverview>
{
    private readonly IBuildingObjectService _service;

    public BuildingObjectController(IBuildingObjectService service) : base(service)
    {
        _service = service;
    }

    [HttpGet("{id}/providers")]
    public async Task<IActionResult> GetProviders(Guid id)
    {
        var providers = await _service.GetProviders(id);

        return Ok(providers);
    }

    [HttpGet("{id}/contracts")]
    public async Task<IActionResult> GetContracts(Guid id)
    {
        var contracts = await _service.GetContracts(id);

        return Ok(contracts);
    }

    [HttpGet("{id}/brigades")]
    public async Task<IActionResult> GetBrigades(Guid id)
    {
        var brigades = await _service.GetBrigades(id);

        return Ok(brigades);
    }

    [HttpPost("{id}/providers")]
    public async Task<IActionResult> AddProvider(Guid id, Guid providerId)
    {
        await _service.AddProvider(id, providerId);

        return Ok();
    }

    [HttpDelete("{id}/provider")]
    public async Task<IActionResult> DeleteProvider(Guid id, Guid providerId)
    {
        await _service.DeleteProvider(id, providerId);

        return Ok();
    }
}

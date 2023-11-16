using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Services.Interfaces.Providers;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers.Providers;

[ApiController]
[Route("api/v1/[controller]")]
public class ContractController : BuildingWorksOverviewController<ContractResource, ContractOverview>
{
    private readonly IContractService _service;

    public ContractController(IContractService service) : base(service)
    {
        _service = service;
    }

    [HttpGet("{id}/providers")]
    public async Task<IActionResult> GetProviders(Guid id)
    {
        var providers = await _service.GetProviders(id);

        return Ok(providers);
    }

    [HttpGet("{id}/providers/{providerId}/materials")]
    public async Task<IActionResult> GetMaterials(Guid id, Guid providerId)
    {
        var materials = await _service.GetMaterials(id, providerId);

        return Ok(materials);
    }

    [HttpPost("{id}/providers")]
    public async Task<IActionResult> AddProviderToContract(Guid id, Guid providerId)
    {
        await _service.AddProvider(id, providerId);
        return Ok();
    }

    [HttpDelete("{id}/providers")]
    public async Task<IActionResult> DeleteProvider(Guid id, Guid providerId)
    {
        await _service.DeleteProvider(id, providerId);

        return Ok();
    }
}

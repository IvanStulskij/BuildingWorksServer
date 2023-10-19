using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;
using BuildingWorks.Services.Interfaces.Workers;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers.Workers;

[ApiController]
[Route("api/v1/[controller]")]
public class BrigadeController : BuildingWorksOverviewController<BrigadeResource, BrigadeOverview>
{
    private readonly IBrigadeService _service;

    public BrigadeController(IBrigadeService service) : base(service)
    {
        _service = service;
    }

    [HttpGet("{id}/workers")]
    public async Task<IActionResult> GetWorkers(Guid id)
    {
        var workers = await _service.GetWorkers(id);

        return Ok(workers);
    }

    [HttpGet("short")]
    public async Task<IActionResult> GetShortInfos()
    {
        var shortInfos = await _service.GetShortInfos();

        return Ok(shortInfos);
    }

    [HttpPost("{id}/workers")]
    public async Task<IActionResult> AddWorker(Guid id, Guid workerId)
    {
        await _service.AddWorker(id, workerId);

        return Ok();
    }
}

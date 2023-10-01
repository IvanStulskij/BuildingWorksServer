using BuildingWorks.Models.Overviews;
using BuildingWorks.Models.Resources;
using BuildingWorks.Services.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers;

public abstract class BuildingWorksController<TResource, TService> : ControllerBase
    where TResource : IResource
    where TService : IService<TResource>
{
    private readonly TService _service;

    public BuildingWorksController(TService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var entities = _service.GetAll();

        return Ok(entities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var entity = await _service.GetById(id);

        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TResource entity)
    {
        var created = await _service.Create(entity);

        return Created(Request.GetDisplayUrl(), created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(TResource entity)
    {
        var updated = await _service.Update(entity);

        return Ok(updated);
    }
}

public abstract class BuildingWorksOverviewController<TResource, TOverview> : BuildingWorksController<TResource, IOverviewService<TResource, TOverview>>
    where TOverview : IOverview
    where TResource : IResource
{
    private readonly IOverviewService<TResource, TOverview> _service;

    protected BuildingWorksOverviewController(IOverviewService<TResource, TOverview> service) : base(service)
    {
        _service = service;
    }

    [HttpGet("overview")]
    public IActionResult GetAllOverview()
    {
        var entities = _service.GetAllOverview();

        return Ok(entities);
    }
}
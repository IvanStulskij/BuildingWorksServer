using BuildingWorks.Models.Resources;
using BuildingWorks.Repositories.Abstractions;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController : ControllerBase
{
	private readonly IOrdersRepository _repository;

	public OrdersController(IOrdersRepository repository)
	{
		_repository = repository;
	}

	[HttpPost]
	public async Task<IActionResult> AddOrder(OrderResource order)
	{
		await _repository.Add(order);

		return Created(Request.GetDisplayUrl(), order);
	}

	[HttpPost("{id}/send-link")]
	public async Task<IActionResult> SendLink(Guid id)
	{
		await _repository.SendOrderLink(id);
		return Ok();
	}

	[HttpGet("{id}/materials")]
	public async Task<IActionResult> GetMaterials(Guid id)
	{
		var materials = await _repository.GetMaterials(id);

		return Ok(materials);
	}

	[HttpPatch("{id}/delivered")]
	public async Task<IActionResult> UpdateDeliveredDate(Guid id)
	{
		await _repository.SetAsDelivered(id);

		return Ok();
	}

	[HttpPatch("{id}/approved-by-provider")]
	public async Task<IActionResult> UpdateProviderApprovedStatus(Guid id)
	{
		var approvedByProvider = await _repository.ApproveByProvider(id);

		return Ok(approvedByProvider);
	}
}

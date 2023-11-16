using BuildingWorks.Models.Resources;
using BuildingWorks.Repositories.Abstractions;
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
}

using BuildingWorks.Common.Constants;
using BuildingWorks.Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildingWorksServer.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DictionariesController : ControllerBase
{
    [HttpGet("building-object-types")]
    public IActionResult GetBuildingObjectTypes()
    {
        var dictionaryItems = DictionariesConstants.BuildingObjectTypesWithNames.Select(type => new DictionaryItem
        {
            Id = ((int)type.Key).ToString(),
            Name = type.Value
        });

        return Ok(dictionaryItems);
    }
}

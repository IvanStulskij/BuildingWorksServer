using BuildingWorks.Common.Entities;

namespace BuildingWorks.Models.Resources.Workers;

public class BrigadeResource : Entity, IResource
{
    public string Number { get; set; } = string.Empty;

    public Guid BuildingObjectId { get; set; }
    public Guid BrigadierId { get; set; }
}

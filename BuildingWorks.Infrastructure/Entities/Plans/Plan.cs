using BuildingWorks.Common;

namespace BuildingWorks.Infrastructure.Entities.Plans;

public class Plan : Entity
{
    public DateTime StartDate { get; set; }
    public DateTime? CompleteTime { get; set; }
    public bool IsCompleted { get; set; }
    public decimal Cost { get; set; }
    public string? PathToImage { get; set; }

    public Guid BuildingObjectId { get; set; }
    public BuildingObject BuildingObject { get; set; } = null!;
}

using BuildingWorks.Common;

namespace BuildingWorks.Models.Resources.Plans;

public class PlanResource : Entity, IResource
{
    public DateTime StartDate { get; set; }
    public DateTime? CompleteTime { get; set; }
    public bool IsCompleted { get; set; }
    public decimal Cost { get; set; }
    public string? PathToImage { get; set; }

    public Guid BuildingObjectId { get; set; }
}

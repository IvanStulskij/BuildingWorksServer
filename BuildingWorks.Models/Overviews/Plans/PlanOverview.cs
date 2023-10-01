using BuildingWorks.Common.Entities;
using BuildingWorks.Models.Overviews.BuildingObjects;

namespace BuildingWorks.Models.Overviews.Plans;

public class PlanOverview : Entity, IOverview
{
    public DateTime StartDate { get; set; }
    public DateTime? CompleteTime { get; set; }
    public bool IsCompleted { get; set; }
    public decimal Cost { get; set; }
    public string? PathToImage { get; set; }
    public Guid BuildingObjectId { get; set; }
    public BuildingObjectOverview BuildingObject { get; set; } = null!;
}
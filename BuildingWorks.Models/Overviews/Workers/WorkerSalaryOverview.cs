using BuildingWorks.Common.Entities;

namespace BuildingWorks.Models.Overviews.Workers;

public class WorkerSalaryOverview : Entity, IOverview
{
    public DateTime AddedOn { get; set; }
    public float BaseSalary { get; set; }
    public float Experience { get; set; }
    public int ChildrenCount { get; set; }
    public int WorkedDays { get; set; }
    public float TotalAmount { get; set; }
    public WorkerOverview Worker { get; set; } = null!;
}

using BuildingWorks.Common.Entities;

namespace BuildingWorks.Models.Resources.Workers;

public class WorkerSalaryResource : Entity, IResource
{
    public DateTime AddedOn { get; set; }
    public float BaseSalary { get; set; }
    public float Experience { get; set; }
    public int ChildrenCount { get; set; }
    public int WorkedDays { get; set; }
    public float TotalAmount { get; set; }

    public Guid WorkerId { get; set; }
}
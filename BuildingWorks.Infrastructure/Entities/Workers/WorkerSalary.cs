using BuildingWorks.Common.Entities;

namespace BuildingWorks.Infrastructure.Entities.Workers;

public class WorkerSalary : Entity
{
    public DateTime AddedOn { get; set; }
    public float BaseSalary { get; set; }
    public float Experience { get; set; }
    public int ChildrenCount { get; set; }
    public int WorkedDays { get; set; }
    public float TotalAmount { get; set; }

    public Guid WorkerId { get; set; }
    public virtual Worker Worker { get; set; } = null!;
}

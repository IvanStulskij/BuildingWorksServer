using BuildingWorks.Common;
using BuildingWorks.Infrastructure.Entities.Plans;

namespace BuildingWorks.Infrastructure.Entities;

public class BuildingObject : Entity 
{
    public string ObjectName { get; set; } = string.Empty; 
    public string ObjectType { get; set; } = string.Empty;
    public string? ObjectCustomer { get; set; }
    public string ExecutorCompany { get; set; } = string.Empty;

    public virtual ICollection<Plan> Plans { get; set; } = null!;
}

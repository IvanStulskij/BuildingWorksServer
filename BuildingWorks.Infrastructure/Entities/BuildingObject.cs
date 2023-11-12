using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Plans;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Entities.Workers;

namespace BuildingWorks.Infrastructure.Entities;

public class BuildingObject : Entity 
{
    public string ObjectName { get; set; } = string.Empty;
    public BuildingObjectTypes BuildingObjectType { get; set; }
    public string BuildingObjectTypeName { get; set; } = string.Empty;
    public string? ObjectCustomer { get; set; }
    public string ExecutorCompany { get; set; } = string.Empty;

    public virtual ICollection<Contract> Contracts { get; set; } = null!;
    public virtual ICollection<Provider> Providers { get; set; } = null!;
    public virtual ICollection<Brigade> Brigades { get; set; } = null!;
    public virtual ICollection<Plan> Plans { get; set; } = null!;
}
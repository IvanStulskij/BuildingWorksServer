using BuildingWorks.Common;

namespace BuildingWorks.Models.Resources.BuildingObjects;

public class BuildingObjectResource : Entity, IResource
{
    public string ObjectName { get; set; } = string.Empty;
    public string ObjectType { get; set; } = string.Empty;
    public string? ObjectCustomer { get; set; }
    public string ExecutorCompany { get; set; } = string.Empty;
}
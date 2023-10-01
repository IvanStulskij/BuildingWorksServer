using BuildingWorks.Common;

namespace BuildingWorks.Models.Overviews.BuildingObjects;

public class BuildingObjectOverview : Entity, IOverview 
{
    public string ObjectName { get; set; } = string.Empty;
    public string ObjectType { get; set; } = string.Empty;
    public string? ObjectCustomer { get; set; }
    public string ExecutorCompany { get; set; } = string.Empty;
}

using BuildingWorks.Common.Entities;

namespace BuildingWorks.Models.Overviews.BuildingObjects;

public class BuildingObjectOverview : Entity, IOverview 
{
    public string ObjectName { get; set; } = string.Empty;
    public BuildingObjectTypes BuildingObjectType { get; set; }
    public string BuildingObjectTypeName { get; set; } = string.Empty;
    public string? ObjectCustomer { get; set; }
    public string ExecutorCompany { get; set; } = string.Empty;
}

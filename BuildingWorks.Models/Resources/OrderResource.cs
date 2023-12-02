using BuildingWorks.Models.Resources.Providers;

namespace BuildingWorks.Models.Resources;

public class OrderResource
{
    public string OrderId { get; set; } = string.Empty;
    public DateTime PlannedDeliveredAt { get; set; }
    public Guid ProviderId { get; set; }
    public Guid BuildingObjectId { get; set; }
    public IEnumerable<OrderMaterialResource> Materials { get; set; }
}
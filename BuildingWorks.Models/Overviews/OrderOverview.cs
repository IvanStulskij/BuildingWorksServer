using BuildingWorks.Common.Entities;

namespace BuildingWorks.Models.Overviews;

public class OrderOverview : Entity, IOverview
{
    public float Cost { get; set; }
    public string OrderId { get; set; } = string.Empty;
    public DateTime? DeliveredAt { get; set; }
    public DateTime StartDeliverAt { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public string Status { get; set; } = string.Empty;
}

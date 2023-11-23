using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Infrastructure.Entities;

public class Order : Entity
{
    public float Cost { get; set; }
    public int OrderID { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public DateTime StartDeliverAt { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public string Status { get; set; } = string.Empty;

    public Guid ProviderId { get; set; }
    public virtual Provider Provider { get; set; }
    public Guid? BuildingObjectId { get; set; }
    public virtual BuildingObject? BuildingObject { get; set; }

    public ICollection<Material> Materials { get; set; }
    public ICollection<OrderMaterial> OrderMaterials { get; set; }
}

public enum OrderStatuses
{
    Created = 0,
    ApprovedByProvider = 1,
    ApprovedByContractor = 2,
    StartDeliver = 4,
    Delivered = 5,
    Rejected = 6,
    MoneyTransferred = 7
}

public class OrderStatusInfo
{
    public Guid Id { get; set; }
    public OrderStatuses StatusId { get; set; }
    public string Status { get; set; } = string.Empty;
}
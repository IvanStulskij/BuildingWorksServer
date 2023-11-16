using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Entities.Workers;

namespace BuildingWorks.Infrastructure.Entities;

public class Order : Entity
{
    public float Cost { get; set; }
    public int OrderID { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public DateTime StartDeliverAt { get; set; }
    public string ProviderName { get; set; } = string.Empty;

    public Guid ProviderId { get; set; }
    public virtual Provider Provider { get; set; }
    public Guid ContractId { get; set; }
    public virtual Contract Contract { get; set; }
    public Guid WorkerId { get; set; }
    public virtual Worker Worker { get; set; }
    public ICollection<Material> Materials { get; set; }
    public ICollection<OrderMaterial> OrderMaterials { get; set; }
}

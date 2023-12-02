using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Infrastructure.Entities.Joininig;

public class OrderMaterial
{
    public decimal PricePerOne { get; set; }
    public int Quantity { get; set; }

    public Guid OrdersId { get; set; }
    public virtual Order Order { get; set; }

    public Guid MaterialsId { get; set; }
    public virtual Material Material { get; set; }
}

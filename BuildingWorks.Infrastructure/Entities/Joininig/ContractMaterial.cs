using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Infrastructure.Entities.Joininig;

public class ContractMaterial
{
    public int Quantity { get; set; }
    public float PricePerOne { get; set; }

    public Guid MaterialsId { get; set; }
    public virtual Material Material { get; set; } = null!;

    public Guid ContractsId { get; set; }
    public virtual Contract Contract { get; set; } = null!;

    public Guid ProviderId { get; set; }
    public virtual Provider Provider { get; set; } = null!;
}

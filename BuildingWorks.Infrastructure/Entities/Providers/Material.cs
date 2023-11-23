using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;

namespace BuildingWorks.Infrastructure.Entities.Providers;

public class Material : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Measure { get; set; } = string.Empty;

    public virtual ICollection<MaterialProvider> MaterialProviders { get; set; } = null!;
    public virtual ICollection<Provider> Providers { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = null!;
    public virtual ICollection<OrderMaterial> MaterialOrders { get; set; } = null!;
}
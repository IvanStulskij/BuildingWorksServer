using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;

namespace BuildingWorks.Infrastructure.Entities.Providers;

public class Provider : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Signer { get; set; } = string.Empty;
    public string? AdditionalData { get; set; }

    public virtual ICollection<MaterialProvider> MaterialProviders { get; set; } = null!;
    public virtual ICollection<Material> Materials { get; set; } = null!;
    public virtual ICollection<BuildingObject> BuildingObjects { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = null!;
}

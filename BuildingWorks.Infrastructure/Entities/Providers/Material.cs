using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;

namespace BuildingWorks.Infrastructure.Entities.Providers;

public class Material : Entity
{
    public string Name { get; set; } = string.Empty;
    public decimal PricePerOne { get; set; }
    public string Measure { get; set; } = string.Empty;

    public virtual ICollection<MaterialProvider> MaterialProviders { get; set; } = null!;
    public virtual ICollection<Contract> Contracts { get; set; } = null!;
    public virtual ICollection<Provider> Providers { get; set; } = null!;
}
using BuildingWorks.Common;

namespace BuildingWorks.Infrastructure.Entities.Providers;

public class Material : Entity
{
    public string Name { get; set; } = string.Empty;
    public decimal PricePerOne { get; set; }
    public string Measure { get; set; } = string.Empty;

    public virtual ICollection<Contract> Contracts { get; set; } = null!;
}
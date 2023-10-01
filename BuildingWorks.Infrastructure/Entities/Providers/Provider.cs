using BuildingWorks.Common;

namespace BuildingWorks.Infrastructure.Entities.Providers;

public class Provider : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Signer { get; set; } = string.Empty;
    public string AdditionalData { get; set; } = string.Empty;

    public ICollection<Contract> Contracts { get; set; } = null!;
}

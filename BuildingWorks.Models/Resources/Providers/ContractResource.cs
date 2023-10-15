using BuildingWorks.Common.Entities;

namespace BuildingWorks.Models.Resources.Providers;

public class ContractResource : Entity, IResource
{
    public DateTime SignedOn { get; set; }
    public string Conditions { get; set; } = string.Empty;

    public ICollection<ProviderResource> Providers { get; set; } = null!;
    public ICollection<MaterialResource> Materials { get; set; } = null!;
}

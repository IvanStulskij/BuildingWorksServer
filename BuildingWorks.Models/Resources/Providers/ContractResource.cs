using BuildingWorks.Common.Entities;

namespace BuildingWorks.Models.Resources.Providers;

public class ContractResource : Entity, IResource
{
    public DateTime SignedOn { get; set; }
    public string Conditions { get; set; } = string.Empty;

    public virtual ICollection<ProviderResource> Providers { get; set; } = null!;
    public virtual ICollection<MaterialResource> Materials { get; set; } = null!;
}

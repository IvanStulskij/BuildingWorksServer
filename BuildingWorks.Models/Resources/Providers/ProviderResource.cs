using BuildingWorks.Common.Entities;

namespace BuildingWorks.Models.Resources.Providers;

public class ProviderResource : Entity, IResource
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Signer { get; set; } = string.Empty;
    public string AdditionalData { get; set; } = string.Empty;
}
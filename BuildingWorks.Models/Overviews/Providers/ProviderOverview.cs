using BuildingWorks.Common;

namespace BuildingWorks.Models.Overviews.Providers;

public class ProviderOverview : Entity, IOverview
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Signer { get; set; } = string.Empty;
    public string AdditionalData { get; set; } = string.Empty;
}
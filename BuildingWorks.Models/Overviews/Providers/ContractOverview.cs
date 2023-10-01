using BuildingWorks.Common;

namespace BuildingWorks.Models.Overviews.Providers;

public class ContractOverview : Entity, IOverview
{
    public DateTime SignedOn { get; set; }
    public string Conditions { get; set; } = string.Empty;

    public IEnumerable<ProviderOverview> Providers { get; set; } = null!;
    public IEnumerable<MaterialOverview> Materials { get; set; } = null!;
}
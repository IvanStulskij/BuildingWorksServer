using BuildingWorks.Common.Entities;

namespace BuildingWorks.Models.Overviews.Providers;

public class ContractOverview : Entity, IOverview
{
    public DateTime? SignedOn { get; set; }
    public string Conditions { get; set; } = string.Empty;
    public int ProvidersCount { get; set; }
    public int MaterialsCount { get; set; }
}
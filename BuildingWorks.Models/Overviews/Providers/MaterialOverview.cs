using BuildingWorks.Common;

namespace BuildingWorks.Models.Overviews.Providers;

public class MaterialOverview : Entity, IOverview
{
    public string Name { get; set; } = string.Empty;
    public decimal PricePerOne { get; set; }
    public string Measure { get; set; } = string.Empty;
}

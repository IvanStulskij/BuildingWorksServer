using BuildingWorks.Common;

namespace BuildingWorks.Models.Resources.Providers;

public class MaterialResource : Entity, IResource
{
    public string Name { get; set; } = string.Empty;
    public decimal PricePerOne { get; set; }
    public string Measure { get; set; } = string.Empty;
}

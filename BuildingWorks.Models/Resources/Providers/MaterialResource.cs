using BuildingWorks.Common.Entities;

namespace BuildingWorks.Models.Resources.Providers;

public class MaterialResource : Entity, IResource
{
    public string Name { get; set; } = string.Empty;
    public string Measure { get; set; } = string.Empty;
}

public class OrderMaterialResource : Entity, IResource
{
    public int Quantity { get; set; }
    public decimal PricePerOne { get; set; }
}

public class OrderMaterialResult : Entity, IResource
{
    public string Name { get; set; } = string.Empty;
    public string Measure { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal PricePerOne { get; set; }
}
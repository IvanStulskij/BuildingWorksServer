using BuildingWorks.Models.Resources.Providers;

namespace BuildingWorks.Models.Resources;

public class OrderResource : IResource
{
    public Guid Id { get; set; }
    public string OrderId { get; set; } = string.Empty;
    public Guid ProviderId { get; set; }
    public Guid ContractId { get; set; }
    public IEnumerable<OrderMaterialResource> Materials { get; set; }
}
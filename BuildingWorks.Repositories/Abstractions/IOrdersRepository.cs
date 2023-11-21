using BuildingWorks.Models.Resources;
using BuildingWorks.Models.Resources.Providers;

namespace BuildingWorks.Repositories.Abstractions;

public interface IOrdersRepository
{
    Task Add(OrderResource order);
    Task SetAsDelivered(Guid orderId);
    Task<IEnumerable<OrderMaterialResult>> GetMaterials(Guid orderId);
    Task SendOrderLink(Guid orderId);
    Task<bool> ApproveByProvider(Guid id);
}

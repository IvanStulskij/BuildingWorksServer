using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Models.Resources;
using BuildingWorks.Models.Resources.Providers;

namespace BuildingWorks.Repositories.Abstractions;

public interface IOrdersRepository
{
    Task Add(OrderResource order);
    Task SetAsDelivered(Guid orderId);
    Task<IEnumerable<OrderMaterialResult>> GetMaterials(Guid orderId);
}

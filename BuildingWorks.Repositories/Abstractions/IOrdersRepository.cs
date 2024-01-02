using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Loading;
using BuildingWorks.Models.Resources;
using BuildingWorks.Models.Resources.Providers;

namespace BuildingWorks.Repositories.Abstractions;

public interface IOrdersRepository
{
    Task Add(OrderResource order);
    Task SetAsDelivered(Guid orderId);
    Task<LoadResult<OrderMaterialResult>> GetMaterials(Guid orderId, LoadConditions loadConditions);
    Task SendOrderLink(Guid orderId);
    Task<bool> ApproveByProvider(Guid id);
    Task<IEnumerable<DictionaryItem>> GetMaterialsToAddToOrder(Guid providerId, Guid orderId);
}

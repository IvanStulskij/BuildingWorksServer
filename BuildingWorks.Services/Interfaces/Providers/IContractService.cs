using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;

namespace BuildingWorks.Services.Interfaces.Providers;

public interface IContractService : IOverviewService<ContractResource, ContractOverview>
{
    Task<IEnumerable<ProviderOverview>> GetProviders(Guid id);
    Task<IEnumerable<MaterialOverview>> GetMaterials(Guid id, Guid providerId);
    Task AddProvider(Guid id, Guid providerId);
    Task DeleteProvider(Guid id, Guid providerId);
    Task<OrderMaterialResult> AddMaterial(Guid id, Guid providerId, OrderMaterialResource material);
    Task<OrderMaterialResult> UpdateMaterial(Guid id, Guid providerId, OrderMaterialResource material);
    Task DeleteMaterial(Guid id, Guid materialId, Guid providerId);
}

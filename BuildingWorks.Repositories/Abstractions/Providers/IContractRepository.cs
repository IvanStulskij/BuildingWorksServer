using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;

namespace BuildingWorks.Repositories.Abstractions.Providers;

public interface IContractRepository : IOverviewRepository<Contract>
{
    //Document GetContractDocument(Document template, Guid contractId);
    //float CalculateTotalCost(Guid contractId);
    Task<IEnumerable<MaterialOverview>> GetMaterials(Guid id, Guid providerId);
    Task<IEnumerable<Provider>> GetProviders(Guid id);
    Task<bool> IsSigned(Guid id);
    Task AddProvider(Guid id, Guid providerId);
    Task DeleteProvider(Guid id, Guid providerId);
    Task<OrderMaterialResult> AddMaterial(Guid id, Guid providerId, OrderMaterialResource material);
    Task<OrderMaterialResult> UpdateMaterial(Guid id, Guid providerId, OrderMaterialResource material);
    Task DeleteMaterial(Guid id, Guid materialId, Guid providerId);
}

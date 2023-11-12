using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Repositories.Abstractions.Providers;

public interface IContractRepository : IOverviewRepository<Contract>
{
    //Document GetContractDocument(Document template, Guid contractId);
    //float CalculateTotalCost(Guid contractId);
    Task<IEnumerable<Material>> GetMaterials(Guid id, Guid providerId);
    Task<IEnumerable<Provider>> GetProviders(Guid id);
    Task<bool> IsSigned(Guid id);
    Task AddProvider(Guid id, Guid providerId);
    Task DeleteProvider(Guid id, Guid providerId);
    Task AddMaterial(Guid id, Guid materialId);
    Task DeleteMaterial(Guid id, Guid materialId);
}

using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Repositories.Abstractions.Providers;

public interface IContractRepository : IOverviewRepository<Contract>
{
    //Document GetContractDocument(Document template, Guid contractId);
    //float CalculateTotalCost(Guid contractId);
    Task<IEnumerable<Material>> GetMaterials(Guid id);
    Task<IEnumerable<Provider>> GetProviders(Guid id);
    Task<bool> IsSigned(Guid id);
    Task AddProviderToContract(Guid id, Guid providerId);
}

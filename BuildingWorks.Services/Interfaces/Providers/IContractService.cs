using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;

namespace BuildingWorks.Services.Interfaces.Providers;

public interface IContractService : IOverviewService<ContractResource, ContractOverview>
{
    Task<IEnumerable<ProviderOverview>> GetProviders(Guid id);
    Task<IEnumerable<MaterialOverview>> GetMaterials(Guid id, Guid providerId);
    Task AddProvider(Guid id, Guid providerId);
    Task DeleteProvider(Guid id, Guid providerId);
}

using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;

namespace BuildingWorks.Services.Interfaces.Providers;

public interface IContractService : IOverviewService<ContractResource, ContractOverview>
{
    Task<IEnumerable<ProviderOverview>> GetProviders(Guid id);
    Task<IEnumerable<MaterialOverview>> GetMaterials(Guid id);
    Task AddProviderToContract(Guid id, Guid providerId);
}

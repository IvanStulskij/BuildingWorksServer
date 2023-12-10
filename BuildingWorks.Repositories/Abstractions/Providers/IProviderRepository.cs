using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Models.Overviews.Providers;

namespace BuildingWorks.Repositories.Abstractions.Providers;

public interface IProviderRepository : IOverviewRepository<Provider, ProviderOverview>
{
    Task<IEnumerable<DictionaryItem>> GetShortInfos();
    Task<IEnumerable<Material>> GetMaterials(Guid providerId);
    Task AddMaterial(Guid id, Guid materialId);
    Task DeleteMaterial(Guid id, Guid materialId);
}

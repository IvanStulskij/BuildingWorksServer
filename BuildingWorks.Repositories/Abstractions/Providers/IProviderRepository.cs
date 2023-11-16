using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Repositories.Abstractions.Providers;

public interface IProviderRepository : IOverviewRepository<Provider>
{
    Task<IEnumerable<DictionaryItem>> GetShortInfos();
    Task<IEnumerable<Material>> GetMaterials(Guid providerId);
    Task AddMaterial(Guid id, Guid materialId);
    Task DeleteMaterial(Guid id, Guid materialId);
}

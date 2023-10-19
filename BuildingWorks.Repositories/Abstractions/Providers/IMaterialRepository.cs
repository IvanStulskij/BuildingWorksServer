using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Repositories.Abstractions.Providers;

public interface IMaterialRepository : IOverviewRepository<Material>
{
    Task<IEnumerable<DictionaryItem>> GetShortInfos();
}

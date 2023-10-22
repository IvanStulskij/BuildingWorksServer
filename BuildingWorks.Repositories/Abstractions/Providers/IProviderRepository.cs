using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Repositories.Abstractions.Providers;

public interface IProviderRepository : IOverviewRepository<Provider>
{
    Task<IEnumerable<DictionaryItem>> GetShortInfos();
}

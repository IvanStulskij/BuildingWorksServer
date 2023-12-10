using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Models.Overviews.Providers;

namespace BuildingWorks.Repositories.Abstractions.Providers;

public interface IMaterialRepository : IOverviewRepository<Material, MaterialOverview>
{
    Task<IEnumerable<DictionaryItem>> GetShortInfos();
}

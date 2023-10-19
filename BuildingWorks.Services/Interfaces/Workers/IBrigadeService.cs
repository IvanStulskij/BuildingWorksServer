using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;

namespace BuildingWorks.Services.Interfaces.Workers;

public interface IBrigadeService : IOverviewService<BrigadeResource, BrigadeOverview>
{
    Task<IEnumerable<Worker>> GetWorkers(Guid brigadeId);
    Task<IEnumerable<DictionaryItem>> GetShortInfos();
    Task AddWorker(Guid id, Guid workerId);
}

using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Workers;

namespace BuildingWorks.Repositories.Abstractions.Workers;

public interface IBrigadeRepository : IOverviewRepository<Brigade>
{
    Task<IEnumerable<Worker>> GetWorkers(Guid brigadeId);
    Task AddWorker(Guid id, Guid workerId);
    Task<IEnumerable<DictionaryItem>> GetShortInfos();
}

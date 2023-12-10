using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;

namespace BuildingWorks.Repositories.Abstractions.Workers;

public interface IWorkerRepository : IOverviewRepository<Worker, WorkerOverview>
{
    
}

using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;

namespace BuildingWorks.Repositories.Abstractions.Workers;

public interface IWorkerSalaryRepository : IOverviewRepository<WorkerSalary, WorkerSalaryOverview>
{
    //float Calculate(Guid workerSalaryId);
}

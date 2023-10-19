using BuildingWorks.Infrastructure.Entities.Workers;

namespace BuildingWorks.Repositories.Abstractions.Workers;

public interface IWorkerSalaryRepository : IOverviewRepository<WorkerSalary>
{
    //float Calculate(Guid workerSalaryId);
}

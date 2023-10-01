using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;

namespace BuildingWorks.Services.Interfaces.Workers;

public interface IWorkerSalaryService : IOverviewService<WorkerSalaryResource, WorkerSalaryOverview>
{
}

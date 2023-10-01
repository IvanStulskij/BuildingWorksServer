using AutoMapper;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Services.Interfaces.Workers;

namespace BuildingWorks.Services.Implementations.Workers;

public class WorkerService : OverviewService<Worker, WorkerResource, WorkerOverview>, IWorkerService
{
    public WorkerService(IMapper mapper, IWorkerRepository repository) : base(mapper, repository)
    {
    }
}

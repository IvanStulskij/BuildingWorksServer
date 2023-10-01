using AutoMapper;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Services.Interfaces.Workers;
using FluentValidation;

namespace BuildingWorks.Services.Implementations.Workers;

public class WorkerService : OverviewService<Worker, WorkerResource, WorkerOverview>, IWorkerService
{
    public WorkerService(IMapper mapper, IWorkerRepository repository, IValidator<WorkerResource> validator) : base(mapper, repository, validator)
    {
    }
}

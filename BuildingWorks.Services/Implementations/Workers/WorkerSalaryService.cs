using AutoMapper;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Services.Interfaces.Workers;
using FluentValidation;

namespace BuildingWorks.Services.Implementations.Workers;

public class WorkerSalaryService : OverviewService<WorkerSalary, WorkerSalaryResource, WorkerSalaryOverview>, IWorkerSalaryService
{
    public WorkerSalaryService(IMapper mapper, IWorkerSalaryRepository repository, IValidator<WorkerSalaryResource> validator) : base(mapper, repository, validator)
    {
    }
}

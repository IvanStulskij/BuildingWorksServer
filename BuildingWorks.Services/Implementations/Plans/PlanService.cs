using AutoMapper;
using BuildingWorks.Infrastructure.Entities.Plans;
using BuildingWorks.Models.Overviews.Plans;
using BuildingWorks.Models.Resources.Plans;
using BuildingWorks.Repositories.Abstractions.Plans;
using BuildingWorks.Services.Interfaces.Plans;
using FluentValidation;

namespace BuildingWorks.Services.Implementations.Plans;

public class PlanService : OverviewService<Plan, PlanResource, PlanOverview>, IPlanService
{
    public PlanService(IMapper mapper, IPlanRepository repository, IValidator<PlanResource> validator) : base(mapper, repository, validator)
    {
    }
}

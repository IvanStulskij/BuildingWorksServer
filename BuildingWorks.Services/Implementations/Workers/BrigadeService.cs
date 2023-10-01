using AutoMapper;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Services.Interfaces.Workers;
using FluentValidation;

namespace BuildingWorks.Services.Implementations.Workers;

public class BrigadeService : OverviewService<Brigade, BrigadeResource, BrigadeOverview>, IBrigadeService
{
    public BrigadeService(IMapper mapper, IBrigadeRepository repository, IValidator<BrigadeResource> validator) : base(mapper, repository, validator)
    {
    }
}

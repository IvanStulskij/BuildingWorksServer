using AutoMapper;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Services.Interfaces.Workers;

namespace BuildingWorks.Services.Implementations.Workers;

public class BrigadeService : OverviewService<Brigade, BrigadeResource, BrigadeOverview>, IBrigadeService
{
    public BrigadeService(IMapper mapper, IBrigadeRepository repository) : base(mapper, repository)
    {
    }
}

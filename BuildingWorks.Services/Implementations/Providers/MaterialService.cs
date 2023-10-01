using AutoMapper;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using BuildingWorks.Services.Interfaces.Providers;

namespace BuildingWorks.Services.Implementations.Providers;

public class MaterialService : OverviewService<Material, MaterialResource, MaterialOverview>, IMaterialService
{
    public MaterialService(IMapper mapper, IMaterialRepository repository) : base(mapper, repository)
    {
    }
}

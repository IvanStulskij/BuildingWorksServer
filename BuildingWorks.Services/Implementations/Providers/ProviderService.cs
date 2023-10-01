using AutoMapper;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using BuildingWorks.Services.Interfaces.Providers;
using FluentValidation;

namespace BuildingWorks.Services.Implementations.Providers;

public class ProviderService : OverviewService<Provider, ProviderResource, ProviderOverview>, IProviderService
{
    public ProviderService(IMapper mapper, IProviderRepository repository, IValidator<ProviderResource> validator) : base(mapper, repository, validator)
    {
    }
}

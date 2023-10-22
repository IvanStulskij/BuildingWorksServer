using AutoMapper;
using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using BuildingWorks.Services.Interfaces.Providers;
using FluentValidation;

namespace BuildingWorks.Services.Implementations.Providers;

public class ProviderService : OverviewService<Provider, ProviderResource, ProviderOverview>, IProviderService
{
    private readonly IProviderRepository _repository;

    public ProviderService(IMapper mapper, IProviderRepository repository, IValidator<ProviderResource> validator) : base(mapper, repository, validator)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DictionaryItem>> GetShortInfos()
    {
        var shortInfos = await _repository.GetShortInfos();

        return shortInfos;
    }
}

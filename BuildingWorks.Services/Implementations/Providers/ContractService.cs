using AutoMapper;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using BuildingWorks.Services.Interfaces.Providers;
using FluentValidation;

namespace BuildingWorks.Services.Implementations.Providers;

public class ContractService : OverviewService<Contract, ContractResource, ContractOverview>, IContractService
{
    private readonly IContractRepository _repository;
    private readonly IMapper _mapper;

    public ContractService(IMapper mapper, IContractRepository repository, IValidator<ContractResource> validator) : base(mapper, repository, validator)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MaterialOverview>> GetMaterials(Guid id)
    {
        var materials = await _repository.GetMaterials(id);

        return _mapper.Map<IEnumerable<MaterialOverview>>(materials);
    }

    public async Task<IEnumerable<ProviderOverview>> GetProviders(Guid id)
    {
        var providers = await _repository.GetProviders(id);

        return _mapper.Map<IEnumerable<ProviderOverview>>(providers);
    }

    public async Task AddProviderToContract(Guid id, Guid providerId)
    {
        await _repository.AddProviderToContract(id, providerId);
    }
}

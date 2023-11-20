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

    public override IEnumerable<ContractOverview> GetAllOverview()
    {
        var dtos = _repository.GetOverviewDisplayedData();
        var overviews = dtos.Select(dto => new ContractOverview
        {
            Id = dto.Id,
            Conditions = dto.Conditions,
            SignedOn = dto.SignedOn,
            MaterialsCount = dto.Materials.Count(),
            ProvidersCount = dto.Providers.Count()
        });

        return overviews;
    }

    public async Task<IEnumerable<MaterialOverview>> GetMaterials(Guid id, Guid providerId)
    {
        var materials = await _repository.GetMaterials(id, providerId);

        return _mapper.Map<IEnumerable<MaterialOverview>>(materials);
    }

    public async Task<IEnumerable<ProviderOverview>> GetProviders(Guid id)
    {
        var providers = await _repository.GetProviders(id);

        return _mapper.Map<IEnumerable<ProviderOverview>>(providers);
    }

    public async Task AddProvider(Guid id, Guid providerId)
    {
        await _repository.AddProvider(id, providerId);
    }

    public async Task DeleteProvider(Guid id, Guid providerId)
    {
        await _repository.DeleteProvider(id, providerId);
    }

    public async Task<OrderMaterialResult> AddMaterial(Guid id, Guid providerId, OrderMaterialResource material)
    {
        return await _repository.AddMaterial(id, providerId, material);
    }

    public async Task<OrderMaterialResult> UpdateMaterial(Guid id, Guid providerId, OrderMaterialResource material)
    {
        return await _repository.UpdateMaterial(id, providerId, material);
    }

    public async Task DeleteMaterial(Guid id, Guid materialId, Guid providerId)
    {
        await _repository.DeleteMaterial(id, materialId, providerId);
    }
}

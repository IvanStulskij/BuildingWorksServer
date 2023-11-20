using BuildingWorks.Common.Constants;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using BuildingWorks.Repositories.Common;
using BuildingWorks.Repositories.Query;
using BuildingWorks.Repositories.Specification;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations.Providers;

public class ContractRepository : OverviewRepository<Contract>, IContractRepository
{
    private readonly IDatabaseChanges _databaseChanges;
    private readonly ContractIsChangableSpecification _specification = new ContractIsChangableSpecification();

    public ContractRepository(BuildingWorksDbContext context, IDatabaseChanges databaseChanges) : base(context)
    {
        _databaseChanges = databaseChanges;
    }

    public override async Task Delete(Guid id)
    {
        var contract = await Context.Contracts.FirstOrDefaultAsync(contract => contract.Id == id);

        if (contract == null)
        {
            throw new EntityNotExistException($"Contract with id {id} doesn't exist in database");
        }

        if (!string.IsNullOrWhiteSpace(contract.Conditions))
        {
            throw new ValidationException(ErrorsConstants.Messages.ContractHasConditions);
        }

        await base.Delete(id);
    }

    public override async Task<Contract> Update(Contract entity)
    {
        if (entity.SignedOn != null)
        {
            throw new ValidationException(ErrorsConstants.Messages.ContractIsSigned);
        }

        return await base.Update(entity);
    }

    public async Task AddProvider(Guid id, Guid providerId)
    {
        var buildingObjectIds = Context.BuildingObjectProvider.AsNoTracking()
            .Where(entity => entity.ProvidersId == providerId)
            .Select(entity => entity.BuildingObjectsId);
        var contract = await Set.FirstOrDefaultAsync(contract => contract.Id == id);
        var providersExistForBuildingObject = await buildingObjectIds.ContainsAsync(contract.BuildingObjectId.Value);

        if (!providersExistForBuildingObject)
        {
            throw new ValidationException(ErrorsConstants.Messages.ProviderNotExistToBuildingObject);
        }

        if (_specification.IsSatisfiedBy(contract))
        {
            throw new ValidationException(ErrorsConstants.Messages.ContractIsSigned);
        }

        var entity = new ContractProvider
        {
            ContractsId = id,
            ProvidersId = providerId
        };
        await Context.ContractProvider.AddAsync(entity);
        await _databaseChanges.TrySaveChanges(ErrorsConstants.Messages.ContractAlreadyHasProvider);
    }

    public async Task<IEnumerable<MaterialOverview>> GetMaterials(Guid id, Guid providerId)
    {
        var contract = await Set.AsNoTracking()
            .Include(contract => contract.Providers)
            .SingleOrDefaultAsync(contract => contract.Id == id);

        if (contract == null)
        {
            throw new EntityNotExistException($"Contract with id {id} doesn't exist in database ");
        }

        if (_specification.IsSatisfiedBy(contract))
        {
            throw new ValidationException(ErrorsConstants.Messages.ContractIsSigned);
        }

        var materials = await Context.ContractMaterial.AsNoTracking()
            .Include(entity => entity.Material)
            .Where(entity => entity.ProviderId == providerId && entity.ContractsId == id)
            .Select(entity => new MaterialOverview
            {
                Id = entity.MaterialsId,
                Measure = entity.Material.Measure,
                Name = entity.Material.Name,
                PricePerOne = entity.PricePerOne,
                Quantity = entity.Quantity,
                TotalPrice = entity.Quantity * entity.PricePerOne
            })
            .ToListAsync();

        return materials;
    }

    public async Task<IEnumerable<Provider>> GetProviders(Guid id)
    {
        var providers = await Context.ContractProvider.AsNoTracking()
            .Include(contractProvider => contractProvider.Provider)
            .Where(contractProvider => contractProvider.ContractsId == id)
            .Select(contractProvider => contractProvider.Provider)
            .ToListAsync();

        return providers;
    }

    public async Task<bool> IsSigned(Guid id)
    {
        var contract = await Context.Contracts.FirstOrDefaultAsync(contract => contract.Id == id);

        if (contract == null)
        {
            throw new EntityNotExistException($"Contract with id {id} doesn't exist in database ");
        }

        return contract.SignedOn == null;
    }

    protected override IQueryable<Contract> IncludeHierarchy()
    {
        return Set.IncludeHierarchy();
    }

    public async Task DeleteProvider(Guid id, Guid providerId)
    {
        var contract = await Set.SingleOrDefaultAsync(contract => contract.Id == id);

        if (contract == null)
        {
            throw new EntityNotExistException($"Contract with id {id} doesn't exist in database ");
        }

        if (_specification.IsSatisfiedBy(contract))
        {
            throw new ValidationException(ErrorsConstants.Messages.ContractIsSigned);
        }

        var deletedCount = await Context.ContractProvider
            .Where(entity => entity.ContractsId == id && entity.ProvidersId == providerId)
            .ExecuteDeleteAsync();

        if (deletedCount == 0)
        {
            throw new EntityNotExistException($"Material with id {id} doesn't exist in database or not linked to provider with id {providerId}");
        }
    }

    public async Task<OrderMaterialResult> AddMaterial(Guid id, Guid providerId, OrderMaterialResource resource)
    {
        var contract = await Set.AsNoTracking()
            .Include(contract => contract.Providers)
                .ThenInclude(provider => provider.Materials)
            .SingleOrDefaultAsync(contract => contract.Id == id);

        if (contract == null)
        {
            throw new EntityNotExistException($"Contract with id {id} doesn't exist in database ");
        }

        if (_specification.IsSatisfiedBy(contract))
        {
            throw new ValidationException(ErrorsConstants.Messages.ContractIsSigned);
        }

        var providerIds = contract.Providers.Select(provider => provider.Id);

        var entity = new ContractMaterial
        {
            MaterialsId = resource.Id,
            ProviderId = providerId,
            ContractsId = id,
            PricePerOne = resource.PricePerOne,
            Quantity = resource.Quantity,
        };
        await Context.ContractMaterial.AddAsync(entity);
        await _databaseChanges.TrySaveChanges(ErrorsConstants.Messages.ContractAlreadyHasProvider);

        return new OrderMaterialResult
        {
            Id = id,
            Quantity = entity.Quantity,
            PricePerOne = entity.PricePerOne
        };
    }

    public async Task DeleteMaterial(Guid id, Guid materialId, Guid providerId)
    {
        var deletedCount = await Context.ContractMaterial
            .Include(entity => entity.Contract)
            .Where(entity => entity.ContractsId == id && entity.ProviderId == providerId && entity.MaterialsId == materialId && entity.Contract.SignedOn == null)
            .ExecuteDeleteAsync();

        if (deletedCount == 0)
        {
            throw new EntityNotExistException($"Material with id {materialId} doesn't exist in database or not linked to provider with id {providerId} or contract with id {id}");
        }
    }

    public async Task<OrderMaterialResult> UpdateMaterial(Guid id, Guid providerId, OrderMaterialResource material)
    {
        var contractMaterial = await Context.ContractMaterial
            .Include(entity => entity.Material)
            .SingleOrDefaultAsync(entity => entity.MaterialsId == material.Id && entity.ProviderId == providerId && entity.ContractsId == id);

        if (contractMaterial == null)
        {
            throw new EntityNotExistException($"Pair of material with id {material.Id}, contract with id {id}, provider with id {providerId} not exist in database");
        }

        contractMaterial.Quantity = material.Quantity;
        contractMaterial.PricePerOne = material.PricePerOne;

        await Context.SaveChangesAsync();

        return new OrderMaterialResult
        {
            Id = material.Id,
            Name = contractMaterial.Material.Name,
            Measure = contractMaterial.Material.Measure,
            Quantity = material.Quantity,
            PricePerOne = material.PricePerOne,
        };
    }
}
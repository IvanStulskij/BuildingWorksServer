using BuildingWorks.Common.Constants;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Providers;
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

    public async Task<IEnumerable<Material>> GetMaterials(Guid id, Guid providerId)
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
            .Select(entity => entity.Material)
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

        await Context.ContractProvider
            .Where(entity => entity.ContractsId == id && entity.ProvidersId == providerId)
            .ExecuteDeleteAsync();
    }

    public async Task AddMaterial(Guid id, Guid materialId)
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

        var providerIds = contract.Providers.Select(provider => provider.Id);

        var entity = new MaterialProvider
        {
            MaterialsId = id,
            ProvidersId = materialId
        };
        //await Context.MaterialProvider.AddAsync(entity);
        await _databaseChanges.TrySaveChanges(ErrorsConstants.Messages.ContractAlreadyHasProvider);
    }

    public Task DeleteMaterial(Guid id, Guid materialId)
    {
        throw new NotImplementedException();
    }
}
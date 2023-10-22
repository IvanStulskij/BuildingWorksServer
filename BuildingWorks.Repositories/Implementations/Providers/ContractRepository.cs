using BuildingWorks.Common.Constants;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using BuildingWorks.Repositories.Common;
using BuildingWorks.Repositories.Query;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations.Providers;

public class ContractRepository : OverviewRepository<Contract>, IContractRepository
{
    private readonly IDatabaseChanges _databaseChanges;

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

    public async Task AddProviderToContract(Guid id, Guid providerId)
    {
        var entity = new ContractProvider
        {
            ContractsId = id,
            ProvidersId = providerId
        };
        await Context.ContractProvider.AddAsync(entity);
        await _databaseChanges.TrySaveChanges(ErrorsConstants.Messages.ContractAlreadyHasProvider);
    }

    public async Task<IEnumerable<Material>> GetMaterials(Guid id)
    {
        var materials = await Context.ContractMaterial.AsNoTracking()
            .Include(contractMaterial => contractMaterial.Material)
            .Where(contractMaterial => contractMaterial.ContractsId == id)
            .Select(contractMaterial => contractMaterial.Material)
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
}

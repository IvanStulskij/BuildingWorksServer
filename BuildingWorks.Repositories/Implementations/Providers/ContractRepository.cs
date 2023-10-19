using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using BuildingWorks.Repositories.Query;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations.Providers;

public class ContractRepository : OverviewRepository<Contract>, IContractRepository
{
    public ContractRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    public async Task AddProviderToContract(Guid id, Guid providerId)
    {
        var entity = new ContractProvider
        {
            ContractsId = id,
            ProvidersId = providerId
        };
        await Context.ContractProvider.AddAsync(entity);
        await Context.SaveChangesAsync();
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

using BuildingWorks.Common.Entities;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations.Providers;

public class ProviderRepository : OverviewRepository<Provider, ProviderOverview>, IProviderRepository
{
    public ProviderRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    public async Task AddMaterial(Guid id, Guid materialId)
    {
        var providerMaterial = new MaterialProvider
        {
            MaterialsId = materialId,
            ProvidersId = id,
        };

        try
        {
            await Context.MaterialProvider.AddAsync(providerMaterial);
            await Context.SaveChangesAsync();
        }
        catch
        {
            throw new EntityAlreadyExistException($"Material with id {materialId} already exist to provider with id {id}");
        }
    }

    public async Task DeleteMaterial(Guid id, Guid materialId)
    {
        var deletedCount = await Context.MaterialProvider
            .Where(entity => entity.MaterialsId == materialId && entity.ProvidersId == id)
            .ExecuteDeleteAsync();

        if (deletedCount == 0)
        {
            throw new EntityNotExistException($"Material with id {materialId} doesn't exist in database or not linked to provider with id {id}");
        }
    }

    public async Task<IEnumerable<Material>> GetMaterials(Guid providerId)
    {
        var materials = await Context.MaterialProvider.AsNoTracking()
            .Include(entity => entity.Material)
            .Where(entity => entity.ProvidersId == providerId)
            .Select(entity => entity.Material)
            .ToListAsync();

        return materials;
    }

    public async Task<IEnumerable<DictionaryItem>> GetShortInfos()
    {
        var providers = await Set.AsNoTracking()
            .Select(provider => new DictionaryItem
            {
                Id = provider.Id.ToString(),
                Name = provider.Name
            })
            .ToListAsync();

        return providers;
    }

    protected override IQueryable<ProviderOverview> IncludeHierarchy()
    {
        return Set.Select(x => new ProviderOverview
        {
            Id = x.Id,
            Name = x.Name,
            AdditionalData = x.AdditionalData,
            Country = x.Country,
            Signer = x.Signer
        });
    }
}

using BuildingWorks.Common.Constants;
using BuildingWorks.Common.Entities;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BuildingWorks.Repositories.Implementations.Providers;

public class MaterialRepository : OverviewRepository<Material>, IMaterialRepository
{
    public MaterialRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<DictionaryItem>> GetShortInfos()
    {
        var dictionaryItems = await Set.Select(material => new DictionaryItem
        {
            Id = material.Id.ToString(),
            Name = material.Name
        }).ToListAsync();

        return dictionaryItems;
    }

    public override async Task Delete(Guid id)
    {
        var contractsExistForMaterial = await Context.ContractMaterial.AnyAsync(entity => entity.MaterialsId == id);

        if (contractsExistForMaterial)
        {
            throw new ValidationException(ErrorsConstants.Messages.MaterialHasContracts);
        }

        var deletedCount = await Set
            .Where(material => contractsExistForMaterial && material.Id == id)
            .ExecuteDeleteAsync();

        if (deletedCount == 0)
        {
            throw new EntityNotExistException($"Material with id {id} doesn't exist in database");
        }
    }

    protected override IQueryable<Material> IncludeHierarchy()
    {
        return Set;
    }
}

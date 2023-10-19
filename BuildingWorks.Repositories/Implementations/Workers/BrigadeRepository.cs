using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Repositories.Query;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations.Workers;

public class BrigadeRepository : OverviewRepository<Brigade>, IBrigadeRepository
{
    public BrigadeRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    public async Task AddWorker(Guid id, Guid workerId)
    {
        var entity = new BrigadeWorker
        {
            BrigadesId = id,
            WorkersId = workerId
        };
        await Context.BrigadeWorker.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<DictionaryItem>> GetShortInfos()
    {
        var brigades = await Set.Select(brigade => new DictionaryItem
        {
            Id = brigade.Id.ToString(),
            Name = brigade.Number
        }).ToListAsync();

        return brigades;
    }

    public async Task<IEnumerable<Worker>> GetWorkers(Guid brigadeId)
    {
        var workers = await Context.BrigadeWorker.AsNoTracking()
            .Include(brigadeWorker => brigadeWorker.Worker)
            .Where(brigadeWorker => brigadeWorker.BrigadesId == brigadeId)
            .Select(brigadeWorker => brigadeWorker.Worker)
            .ToListAsync();

        return workers;
    }

    protected override IQueryable<Brigade> IncludeHierarchy()
    {
        return Set.IncludeHierarchy();
    }
}

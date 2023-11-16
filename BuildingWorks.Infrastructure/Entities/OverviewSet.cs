using BuildingWorks.Infrastructure.Entities.Workers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BuildingWorks.Infrastructure.Entities;

public abstract class OverviewSet<T> : DbSet<T>
    where T : class
{
    public override IEntityType EntityType => (IEntityType)typeof(T);

    public abstract IQueryable<T> IncludeHierarchy();
}

public class WorkerSet : OverviewSet<Worker>
{
    public override IQueryable<Worker> IncludeHierarchy()
    {
        return this
            .Include(worker => worker.Brigades);
    }
}
﻿using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure;
using BuildingWorks.Repositories.Abstractions;

namespace BuildingWorks.Repositories.Implementations;

public abstract class OverviewRepository<T> : Repository<T>, IOverviewRepository<T>
    where T : Entity
{
    protected OverviewRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    public virtual IQueryable<T> GetOverviewDisplayedData()
    {
        return IncludeHierarchy();
    }

    protected abstract IQueryable<T> IncludeHierarchy();
}

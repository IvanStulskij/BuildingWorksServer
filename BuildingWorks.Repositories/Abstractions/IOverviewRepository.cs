using BuildingWorks.Common.Entities;

namespace BuildingWorks.Repositories.Abstractions;

public interface IOverviewRepository<T> : IRepository<T>
    where T : Entity
{
    IQueryable<T> GetOverviewDisplayedData();
}

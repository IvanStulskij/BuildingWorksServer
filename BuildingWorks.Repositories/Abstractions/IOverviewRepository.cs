using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Loading;

namespace BuildingWorks.Repositories.Abstractions;

public interface IOverviewRepository<T, TOverview> : IRepository<T>
    where T : Entity
{
    Task<IEnumerable<TOverview>> GetOverviewDisplayedData(LoadConditions loadConditions);
}

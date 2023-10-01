using BuildingWorks.Infrastructure.Entities.Providers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Query;

public static class ContractQuery
{
    public static IQueryable<Contract> IncludeHierarchy(this IQueryable<Contract> contracts)
    {
        return contracts
            .Include(contract => contract.Materials)
            .Include(contract => contract.Providers);
    }
}

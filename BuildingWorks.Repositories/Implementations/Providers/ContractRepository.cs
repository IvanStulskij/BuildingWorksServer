using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using BuildingWorks.Repositories.Query;

namespace BuildingWorks.Repositories.Implementations.Providers;

public class ContractRepository : OverviewRepository<Contract>, IContractRepository
{
    public ContractRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<Contract> IncludeHierarchy()
    {
        return Set.IncludeHierarchy();
    }
}

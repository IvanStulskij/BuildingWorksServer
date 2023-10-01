using AutoMapper;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Repositories.Abstractions.Providers;
using BuildingWorks.Services.Interfaces.Providers;

namespace BuildingWorks.Services.Implementations.Providers;

public class ContractService : OverviewService<Contract, ContractResource, ContractOverview>, IContractService
{
    public ContractService(IMapper mapper, IContractRepository repository) : base(mapper, repository)
    {
    }
}

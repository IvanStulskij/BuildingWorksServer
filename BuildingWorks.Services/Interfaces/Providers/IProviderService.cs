using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Resources.Providers;

namespace BuildingWorks.Services.Interfaces.Providers;

public interface IProviderService : IOverviewService<ProviderResource, ProviderOverview>
{
}

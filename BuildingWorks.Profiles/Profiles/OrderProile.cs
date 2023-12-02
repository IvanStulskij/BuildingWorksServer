using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Models.Overviews;
using BuildingWorks.Models.Resources;

namespace BuildingWorks.Profiles.Profiles;

public class OrderProile : BaseOverviewProfile<Order, OrderResource, OrderOverview>
{
    protected override void ConfigureOverviewProfiling()
    {
        CreateMap<OrderResource, Order>()
            .ForMember(order => order.Materials, options => options.Ignore());
    }
}

using BuildingWorks.Infrastructure.Entities;
using Microsoft.AspNetCore.SignalR;

namespace BuildingWorksServer.Hubs;

public class ProviderSubmitStatusHub : Hub
{
    public async Task SendOrderStatus(OrderStatusInfo orderStatusInfo)
    {
        await Clients.All.SendAsync("ReceiveOrderStatus", orderStatusInfo);
    }
}

using AutoWrapper;
using BuildingWorksServer.Hubs;

namespace BuildingWorksServer.Extensions;

public static class WebApplicationExtensions
{
    public static void UseAutoWrapper(this WebApplication webApplication)
    {
        webApplication.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions
        {
            EnableExceptionLogging = true,
            UseApiProblemDetailsException = true,
            IgnoreWrapForOkRequests = true,
        });
    }

    public static void ConfigureHubs(this WebApplication webApplication)
    {
        webApplication.MapHub<ProviderSubmitStatusHub>("/orders/submit-status");
    }
}

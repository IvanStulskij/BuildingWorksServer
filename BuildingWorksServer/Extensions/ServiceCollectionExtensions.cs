using BuildingWorks.Infrastructure.Entities.Configuration;
using BuildingWorks.Profiles;
using BuildingWorks.Repositories;
using BuildingWorks.Services;

namespace BuildingWorksServer.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigrueCors(this IServiceCollection services, string[] allowedHosts)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins(allowedHosts)
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(x => true)
                        .AllowCredentials()
                        .AllowAnyMethod();
                });
        });
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddMapper();
        services.AddRepositories();  
        services.AddServices();
    }

    public static void ConfigureOptions(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<DbSettings>(configuration.GetSection("Database"));
    }
}

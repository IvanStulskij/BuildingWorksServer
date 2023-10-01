using BuildingWorks.Infrastructure.Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BuildingWorks.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<BuildingWorksDbContext>((provider, options) =>
        {
            var endpointOptions = provider.GetRequiredService<IOptions<DbSettings>>().Value;
            options.UseNpgsql(endpointOptions.ConnectionString ?? throw new ArgumentException("PostgreSQL connection string is not specified."));
        });

        return services;
    }

    public static async Task ApplyMigrations(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        await using var dbContext = scope.ServiceProvider.GetRequiredService<BuildingWorksDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}

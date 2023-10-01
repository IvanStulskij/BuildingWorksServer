using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingWorks.Validation;

public static class DependencyInjection
{
    public static void AddValidators(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddValidatorsFromAssembly(assembly);
    }
}

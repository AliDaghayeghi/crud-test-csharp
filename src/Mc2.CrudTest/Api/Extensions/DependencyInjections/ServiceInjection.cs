using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Api.Extensions.DependencyInjections;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // TODO: Implement this part.
        // services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
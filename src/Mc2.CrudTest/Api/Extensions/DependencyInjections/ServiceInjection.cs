using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Persistence;

namespace Mc2.CrudTest.Api.Extensions.DependencyInjections;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
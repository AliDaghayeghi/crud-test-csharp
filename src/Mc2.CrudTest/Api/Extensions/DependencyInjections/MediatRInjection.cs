using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Api.Extensions.DependencyInjections;

internal static class MediatRInjection
{
    public static IServiceCollection AddConfiguredMediatR(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Program));

        // TODO: Implement this part.
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommitBehavior<,>));

        return services;
    }
}
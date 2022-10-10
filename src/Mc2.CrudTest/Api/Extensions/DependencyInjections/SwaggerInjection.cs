using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Mc2.CrudTest.Api.Extensions.DependencyInjections;

public static class SwaggerInjection
{
    public static IServiceCollection AddConfiguredSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(configs =>
            configs.SwaggerDoc(
                name: "v1",
                info: new OpenApiInfo
                {
                    Title = "CrudTest API",
                    Version = "v1"
                }));

        return services;
    }
}

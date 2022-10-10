using Microsoft.AspNetCore.Builder;

namespace Mc2.CrudTest.Api.Extensions.Middleware;

internal static class ConfiguredSwaggerMiddleware
{
    public static void UseConfiguredSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(configs =>
            configs.SwaggerEndpoint("/swagger/v1/swagger.json", "CrudTest API"));
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Api.Extensions.Middleware;

internal static class ConfiguredMigrationMiddleware
{
    public static void UseConfiguredMigration(this IApplicationBuilder app)
    {
        // TODO: Implement this part.
        using var scoped = app.ApplicationServices.CreateScope();
        // var context = scoped.ServiceProvider.GetRequiredService<AppDbContext>();
        // context.Database.Migrate();
    }
}
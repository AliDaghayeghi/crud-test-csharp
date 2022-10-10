using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Api.Extensions.DependencyInjections;

public static class DatabaseInjection
{
    public static IServiceCollection AddConfiguredDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Implement this part.
        // services.AddDbContext<AppDbContext>(options =>
        //     options.UseNpgsql(configuration.GetConnectionString("DbConnection")));

        return services;
    }
}

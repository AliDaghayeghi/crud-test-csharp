using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.BDD.Tests;

public class InMemoryDbContextFactory
{
    public InMemoryDbContext CreateDbContext()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();
        
        var builder = new DbContextOptionsBuilder<InMemoryDbContext>();
        builder.UseInMemoryDatabase("InMemoryCrudTest")
            .UseInternalServiceProvider(serviceProvider);
        
        var options = builder.Options;
        
        return new InMemoryDbContext(options);
    }
}
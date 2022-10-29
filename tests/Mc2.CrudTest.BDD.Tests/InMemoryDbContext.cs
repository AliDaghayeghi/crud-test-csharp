using Mc2.CrudTest.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.BDD.Tests;

public class InMemoryDbContext : AppDbContext
{
    public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InMemoryCustomerEntityConfiguration());
    }
}


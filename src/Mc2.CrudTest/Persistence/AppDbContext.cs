using Mc2.CrudTest.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence;

public class AppDbContext : DbContext
{
    #region DbSets

    public DbSet<Customer> Customers { get; set; }

    #endregion

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        // Creating Model
        base.OnModelCreating(modelBuilder);
    }
}
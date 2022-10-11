using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence;

public class AppDbContext : DbContext
{
    #region DbSets

    // TODO: Implement this part.
    // public DbSet<Customer> Customers { get; set; }

    #endregion

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
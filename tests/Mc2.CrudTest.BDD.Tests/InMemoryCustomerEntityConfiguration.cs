using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Persistence.EntityConfigurations.Customers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.BDD.Tests;

public class InMemoryCustomerEntityConfiguration : CustomerEntityConfiguration
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);
        builder.HasKey(x => x.Id);
    }
}
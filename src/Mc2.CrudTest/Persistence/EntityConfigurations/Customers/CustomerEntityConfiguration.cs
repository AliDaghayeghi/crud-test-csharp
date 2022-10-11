using Mc2.CrudTest.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Persistence.EntityConfigurations.Customers;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.FirstName, x.LastName, x.DateOfBirth })
            .IsUnique();

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.DateOfBirth)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(320);

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(15);

        builder.Property(x => x.BankAccountNumber)
            .HasMaxLength(17);
    }
}

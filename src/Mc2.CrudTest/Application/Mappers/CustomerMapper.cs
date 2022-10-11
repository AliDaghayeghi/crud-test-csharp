using Mc2.CrudTest.Application.Models.Base.Customers;
using Mc2.CrudTest.Domain.Customers;

namespace Mc2.CrudTest.Application.Mappers;

public static class CustomerMapper
{
    public static CustomerModel MapToCustomerModel(this Customer entity)
    {
        if (entity == null)
            return null;

        return new CustomerModel
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            DateOfBirth = entity.DateOfBirth,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email,
            BankAccountNumber = entity.BankAccountNumber
        };
    }

    public static IEnumerable<CustomerModel> MapToCustomerModels(this IEnumerable<Customer> entities)
    {
        foreach (var entity in entities ?? new List<Customer>())
            yield return entity.MapToCustomerModel();
    }
}

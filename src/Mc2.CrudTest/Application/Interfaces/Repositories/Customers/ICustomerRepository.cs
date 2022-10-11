using Mc2.CrudTest.Application.Models.Filters.Customers;
using Mc2.CrudTest.Domain.Customers;

namespace Mc2.CrudTest.Application.Interfaces.Repositories.Customers;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<Customer> GetCustomerByEmailAsync(string email);
    Task<List<Customer>> GetCustomersByFilterAsync(CustomerFilter filter);
    Task<int> CountCustomersByFilterAsync(CustomerFilter filter);
}

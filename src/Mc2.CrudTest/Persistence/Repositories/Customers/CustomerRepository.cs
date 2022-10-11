using Mc2.CrudTest.Application.Helpers;
using Mc2.CrudTest.Application.Interfaces.Repositories.Customers;
using Mc2.CrudTest.Application.Models.Filters.Customers;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence.Repositories.Customers;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private readonly IQueryable<Customer> _queryable;

    public CustomerRepository(AppDbContext dbContext) : base(dbContext)
    {
        _queryable = dbContext.Set<Customer>();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _queryable.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<Customer> GetCustomerByEmailAsync(string email)
    {
        return await _queryable.SingleOrDefaultAsync(x => x.Email == email && !x.IsDeleted);
    }

    public async Task<List<Customer>> GetCustomersByFilterAsync(CustomerFilter filter)
    {
        var query = _queryable;

        query = query.ApplyFilter(filter);

        query = query.ApplySort(filter.SortBy);

        return await query.ToPaginatedListAsync(filter.Page, filter.PageSize);
    }

    public async Task<int> CountCustomersByFilterAsync(CustomerFilter filter)
    {
        var query = _queryable;

        query = query.ApplyFilter(filter);

        return await query.CountAsync();
    }
}

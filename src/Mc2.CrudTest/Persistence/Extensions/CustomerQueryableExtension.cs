using Mc2.CrudTest.Application.Models.Filters.Customers;
using Mc2.CrudTest.Domain.Customers;

namespace Mc2.CrudTest.Persistence.Extensions;

public static class CustomerQueryableExtension
{
    public static IQueryable<Customer> ApplyFilter(this IQueryable<Customer> query, CustomerFilter filter)
    {
        // Remove deleted customers from search result
        query = query.Where(x => !x.IsDeleted);

        // Filter by DateOfBirth
        if (filter.FromDateOfBirth.HasValue)
            query = query.Where(x =>
                x.DateOfBirth.Date >= filter.FromDateOfBirth.Value.Date);
        if (filter.ToDateOfBirth.HasValue)
            query = query.Where(x =>
                x.DateOfBirth.Date <= filter.ToDateOfBirth.Value.Date);

        // Filter by FullNameSearchKeyword
        if (!string.IsNullOrEmpty(filter.FullNameSearchKeyword))
        {
            filter.FullNameSearchKeyword = filter.FullNameSearchKeyword.ToUpper().Trim();
            query = query.Where(x =>
                $"{x.FirstName.ToUpper()} {x.LastName.ToUpper()}"
                    .Contains(filter.FullNameSearchKeyword));
        }

        return query;
    }

    public static IQueryable<Customer> ApplySort(this IQueryable<Customer> query, CustomerSortBy? sortBy)
    {
        return sortBy switch
        {
            CustomerSortBy.FirstName => query.OrderBy(x => x.FirstName),
            CustomerSortBy.LastName => query.OrderBy(x => x.LastName),

            CustomerSortBy.CreateAt => query.OrderBy(x => x.CreatedAt),
            CustomerSortBy.CreateAtDescending => query.OrderByDescending(x => x.CreatedAt),

            CustomerSortBy.UpdatedAt => query.OrderBy(x => x.UpdatedAt),
            CustomerSortBy.UpdatedAtDescending => query.OrderByDescending(x => x.UpdatedAt),

            _ => query.OrderByDescending(x => x.CreatedAt)
        };
    }
}

using Mc2.CrudTest.Application.Infrastructure.Pagination;

namespace Mc2.CrudTest.Application.Models.Filters.Customers;

public class CustomerFilter : PaginationFilter
{
    public CustomerFilter(int page, int pageSize) : base(page, pageSize) { }

    public DateTime? FromDateOfBirth { get; set; }
    public DateTime? ToDateOfBirth { get; set; }
    public string FullNameSearchKeyword { get; set; }
    public CustomerSortBy? SortBy { get; set; }
}

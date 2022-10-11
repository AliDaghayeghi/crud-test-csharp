using Mc2.CrudTest.Application.Models.Filters.Customers;

namespace Mc2.CrudTest.Api.Models.Requests.Customers;

public class GetCustomersRequest
{
    public DateTime? FromDateOfBirth { get; set; }
    public DateTime? ToDateOfBirth { get; set; }
    public string FullNameSearchKeyword { get; set; }
    public CustomerSortBy? SortBy { get; set; }

    public int Page { get; set; }
    public int PageSize { get; set; }
}
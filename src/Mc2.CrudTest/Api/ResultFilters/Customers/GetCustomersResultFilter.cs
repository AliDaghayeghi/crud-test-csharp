using Mc2.CrudTest.Application.Infrastructure.Pagination;
using Mc2.CrudTest.Application.Models.Base.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mc2.CrudTest.Api.ResultFilters.Customers;

public class GetCustomersResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<CustomerModel> value)
        {
            result.Value = new
            {
                Page = value.Page,
                PageSize = value.PageSize,
                TotalCount = value.TotalCount,
                Data = value.Data?.Select(x => new
                {
                    Id = x.Id,
                    FullName = $"{x.FirstName} {x.LastName}",
                    DateOfBirth = x.DateOfBirth,
                })
            };
        }
        await next();
    }
}
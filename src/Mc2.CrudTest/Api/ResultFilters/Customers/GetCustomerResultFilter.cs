using Mc2.CrudTest.Application.Models.Base.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mc2.CrudTest.Api.ResultFilters.Customers;

public class GetCustomerResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is CustomerModel value)
        {
            result.Value = new
            {
                Id = value.Id,
                FullName = $"{value.FirstName} {value.LastName}",
                DateOfBirth = value.DateOfBirth,
                PhoneNumber = value.PhoneNumber,
                Email = value.Email,
                BankAccountNumber = value.BankAccountNumber
            };
        }
        await next();
    }
}
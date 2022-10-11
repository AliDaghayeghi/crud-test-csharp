using Mc2.CrudTest.Api.Extensions;
using Mc2.CrudTest.Api.Models.Requests.Customers;
using Mc2.CrudTest.Api.ResultFilters.Customers;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Application.Models.Filters.Customers;
using Mc2.CrudTest.Application.Models.Queries.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers;

[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Routes.Customers)]
    [AddCustomerResultFilter]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
    {
        // Operation
        var operation = await _mediator.Send(new AddCustomerCommand
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            BankAccountNumber = request.BankAccountNumber
        });

        // Result
        return this.ReturnResponse(operation);
    }

    [HttpGet(Routes.Customers)]
    [GetCustomersResultFilter]
    public async Task<IActionResult> GetCustomers([FromQuery] GetCustomersRequest request)
    {
        // Operation
        var operation = await _mediator.Send(new GetCustomersByFilterQuery
        {
            Filter = new CustomerFilter(request.Page, request.PageSize)
            {
                FromDateOfBirth = request.FromDateOfBirth,
                ToDateOfBirth = request.ToDateOfBirth,
                FullNameSearchKeyword = request.FullNameSearchKeyword,
                SortBy = request.SortBy
            }
        });

        // Result
        return this.ReturnResponse(operation);
    }

    [HttpGet(Routes.Customers + "{id}")]
    [GetCustomerResultFilter]
    public async Task<IActionResult> GetCustomer([FromRoute] int id)
    {
        // Operation
        var operation = await _mediator.Send(new GetCustomerByIdQuery
        {
            Id = id
        });

        // Result
        return this.ReturnResponse(operation);
    }

    [HttpPut(Routes.Customers + "{id}")]
    [UpdateCustomerResultFilter]
    public async Task<IActionResult> UpdateCustomer([FromRoute] int id,
        [FromBody] UpdateCustomerRequest request)
    {
        // Operation
        var operation = await _mediator.Send(new UpdateCustomerCommand
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            BankAccountNumber = request.BankAccountNumber
        });

        // Result
        return this.ReturnResponse(operation);
    }

    [HttpDelete(Routes.Customers + "{id}")]
    [DeleteCustomerResultFilter]
    public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
    {
        // Operation
        var operation = await _mediator.Send(new DeleteCustomerCommand
        {
            Id = id
        });

        // Result
        return this.ReturnResponse(operation);
    }
}

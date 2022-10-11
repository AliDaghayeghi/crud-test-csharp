using Mc2.CrudTest.Application.Infrastructure.Operations;
using Mc2.CrudTest.Application.Models.Filters.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Models.Queries.Customers;

public class GetCustomersByFilterQuery : IRequest<OperationResult>
{
    public CustomerFilter Filter { get; set; }
}

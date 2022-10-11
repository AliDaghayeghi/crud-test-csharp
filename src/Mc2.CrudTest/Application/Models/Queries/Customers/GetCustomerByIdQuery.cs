using Mc2.CrudTest.Application.Infrastructure.Operations;
using MediatR;

namespace Mc2.CrudTest.Application.Models.Queries.Customers;

public class GetCustomerByIdQuery : IRequest<OperationResult>
{
    public int Id { get; set; }
}

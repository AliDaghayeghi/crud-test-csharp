using Mc2.CrudTest.Application.Infrastructure.Operations;
using MediatR;

namespace Mc2.CrudTest.Application.Models.Commands.Customers;

public class DeleteCustomerCommand : IRequest<OperationResult>
{
    public int Id { get; set; }
}

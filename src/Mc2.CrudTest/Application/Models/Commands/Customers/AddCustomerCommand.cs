using Mc2.CrudTest.Application.Infrastructure.Operations;
using MediatR;

namespace Mc2.CrudTest.Application.Models.Commands.Customers;

public class AddCustomerCommand : IRequest<OperationResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}

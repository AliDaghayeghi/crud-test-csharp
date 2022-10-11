using Mc2.CrudTest.Application.Infrastructure.Operations;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Mappers;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Application.ResponseErrors;
using Mc2.CrudTest.Domain.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customers;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(AddCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var existingCustomer = await _unitOfWork.Customers.GetCustomerByEmailAsync(request.Email);

        if (existingCustomer is not null)
            return new OperationResult(OperationResultStatus.Unprocessable,
                value: CustomerErrors.EmailAddressUniquenessError);

        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            BankAccountNumber = request.BankAccountNumber,

            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _unitOfWork.Customers.Add(customer);

        var response = customer.MapToCustomerModel();

        return new OperationResult(OperationResultStatus.Ok, isPersistable: true, value: response);
    }
}

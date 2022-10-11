using Mc2.CrudTest.Application.Infrastructure.Operations;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Mappers;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Application.ResponseErrors;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Customers.GetCustomerByIdAsync(request.Id);

        if (customer is null)
            return new OperationResult(OperationResultStatus.NotFound,
                value: CustomerErrors.NotFoundCustomerError);

        if (customer.Email != request.Email)
        {
            var emailUniquenessCheck = await _unitOfWork.Customers.GetCustomerByEmailAsync(request.Email);
            if (emailUniquenessCheck is not null)
                return new OperationResult(OperationResultStatus.Unprocessable,
                    value: CustomerErrors.EmailAddressUniquenessError);
        }

        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.DateOfBirth = request.DateOfBirth;
        customer.PhoneNumber = request.PhoneNumber;
        customer.Email = request.Email;
        customer.BankAccountNumber = request.BankAccountNumber;
        customer.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Customers.Update(customer);

        var response = customer.MapToCustomerModel();

        return new OperationResult(OperationResultStatus.Ok, isPersistable: true, value: response);
    }
}

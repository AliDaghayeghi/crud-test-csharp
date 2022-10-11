using Mc2.CrudTest.Application.Infrastructure.Operations;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Mappers;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Application.ResponseErrors;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeleteCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Customers.GetCustomerByIdAsync(request.Id);

        if (customer is null)
            return new OperationResult(OperationResultStatus.NotFound,
                value: CustomerErrors.NotFoundCustomerError);

        customer.IsDeleted = true;
        customer.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Customers.Update(customer);

        var response = customer.MapToCustomerModel();

        return new OperationResult(OperationResultStatus.Ok, isPersistable: true, value: response);
    }
}

using Mc2.CrudTest.Application.Infrastructure.Operations;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Mappers;
using Mc2.CrudTest.Application.Models.Queries.Customers;
using Mc2.CrudTest.Application.ResponseErrors;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Customers.GetCustomerByIdAsync(request.Id);

        if (customer is null)
            return new OperationResult(OperationResultStatus.NotFound,
                value: CustomerErrors.NotFoundCustomerError);

        var response = customer.MapToCustomerModel();

        return new OperationResult(OperationResultStatus.Ok, value: response);
    }
}

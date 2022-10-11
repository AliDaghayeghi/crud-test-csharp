using Mc2.CrudTest.Application.Infrastructure.FluentValidation;
using Mc2.CrudTest.Application.Infrastructure.Operations;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Application.Validators.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Behaviors.Customers;

public class AddCustomerValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<AddCustomerCommand, OperationResult>
{
    public async Task<OperationResult> Handle(AddCustomerCommand request,
       CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        // Validation
        var validation = new AddCustomerValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.InvalidRequest,
                value: validation.GetFirstCustomState());

        return await next();
    }
}

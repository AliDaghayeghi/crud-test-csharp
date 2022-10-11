using Mc2.CrudTest.Application.Infrastructure.FluentValidation;
using Mc2.CrudTest.Application.Infrastructure.Operations;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Application.Validators.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Behaviors.Customers;

public class UpdateCustomerValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<UpdateCustomerCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdateCustomerCommand request,
       CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        // Validation
        var validation = new UpdateCustomerValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.InvalidRequest,
                value: validation.GetFirstCustomState());

        return await next();
    }
}

using Mc2.CrudTest.Application.Infrastructure.Operations;
using Mc2.CrudTest.Application.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Behaviors;

public class CommitBehavior<TRequest, TResponse> : IPipelineBehavior<IRequest<OperationResult>, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CommitBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(IRequest<OperationResult> request, CancellationToken cancellationToken,
        RequestHandlerDelegate<OperationResult> next)
    {
        var response = await next();

        if (response.Succeeded && response.IsPersistable)
            if (!await _unitOfWork.CommitAsync())
                return new OperationResult(OperationResultStatus.Unprocessable, response);

        return response;
    }
}

using Mc2.CrudTest.Application.Infrastructure.Operations;
using Mc2.CrudTest.Application.Infrastructure.Pagination;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Mappers;
using Mc2.CrudTest.Application.Models.Base.Customers;
using Mc2.CrudTest.Application.Models.Queries.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customers;

public class GetCustomersByFilterQueryHandler : IRequestHandler<GetCustomersByFilterQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomersByFilterQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(GetCustomersByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var customers = await _unitOfWork.Customers.GetCustomersByFilterAsync(request.Filter);

        var totalCount = await _unitOfWork.Customers.CountCustomersByFilterAsync(request.Filter);

        // Response
        var response = new PaginatedList<CustomerModel>
        {
            Page = request.Filter.Page,
            PageSize = request.Filter.PageSize,
            TotalCount = totalCount,
            Data = customers.MapToCustomerModels().ToList()
        };

        return new OperationResult(OperationResultStatus.Ok, value: response);
    }
}

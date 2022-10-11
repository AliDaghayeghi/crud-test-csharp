namespace Mc2.CrudTest.Application.Infrastructure.Operations;

public enum OperationResultStatus
{
    Ok = 1,
    InvalidRequest,
    Unauthorized,
    NotFound,
    Unprocessable
}

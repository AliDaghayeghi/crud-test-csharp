using Mc2.CrudTest.Application.Infrastructure.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Extensions;

public static class ControllerExtension
{
    public static IActionResult ReturnResponse(this ControllerBase controller, OperationResult operation)
    {
        object response = operation.Value;

        return operation.Status switch
        {
            OperationResultStatus.Ok => controller.Ok(response),
            OperationResultStatus.InvalidRequest => controller.BadRequest(response),
            OperationResultStatus.NotFound => controller.NotFound(response),
            OperationResultStatus.Unauthorized => controller.UnprocessableEntity(response),
            OperationResultStatus.Unprocessable => controller.UnprocessableEntity(response),
            _ => controller.UnprocessableEntity(response)
        };
    }
}

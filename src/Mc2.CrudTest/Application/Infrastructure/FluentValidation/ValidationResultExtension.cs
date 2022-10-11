using System.Linq;
using FluentValidation.Results;

namespace Mc2.CrudTest.Application.Infrastructure.FluentValidation;

public static class ValidationResultExtension
{
    public static string GetFirstErrorMessage(this ValidationResult result)
    {
        return result.Errors.FirstOrDefault()?.ErrorMessage;
    }

    public static object GetFirstCustomState(this ValidationResult result)
    {
        return result.Errors.FirstOrDefault()?.CustomState;
    }
}

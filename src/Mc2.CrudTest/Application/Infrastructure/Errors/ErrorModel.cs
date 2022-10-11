namespace Mc2.CrudTest.Application.Infrastructure.Errors;

public struct ErrorModel
{
    public ErrorModel(int code, string title, string message)
    {
        Code = code;
        Title = title;
        Message = message;
    }

    public readonly int Code;
    public readonly string Title;
    public readonly string Message;
}

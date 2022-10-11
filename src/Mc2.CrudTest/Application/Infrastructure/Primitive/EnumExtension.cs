using System.ComponentModel;
using Microsoft.OpenApi.Extensions;

namespace Mc2.CrudTest.Application.Infrastructure.Primitive;

public static class EnumExtension
{
    public static int GetMaxLength(this Enum value)
    {
        var type = value.GetType();
        var names = Enum.GetNames(type);
        return names.Select(name => name.Length).Concat(new[] { 0 }).Max();
    }

    public static string GetDescription(Enum value) =>
        value.GetAttributeOfType<DescriptionAttribute>()?.Description ?? value.ToString();
}

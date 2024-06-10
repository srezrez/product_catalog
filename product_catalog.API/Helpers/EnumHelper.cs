using System.ComponentModel;
using System.Reflection;

namespace product_catalog.API.Helpers;

public static class EnumHelper
{
    public static string GetEnumDescription(this Enum enumValue)
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        if (fieldInfo?.GetCustomAttribute(typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
            return attribute.Description;
        }
        return enumValue.ToString();
    }

    public static Enum? GetEnumFromString(Type enumType, string? enumValue)
    {
        if (Enum.TryParse(enumType, enumValue, out object? convertedEnum))
        {
            return (Enum)convertedEnum;
        }

        return string.IsNullOrEmpty(enumValue)
            ? null
            : Enum.GetValues(enumType).OfType<Enum>()
                .Where(n => n.GetEnumDescription() == enumValue)
                .FirstOrDefault();

    }

    public static bool IsInEnumDescription<T>(Type enumType, T descriptionValue)
    {
        var value = descriptionValue as string;
        return Enum.GetValues(enumType).OfType<Enum>().Select(n => n.GetEnumDescription()).Contains(value);
    }
}
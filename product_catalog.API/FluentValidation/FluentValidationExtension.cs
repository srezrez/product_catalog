using FluentValidation;
using product_catalog.API.FluentValidation.ValidationRules;

namespace product_catalog.API.FluentValidation;

internal static class FluentValidationExtension
{
    public static IRuleBuilderOptions<T, TProperty> IsInEnumValues<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Type enumType)
        => ruleBuilder.SetValidator(new EnumValuesValidator<T, TProperty>(enumType));
}

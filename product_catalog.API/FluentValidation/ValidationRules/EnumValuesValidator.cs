using FluentValidation.Validators;
using FluentValidation;
using product_catalog.API.Helpers;

namespace product_catalog.API.FluentValidation.ValidationRules;

public class EnumValuesValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    private readonly Type _enumType;
    public override string Name { get; } = "EnumValuesValidator";

    public EnumValuesValidator(Type enumType)
    {
        _enumType = enumType;
    }

    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        return value is null || Enum.IsDefined(_enumType, value) || EnumHelper.IsInEnumDescription<TProperty>(_enumType, value);
    }
}

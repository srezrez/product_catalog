using FluentValidation;
using product_catalog.API.Requests;

namespace product_catalog.API.FluentValidation.Validators;

public class ChangeCategoryValidator : AbstractValidator<ChangeCategoryRequest>
{
    public ChangeCategoryValidator()
    {
        RuleFor(category => category.Id)
            .GreaterThanOrEqualTo(1);

        RuleFor(category => category.Title)
            .NotEmpty();
    }
}

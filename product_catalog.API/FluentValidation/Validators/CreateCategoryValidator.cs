using FluentValidation;
using product_catalog.API.Requests;

namespace product_catalog.API.FluentValidation.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(category => category.Title)
            .NotEmpty();
    }
}

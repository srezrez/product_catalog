using FluentValidation;
using product_catalog.API.Requests;

namespace product_catalog.API.FluentValidation.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty();

        RuleFor(product => product.Description)
            .NotEmpty();

        RuleFor(product => product.Price)
            .GreaterThan(0);

        RuleFor(product => product.GeneralNote)
            .NotEmpty();

        RuleFor(product => product.SpecialNote)
            .NotEmpty();

        RuleFor(product => product.CategoryId)
            .GreaterThanOrEqualTo(1);
    }
}
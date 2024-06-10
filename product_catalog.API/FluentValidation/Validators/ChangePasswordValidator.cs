using FluentValidation;
using product_catalog.API.Requests;

namespace product_catalog.API.FluentValidation.Validators;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordValidator()
    {
        RuleFor(request => request.Password)
            .NotEmpty()
            .MinimumLength(5);

        RuleFor(request => request.ConfirmPassword)
            .Equal(request => request.Password);
    }
}

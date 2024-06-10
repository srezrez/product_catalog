using FluentValidation;
using product_catalog.API.Requests;
using System.Text.RegularExpressions;

namespace product_catalog.API.FluentValidation.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .Matches(new Regex(@"^(?=.{1,50}$)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,256}$"));

        RuleFor(user => user.Password)
            .NotEmpty()
            .MinimumLength(5);
    }
}

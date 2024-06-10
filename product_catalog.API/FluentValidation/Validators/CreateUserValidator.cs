using FluentValidation;
using product_catalog.API.Requests;
using product_catalog.Domain.Enums;
using System.Text.RegularExpressions;

namespace product_catalog.API.FluentValidation.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .Matches(new Regex(@"^(?=.{1,50}$)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,256}$"));

        RuleFor(user => user.Password)
            .NotEmpty()
            .MinimumLength(5);

        RuleFor(user => user.ConfirmPassword)
            .Equal(request => request.Password);

        RuleFor(user => user.FirstName)
            .NotEmpty();

        RuleFor(user => user.LastName)
            .NotEmpty();

        RuleFor(user => user.Role)
            .NotEmpty()
            .IsInEnumValues(typeof(UserRole));
    }
}
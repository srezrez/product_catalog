using MediatR;
using product_catalog.Application.CQRSResults;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.Domain.Enums;
using product_catalog.Domain.Exceptions;

namespace product_catalog.Application.UserCQRS.Commands;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserCommandResult>
{
    private readonly IUserReadRepository _userReadRepository;

    public AuthenticateUserCommandHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<AuthenticateUserCommandResult> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var normalizedEmail = request.Email.ToLower();
        var user = await _userReadRepository.GetByEmailAsync(normalizedEmail);
        if (user == null || user.Status == UserStatus.Blocked || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) 
            throw new IncorrectLoginOrPasswordException();

        return new AuthenticateUserCommandResult(user.Id, user.Role);
    }
}

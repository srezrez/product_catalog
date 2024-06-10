using MediatR;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.DataAccess.WriteRepositories.Contracts;

namespace product_catalog.Application.UserCQRS.Commands;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;

    public ChangePasswordCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
    {
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        await _userWriteRepository.UpdatePasswordAsync(request.UserId, BCrypt.Net.BCrypt.HashPassword(request.Password));
        return true;
    }
}

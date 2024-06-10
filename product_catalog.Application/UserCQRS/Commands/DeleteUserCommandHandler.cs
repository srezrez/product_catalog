using MediatR;
using product_catalog.DataAccess.WriteRepositories.Contracts;

namespace product_catalog.Application.UserCQRS.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUserWriteRepository _userWriteRepository;

    public DeleteUserCommandHandler(IUserWriteRepository userWriteRepository)
    {
        _userWriteRepository = userWriteRepository;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userWriteRepository.DeleteByIdAsync(request.UserId);
        return true;
    }
}

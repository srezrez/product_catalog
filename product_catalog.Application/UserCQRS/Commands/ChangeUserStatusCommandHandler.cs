using MediatR;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.DataAccess.WriteRepositories.Contracts;
using product_catalog.Domain.Enums;
using product_catalog.Domain.Exceptions;
using product_catalog.Domain.Models;

namespace product_catalog.Application.UserCQRS.Commands;

public class ChangeUserStatusCommandHandler : IRequestHandler<ChangeUserStatusCommand, bool>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;

    public ChangeUserStatusCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
    {
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<bool> Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetByIdAsync(request.UserId);
        if (user == null) throw new ModelNotFoundException(typeof(User), nameof(request.UserId), request.UserId);

        if (user.Status == UserStatus.Active) 
            await _userWriteRepository.UpdateStatusAsync(user.Id, UserStatus.Blocked);
        else
            await _userWriteRepository.UpdateStatusAsync(user.Id, UserStatus.Active);

        return true;
    }
}

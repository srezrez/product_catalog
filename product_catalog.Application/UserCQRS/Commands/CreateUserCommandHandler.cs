using MediatR;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.DataAccess.WriteRepositories.Contracts;
using product_catalog.Domain.Enums;
using product_catalog.Domain.Exceptions;
using product_catalog.Domain.Models;

namespace product_catalog.Application.UserCQRS.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;

    public CreateUserCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
    {
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userReadRepository.CheckIfExistsByEmailAsync(request.Email);
        if (userExists) throw new ModelAlreadyExistsException(typeof(User), nameof(request.Email), request.Email);

        var user = new User
        {
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = request.Role,
            Status = UserStatus.Active,
        };

        return await _userWriteRepository.CreateAsync(user);
    }
}

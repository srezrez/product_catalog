using MediatR;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.Domain.Models;

namespace product_catalog.Application.UserCQRS.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IReadOnlyCollection<User>>
{
    private readonly IUserReadRepository _userReadRepository;

    public GetAllUsersQueryHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<IReadOnlyCollection<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userReadRepository.GetAllAsync();
    }
}

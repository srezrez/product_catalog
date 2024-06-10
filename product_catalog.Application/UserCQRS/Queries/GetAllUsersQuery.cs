using MediatR;
using product_catalog.Domain.Models;

namespace product_catalog.Application.UserCQRS.Queries;

public record GetAllUsersQuery() : IRequest<IReadOnlyCollection<User>>;

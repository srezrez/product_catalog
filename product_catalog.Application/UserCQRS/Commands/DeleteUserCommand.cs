using MediatR;

namespace product_catalog.Application.UserCQRS.Commands;

public record DeleteUserCommand(int UserId) : IRequest<bool>;

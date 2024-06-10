using MediatR;

namespace product_catalog.Application.UserCQRS.Commands;

public record ChangeUserStatusCommand(int UserId) : IRequest<bool>;

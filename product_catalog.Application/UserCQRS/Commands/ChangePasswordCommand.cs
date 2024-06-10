using MediatR;

namespace product_catalog.Application.UserCQRS.Commands;

public record ChangePasswordCommand(int UserId, string Password) : IRequest<bool>;

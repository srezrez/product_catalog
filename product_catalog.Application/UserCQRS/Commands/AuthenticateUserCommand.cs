using MediatR;
using product_catalog.Application.CQRSResults;
using product_catalog.Domain.Models;

namespace product_catalog.Application.UserCQRS.Commands;

public record AuthenticateUserCommand(string Email, string Password) : IRequest<AuthenticateUserCommandResult>;

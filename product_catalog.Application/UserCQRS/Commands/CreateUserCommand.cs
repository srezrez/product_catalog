using MediatR;
using product_catalog.Domain.Enums;

namespace product_catalog.Application.UserCQRS.Commands;

public record CreateUserCommand(string Email,
                                string Password,
                                string FirstName,
                                string LastName,
                                UserRole Role) : IRequest<int>;

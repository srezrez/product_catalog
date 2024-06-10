using product_catalog.Domain.Enums;

namespace product_catalog.Application.CQRSResults;

public record AuthenticateUserCommandResult(int UserId, UserRole Role);

using product_catalog.Domain.Enums;

namespace product_catalog.API.Responses;

public record LoginResponse(int UserId, UserRole Role, string AccessToken);

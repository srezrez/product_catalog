namespace product_catalog.API.Responses;

public record UserResponse(int Id,
                           string Email,
                           string Password,
                           string FirstName,
                           string LastName,
                           string Role,
                           string Status);

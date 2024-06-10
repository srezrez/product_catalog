using product_catalog.Domain.Enums;

namespace product_catalog.API.Requests;

public record CreateUserRequest(string Email,
                                string Password,
                                string ConfirmPassword,
                                string FirstName,
                                string LastName,
                                string Role);

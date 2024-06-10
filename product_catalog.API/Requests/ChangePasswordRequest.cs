namespace product_catalog.API.Requests;

public record ChangePasswordRequest(int UserId,
                                    string Password,
                                    string ConfirmPassword);

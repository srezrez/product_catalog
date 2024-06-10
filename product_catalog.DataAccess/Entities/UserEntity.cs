using product_catalog.Domain.Enums;

namespace product_catalog.DataAccess.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
}

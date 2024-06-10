using product_catalog.Domain.Enums;
using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.WriteRepositories.Contracts;

public interface IUserWriteRepository
{
    Task<int> CreateAsync(User user);
    Task DeleteByIdAsync(int id);
    Task UpdatePasswordAsync(int id, string password);
    Task UpdateStatusAsync(int id, UserStatus status);
}

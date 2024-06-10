using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.ReadRepositories.Contracts;

public interface IUserReadRepository
{
    Task<bool> CheckIfExistsByEmailAsync(string email);
    Task<IReadOnlyCollection<User>> GetAllAsync();
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByIdAsync(int id);
}

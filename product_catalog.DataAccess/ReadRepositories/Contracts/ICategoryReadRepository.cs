using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.ReadRepositories.Contracts;

public interface ICategoryReadRepository
{
    Task<bool> CheckIfExistsByIdAsync(int id);
    Task<bool> CheckIfExistsByTitleAsync(string title);
    Task<IReadOnlyCollection<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
}

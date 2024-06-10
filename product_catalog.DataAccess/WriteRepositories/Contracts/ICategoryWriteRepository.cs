using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.WriteRepositories.Contracts;

public interface ICategoryWriteRepository
{
    Task<int> CreateAsync(Category category);
    Task DeleteByIdAsync(int id);
    Task UpdateAsync(int id, Category category);
}

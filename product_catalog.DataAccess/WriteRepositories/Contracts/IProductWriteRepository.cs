using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.WriteRepositories.Contracts;

public interface IProductWriteRepository
{
    Task<int> CreateAsync(Product product);
    Task DeleteByIdAsync(int id);
    Task UpdateAsync(int id, Product product);
}

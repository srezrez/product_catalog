using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.ReadRepositories.Contracts;

public interface IProductReadRepository
{
    Task<IReadOnlyCollection<Product>> GetAllFilteredAsync(string? title, int? categoryId);
}

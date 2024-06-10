using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.ReadRepositories;

public class ProductReadRepository : IProductReadRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public ProductReadRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<Product>> GetAllFilteredAsync(string? title, int? categoryId)
    {
        var products = _dataContext.Products.AsQueryable().Include(p => p.Category);

        if (categoryId.HasValue)
        {
            products = products.Where(p => p.CategoryId == categoryId).Include(p => p.Category);
        }

        if (!title.IsNullOrEmpty())
        {
            products = products.Where(p => p.Title.ToLower().Contains(title.ToLower())).Include(p => p.Category);
        }

        return _mapper.Map<IReadOnlyCollection<Product>>(products);
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using product_catalog.DataAccess.Entities;
using product_catalog.DataAccess.WriteRepositories.Contracts;
using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.WriteRepositories;

public class ProductWriteRepository : IProductWriteRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public ProductWriteRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<int> CreateAsync(Product product)
    {
        var entity = _mapper.Map<ProductEntity>(product);
        await _dataContext.Products.AddAsync(entity);
        await _dataContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateAsync(int id, Product product)
    {
        await _dataContext.Products.Where(p => p.Id == id)
            .ExecuteUpdateAsync(c => c.SetProperty(p => p.Title, product.Title)
                                      .SetProperty(p => p.Description, product.Description)
                                      .SetProperty(p => p.Price, product.Price)
                                      .SetProperty(p => p.GeneralNote, product.GeneralNote)
                                      .SetProperty(p => p.SpecialNote, product.SpecialNote)
                                      .SetProperty(p => p.CategoryId, product.CategoryId));
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _dataContext.Products.Where(c => c.Id == id).ExecuteDeleteAsync();
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using product_catalog.DataAccess.Entities;
using product_catalog.DataAccess.WriteRepositories.Contracts;
using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.WriteRepositories;

public class CategoryWriteRepository : ICategoryWriteRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public CategoryWriteRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<int> CreateAsync(Category category)
    {
        var entity = _mapper.Map<CategoryEntity>(category);
        await _dataContext.Categories.AddAsync(entity);
        await _dataContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateAsync(int id, Category category)
    {
        await _dataContext.Categories.Where(c => c.Id == id)
            .ExecuteUpdateAsync(c => c.SetProperty(p => p.Title, category.Title));
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _dataContext.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();
    }
}

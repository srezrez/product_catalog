using AutoMapper;
using Microsoft.EntityFrameworkCore;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.ReadRepositories;

public class CategoryReadRepository : ICategoryReadRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public CategoryReadRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<Category>> GetAllAsync()
    {
        var categories = await _dataContext.Categories.ToListAsync();
        return _mapper.Map<IReadOnlyCollection<Category>>(categories);
    }

    public async Task<bool> CheckIfExistsByTitleAsync(string title)
    {
        return await _dataContext.Categories.AnyAsync(c => c.Title.ToLower() == title.ToLower());
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var category = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        return _mapper.Map<Category>(category);
    }

    public async Task<bool> CheckIfExistsByIdAsync(int id)
    {
        return await _dataContext.Categories.AnyAsync(c => c.Id == id);
    }
}

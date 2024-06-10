using AutoMapper;
using Microsoft.EntityFrameworkCore;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.ReadRepositories;

public class UserReadRepository : IUserReadRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public UserReadRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<User>> GetAllAsync()
    {
        var users = await _dataContext.Users.ToListAsync();
        return _mapper.Map<IReadOnlyCollection<User>>(users);
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        return _mapper.Map<User>(user);
    }

    public async Task<bool> CheckIfExistsByEmailAsync(string email)
    {
        return await _dataContext.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        return _mapper.Map<User>(user);
    }
}

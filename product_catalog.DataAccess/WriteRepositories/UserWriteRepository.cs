using AutoMapper;
using Microsoft.EntityFrameworkCore;
using product_catalog.DataAccess.Entities;
using product_catalog.DataAccess.WriteRepositories.Contracts;
using product_catalog.Domain.Enums;
using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.WriteRepositories;

public class UserWriteRepository : IUserWriteRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public UserWriteRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<int> CreateAsync(User user)
    {
        var entity = _mapper.Map<UserEntity>(user);
        await _dataContext.Users.AddAsync(entity);
        await _dataContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateStatusAsync(int id, UserStatus status)
    {
        await _dataContext.Users.Where(u => u.Id == id)
            .ExecuteUpdateAsync(u => u.SetProperty(p => p.Status, status));
    }

    public async Task UpdatePasswordAsync(int id, string password)
    {
        await _dataContext.Users.Where(u => u.Id == id)
            .ExecuteUpdateAsync(u => u.SetProperty(p => p.Password, password));
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _dataContext.Users.Where(c => c.Id == id).ExecuteDeleteAsync();
    }
}

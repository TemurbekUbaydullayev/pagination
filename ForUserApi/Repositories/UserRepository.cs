using ForUserApi.DbContexts;
using ForUserApi.Entities;
using ForUserApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ForUserApi.Repositories;

public class UserRepository(AppDbContext dbSet) : IUserInterface
{
    private readonly AppDbContext _dbSet = dbSet;

    public async Task CreateAsync(User user)
    {
        await _dbSet.Users.AddAsync(user);
        await _dbSet.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _dbSet.Users.Remove(user);
        await _dbSet.SaveChangesAsync();
    }

    public IQueryable<User> GetAll(Expression<Func<User, bool>> expression)
        => _dbSet.Users.Where(expression);

    public async Task<User?> GetByEmailAsync(Expression<Func<User, bool>> expression)
        => await _dbSet.Users.FirstOrDefaultAsync(expression);

    public async Task<User?> GetByIdAsync(Expression<Func<User, bool>> expression)
        => await _dbSet.Users.FirstOrDefaultAsync(expression);

    public async Task<User?> GetByNameAsync(Expression<Func<User, bool>> expression)
        => await _dbSet.Users.FirstOrDefaultAsync(expression);

    public async Task UpdateAsync(User user)
    {
        _dbSet.Users.Update(user);
        await _dbSet.SaveChangesAsync();
    }
}

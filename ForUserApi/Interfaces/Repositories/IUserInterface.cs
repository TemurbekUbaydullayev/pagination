using ForUserApi.Entities;
using System.Linq.Expressions;

namespace ForUserApi.Interfaces.Repositories;

public interface IUserInterface
{
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task<User?> GetByIdAsync(Expression<Func<User, bool>> expression);
    Task<User?> GetByNameAsync(Expression<Func<User, bool>> expression);
    Task<User?> GetByEmailAsync(Expression<Func<User, bool>> expression);
    IQueryable<User> GetAll(Expression<Func<User, bool>> expression);
}

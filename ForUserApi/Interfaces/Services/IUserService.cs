using ForUserApi.Common.Utils;
using ForUserApi.DTOs;
using ForUserApi.Entities;
using System.Linq.Expressions;

namespace ForUserApi.Interfaces.Services;

public interface IUserService
{
    Task UpdateAsync(AddUserDto dto);
    Task DeleteAsync(Guid id);
    Task<string> GetByIdAsync(Guid id);
    Task<string> GetByNameAsync(string name);
    Task<string> GetAllAsync(PaginationParams @params,
                                           Expression<Func<User, bool>>? expression = null);
}

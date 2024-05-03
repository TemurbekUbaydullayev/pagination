using ForUserApi.Common.Utils;
using ForUserApi.DTOs;
using ForUserApi.Entities;
using System.Linq.Expressions;

namespace ForUserApi.Interfaces.Services;

public interface IUserService
{
    Task UpdateAsync(AddUserDto dto);
    Task DeleteAsync(Guid id);
    Task<UserDto> GetByIdAsync(Guid id);
    Task<UserDto> GetByNameAsync(string name);
    Task<IEnumerable<UserDto>> GetAllAsync(PaginationParams @params,
                                           Expression<Func<User, bool>>? expression = null);
}

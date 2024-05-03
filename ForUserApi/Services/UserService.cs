using ForUserApi.Common.Extensions;
using ForUserApi.Common.Utils;
using ForUserApi.DTOs;
using ForUserApi.Entities;
using ForUserApi.Interfaces.Repositories;
using ForUserApi.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ForUserApi.Services;

public class UserService(IUserInterface userInterface,
                         IHttpContextAccessor accessor) : IUserService
{
    private readonly IUserInterface _userInterface = userInterface;
    private readonly IHttpContextAccessor _accessor = accessor;

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(PaginationParams @params,
                                                        Expression<Func<User, bool>>? expression = null)
    {   
        var users = _userInterface.GetAll(expression!);

        return await users.Select(p => (UserDto)p)
                          .ToPagedListAsync(@params);
    }

    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var user = await _userInterface.GetByIdAsync(p => p.Id.Equals(id));

        return user is not null ? user : throw new Exception("User not found!");
    }

    public async Task<UserDto> GetByNameAsync(string name)
    {
        var user = await _userInterface.GetByNameAsync(p => $"{p.FirstName} {p.LastName}"
                                            .ToLower()
                                            .Equals(name.ToLower()));

        return user is not null ? user : throw new Exception("User not found!");
    }

    public Task UpdateAsync(AddUserDto dto)
    {
        throw new NotImplementedException();
    }
}

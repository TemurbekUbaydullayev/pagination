using ForUserApi.Common.Extensions;
using ForUserApi.Common.Utils;
using ForUserApi.DTOs;
using ForUserApi.Entities;
using ForUserApi.Interfaces.Repositories;
using ForUserApi.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace ForUserApi.Services;

public class UserService(IUserInterface userInterface,
                         IHttpContextAccessor accessor,
                         IRedisService redisService) : IUserService
{
    private readonly IUserInterface _userInterface = userInterface;
    private readonly IHttpContextAccessor _accessor = accessor;
    private readonly IRedisService _redisService = redisService;
    private const string CACHE_KEY = "users";

    public async Task DeleteAsync(Guid id)
    {
        var user = await _userInterface.GetByIdAsync(p => p.Id.Equals(id));

        if (user is null)
            throw new Exception("User not found!");

        await _userInterface.DeleteAsync(user);
        await _redisService.DeleteAsync(CACHE_KEY);
    }

    public async Task<string> GetAllAsync(PaginationParams @params,
                                                        Expression<Func<User, bool>>? expression = null)
    {
        var entities = await _redisService.GetAsync(CACHE_KEY);

        if (entities is not null)
        {
            var data = JsonConvert.DeserializeObject<List<UserDto>>(entities);

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        var users = _userInterface.GetAll(expression!);

        var json = JsonConvert.SerializeObject(users.Select(p => (UserDto)p), Formatting.Indented);

        await _redisService.SetAsync(CACHE_KEY, json);

        return JsonConvert.SerializeObject(users.Select(p => (UserDto)p), Formatting.Indented);
    }

    public async Task<string> GetByIdAsync(Guid id)
    {
        var user = await _userInterface.GetByIdAsync(p => p.Id.Equals(id));

        return user is not null ? JsonConvert.SerializeObject((UserDto)user) 
                                : throw new Exception("User not found!");
    }

    public async Task<string> GetByNameAsync(string name)
    {
        var user = await _userInterface.GetByNameAsync(p => $"{p.FirstName} {p.LastName}"
                                            .ToLower()
                                            .Equals(name.ToLower()));

        return user is not null ? JsonConvert.SerializeObject((UserDto)user) 
                                : throw new Exception("User not found!");
    }

    public Task UpdateAsync(AddUserDto dto)
    {
        throw new NotImplementedException();
    }
}
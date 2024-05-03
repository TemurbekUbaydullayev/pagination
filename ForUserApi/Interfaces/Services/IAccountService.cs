using ForUserApi.DTOs;

namespace ForUserApi.Interfaces.Services;

public interface IAccountService
{
    Task RegisterAsync(AddUserDto dto);
    Task<string> LoginAsync(LoginDto dto);
}

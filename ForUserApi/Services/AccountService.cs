using ForUserApi.Common.Security;
using ForUserApi.DTOs;
using ForUserApi.Entities;
using ForUserApi.Interfaces.Repositories;
using ForUserApi.Interfaces.Services;

namespace ForUserApi.Services;

public class AccountService(IUserInterface userInterface) : IAccountService
{
    private readonly IUserInterface _userInterface = userInterface;

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _userInterface.GetByEmailAsync(p => p.Email.Equals(dto.Email));
        if (user is null)
            throw new Exception("404 : not found!");

        if (!PasswordHasher.IsEqual(user.Password, dto.Password, user.Salt))
            return "Incorrect password!";

        return "JWT";
    }

    public async Task RegisterAsync(AddUserDto dto)
    {
        var user = await _userInterface.GetByEmailAsync(p => p.Email.Equals(dto.Email));
        if (user is not null)
            throw new Exception("409: user already exists!");

        var result = PasswordHasher.GetHash(dto.Password, out var salt);
        
        var entity = (User)dto;
        entity.Password = result;
        entity.Salt = salt;

        await _userInterface.CreateAsync(entity);
    }
}

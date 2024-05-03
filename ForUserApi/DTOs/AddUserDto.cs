using ForUserApi.Entities;
using ForUserApi.Enums;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ForUserApi.DTOs;

public class AddUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Gender Gender { get; set; }

    public static implicit operator User(AddUserDto dto)
    {
        return new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            Gender = dto.Gender
        };
    }
}

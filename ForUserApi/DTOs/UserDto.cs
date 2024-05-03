using ForUserApi.Entities;

namespace ForUserApi.DTOs;

public class UserDto : AddUserDto
{
    public Guid Id { get; set; }


    public static implicit operator UserDto(User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password,
            Gender = user.Gender
        };
    }

    //public static implicit operator User(UserDto dto)
    //{
    //    return new User()
    //    {
    //        Id = dto.Id,
    //        FirstName = dto.FirstName,
    //        LastName = dto.LastName,
    //        Email = dto.Email,
    //        Password = dto.Password,
    //        Gender = dto.Gender
    //    };
    //}
}

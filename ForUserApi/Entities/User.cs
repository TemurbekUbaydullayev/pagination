using ForUserApi.Enums;

namespace ForUserApi.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public UserRole UserRole { get; set; } = UserRole.User;
    public string Salt { get; set; } = string.Empty;
    public bool IsVerified { get; set; } = false;
}

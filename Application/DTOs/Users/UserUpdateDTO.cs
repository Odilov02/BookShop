using Application.DTOs.Users;

namespace Application.DTOs.users;

public class UserUpdateDTO : UserBaseDTO
{
    public string FullName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Password { get; set; } = "";
}

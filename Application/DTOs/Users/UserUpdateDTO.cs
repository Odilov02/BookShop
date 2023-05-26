using Domain.Entities.IdentityEntities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Users;

namespace Application.DTOs.users;

public class UserUpdateDTO:UserBaseDTO
{
    public string FullName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Password { get; set; } = "";
    public ICollection<Role>? Roles { get; set; }
}

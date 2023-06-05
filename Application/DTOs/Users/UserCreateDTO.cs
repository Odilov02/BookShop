using Domain.Entities.IdentityEntities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Users;

public class UserCreateDTO
{
    public string FullName { get; set; } 
    public string PhoneNumber { get; set; } 
    public string Password { get; set; }

}

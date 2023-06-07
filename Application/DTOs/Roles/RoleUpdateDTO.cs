using Domain.Entities.IdentityEntities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Roles;

public class RoleUpdateDTO:RoleBaseDTO
{
    public string? RoleName { get; set; } = "";
    public ICollection<Guid>? permissionIds { get; set; }
}

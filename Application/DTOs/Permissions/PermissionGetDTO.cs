using Domain.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Permissions;

public class PermissionGetDTO
{
    public Guid Id { get; set; }
    public string PermissionName { get; set; } = "";
}

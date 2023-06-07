using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.IdentityEntities;

public class Role
{
    public Guid Id { get; set; }
    public string? RoleName { get; set; } = "";
    public ICollection<Permission> permissions {get; set; }
    public ICollection<User>? Users {get; set; }
}

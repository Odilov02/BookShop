using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.IdentityEntities;

public class Role:BaseAuditableEntity
{
    public string? RoleName { get; set; } = "";
    public ICollection<Permission>? permissions {get; set; }
    public ICollection<User>? Users {get; set; }
}

using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.IdentityEntities;

public class Permission: BaseEntity
{
    public string PermissionName { get; set; } = "";
    public ICollection<Role>? Roles { get; set; }

}

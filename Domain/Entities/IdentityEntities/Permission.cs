namespace Domain.Entities.IdentityEntities;

public class Permission : BaseEntity
{
    public string PermissionName { get; set; }
    public virtual ICollection<Role>? Roles { get; set; }

}

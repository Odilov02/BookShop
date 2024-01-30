namespace Domain.Entities.IdentityEntities;

public class Role : BaseAuditableEntity
{
    public string Name { get; set; }
    public virtual ICollection<Permission> permissions { get; set; }
    public virtual ICollection<User>? Users { get; set; }
}

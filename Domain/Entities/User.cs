using Domain.Entities.IdentityEntities;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Role>? Roles { get; set; }
    public virtual ICollection<Commentary>? Commentaries { get; set; }
}


namespace Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; }
    public virtual ICollection<Book>? Books { get; set; }
}


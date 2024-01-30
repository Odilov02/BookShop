
namespace Domain.Entities;

public class Author : BaseAuditableEntity
{
    public string FullName { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Book>? Books { get; set; }
}

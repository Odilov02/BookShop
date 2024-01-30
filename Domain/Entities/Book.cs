namespace Domain.Entities;

public class Book : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
    public int PageCount { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int Count { get; set; }

    public virtual Author Author { get; set; }

    public virtual Category Category { get; set; }
    public virtual ICollection<Commentary>? Commentaries { get; set; }
}


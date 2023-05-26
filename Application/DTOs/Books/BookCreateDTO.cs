using Domain.Entities;

namespace Application.DTOs.Books;

public class BookCreateDTO
{
    public string Name { get; set; } = "";

    public string Description { get; set; } = "";
    public string Language { get; set; } = "";
    public int PageCount { get; set; }

    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = "";
    public int Count { get; set; }

    public Guid AuthorId { get; set; }

    public Guid CategoryId { get; set; }
}

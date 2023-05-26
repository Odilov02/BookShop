using Domain.Entities;

namespace Application.DTOs.Books;

public class BookGetDTO
{
    public string Name { get; set; } = "";

    public string Description { get; set; } = "";
    public string Language { get; set; } = "";
    public int PageCount { get; set; }

    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = "";
    public int Count { get; set; }
    public Author? Author { get; set; }
    public Category? Category { get; set; }
    public ICollection<Commentary>? Commentaries { get; set; }
}

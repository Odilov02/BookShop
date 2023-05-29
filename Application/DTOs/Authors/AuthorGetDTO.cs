using Domain.Entities;
namespace Application.DTOs.Authors;


public class AuthorGetDTO
{
    public string FullName { get; set; } = "";

    public string Description { get; set; } = "";

    public ICollection<Guid>? BooksId { get; set; }
}

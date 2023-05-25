using Domain.Entities;
namespace Application.DTOs.Author;


public class AuthorGetDTO
{
    public string FullName { get; set; } = "";

    public string Description { get; set; } = "";

   // public ICollection<Book>? Books { get; set; }
}

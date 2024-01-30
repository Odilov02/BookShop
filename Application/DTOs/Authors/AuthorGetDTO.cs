using Domain.Entities;
namespace Application.DTOs.Authors;


public class AuthorGetDTO:AuthorkBaseDTO
{
    public string FullName { get; set; }

    public string Description { get; set; }
    public ICollection<Guid>? BookIds { get; set; }
}

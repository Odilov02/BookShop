namespace Application.DTOs.Authors;

public class AuthorUpdateDTO:AuthorkBaseDTO
{

    public string FullName { get; set; } = "";

    public string Description { get; set; } = "";
}

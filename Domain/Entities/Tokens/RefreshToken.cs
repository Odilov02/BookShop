namespace Domain.Entities.Tokens;

public class RefreshToken : BaseEntity
{
    public Guid UserId { get; set; }
    public string Refresh { get; set; }
    public DateTime ActiveDate;

}

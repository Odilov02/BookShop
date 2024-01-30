namespace Domain.Entities;

public class Commentary : BaseEntity
{
    public string Description { get; set; }
    public virtual User User { get; set; }
    public virtual Book book { get; set; }
}

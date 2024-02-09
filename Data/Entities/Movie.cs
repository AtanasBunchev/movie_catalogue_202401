namespace MC.Data.Entities;
public class Movie : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime? ReleaseDate { get; set; }
}

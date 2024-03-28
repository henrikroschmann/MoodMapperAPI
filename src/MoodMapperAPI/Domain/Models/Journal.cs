namespace MoodMapperAPI.Domain.Options;

public class Journal
{
    public int Id { get; set; }
    public ApplicationUser User { get; set; }
    public string UserId { get; set; }
}
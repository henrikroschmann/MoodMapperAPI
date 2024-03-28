namespace MoodMapperAPI.Domain.Options;

public class Entry
{
    public int? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CreationInfo Creation { get; set; }
    public MoodLevel Mood { get; set; }
    public int JournalId { get; set; }
    public Journal Journal { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
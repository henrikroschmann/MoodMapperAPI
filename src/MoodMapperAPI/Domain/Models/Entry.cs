namespace MoodMapperAPI.Domain.Options;

public class Entry : IUserObject
{
    public Ulid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CreationInfo Creation { get; set; }
    public MoodLevel Mood { get; set; }
    public Ulid JournalId { get; set; }
    public virtual Journal Journal { get; set; }

    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    public Ulid TagId { get; set; }
    public virtual Tag Tag { get; set; }
}

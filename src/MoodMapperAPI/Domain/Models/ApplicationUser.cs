namespace MoodMapperAPI.Domain.Options;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Journal>? Journals { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
    public virtual ICollection<Entry> Entries { get; set; }
    public DateTime LastLoggedIn { get; internal set; }
}
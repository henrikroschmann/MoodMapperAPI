namespace MoodMapperAPI.Domain.Options;

public class ApplicationUser : IdentityUser
{
    public List<Entry> Entries { get; set; }
    public Journal Journal { get; set; }
    public DateTime LastLoggedIn { get; internal set; }
}
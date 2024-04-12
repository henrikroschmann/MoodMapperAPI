namespace MoodMapperAPI.Domain.Options;

public interface IUserObject
{
    public Ulid Id {  get; set; }
    public string UserId { get; set; }
}

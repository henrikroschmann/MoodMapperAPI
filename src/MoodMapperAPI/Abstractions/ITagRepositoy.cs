namespace MoodMapperAPI.Abstractions;

public interface ITagRepositoy : IDisposable
{
    IEnumerable<Tag> GetTags();

    Tag? GetTagById(Ulid id);

    void InsertTag(Tag tag);

    void DeleteTag(Ulid id);

    void UpdateTag(Tag tag);

    void Save();
}

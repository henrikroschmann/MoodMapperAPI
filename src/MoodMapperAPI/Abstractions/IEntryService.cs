namespace MoodMapperAPI.Abstractions;

public interface IEntryService
{
    Task<Entry> CreateEntry(EntryDto entry, string? userId);
    Task<List<Entry>> GetAllWithPagination(EntryParameters parameters, string? userId);
    Task DeleteEntry(int entryId, int userId);
    EntryDto UpdateEntry(EntryDto entry);
}
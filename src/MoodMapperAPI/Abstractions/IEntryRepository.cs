namespace MoodMapperAPI.Abstractions;

public interface IEntryRepository
{
    List<Entry> GetJournalEntriesWithPagination(int journalId, EntryParameters parameters);
    Task<Entry> GetById(int entryId);
}
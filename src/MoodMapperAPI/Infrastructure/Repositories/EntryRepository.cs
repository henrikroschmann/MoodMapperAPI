using MoodMapperAPI.Infrastructure.Data;

namespace MoodMapperAPI.Infrastructure.Repositories;

public class EntryRepository(ApplicationDbContext context) : IEntryRepository
{
    private readonly ApplicationDbContext _context = context;

    public Task? AddEntry(Entry newEntry)
    {
        _context.Entries.Add(newEntry);
        return null;
    }

    public Task DeleteAsync(Entry entry)
    {
        throw new NotImplementedException();
    }

    public Task<Entry> GetById(int entryId)
    {
        throw new NotImplementedException();
    }

    public List<Entry> GetJournalEntriesWithPagination(int journalId, EntryParameters parameters)
    {
        throw new NotImplementedException();
    }
}
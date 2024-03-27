using Microsoft.AspNetCore.Authorization;
using MoodMapperAPI.Domain.Enums;

namespace MoodMapperAPI.Services;

public class EntityService : IEntryService
{
    private readonly IJournalRepository _journalRepository;
    private readonly IEntryRepository _entryRepository;
    private readonly IAuthService _authorizationService;

    public EntityService(
        IEntryRepository entryRepository,
        IJournalRepository journalRepository,
        IAuthService authorizationService)
    {
        _entryRepository = entryRepository;
        _journalRepository = journalRepository;
        _authorizationService = authorizationService;
    }

    public async Task<Entry> CreateEntry(EntryDto entry, string? userId)
    {
        ArgumentNullException.ThrowIfNull(userId);
        var journal = await _journalRepository.GetByUser(userId) ??
                      throw new JournalNotFoundException("Journal not found for the specified user.");
        
        //if (!await _authorizationService.CanUserModifyJournal(userId, journal.Id))
        //{
        //    throw new UnauthorizedAccessException("User is not authorized to modify this journal.");
        //}

        var newEntry = new Entry
        {
            Id = null,
            Title = entry.Title,
            Description = entry.Description, 
            Creation = new CreationInfo(DateTime.UtcNow),
            Mood = (MoodLevel)entry.Mood
        };
        
        await _entries
        
        
        journal.Entries.Add(newEntry);
        await _journalRepository.SaveAsync();

        return newEntry;
    }

    public async Task<List<Entry>> GetAllWithPagination(EntryParameters parameters, string? userId)
    {
        ArgumentNullException.ThrowIfNull(userId);
        var journal = await _journalRepository.GetByUser(userId) ??
                      throw new JournalNotFoundException("Journal not found for the specified user.");

        return _entryRepository.GetJournalEntriesWithPagination(journal.Id, parameters);
    }

    public async Task DeleteEntry(int entryId, int userId)
    {
        var entry = await _entryRepository.GetById(entryId) ??
                    throw new EntryNotFoundException("Entry not found.");

        // Authorization check
        if (!await _authorizationService.CanUserModifyEntry(userId, entryId))
        {
            throw new UnauthorizedAccessException("User is not authorized to delete this entry.");
        }

        await _entryRepository.DeleteAsync(entry);
    }

    public EntryDto UpdateEntry(EntryDto entry)
    {
        throw new NotImplementedException();
    }
}

public interface IAuthService
{
    Task<bool> CanUserModifyJournal(string userId, int journalId);
    Task<bool> CanUserModifyEntry(int userId, int entryId);
}
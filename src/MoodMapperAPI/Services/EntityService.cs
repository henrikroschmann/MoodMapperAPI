namespace MoodMapperAPI.Services;

public class EntityService(
    IEntryRepository entryRepository,
    IJournalRepository journalRepository,
    IAuthService authorizationService,
    UserManager<ApplicationUser> userManager) : IEntryService
{
    private readonly IJournalRepository _journalRepository = journalRepository;
    private readonly IEntryRepository _entryRepository = entryRepository;
    private readonly IAuthService _authorizationService = authorizationService;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<Entry> CreateEntry(EntryDto entry, string? userId)
    {
        ArgumentNullException.ThrowIfNull(userId);
        var journal = await _journalRepository.GetByUser(userId) ??
                      throw new JournalNotFoundException("Journal not found for the specified user.");

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId) ??
            throw new UnauthorizedAccessException("User not found.");
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
            Mood = (MoodLevel)entry.Mood,
            JournalId = journal.Id,
            UserId = userId,
            User = user
        };

        await _entryRepository.AddEntry(newEntry);
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
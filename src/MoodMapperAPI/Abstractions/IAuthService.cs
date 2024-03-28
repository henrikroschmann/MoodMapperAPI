namespace MoodMapperAPI.Abstractions;

public interface IAuthService
{
    Task<bool> CanUserModifyJournal(string userId, int journalId);

    Task<bool> CanUserModifyEntry(int userId, int entryId);
}
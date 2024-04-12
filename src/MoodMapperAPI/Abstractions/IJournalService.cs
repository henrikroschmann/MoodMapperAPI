namespace MoodMapperAPI.Abstractions;

public interface IJournalService
{
    Task<Journal> CreateJournal(string userid, JournalDto journal);

    Task DeleteJournal(string userid, int id);

    Task<Journal> GetJournal(string userid, int id);
}
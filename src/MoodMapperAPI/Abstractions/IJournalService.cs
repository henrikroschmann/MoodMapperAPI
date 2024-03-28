namespace MoodMapperAPI.Abstractions;

public interface IJournalService
{
    Task<Journal> CreateJournal(JournalDto journal);

    Task DeleteJournal(int id);

    Task<Journal> GetJournal(int id);
}
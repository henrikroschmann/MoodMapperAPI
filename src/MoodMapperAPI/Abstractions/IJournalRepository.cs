namespace MoodMapperAPI.Abstractions;

public interface IJournalRepository
{  
    Task CreateJournalAsync(Journal journal);
    IEnumerable<Journal?> GetByUser(string userId);
}

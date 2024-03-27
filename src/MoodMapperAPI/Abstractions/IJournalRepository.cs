namespace MoodMapperAPI.Abstractions;

public interface IJournalRepository
{
    Task<Journal?> GetByUser(string userId);
}
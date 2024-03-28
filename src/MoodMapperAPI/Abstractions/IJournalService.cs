using MoodMapperAPI.Controllers;

namespace MoodMapperAPI.Abstractions;

public interface IJournalService
{
    Task CreateJournal(JournalDto journal);
    Task DeleteJournal(int id);
    Task GetJournal(int id);
}
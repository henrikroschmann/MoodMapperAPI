namespace MoodMapperAPI.Infrastructure.Repositories;

public class JournalRepository(IGenericRepository<Journal> repo) : IJournalRepository
{
    private readonly IGenericRepository<Journal> _repo = repo;

    public async Task<Journal> CreateJournalAsync(Journal journal)
    {
        await _repo.InsertAsync(journal);
        return _repo.SaveAsync();
    }

    public IEnumerable<Journal?> GetByUser(string userId)
    {
        return _repo.GetByUserId(userId);
    }
}
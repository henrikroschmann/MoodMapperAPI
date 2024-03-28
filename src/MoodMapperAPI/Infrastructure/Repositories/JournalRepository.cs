using MoodMapperAPI.Infrastructure.Data;

namespace MoodMapperAPI.Infrastructure.Repositories;

public class JournalRepository : IJournalRepository
{
    private readonly ApplicationDbContext _context;

    public JournalRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Journal?> GetByUser(string userId)
    {
        return await _context.Journals
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }
}
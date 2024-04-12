using MoodMapperAPI.Infrastructure.Data;

namespace MoodMapperAPI.Infrastructure.Repositories;

public class EntryRepository(ApplicationDbContext context) : GenericRepository<Entry>(context), IDisposable
{
    private readonly ApplicationDbContext _context = context;
    private bool disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }
}
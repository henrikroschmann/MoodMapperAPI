using MoodMapperAPI.Infrastructure.Data;

namespace MoodMapperAPI.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IUserObject
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public void Delete(string userId, Ulid id)
    {
        var data = _dbSet.FirstOrDefault(t => t.UserId == userId && t.Id == id);
        if (data != null)
            _dbSet.Remove(data);
    }

    public async Task<TEntity?> GetById(string userId, Ulid id)
    {
        return await _dbSet.FirstOrDefaultAsync(d => d.UserId == userId && d.Id == id);
    }

    public IEnumerable<TEntity> GetByUserId(string userId)
    {
        return _dbSet.Where(t => t.UserId == userId).ToList();
    }

    public async Task InsertAsync(TEntity data)
    {
        await _dbSet.AddAsync(data);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateTag(TEntity data)
    {
        _dbSet.Update(data);
        _dbSet
        _context.Entry(tag).State = EntityState.Modified;
    }
}
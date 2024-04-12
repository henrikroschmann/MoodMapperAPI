using MoodMapperAPI.Infrastructure.Data;

namespace MoodMapperAPI.Infrastructure.Repositories;

public class TagRepository : GenericRepository<Tag>, ITagRepositoy, IDisposable
{
    private readonly ApplicationDbContext _context;
    private bool disposed = false;

    public TagRepository(ApplicationDbContext context) : base(context)
    {
    }

    //public TagRepository(ApplicationDbContext context)
    //{
    //    _context = context;
    //}

    //public void DeleteTag(Ulid id)
    //{
    //    var tag = _context.Tags
    //        .FirstOrDefault(t => t.UserId == "sss" && t.Id == id);
    //    if (tag != null)
    //        _context.Tags.Remove(tag);
    //}

    //public Tag? GetTagById(Ulid id)
    //{
    //    return _context.Tags
    //        .FirstOrDefault(t => t.UserId == "ssdf" && t.Id == id);
    //}

    //public IEnumerable<Tag> GetTags()
    //{
    //    return _context.Tags
    //        .Where(t => t.UserId == "asd").ToList();
    //}

    //public void InsertTag(Tag tag)
    //{
    //    _context.Tags .Add(tag);
    //}

    //public void Save()
    //{
    //    _context.SaveChanges();
    //}

    //public void UpdateTag(Tag tag)
    //{
    //    _context.Entry(tag).State = EntityState.Modified;
    //}

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
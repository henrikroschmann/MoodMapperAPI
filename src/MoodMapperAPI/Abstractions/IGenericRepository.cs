namespace MoodMapperAPI.Abstractions
{
    public interface IGenericRepository<TEntity> where TEntity : class, IUserObject
    {
        void Delete(string userId, Ulid id);
        Task<TEntity?> GetById(string userId, Ulid id);
        IEnumerable<TEntity> GetByUserId(string userId);
        Task InsertAsync(TEntity data);
        Task SaveAsync();
        void UpdateTag(TEntity data);
    }
}
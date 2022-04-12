namespace Report.DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task Remove(string id);
        Task RemoveRange(IEnumerable<TEntity> entities);
    }
}
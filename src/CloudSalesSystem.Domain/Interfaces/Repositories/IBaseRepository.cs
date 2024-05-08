using System.Linq.Expressions;

namespace CloudSalesSystem.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<List<TEntity>> GetListAsync();
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
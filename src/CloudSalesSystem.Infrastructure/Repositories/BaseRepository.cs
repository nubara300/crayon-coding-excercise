using CloudSalesSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CloudSalesSystem.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
            => _entities.Add(entity);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
            => _entities.AnyAsync(expression);

        public void Delete(TEntity entity)
            => _entities.Remove(entity);

        public async Task DeleteById(int id)
            => Delete(await _context.Set<TEntity>().FindAsync(id));

        public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
            => _entities.FirstOrDefaultAsync(expression);

        public async Task<TEntity?> GetByIdAsync(int id)
            => await _entities.FindAsync(id);

        public Task<List<TEntity>> GetListAsync()
            => _entities.AsNoTracking().ToListAsync();

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression)
           => _entities.AsNoTracking().Where(expression).ToListAsync();

        public void Update(TEntity entity)
           => _entities.Update(entity);
    }
}

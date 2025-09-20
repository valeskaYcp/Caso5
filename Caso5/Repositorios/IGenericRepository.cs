using System.Linq.Expressions;

namespace Caso5.Repositorios
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddAndSaveAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}

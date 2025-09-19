namespace DefaultNamespace;

using Microsoft.EntityFrameworkCore;
using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5_Gestion_de_producci_n.Data;

namespace Caso5_Gestion_de_produccion.Repositorios.Implementaciones
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly FabricaDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(FabricaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity?> GetByIdAsync(object id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _dbSet.Where(predicate).ToListAsync();

        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public async Task AddAndSaveAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity) => _dbSet.Update(entity);

        public void Remove(TEntity entity) => _dbSet.Remove(entity);
    }
}

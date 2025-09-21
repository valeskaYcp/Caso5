using Caso5.Models;
using Caso5.Repositorios;


namespace Caso5_Gestion_de_producci_n.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveAsync();
    }

}

using Caso5.Models;
using Caso5.Repositorios;


namespace Caso5_Gestion_de_producci_n.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Producto> Productos { get; }
        IGenericRepository<MateriasPrima> MateriasPrimas { get; }
        IGenericRepository<InventarioProducto> InventarioProductos { get; }
        IGenericRepository<InventarioMateriasPrima> InventarioMateriasPrimas { get; }
        IGenericRepository<OrdenesProduccion> OrdenesProducciones { get; }
        IGenericRepository<EtapasProduccion> EtapasProducciones { get; }
        IGenericRepository<InspeccionesCalidad> InspeccionesCalidades { get; }
        IGenericRepository<Proveedore> Proveedores { get; }

        Task<int> SaveAsync();
    }
}

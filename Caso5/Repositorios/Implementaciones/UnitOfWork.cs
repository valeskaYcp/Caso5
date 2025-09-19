namespace DefaultNamespace;

using Caso5_Gestion_de_producci_n.Data;
using Caso5_Gestion_de_producci_n.Models;
using Caso5_Gestion_de_producci_n.Repositorios;

namespace Caso5_Gestion_de_produccion.Repositorios.Implementaciones
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FabricaDbContext _context;

        public IGenericRepository<Producto> Productos { get; }
        public IGenericRepository<MateriasPrima> MateriasPrimas { get; }
        public IGenericRepository<InventarioProducto> InventarioProductos { get; }
        public IGenericRepository<InventarioMateriasPrima> InventarioMateriasPrimas { get; }
        public IGenericRepository<OrdenesProduccion> OrdenesProducciones { get; }
        public IGenericRepository<EtapasProduccion> EtapasProducciones { get; }
        public IGenericRepository<InspeccionesCalidad> InspeccionesCalidades { get; }
        public IGenericRepository<Proveedore> Proveedores { get; }

        public UnitOfWork(FabricaDbContext context)
        {
            _context = context;
            Productos = new GenericRepository<Producto>(_context);
            MateriasPrimas = new GenericRepository<MateriasPrima>(_context);
            InventarioProductos = new GenericRepository<InventarioProducto>(_context);
            InventarioMateriasPrimas = new GenericRepository<InventarioMateriasPrima>(_context);
            OrdenesProducciones = new GenericRepository<OrdenesProduccion>(_context);
            EtapasProducciones = new GenericRepository<EtapasProduccion>(_context);
            InspeccionesCalidades = new GenericRepository<InspeccionesCalidad>(_context);
            Proveedores = new GenericRepository<Proveedore>(_context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

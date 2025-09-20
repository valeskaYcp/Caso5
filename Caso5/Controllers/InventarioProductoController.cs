using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Caso5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioProductoController : GenericController<InventarioProducto>
    {
        public InventarioProductoController(IUnitOfWork unitOfWork) 
            : base(unitOfWork) { }

        // Obtener productos con stock bajo
        [HttpGet("stock-bajo")]
        public async Task<IActionResult> StockBajo()
        {
            var productos = await _unitOfWork.Repository<InventarioProducto>()
                .FindAsync(p => p.Cantidad < p.StockMinimo);
            return Ok(productos);
        }
    }
}
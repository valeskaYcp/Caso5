using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Caso5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioMateriasPrimaController : GenericController<InventarioMateriasPrima>
    {
        public InventarioMateriasPrimaController(IUnitOfWork unitOfWork) 
            : base(unitOfWork) { }

        // Obtener materias primas con stock bajo
        [HttpGet("stock-bajo")]
        public async Task<IActionResult> StockBajo()
        {
            var materias = await _unitOfWork.Repository<InventarioMateriasPrima>()
                .FindAsync(m => m.Cantidad < m.StockMinimo);
            return Ok(materias);
        }
    }
}
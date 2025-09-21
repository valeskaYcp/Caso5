using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Caso5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtapasProduccionController : GenericController<EtapasProduccion>
    {
        public EtapasProduccionController(IUnitOfWork unitOfWork) 
            : base(unitOfWork) { }

        // Obtener todas las etapas de una orden
        [HttpGet("por-orden/{ordenId}")]
        public async Task<IActionResult> ObtenerPorOrden(int ordenId)
        {
            var etapas = await _unitOfWork.Repository<EtapasProduccion>()
                .FindAsync(e => e.OrdenId == ordenId);
            return Ok(etapas);
        }
    }
}
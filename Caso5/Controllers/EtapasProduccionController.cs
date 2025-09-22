using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios;
using Caso5.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caso5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtapasProduccionController : GenericController<EtapasProduccion>
    {
        private readonly ProduccionService _produccionService;

        public EtapasProduccionController(IUnitOfWork unitOfWork, ProduccionService produccionService)
            : base(unitOfWork)
        {
            _produccionService = produccionService;
        }

        // Obtener todas las etapas de una orden
        [HttpGet("por-orden/{ordenId}")]
        public async Task<IActionResult> ObtenerPorOrden(int ordenId)
        {
            var etapas = await _unitOfWork.Repository<EtapasProduccion>()
                .FindAsync(e => e.OrdenId == ordenId);
            return Ok(etapas);
        }

        // Obtener porcentaje de productos defectuosos en una etapa
        [HttpGet("{etapaId}/porcentaje-defectuosos")]
        public async Task<IActionResult> ObtenerPorcentajeDefectuosos(int etapaId)
        {
            var porcentaje = await _produccionService.ObtenerPorcentajeDefectuososAsync(etapaId);
            return Ok(new { etapaId, porcentaje });
        }
    }
}
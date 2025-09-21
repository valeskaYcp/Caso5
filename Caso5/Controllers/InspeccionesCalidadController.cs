using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Caso5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InspeccionesCalidadController : GenericController<InspeccionesCalidad>
    {
        public InspeccionesCalidadController(IUnitOfWork unitOfWork) 
            : base(unitOfWork) { }

        // Obtener inspecciones de una etapa específica
        [HttpGet("por-etapa/{etapaId}")]
        public async Task<IActionResult> ObtenerPorEtapa(int etapaId)
        {
            var inspecciones = await _unitOfWork.Repository<InspeccionesCalidad>()
                .FindAsync(i => i.EtapaId == etapaId);
            return Ok(inspecciones);
        }

        // Obtener productos defectuosos de una inspección
        [HttpGet("{id}/defectuosos")]
        public async Task<IActionResult> ProductosDefectuosos(int id)
        {
            var inspeccion = await _unitOfWork.Repository<InspeccionesCalidad>()
                .GetByIdAsync(id);
            if (inspeccion == null) return NotFound();

            return Ok(new { inspeccion.ProductosDefectuosos });
        }
    }
}
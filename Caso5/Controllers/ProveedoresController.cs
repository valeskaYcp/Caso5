using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Caso5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : GenericController<Proveedore>
    {
        public ProveedoresController(IUnitOfWork unitOfWork) 
            : base(unitOfWork) { }

        // Ejemplo: obtener proveedores con buena evaluación
        [HttpGet("evaluacion-alta")]
        public async Task<IActionResult> EvaluacionAlta()
        {
            var proveedores = await _unitOfWork.Repository<Proveedore>()
                .FindAsync(p => p.Evaluacion >= 4);
            return Ok(proveedores);
        }
    }
}
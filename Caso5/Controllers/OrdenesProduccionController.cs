using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Caso5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesProduccionController : GenericController<OrdenesProduccion>
    {
        public OrdenesProduccionController(IUnitOfWork unitOfWork) 
            : base(unitOfWork) { }

        // Método específico: actualizar estado de la orden
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] string nuevoEstado)
        {
            var orden = await _unitOfWork.Repository<OrdenesProduccion>().GetByIdAsync(id);
            if (orden == null) return NotFound();

            orden.Estado = nuevoEstado;
            _unitOfWork.Repository<OrdenesProduccion>().Update(orden);
            await _unitOfWork.SaveAsync();

            return Ok(orden);
        }
    }
}
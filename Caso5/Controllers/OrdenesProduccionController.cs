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
        
        //orden de producción
        [HttpPut("{id}/iniciar")]
        public async Task<IActionResult> IniciarOrden(int id)
        {
            var orden = await _unitOfWork.Repository<OrdenesProduccion>().GetByIdAsync(id);
            if (orden == null) return NotFound();

            orden.FechaInicio = DateOnly.FromDateTime(DateTime.Today);
            orden.Estado = "En Proceso";

            _unitOfWork.Repository<OrdenesProduccion>().Update(orden);
            await _unitOfWork.SaveAsync();

            return Ok(orden);
        }
        
        //Finalizar una orden
        [HttpPut("{id}/finalizar")]
        public async Task<IActionResult> FinalizarOrden(int id, [FromBody] decimal cantidadReal)
        {
            var orden = await _unitOfWork.Repository<OrdenesProduccion>().GetByIdAsync(id);
            if (orden == null) return NotFound();

            orden.FechaFin = DateOnly.FromDateTime(DateTime.Today);
            orden.CantidadReal = cantidadReal;
            orden.Estado = "Finalizada";

            _unitOfWork.Repository<OrdenesProduccion>().Update(orden);
            await _unitOfWork.SaveAsync();

            return Ok(orden);
        }
        
        //listar ordenes por estado
        [HttpGet("por-estado/{estado}")]
        public async Task<IActionResult> ObtenerPorEstado(string estado)
        {
            var ordenes = await _unitOfWork.Repository<OrdenesProduccion>()
                .FindAsync(o => o.Estado == estado);
            return Ok(ordenes);
        }


    }
}
using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Caso5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriasPrimaController : GenericController<MateriasPrima>
    {
        public MateriasPrimaController(IUnitOfWork unitOfWork) 
            : base(unitOfWork) { }

        // Ejemplo: obtener materias de un proveedor
        [HttpGet("por-proveedor/{proveedorId}")]
        public async Task<IActionResult> ObtenerPorProveedor(int proveedorId)
        {
            var materias = await _unitOfWork.Repository<MateriasPrima>()
                .FindAsync(m => m.ProveedorId == proveedorId);
            return Ok(materias);
        }
    }
}
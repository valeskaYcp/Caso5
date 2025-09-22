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
        
        //buscar materias primas por nombre
        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string q)
        {
            var materias = await _unitOfWork.Repository<MateriasPrima>()
                .FindAsync(m => m.Nombre.Contains(q) || m.Descripcion!.Contains(q));
            return Ok(materias);
        }
        //listar materias primas por unidad
        [HttpGet("por-unidad/{unidad}")]
        public async Task<IActionResult> ObtenerPorUnidad(string unidad)
        {
            var materias = await _unitOfWork.Repository<MateriasPrima>()
                .FindAsync(m => m.UnidadMedida == unidad);
            return Ok(materias);
        }
        
        //obtener inventario asociado a una materia prima
        [HttpGet("{id}/inventario")]
        public async Task<IActionResult> ObtenerInventario(int id)
        {
            var materia = await _unitOfWork.Repository<MateriasPrima>().GetByIdAsync(id);
            if (materia == null) return NotFound();

            return Ok(materia.InventarioMateriasPrimas);
        }



    }
}
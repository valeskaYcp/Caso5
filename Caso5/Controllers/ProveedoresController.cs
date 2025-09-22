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
        //Buscar por nombre
        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string q)
        {
            var proveedores = await _unitOfWork.Repository<Proveedore>()
                .FindAsync(p => p.Nombre.Contains(q) || p.Contacto!.Contains(q));
            return Ok(proveedores);
        }
        
        //obtener materias primas que ofrece cada proveedor
        [HttpGet("{id}/materias-primas")]
        public async Task<IActionResult> MateriasPrimas(int id)
        {
            var proveedor = await _unitOfWork.Repository<Proveedore>().GetByIdAsync(id);
            if (proveedor == null) return NotFound();

            return Ok(proveedor.MateriasPrimas);
        }
        
        //Contacto rápido
        [HttpGet("contactos")]
        public async Task<IActionResult> Contactos()
        {
            var proveedores = await _unitOfWork.Repository<Proveedore>().GetAllAsync();
            var contactos = proveedores.Select(p => new {
                p.Nombre,
                p.Contacto,
                p.Telefono,
                p.Email
            });
            return Ok(contactos);
        }



    }
}
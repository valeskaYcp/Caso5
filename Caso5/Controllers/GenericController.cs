using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Caso5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity> : ControllerBase where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public GenericController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _unitOfWork.Repository<TEntity>().GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TEntity entity)
        {
            await _unitOfWork.Repository<TEntity>().AddAndSaveAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = GetEntityId(entity) }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TEntity entity)
        {
            var existing = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
            if (existing == null) return NotFound();

            _unitOfWork.Repository<TEntity>().Update(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
            if (entity == null) return NotFound();

            _unitOfWork.Repository<TEntity>().Remove(entity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // Obtiene el Id de la entidad genérica usando reflexión
        private object? GetEntityId(TEntity entity)
        {
            var prop = typeof(TEntity).GetProperties()
                        .FirstOrDefault(p => p.Name.EndsWith("Id"));
            return prop?.GetValue(entity);
        }
    }
}

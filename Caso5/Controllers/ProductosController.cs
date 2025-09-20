using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Caso5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : GenericController<Producto>
    {
        public ProductosController(IUnitOfWork unitOfWork) 
            : base(unitOfWork) { }
    }
}
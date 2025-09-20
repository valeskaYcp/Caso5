using System;
using System.Collections.Generic;

namespace Caso5.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal? CostoUnitario { get; set; }

    public virtual ICollection<InventarioProducto> InventarioProductos { get; set; } = new List<InventarioProducto>();

    public virtual ICollection<OrdenesProduccion> OrdenesProduccions { get; set; } = new List<OrdenesProduccion>();
}

using System;
using System.Collections.Generic;

namespace Caso5.Models;

public partial class InventarioProducto
{
    public int InventarioId { get; set; }

    public int ProductoId { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? StockMinimo { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}

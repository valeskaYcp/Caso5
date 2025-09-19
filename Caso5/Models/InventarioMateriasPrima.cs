using System;
using System.Collections.Generic;

namespace Caso5.Models;

public partial class InventarioMateriasPrima
{
    public int InventarioId { get; set; }

    public int MateriaId { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? StockMinimo { get; set; }

    public virtual MateriasPrima Materia { get; set; } = null!;
}

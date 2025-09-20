using System;
using System.Collections.Generic;

namespace Caso5.Models;

public partial class MateriasPrima
{
    public int MateriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? UnidadMedida { get; set; }

    public int? ProveedorId { get; set; }

    public virtual ICollection<InventarioMateriasPrima> InventarioMateriasPrimas { get; set; } = new List<InventarioMateriasPrima>();

    public virtual Proveedore? Proveedor { get; set; }
}

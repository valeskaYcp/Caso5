using System;
using System.Collections.Generic;

namespace Caso5.Models;

public partial class Proveedore
{
    public int ProveedorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public decimal? Evaluacion { get; set; }

    public virtual ICollection<MateriasPrima> MateriasPrimas { get; set; } = new List<MateriasPrima>();
}

using System;
using System.Collections.Generic;

namespace Caso5.Models;

public partial class OrdenesProduccion
{
    public int OrdenId { get; set; }

    public int ProductoId { get; set; }

    public DateOnly FechaPlanificada { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public decimal CantidadPlaneada { get; set; }

    public decimal? CantidadReal { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<EtapasProduccion> EtapasProduccions { get; set; } = new List<EtapasProduccion>();

    public virtual Producto Producto { get; set; } = null!;
}

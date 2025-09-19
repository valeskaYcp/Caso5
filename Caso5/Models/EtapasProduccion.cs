using System;
using System.Collections.Generic;

namespace Caso5.Models;

public partial class EtapasProduccion
{
    public int EtapaId { get; set; }

    public int OrdenId { get; set; }

    public string NombreEtapa { get; set; } = null!;

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public decimal? CantidadProcesada { get; set; }

    public virtual ICollection<InspeccionesCalidad> InspeccionesCalidads { get; set; } = new List<InspeccionesCalidad>();

    public virtual OrdenesProduccion Orden { get; set; } = null!;
}

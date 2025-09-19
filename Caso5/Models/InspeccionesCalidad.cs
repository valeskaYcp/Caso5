using System;
using System.Collections.Generic;

namespace Caso5.Models;

public partial class InspeccionesCalidad
{
    public int InspeccionId { get; set; }

    public int EtapaId { get; set; }

    public DateTime? FechaInspeccion { get; set; }

    public string? Inspector { get; set; }

    public string? Resultado { get; set; }

    public decimal? ProductosDefectuosos { get; set; }

    public string? Observaciones { get; set; }

    public virtual EtapasProduccion Etapa { get; set; } = null!;
}
